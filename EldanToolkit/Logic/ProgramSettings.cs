using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EldanToolkit.Logic
{
    public static class ProgramSettings
    {
        private static List<string> lastProjects = new List<string>();
        public static void NoteProjectLoaded(string path)
        {
            lastProjects.Remove(path);
            lastProjects.Insert(0, path);
            if (lastProjects.Count > 10)
            {
                lastProjects.Remove(lastProjects.Last());
            }
            Save();
        }

        public static IReadOnlyList<string> getLastProjects()
        {
            return lastProjects.AsReadOnly();
        }

        private static string appDataPath { get => Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "EldanToolkit"); }
        private static string appSettingsPath { get => Path.Join(appDataPath, "AppSettings.xml"); }

        public static void Save()
        {
            if (!Directory.Exists(appDataPath))
                Directory.CreateDirectory(appDataPath);

            XmlDocument doc = new XmlDocument();
            XmlNode root = doc.CreateElement("ProgramSettings");
            doc.AppendChild(root);
            XmlNode set = doc.CreateElement("Settings");
            root.AppendChild(set);

            XmlNode lpn = doc.CreateElement("LastProjects");
            root.AppendChild(lpn);
            foreach (string path in lastProjects)
            {
                XmlNode p = doc.CreateElement("Path");
                p.InnerText = path;
                lpn.AppendChild(p);
            }

            doc.Save(appSettingsPath);
        }

        public static void Load()
        {
            if (!File.Exists(appSettingsPath))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(appSettingsPath);

            XmlNode? lpn = doc.SelectSingleNode("/ProgramSettings/LastProjects");
            if (lpn != null)
            {
                lastProjects.Clear();
                foreach (XmlNode p in lpn.ChildNodes)
                {
                    lastProjects.Add(p.InnerText);
                }
            }
        }
    }
}
