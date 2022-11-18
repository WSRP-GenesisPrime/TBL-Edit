using Nexus.Archive;
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

        private string[] pathSplitter = new[] 
        {
            "/",
            @"\",
            @"\\",
        };
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

        public Archive? MainArchive { get; private set; }

        public WSProject(string path)
        {
            ProjectPath = path;
            Load(); // try to load any data in that folder.
        }

        public IEnumerable<string> FilesInDirectory(string path)
        {
            string dir = Path.Join(ProjectWorkingPath, path);
            SortedSet<string> files = new SortedSet<string>();
            if (Directory.Exists(dir))
                files.UnionWith(Directory.EnumerateFiles(dir));
            if(MainArchive != null)
            {
                GetArchiveFile(path);
            }
            return files;
        }

        public IEnumerable<string> DirsInDirectory(string path)
        {
            string dir = Path.Join(ProjectWorkingPath, path);
            SortedSet<string> dirs = new SortedSet<string>();
            if (Directory.Exists(dir))
                dirs.UnionWith(Directory.EnumerateDirectories(dir).Select(d => Path.Join(path, Path.GetFileName(d)!)));
            if (MainArchive != null)
            {
                IArchiveFolderEntry? f = GetArchiveDir(path);
                if(f != null)
                {
                    foreach(var d in f.EnumerateFolders())
                    {
                        dirs.Add(Path.Join(path, Path.GetFileName(d.Path)));
                    }
                }
            }
            return dirs;
        }

        public IArchiveFileEntry? GetArchiveFile(string path)
        {
            if (MainArchive != null)
            {
                IArchiveFolderEntry? folder = GetArchiveDir(Path.GetDirectoryName(path) ?? "");
                if(folder != null)
                {
                    string name = Path.GetFileName(path);
                    return folder.EnumerateFiles().FirstOrDefault(f => f!.FileName.Equals(name, StringComparison.InvariantCultureIgnoreCase), null);
                }
            }
            return null;
        }
        public IArchiveFolderEntry? GetArchiveDir(string path)
        {
            if (MainArchive != null)
            {
                IArchiveFolderEntry? dir = MainArchive.IndexFile.RootFolder;
                foreach (string split in SplitPath(path))
                {
                    dir = dir.EnumerateFolders().FirstOrDefault(d => d!.FileName.Equals(split, StringComparison.InvariantCultureIgnoreCase), null);
                    if (dir == null)
                    {
                        return null;
                    }
                }
                return dir;
            }
            return null;
        }

        public IEnumerable<string> SplitPath(string path)
        {
            List<string> split = path.Split(pathSplitter, StringSplitOptions.RemoveEmptyEntries).ToList();
            return split;
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

            SetupArchive();
        }

        private void SetupArchive()
        {
            if (patchPath == null || MainArchive != null)
                return;
            // CoreData archive only applicable to Steam client
            ArchiveFile? coreDataArchive = null;
            if (File.Exists(Path.Combine(patchPath, "CoreData.archive")))
                coreDataArchive = ArchiveFileBase.FromFile(Path.Combine(patchPath, "CoreData.archive")) as ArchiveFile;

            MainArchive = Archive.FromFile(Path.Combine(patchPath, "ClientData.index"), coreDataArchive);
        }
    }
}
