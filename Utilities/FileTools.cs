using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Threading;

namespace Utilities
{
    /// <summary>
    /// FileTools - C++ / Clipper compatible File Tools
    /// </summary>
    [Serializable]
    public class FileTools : IDisposable
    {
        private bool _hasBeenDisposed;
        public string ErrorMessage = "";
        public static string SErrorMessage = "";

        #region IDisposable

        /// <summary>
        /// Calls Dispose(true) to dispose managed objects
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        /// <summary>
        /// Disposes Managed/UnManaged Objects
        /// </summary>
        protected virtual void Dispose(bool disposeManagedObjs)
        {
            if (!_hasBeenDisposed)
            {
                // dispose of Managed Objects
                if (disposeManagedObjs)
                {
                    GC.SuppressFinalize(this);
                }

                // dispose of UnManaged Objects here
                _hasBeenDisposed = true;
            }
        }

        /// <summary>
        /// Destructor that disposes of UnManaged Objects
        /// </summary>
        ~FileTools()
        {
            Dispose(false);
        }

        #endregion IDisposable


        public static void WaitForFile(string filename, int waittimeInSeconds)
        {
            var waittime = waittimeInSeconds*1000;
            var totalwaittime = 0;

            while (totalwaittime < waittime)
            {
                try
                {
                    using (var stream = new StreamReader(filename))
                    {
                        break;
                    }
                }
                catch
                {
                    Thread.Sleep(500);
                    totalwaittime += 500;
                }
            }

        }

        public static void SForceDirIfNecessary(string cDir)
        {
            if (!SDirectoryExists(cDir))
                SForceDirectories(cDir);
        }

        public static bool SDirectoryExists(string cDir)
        {
            var di = new DirectoryInfo(cDir);
            return di.Exists;
        }

        public static void SForceDirectories(string cDir)
        {
            var di = new DirectoryInfo(cDir);
            di.Create();
        }

        public static bool SFileExists(string cFileName)
        {
            var fi = new FileInfo(cFileName);
            return fi.Exists;
        }

        public static long SGetFileSize(string cFileName)
        {
            var fi = new FileInfo(cFileName);
            return fi.Length;
        }

