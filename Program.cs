using System;
using System.IO;
using System.Collections.Generic;

namespace netcorever
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                // TODO: The following code (which determines the starting path) should optionally use a command-line option
                string path = Directory.GetCurrentDirectory();

                // Begin by searching and reporting on project file(s) in the chosen path
                // IN THEORY there should be only one project file.
                List<string> projectFiles = new List<string>();
                // TODO: Project type should be optional command-line switch
                foreach(string pf in ReportLocalVersion(path,"csproj"))
                {
                    Console.WriteLine(pf);
                }


                DirectoryInfo d = new DirectoryInfo(path);
                foreach (DirectoryInfo di in d.GetDirectories())
                    Console.WriteLine(".");
                    //Console.WriteLine(di.Name);
            } catch (Exception e) {
                Console.WriteLine(e.Message);
            } finally {
                Console.WriteLine("Hello World!");
            }
        }
        private static string GetVersionFromProjectFile(string projectFileName) {
            // TODO: open file
            // TODO: get version
            // TODO: close file

            // return version
            return "3.0";
        }
        private static IEnumerable<string> ReportLocalVersion(string path, string projectType)
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
