using EldanToolkit.UI;

namespace EldanToolkit.Logic
{
    internal static class Program
    {
        public static WSProject? Project { get; set; }
        public static void LoadProject(string path)
        {
            Project = new WSProject(path);

            ETEvents.Events.ProjectLoaded();
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ProgramSettings.Load();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ProjectForm());
        }
    }
}