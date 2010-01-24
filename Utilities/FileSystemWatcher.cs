using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Utilities
{
    public class MyFileSystemWatcher
    {
FileSystemWatcher fsw = new FileSystemWatcher();
fsw.Path = textBox1.Text;
fsw.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | 
                   NotifyFilters.DirectoryName | NotifyFilters.FileName;
fsw.Changed += new FileSystemEventHandler(OnChanged);
fsw.Created += new FileSystemEventHandler(OnCreated);
fsw.Deleted += new FileSystemEventHandler(OnChanged);
fsw.Renamed += new RenamedEventHandler(OnRenamed);
fsw.EnableRaisingEvents = true;
    }
}
