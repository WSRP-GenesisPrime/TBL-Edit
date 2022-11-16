using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EldanToolkit
{
    public class ProgramSettings
    {
        private List<string> lastProjects = new List<string>();

        private string appDataPath { get => Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EldanToolkit"); }
        private string appSettingsPath { get => Path.Join(appDataPath, "AppSettings.xml"); }

        public void Save()
        {
            if(!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);

            XmlDocument doc = new XmlDocument();
            XmlNode set = doc.CreateElement("Settings");
            doc.AppendChild(set);

            /*if (patchPath != null)
            {
                XmlNode patchPathNode = doc.CreateElement("PatchPath");
                patchPathNode.InnerText = patchPath;
                set.AppendChild(patchPathNode);
            }*/

            doc.Save(appSettingsPath);
        }

        public void Load()
        {
            if (!File.Exists(appSettingsPath))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(appSettingsPath);

            foreach (XmlNode set in doc.GetElementsByTagName("Settings"))
            {
                
            }
        }
    }
}
