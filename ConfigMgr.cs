using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace MusicBeePlugin
{
    [Serializable()]
    public class ConfigMgr
    {

        public string MaxEntries { get; set; }
        public string OutputPath { get; set; }

        public void SetDefaults(string path)
        {
            MaxEntries = "0";
            OutputPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\MusicBee\\SongHistory.txt";
            SerializeConfig(path);
        }

        public void SerializeConfig(string path)
        {
            using (StreamWriter file = new StreamWriter(path, false))
            {
                //MessageBox.Show($"Serializing {_path}");
                XmlSerializer controlsDefaultsSerializer = new XmlSerializer(typeof(ConfigMgr));
                controlsDefaultsSerializer.Serialize(file, this);
                file.Close();
            }
        }

        public ConfigMgr DeserializeConfig(string path)
        {
            //MessageBox.Show($"Deserializing {_path}");

            try
            {
                StreamReader file = new StreamReader(path);
                XmlSerializer xSerial = new XmlSerializer(typeof(ConfigMgr));
                object oData = xSerial.Deserialize(file);
                var thisConfig = (ConfigMgr)oData;
                file.Close();
                return thisConfig;
            }
            catch (Exception e)
            {

                Console.Write(e.Message);
                return null;
            }
        }

        
    }
}
