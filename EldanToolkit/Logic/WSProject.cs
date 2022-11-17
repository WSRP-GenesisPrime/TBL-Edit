using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace EldanToolkit.Logic
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
        public string ProjectPath
        {
            get; private set;
        }

        public string ProjectFilePath
        {
            get => Path.Join(ProjectPath, "Project.xml");
        }

        public string ProjectWorkingPath
        {
            get => Path.Join(ProjectPath, "WorkingFiles");
        }

        public string ProjectArchivePath
        {
            get => Path.Join(ProjectPath, "Archive");
        }

        public WSProject(string path)
        {
            ProjectPath = path;
            Load(); // try to load any data in that folder.
        }

        public IEnumerable<string> FilesInDirectory(string path)
        {
            string dir = Path.Join(ProjectWorkingPath, path);
            if (Directory.Exists(dir))
                return Directory.EnumerateFiles(dir);
            else
                return Enumerable.Empty<string>();
        }

        public IEnumerable<string> DirsInDirectory(string path)
        {
            string dir = Path.Join(ProjectWorkingPath, path);
            if (Directory.Exists(dir))
                return Directory.EnumerateDirectories(dir);
            else
                return Enumerable.Empty<string>();
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
            if (!File.Exists(ProjectFilePath))
                return;

            XmlDocument doc = new XmlDocument();
            doc.Load(ProjectFilePath);

            XmlNode? patchPathNode = doc.SelectSingleNode("/Settings/PatchPath");
            patchPath = patchPathNode?.InnerText ?? null;

            ProgramSettings.NoteProjectLoaded(ProjectPath);
        }
    }
}
