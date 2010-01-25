using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FileTester
{
    public class FileWacher
    {
        private List<FileSystemWatcher> _watchers;
        private string _basepath;
        //private Func<FileSystemEventHandler> _handler; 
        private FileSystemEventHandler _handler;


        /// <summary>
        /// Will create a FileSystemWatcher on every directory, including and contained in the directory passed in
        /// </summary>
        /// <param name="basepath">directory path</param>
        /// <param name="handler">Method, signature must accept object, FileSystemEventArgs</param>
        public FileWacher(string basepath, FileSystemEventHandler handler)
        {
            _basepath = basepath;
            _watchers = new List<FileSystemWatcher>();
            _handler = handler;
            BuildWatchers(_basepath);
        }

        private void BuildWatchers(String path)
        {
            BuildSingleWatcher(path);

            foreach (var d in Directory.GetDirectories(path))
            {
                BuildWatchers(d);
            }
        }

        private void BuildSingleWatcher(string path)
        {
            var fsw = new FileSystemWatcher();
            fsw.Path = path;
            fsw.NotifyFilter = NotifyFilters.FileName;
            fsw.Created += _handler;
            fsw.EnableRaisingEvents = true;

            _watchers.Add(fsw);
        }
    }
}
