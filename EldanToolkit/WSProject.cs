using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EldanToolkit
{
    public class WSProject
    {
        private string? patchPath;
        public string? PatchPath
        {
            get => patchPath;
            set
            {
                if (Directory.Exists(value))
                {
                    patchPath = value;
                }
            }
        }
        private string ProjectPath;

        private string ProjectFilePath
        {
            get => Path.Join(ProjectPath, "Project.xml");
        }

        public WSProject(string path)
        {
            ProjectPath = path;
            Load(); // try to load any data in that folder.
        }

        public void Save()
        {
            XmlDocument doc = new XmlDocument();
            XmlNode set = doc.CreateElement("Settings");
            doc.AppendChild(set);

            if (patchPath != null)
            {
                XmlNode patchPathNode = doc.CreateElement("PatchPath");
                patchPathNode.InnerText = patchPath;
                set.AppendChild(patchPathNode);
            }

            doc.Save(ProjectFilePath);
        }

        public void Load()
        {
            if(!File.Exists(ProjectFilePath))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(ProjectFilePath);

            XmlNode? patchPathNode = doc.SelectSingleNode("/Settings/PatchPath");
            patchPath = patchPathNode?.InnerText ?? null;
        }
    }
}
