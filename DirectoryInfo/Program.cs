using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryInfo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\DataScience";
            var info=GetInfo(path);
            
            Console.WriteLine(info);
            var alldi= info.SubDirectoryInfos.Where(w => w.DepthLevel ==1);
            Console.WriteLine("-----------------------------------------------------------------------------");
            foreach(var di in alldi)
            {
                Console.WriteLine(di);
                Console.WriteLine(string.Join(",",di.FileExtensions));
                Console.WriteLine(string.Join(",", di.SubDirectoryFileExtensions));
            }
            Console.WriteLine("-----------------------------------------------------------------------------");
            Console.ReadLine();
        }
        static MyDirectoryInfo GetInfo(string path, int depthLevel = 0)
        {
            if (Directory.Exists(path))
            {
                var directories = Directory.GetDirectories(path).ToList();
                var files = Directory.GetFiles(path,"*.*", SearchOption.TopDirectoryOnly).ToList();
                var allFilesExtensions = files.Select(s => Path.GetExtension(s)).Distinct().ToList();
                var di = new MyDirectoryInfo {Path=path, DepthLevel = depthLevel };
                di.hasFiles = files.Any();
                di.FileCount = files.Count;
                di.FileExtensions = allFilesExtensions;
                di.hasSubdirectories=directories.Any();
                di.SubDirectoryCount = directories.Count;
                var subDirfiles = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
                var allSubFilesExtensions = subDirfiles.Select(s => Path.GetExtension(s)).Distinct().ToList();
                di.SubDirectoryFileExtensions= allSubFilesExtensions;

                foreach (var d in directories)
                {
                    var subdi = GetInfo(d, depthLevel + 1);
                    di.SubDirectoryInfos.Add(subdi);
                }
                Console.WriteLine(di);
                return di;
            }
            return null;
        }
    }
}
