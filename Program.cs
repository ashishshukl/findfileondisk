using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace findfileondisk
{
    class Program
    {
        static void Main(string[] args)
        {
            //string partialName = "171_s";
            Console.WriteLine("enter the file to be searched");
            string partialName =  Console.ReadLine();
            DirectoryInfo hdDirectoryInWhichToSearch = new DirectoryInfo(@"E:\");
            //FileInfo[] filesInDir = hdDirectoryInWhichToSearch.GetFiles("*" + partialName + "*.*");
            FileSystemInfo[] filesAndDirs = hdDirectoryInWhichToSearch.GetFileSystemInfos("*" + partialName + "*");
            DirectoryInfo[] dirsInDir = hdDirectoryInWhichToSearch.GetDirectories("*" + partialName + "*.*");
            //foreach (FileInfo foundFile in filesInDir)
            //{
            //    string fullName = foundFile.FullName;
            //    Console.WriteLine(fullName);
            //}
            IEnumerable<string> dirs = Directory.EnumerateDirectories(@"E:\cdac\", "*", SearchOption.AllDirectories).Where(x => x.Contains(partialName));

            foreach (string dir in dirs)
            {

                IEnumerable<string> files = Directory.EnumerateFiles(dir, "*", SearchOption.TopDirectoryOnly).Where(x => x.Contains(partialName));
                foreach (string fil in files)
                {
                    FileInfo fi = new FileInfo(fil);
                    string ss = fi.FullName;
                    Console.WriteLine(ss + ",");
                }
            }
            //foreach (DirectoryInfo foundDir in dirsInDir)
            //{
            //    string fullName = foundDir.FullName;
            //    Console.WriteLine(fullName);
            //}
            //foreach (FileSystemInfo foundFile in filesAndDirs)
            //{
            //    string fullName = foundFile.FullName;
            //    Console.WriteLine(fullName);

            //    if (foundFile.GetType() == typeof(FileInfo))
            //    {
            //        Console.WriteLine("... is a file");
            //        FileInfo fileInfo = (FileInfo)foundFile;
            //        Console.WriteLine("Extension: " + fileInfo.Extension);
            //    }

            //    if (foundFile.GetType() == typeof(DirectoryInfo))
            //    {
            //        Console.WriteLine("... is a directory");
            //        DirectoryInfo directoryInfo = (DirectoryInfo)foundFile;
            //        FileInfo[] subfileInfos = directoryInfo.GetFiles();
            //    }
            //}

            Console.ReadKey();
        }
    }
}
