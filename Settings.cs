using System;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;


namespace MusicBeePlugin
{

    public partial class Settings : Form
    {

        private ConfigMgr configMgr;
        private string _path;
        public Settings(string path)
        {
            InitializeComponent();
            _path = path;
            configMgr = new ConfigMgr();
            if (!File.Exists(_path))
            {
                File.Create(_path).Close();
                configMgr.SetDefaults(_path);
                MessageBox.Show("Please configure mb_SongHistory in the Preferences > Plugins menu, then restart MusicBee.");
            }
            
        }

        public void SetText()
        {

            var deserializedObject = configMgr.DeserializeConfig(_path);

            //MessageBox.Show("Retrieving settings.");

            outputPathBox.Text = deserializedObject.OutputPath;
            entriesBox.Text = deserializedObject.MaxEntries;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            configMgr.MaxEntries = entriesBox.Text;
            configMgr.OutputPath = outputPathBox.Text;

            //MessageBox.Show($"{entriesBox.Text.ToString()} \n {outputPathBox.Text.ToString()}");
            //MessageBox.Show($"{configMgr.MaxEntries} \n {configMgr.OutputPath}");

            configMgr.SerializeConfig(_path);
            MessageBox.Show("Settings Saved.");
        }
    }
}
