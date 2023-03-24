using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryInfo
{
    internal class MyDirectoryInfo
    {
        public string Path { get; set; }
        public bool hasFiles { get; set; }
        public int FileCount { get; set; }
        public List<string> FileExtensions { get; set; } = new List<string>();
        public List<string> SubDirectoryFileExtensions { get; set; } = new List<string>();
        public bool hasSubdirectories { get; set; }
        public int SubDirectoryCount { get; set; }
        public List<string> SubDirectoryFilesExtensions { get; set; } = new List<string>();
        public int DepthLevel { get; set; }
        public List<MyDirectoryInfo> SubDirectoryInfos { get; set; } = new List<MyDirectoryInfo>();

        public override string ToString()
        {
            return $"Path:{Path}, FileCount:{FileCount},SubdirectoriesCount:{SubDirectoryCount},depthLeve:{DepthLevel}";
        }
    }
}
