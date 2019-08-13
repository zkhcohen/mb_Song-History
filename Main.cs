using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace MusicBeePlugin
{
    public partial class Plugin
    {
        private MusicBeeApiInterface _mbApiInterface;
        private PluginInfo about = new PluginInfo();
        private Settings _settingsWindow;
        private int _maxEntries;
        private string _outputPath;
        private string _path;
        private ConfigMgr _configMgr;

        public PluginInfo Initialise(IntPtr apiInterfacePtr)
        {
            _mbApiInterface = new MusicBeeApiInterface();
            _mbApiInterface.Initialise(apiInterfacePtr);

            _path = _mbApiInterface.Setting_GetPersistentStoragePath() + "mb_SongHistoryConfig.xml";

            about.PluginInfoVersion = PluginInfoVersion;
            about.Name = "mb_SongHistory";
            about.Description = "This plugin enables you to record your play history in a text file.";
            about.Author = "Zkhcohen";
            about.TargetApplication = "";   //  the name of a Plugin Storage device or panel header for a dockable panel
            about.Type = PluginType.General;
            about.VersionMajor = 1;  // your plugin version
            about.VersionMinor = 0;
            about.Revision = 1;
            about.MinInterfaceVersion = MinInterfaceVersion;
            about.MinApiRevision = MinApiRevision;
            about.ReceiveNotifications = (ReceiveNotificationFlags.PlayerEvents | ReceiveNotificationFlags.TagEvents);
            about.ConfigurationPanelHeight = 0;   // height in pixels that musicbee should reserve in a panel for config settings. When set, a handle to an empty panel will be passed to the Configure function
            return about;
        }

        public bool Configure(IntPtr panelHandle)
        {
            // save any persistent settings in a sub-folder of this path
            string dataPath = _mbApiInterface.Setting_GetPersistentStoragePath();
            // panelHandle will only be set if you set about.ConfigurationPanelHeight to a non-zero value
            // keep in mind the panel width is scaled according to the font the user has selected
            // if about.ConfigurationPanelHeight is set to 0, you can display your own popup window
            
            _settingsWindow = new Settings(_path);
            _settingsWindow.SetText();
            _settingsWindow.ShowDialog();


            return true;
        }
       
        // called by MusicBee when the user clicks Apply or Save in the MusicBee Preferences screen.
        // its up to you to figure out whether anything has changed and needs updating
        public void SaveSettings()
        {
            SetVariables();
        }

        // MusicBee is closing the plugin (plugin is being disabled by user or MusicBee is shutting down)
        public void Close(PluginCloseReason reason)
        {
        }

        // uninstall this plugin - clean up any persisted files
        public void Uninstall()
        {
        }

        private void GetSettings()
        {
            _configMgr = new ConfigMgr();

            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
                _configMgr.SetDefaults(_path);
                MessageBox.Show("Please configure mb_SongHistory in the Preferences > Plugins menu, then restart MusicBee.");
            }
            else
            {
                SetVariables();
            }

        }

        private void SetVariables()
        {
            var deserializedObject = _configMgr.DeserializeConfig(_path);
            _outputPath = deserializedObject.OutputPath;
            _maxEntries = Convert.ToInt16(deserializedObject.MaxEntries);
        }

        private string Entry()
        {
            string time = DateTime.Now.ToString("dddd, dd MMMM yyyy HH:mm:ss");
            string title = _mbApiInterface.NowPlaying_GetFileTag(MetaDataType.TrackTitle);
            string artist = _mbApiInterface.NowPlaying_GetFileTag(MetaDataType.Artist);
            return $"{time} - {title} - {artist}";
        }

        private void WriteEntry()
        {
            //MessageBox.Show("Writing Entries.");

            if (!File.Exists(_outputPath))
            {
                File.Create(_outputPath).Close();
            }

            var lineCount = File.ReadLines(_outputPath).Count();

            if (_maxEntries != 0 && lineCount >= _maxEntries)
            {
                var lines = File.ReadAllLines(_outputPath).Skip((lineCount + 1) - _maxEntries);
                File.WriteAllLines(_outputPath, lines);
            }

            using (StreamWriter sw = new StreamWriter(_outputPath, true))
            {
                    sw.WriteLine(Entry());
            }

        }

        // receive event notifications from MusicBee
        // you need to set about.ReceiveNotificationFlags = PlayerEvents to receive all notifications, and not just the startup event
        public void ReceiveNotification(string sourceFileUrl, NotificationType type)
        {
            // perform some action depending on the notification type
            switch (type)
            {
                case NotificationType.PluginStartup:
                    GetSettings();
                    break;
                case NotificationType.TrackChanged:
                    WriteEntry();
                    break;
            }
        }

    }
}