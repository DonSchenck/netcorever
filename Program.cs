using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Linq;


namespace netcorever
{
    class Program
    {
        private static int _projectCount = 0;
        private static int _coreCount = 0;
        private static int _frameworkCount = 0;
        private static int _noFrameworkFoundCount = 0;

        static void Main(string[] args)
        {
            try {

                // Here's the algorithm:
                //  1. Find the project files (*.csproj, *.fsproj, *.vbproj) files in the current directory.
                //  2. Report on said files
                //  3. Get list of directories in current directory.
                //  4. For each directory, return to step 1. Recursively.


                // TODO: The following code (which determines the starting path) should optionally use a command-line option
                string path = Directory.GetCurrentDirectory();

                ReportOnCurrentDirectory(path, "csproj");
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                Console.WriteLine("{0} project(s) found.",_projectCount);
                Console.WriteLine("{0} .NET Core project(s) found",_coreCount);
                Console.WriteLine("{0} .NET Framework project(s) found",_frameworkCount);
                if (_noFrameworkFoundCount > 0) Console.WriteLine("{0} project(s) had No Framework found",_noFrameworkFoundCount);
            }
        }

        private static void ReportOnCurrentDirectory(string path, string projectType)
        {
                // Search and report on project file(s) in the chosen path
                // IN THEORY there should be only one project file.
                List<string> projectFiles = new List<string>();
                // TODO: Project type should be optional command-line switch
                foreach(string pf in ReportResults(path,"csproj"))
                {
                    Console.WriteLine(pf);
                }
                DirectoryInfo d = new DirectoryInfo(path);
                
                foreach (DirectoryInfo di in d.GetDirectories())
                    ReportOnCurrentDirectory(di.FullName, projectType);
        }
        private static string GetVersionFromProjectFile(string projectFileName) {

            string version = "No Target Framework found";

            _projectCount++;

            XmlDocument doc = new XmlDocument();
            doc.Load(projectFileName);

            string coreVersion = null;
            string frameworkVersion = null;
            XmlElement element;

            element = doc.GetElementById("TargetFramework");
            if (element != null) coreVersion = element.Value;

            element = doc.GetElementById("TargetFrameworkVersion");
            if (element != null) frameworkVersion = element.Value;

            if (coreVersion != null)
            {
                _coreCount++;
                version = coreVersion;
            } 
            if (frameworkVersion != null)
            {
                version = frameworkVersion;
                _frameworkCount++;
            } 
            if (coreVersion == null && frameworkVersion == null) _noFrameworkFoundCount++;

            return version;
        }
        private static IEnumerable<string> ReportResults(string path, string projectType)
        {
                string projectSearchString = String.Format("*.{0}", projectType);
                foreach (FileInfo fi in new DirectoryInfo(path).GetFiles(projectSearchString)) {
                    string outstring;
                    string projectName = fi.Name;
                    string ver = GetVersionFromProjectFile(fi.FullName);
                    outstring = String.Format("{0},{1}",projectName,ver);
                    yield return outstring;
                }
        }

    }
}