        public static void SLoadFileToArray(string cFileName, ref List<string> al)
        {
            if (!String.IsNullOrEmpty(cFileName) && al != null && SFileExists(cFileName))
            {
                StreamReader pStream = null;
                try
                {
                    var pFS = new FileStream(cFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    pStream = new StreamReader(pFS);
                    string text;

                    do
                    {
                        text = pStream.ReadLine();

                        if (text != null)
                            al.Add(text);
                    } while (text != null);
                }

                finally
                {
                    if (pStream != null) pStream.Close();
                }
            }

            /*
            if (cFileName != null)
                if (al != null)
                    if (File.Exists(cFileName))
                    {
                        var theSourceFile = new FileInfo(cFileName);
                        StreamReader stream = null;

                        try
                        {
                            stream = theSourceFile.OpenText();
                            string text;

                            do
                            {
                                text = stream.ReadLine();

                                if (text != null)
                                    al.Add(text);
                            } while (text != null);
                        }
                        finally
                        {
                            if (stream != null) stream.Close();
                        }
                    }
             */
        }

        public static void SLoadFileToArray(string cFileName, ref Collection<string> al)
        {
            if (!String.IsNullOrEmpty(cFileName) && al != null && SFileExists(cFileName))
            {
                StreamReader pStream = null;
                try
                {
                    var pFS = new FileStream(cFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    pStream = new StreamReader(pFS);
                    string text;

                    do
                    {
                        text = pStream.ReadLine();

                        if (text != null)
                            al.Add(text);
                    } while (text != null);
                }

                finally
                {
                    if (pStream != null) pStream.Close();
                }
            }

            /*
            if (cFileName != null)
                if (al != null)
                    if (File.Exists(cFileName))
                    {
                        var theSourceFile = new FileInfo(cFileName);
                        StreamReader stream = null;

                        try
                        {
                            stream = theSourceFile.OpenText();
                            string text;

                            do
                            {
                                text = stream.ReadLine();

                                if (text != null)
                                {
                                    al.Add(text);
                                }
                            } while (text != null);
                        }
                        finally
                        {
                            if (stream != null) stream.Close();
                        }
                    }
             */
        }

        public static void SLoadFileToArray(string cFileName, ref ArrayList al)
        {
            if (!String.IsNullOrEmpty(cFileName) && al != null && SFileExists(cFileName))
            {
                StreamReader pStream = null;
                try
                {
                    var pFS = new FileStream(cFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    pStream = new StreamReader(pFS);
                    string text;

                    do
                    {
                        text = pStream.ReadLine();

                        if (text != null)
                            al.Add(text);
                    } while (text != null);
                }

                finally
                {
                    if (pStream != null) pStream.Close();
                }
            }

            /*
            if (cFileName != null)
                if (al != null)
                    if (File.Exists(cFileName))
                    {
                        var theSourceFile = new FileInfo(cFileName);
                        StreamReader stream = null;

                        try
                        {
                            stream = theSourceFile.OpenText();

                            string text;
                            do
                            {
                                text = stream.ReadLine();

                                if (text != null)
                                    al.Add(text);
                            } while (text != null);
                        }
                        finally
                        {
                            if (stream != null) stream.Close();
                        }
                    }
             */
        }

        public static void SSaveArrayToFile(string cFileName, Collection<string> al)
        {
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(cFileName, false);

                for (int i = 0; i < al.Count; ++i)
                {
                    writer.WriteLine(al[i]);
                }
            }
            catch (Exception e)
            {
                SErrorMessage = e.Message;
            }
            finally
            {
                if (writer != null) writer.Close();
            }
        }

        public static void SSaveArrayToFile(string cFileName, ArrayList al)
        {
            StreamWriter writer = null;

            if (al != null)
                try
                {
                    writer = new StreamWriter(cFileName, false);

                    for (int i = 0; i < al.Count; ++i)
                    {
                        writer.WriteLine(al[i].ToString());
                    }
                }
                finally
                {
                    if (writer != null) writer.Close();
                }
        }

        public static string SReadFile(string cFileName)
        {
            string retStr;
            SReadFile(cFileName, out retStr);
            return retStr;
        }

        /// <summary>
        /// Reads content of file into string and returns whether or not the operation was
        /// successful. If it wasn't, the returned string will contain the error message.
        /// </summary>
        /// <param name="cFileName"></param>
        /// <param name="cContent"></param>
        /// <returns></returns>
        public static bool SReadFile(string cFileName, out string cContent)
        {
            bool success;

            try
            {
                var sr = new StreamReader(cFileName);
                cContent = sr.ReadToEnd();
                sr.Close();
                success = true;
            }
            catch (Exception e)
            {
                cContent = e.Message;
                success = false;
            }

            return success;
        }

        public static char[] SReadBinaryFile(string cFileName)
        {
            char[] a = null;

            try
            {
                var fi = new FileInfo(cFileName);
                var fs = new FileStream(cFileName, FileMode.Open, FileAccess.Read);
                var r = new BinaryReader(fs);
                a = new char[fi.Length];
                a = r.ReadChars(Convert.ToInt32(fi.Length));
                r.Close();
            }
            catch (Exception e)
            {
                SErrorMessage = e.Message;
            }

            return a;
        }

        public static string SReadBinaryFileToBase64(string cFileName)
        {
            string cRet = "";
            byte[] a;

            try
            {
                var fs = new FileStream(cFileName, FileMode.Open, FileAccess.Read);
                var r = new BinaryReader(fs);
                a = r.ReadBytes(Convert.ToInt32(fs.Length));
                r.Close();
                cRet = Convert.ToBase64String(a, 0, a.Length);
            }
            catch (Exception e)
            {
                SErrorMessage = e.Message;
            }

            return cRet;
        }

        public static void SWriteBase64ToBinaryFile(string cFileName, string cBase64)
        {
            if (cFileName != null)
                if (cBase64 != null)
                    try
                    {
                        byte[] todecode_byte = Convert.FromBase64String(cBase64);
                        FileStream fs = File.Create(cFileName);
                        var bw = new BinaryWriter(fs);
                        bw.Write(todecode_byte);
                        bw.Close();
                        fs.Close();
                    }
                    catch (Exception e)
                    {
                        throw new Exception("Error in base64Decode" + e.Message);
                    }
        }

        public static bool SWriteFile(string cFileName, string cText)
        {
            string ofSightOutOfMind;
            return SWriteFile(cFileName, cText, out ofSightOutOfMind);
        }

        public static bool SWriteFile(string cFileName, string cText, out string cErrorMessage)
        {
            bool bOk = true;
            StreamWriter sr = null;
            cErrorMessage = "";

            try
            {
                sr = new StreamWriter(cFileName, false);
                sr.WriteLine(cText);
            }
            catch (Exception e)
            {
                cErrorMessage = "WriteFile Error: " + e.Message;
                bOk = false;
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                }
            }
            return bOk;
        }

        public static bool SDelFile(string cFileName)
        {
            string ofSightOutOfMind;
            return SDelFile(cFileName, out ofSightOutOfMind);
        }

        public static bool SDelFile(string cFileName, out string cErrorMessage)
        {
            cErrorMessage = "";
            bool bOk = false;
            var fi = new FileInfo(cFileName);

            try
            {
                fi.Delete();
                bOk = true;
            }
            catch (Exception e)
            {
                cErrorMessage = e.Message;
            }

            return bOk;
        }

        public static Collection<string> SFindFilesList(string cSearchPath, string cSearch)
        {
            var a = new Collection<string>();

            try
            {
                var di = new DirectoryInfo(cSearchPath);
                FileInfo[] files = di.GetFiles(cSearch);

                foreach (FileInfo fiNext in files)
                    a.Add(fiNext.Name);
            }
            catch (Exception e)
            {
                SErrorMessage = e.Message;
            }

            return a;
        }

        public static ArrayList SFindFiles(string cSearchPath, string cSearch)
        {
            var a = new ArrayList();

            try
            {
                var di = new DirectoryInfo(cSearchPath);
                FileInfo[] files = di.GetFiles(cSearch);

                foreach (FileInfo fiNext in files)
                {
                    a.Add(fiNext.Name);
                }
            }
            catch (Exception e)
            {
                SErrorMessage = e.Message;
            }

            return a;
        }

        public static Collection<string> SFindDirectoriesList(string cSearchPath, string cSearch)
        {
            var a = new Collection<string>();

            if (cSearchPath != null)
                if (cSearch != null)
                    try
                    {
                        var di = new DirectoryInfo(cSearchPath);
                        DirectoryInfo[] dirs = di.GetDirectories(cSearch);

                        foreach (DirectoryInfo diNext in dirs)
                        {
                            a.Add(diNext.Name);
                        }
                    }
                    catch (Exception e)
                    {
                        SErrorMessage = e.Message;
                    }

            return a;
        }

        public static ArrayList SFindDirectories(string cSearchPath, string cSearch)
        {
            var a = new ArrayList();

            try
            {
                var di = new DirectoryInfo(cSearchPath);
                DirectoryInfo[] dirs = di.GetDirectories(cSearch);

                foreach (DirectoryInfo diNext in dirs)
                {
                    a.Add(diNext.Name);
                }
            }
            catch (Exception e)
            {
                SErrorMessage = e.Message;
            }

            return a;
        }

        public static bool SCreateZeroFile(string cFileName)
        {
            bool bResult = true;

            try
            {
                var fout = new StreamWriter(cFileName, false);
                fout.WriteLine("");
                fout.Close();
            }
            catch (Exception)
            {
                bResult = false;
            }

            return bResult;
        }

        public static bool SCopyFile(string cFrom, string cTo)
        {
            bool bOk = true;

            try
            {
                File.Delete(cTo);
                File.Copy(cFrom, cTo);
            }
            catch
            {
                bOk = false;
            }

            return bOk;
        }

        /// <summary>
        /// Returns the root drive in C:\ format.  If an error occurs, C:\ is returned and
        /// the errorOccured variable is set to true.
        /// </summary>		
        public static string SGetRootDrive(out bool errorOccured)
        {
            errorOccured = false;
            string drive = null;

            try
            {
                string[] rootDrive = Directory.GetLogicalDrives();

                if (rootDrive.Length < 1)
                    return null;

                for (int i = 0; i < rootDrive.Length; i++)
                {
                    if (String.Compare(rootDrive[i].Substring(0, 1), "C", true) == 0)
                    {
                        drive = "C:\\";
                        break;
                    }
                }

                // If C was not found, use the first drive found
                if (drive == null)
                    drive = rootDrive[0];
            }
            catch
            {
                errorOccured = true;
                drive = "C:\\";
            }

            return drive;
        }

        /// <summary>
        /// Returns the root drive in C:\ format.  IF AN ERROR OCCURS, NULL IS RETURNED!
        /// </summary>
        public static string SGetRootDrive()
        {
            bool err;
            string drive = SGetRootDrive(out err);
            if (err)
                return null;
            return drive;
        }

        /// <summary>
        /// Tries multiple ways to create the file (including splitting the path at the directory level).
        /// If the file is created, true is returned.  Otherwise, false is returned.
        /// </summary>        
        public static bool SForceFileCreation(string path)
        {
            if (path == null)
                return false;

            if (path.Trim().Length <= 0)
                return false;

            if (File.Exists(path))
                return true;

            string dir = SGetDirectory(path);

            if (Directory.Exists(dir))
            {
                try
                {
                    File.Create(path).Close();
                    return true;
                }
                catch
                {
                    if (File.Exists(path)) // Did we create it???
                        return true;
                    return false; // An expection was thrown.  Bad block, permissions, etc???
                }
            }

            string[] dirs = path.Split('\\');

            if (dirs.GetLength(0) <= 0)
                return false; // Bad path

            var root = new StringBuilder(dirs[0] + "\\");

            if (!Directory.Exists(root.ToString()))
                return false; // Probably a bad drive mapping

            // Assume last index refers to the file
            for (int i = 1; i < dirs.GetLength(0) - 1; i++)
            {
                root.Append(dirs[i] + "\\");

                if (!Directory.Exists(root.ToString()))
                {
                    try
                    {
                        Directory.CreateDirectory(root.ToString());
                    }
                    catch
                    {
                        return false; // We can't create the directory.  Get out now.
                    }
                }
            }

            try
            {
                File.Create(path).Close();
            }
            catch
            {
                if (File.Exists(path))
                    return true;

                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the directory of the passed in path.  For example, C:\CSharp\CSFileTools.cs returns C:\CSharp.
        /// If an error occurs, the original path is returned.
        /// </summary>
        public static string SGetDirectory(string path)
        {
            if (path == null || (path.Trim().Length <= 0))
                return path;

            if (Directory.Exists(path))
                return path;

            string dirPath = path.Trim();

            try
            {
                int i = dirPath.LastIndexOf("\\");
                if (i < 0 || i >= dirPath.Length)
                    throw new Exception("ERROR: Invalid path.");

                dirPath = dirPath.Substring(0, i);
                if (!Directory.Exists(dirPath))
                    throw new Exception("ERROR: Unable to parse directory.");
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
                dirPath = path;
            }

            return dirPath;
        }

        public static bool SAppendToFile(string filePath, string dataToAppend)
        {
            bool close = false;
            StreamWriter cs = null;

            try
            {
                if (!SForceFileCreation(filePath))
                    return false;

                close = true;
                cs = new StreamWriter(filePath, true);
                cs.WriteLine(dataToAppend);
                cs.Flush();
            }
            catch
            {
                return false;
            }
            finally
            {
                try
                {
                    if (close) if (cs != null) cs.Close();
                }
                catch (Exception e)
                {
                    SErrorMessage = e.Message;
                }
            }

            return true;
        }

        public static bool SCompareFiles(string cFile1, string cFile2, ref List<string> aReasons)
        {
            bool bOk = true;
            var aFile1 = new List<string>();
            var aFile2 = new List<string>();
            SLoadFileToArray(cFile1, ref aFile1);
            SLoadFileToArray(cFile2, ref aFile2);

            if (aFile1.Count != aFile2.Count)
            {
                aReasons.Add("File1 Count: " + Convert.ToString(aFile1.Count) + "  File2 Count: " +
                             Convert.ToString(aFile2.Count));
                bOk = false;
            }
            else
            {
                for (int i = 0; i < aFile1.Count; ++i)
                {
                    string cF1 = aFile1[i];
                    string cF2 = aFile2[i];

                    if (cF1 != cF2)
                    {
                        aReasons.Add("Line: " + Convert.ToString(i + 1) + "  " + cF1 + " <> " + cF2);
                        bOk = false;
                        break;
                    }
                }
            }

            return bOk;
        }

        ///<summary>
        ///</summary>
        ///<param name="cFile1"></param>
        ///<param name="cFile2"></param>
        ///<param name="aReasons"></param>
        ///<returns></returns>
        public static bool SCompareFiles(string cFile1, string cFile2, ref ArrayList aReasons)
        {
            bool bOk = true;
            var aFile1 = new List<string>();
            var aFile2 = new List<string>();
            SLoadFileToArray(cFile1, ref aFile1);
            SLoadFileToArray(cFile2, ref aFile2);

            if (aFile1.Count != aFile2.Count)
            {
                aReasons.Add("File1 Count: " + Convert.ToString(aFile1.Count) + "  File2 Count: " +
                             Convert.ToString(aFile2.Count));
                bOk = false;
            }
            else
            {
                for (int i = 0; i < aFile1.Count; ++i)
                {
                    string cF1 = aFile1[i];
                    string cF2 = aFile2[i];

                    if (cF1 != cF2)
                    {
                        aReasons.Add("Line: " + Convert.ToString(i + 1) + "  " + cF1 + " <> " + cF2);
                        bOk = false;
                        break;
                    }
                }
            }

            return bOk;
        }

        public bool MoveFile(string cSourceFileName, string cDestinationFileName)
        {
            ErrorMessage = "";
            bool bOk = false;
            var fi = new FileInfo(cSourceFileName);

            try
            {
                if (SCopyFile(cSourceFileName, cDestinationFileName))
                {
                    fi.Delete();
                    bOk = true;
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
            }

            return bOk;
        }

        public static string JustFName(string cFileName)
        {
            //Create the FileInfo object
            var fi = new FileInfo(cFileName);
            //Return the file name
            return fi.Name;
        }

        /// <summary>
        /// Returns the file name part without extension from a Path\FileName.ext string
        /// <pre>
        /// JustStem("c:\\My Folders\\MyFile.txt");		//returns "MyFile"
        /// </pre>
        /// </summary>
        /// <param name="cPath"></param>
        /// <returns></returns>
        public static string JustStem(string cPath)
        {
            string lcFileName = "";

            //Get the name of the file
            if (cPath != null)
                lcFileName = JustFName(cPath.Trim());

            //Remove the extension and return the string
            if (lcFileName.IndexOf(".") == -1)
                return lcFileName;

            return lcFileName.Substring(0, lcFileName.LastIndexOf('.'));
        }

        /// <summary>
        /// Receives a path as a parameter and returns only the path part without the file name.
        /// <pre>
        /// Example:
        /// JustPath("c:\\My Folders\\MyFile.txt");		//returns "c:\My Folders"
        /// </pre>
        /// </summary>
        /// <param name="cPath"></param>
        /// <returns></returns>
        public static string JustPath(string cPath)
        {
            string lcPath = "";

            //Get the full path of this path
            if (cPath != null)
                lcPath = cPath.Trim();

            //If the file contains a backslash then remove it and return the path onlyfile name get rid of it
            if (lcPath.IndexOf('\\') == -1)
                return "";

            return lcPath.Substring(0, lcPath.LastIndexOf('\\'));
        }

        /// <summary>
        /// Receives a path to a file  as a parameter and returns the creation time for the file.
        /// </summary>
        /// <param name="cPath"></param>
        /// <returns></returns>
        public static string GetCreationTime(string cPath)
        {
            string sCreationDate = "";

            if (cPath != null)
            {
                cPath = cPath.Trim();

                if (SFileExists(cPath))
                {
                    try
                    {
                        DateTime dtCreationTime = File.GetCreationTime(cPath);
                        sCreationDate = dtCreationTime.ToString();
                    }
                    catch (Exception e)
                    {
                        sCreationDate = "<ERROR>" + e + "</ERROR>";
                    }
                }
                else
                    sCreationDate = "";
            }

            return sCreationDate;
        }

        public static DateTime FileDate(string cFileName)
        {
            var dt = new DateTime();

            try
            {
                dt = File.GetLastWriteTime(cFileName);
            }
            catch (Exception e)
            {
                SErrorMessage = e.Message;
            }

            return dt;
        }

        public static bool SMoveFile(string cFileSource, string cFileDestination)
        {
            bool bSuccess = false;

            if (!StringTools.Empty(cFileSource) && !StringTools.Empty(cFileDestination))
            {
                try
                {
                    File.Move(cFileSource, cFileDestination);
                }
                catch (Exception e)
                {
                    SErrorMessage = e.Message;
                }

                if (!SFileExists(cFileSource) && SFileExists(cFileDestination))
                    bSuccess = true;
            }

            return bSuccess;
        }
    }
}