namespace EldanToolkit
{
    internal static class Program
    {
        private static WSProject? project = null;
        public static WSProject Project
        {
            get
            {
                if(project == null)
                {
                    throw new InvalidOperationException("Archive manager not ready!");
                }
                return project;
            }
            set
            {
                project = value;
            }
        }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ProjectForm());
        }
    }
}