using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Web;

    public abstract class FileSystemObject
    {
        // Methods
        protected FileSystemObject()
        {
        }

        public static string ConvertSizeToShow(int fileSize)
        {
            int num = fileSize / 0x400;
            if (num < 1)
            {
                return (fileSize.ToString() + "<span style='color:red'>&nbsp;&nbsp;B</span>");
            }
            if (num < 0x400)
            {
                return (num.ToString() + "<span style='color:red'>&nbsp;KB</span>");
            }
            int num2 = num / 0x400;
            if (num2 < 1)
            {
                return (num.ToString() + "<span style='color:red'>&nbsp;KB</span>");
            }
            if (num2 >= 0x400)
            {
                num2 /= 0x400;
                return (num2.ToString() + "<span style='color:red'>&nbsp;GB</span>");
            }
            return (num2.ToString() + "<span style='color:red'>&nbsp;MB</span>");
        }

        public static void CopyDirectory(string oldDir, string newDir)
        {
            DirectoryInfo od = new DirectoryInfo(oldDir);
            CopyDirInfo(od, oldDir, newDir);
        }

        private static void CopyDirInfo(DirectoryInfo od, string oldDir, string newDir)
        {
            if (!DirIsExist(newDir))
            {
                Create(newDir, FsoMethod.Folder);
            }
            foreach (DirectoryInfo info in od.GetDirectories())
            {
                CopyDirInfo(info, info.FullName, newDir + info.FullName.Replace(oldDir, ""));
            }
            foreach (FileInfo info2 in od.GetFiles())
            {
                CopyFile(info2.FullName, newDir + info2.FullName.Replace(oldDir, ""));
            }
        }

        public static DataTable CopyDT(DataTable parent, DataTable child)
        {
            for (int i = 0; i < child.Rows.Count; i++)
            {
                DataRow row = parent.NewRow();
                for (int j = 0; j < parent.Columns.Count; j++)
                {
                    row[j] = child.Rows[i][j];
                }
                parent.Rows.Add(row);
            }
            return parent;
        }

        public static void CopyFile(string oldFile, string newFile)
        {
            File.Copy(oldFile, newFile, true);
        }

        public static bool CopyFileStream(string oldPath, string newPath)
        {
            try
            {
                FileStream input = new FileStream(oldPath, FileMode.Open, FileAccess.Read);
                FileStream output = new FileStream(newPath, FileMode.Create, FileAccess.Write);
                BinaryReader reader = new BinaryReader(input);
                BinaryWriter writer = new BinaryWriter(output);
                reader.BaseStream.Seek(0L, SeekOrigin.Begin);
                reader.BaseStream.Seek(0L, SeekOrigin.End);
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    writer.Write(reader.ReadByte());
                }
                reader.Close();
                writer.Close();
                input.Flush();
                input.Close();
                output.Flush();
                output.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void Create(string file, FsoMethod method)
        {
            try
            {
                if (method == FsoMethod.File)
                {
                    WriteFile(file, "");
                }
                else if (method == FsoMethod.Folder)
                {
                    Directory.CreateDirectory(file);
                }
            }
            catch
            {
                throw new UnauthorizedAccessException("û��Ȩ�ޣ�");
            }
        }




        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        /// <param name="dirPath">���·��</param>
        /// <returns>�Ƿ�ɹ�</returns>
        public static bool CreateDirectory(string dirPath)
        {
            if (string.IsNullOrEmpty(dirPath))
                return false;
            dirPath = HttpContext.Current.Server.MapPath(dirPath);
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            if (dirInfo.Exists)
                return true;
            try
            {
                Directory.CreateDirectory(dirPath);
                return true;
            }
            catch
            {
                return false;
            }
        }


        public static void Delete(string file, FsoMethod method)
        {
            if ((method == FsoMethod.File) && File.Exists(file))
            {
                File.Delete(file);
            }
            if ((method == FsoMethod.Folder) && Directory.Exists(file))
            {
                Directory.Delete(file, true);
            }
        }

        private static long[] DirInfo(DirectoryInfo d)
        {
            long[] numArray = new long[3];
            long num = 0L;
            long num2 = 0L;
            long num3 = 0L;
            FileInfo[] files = d.GetFiles();
            num3 += files.Length;
            foreach (FileInfo info in files)
            {
                num += info.Length;
            }
            DirectoryInfo[] directories = d.GetDirectories();
            num2 += directories.Length;
            foreach (DirectoryInfo info2 in directories)
            {
                num += DirInfo(info2)[0];
                num2 += DirInfo(info2)[1];
                num3 += DirInfo(info2)[2];
            }
            numArray[0] = num;
            numArray[1] = num2;
            numArray[2] = num3;
            return numArray;
        }

        private static DataTable GetDirectoryAllInfo(DirectoryInfo d, FsoMethod method)
        {
            DataRow row;
            DataTable parent = new DataTable();
            parent.Columns.Add("name");
            parent.Columns.Add("rname");
            parent.Columns.Add("content_type");
            parent.Columns.Add("type");
            parent.Columns.Add("path");
            parent.Columns.Add("creatime", typeof(DateTime));
            parent.Columns.Add("size", typeof(int));
            foreach (DirectoryInfo info in d.GetDirectories())
            {
                if (method == FsoMethod.File)
                {
                    parent = CopyDT(parent, GetDirectoryAllInfo(info, method));
                }
                else
                {
                    row = parent.NewRow();
                    row[0] = info.Name;
                    row[1] = info.FullName;
                    row[2] = "";
                    row[3] = 1;
                    row[4] = info.FullName.Replace(info.Name, "");
                    row[5] = info.CreationTime;
                    row[6] = "";
                    parent.Rows.Add(row);
                    parent = CopyDT(parent, GetDirectoryAllInfo(info, method));
                }
            }
            if (method != FsoMethod.Folder)
            {
                foreach (FileInfo info2 in d.GetFiles())
                {
                    row = parent.NewRow();
                    row[0] = info2.Name;
                    row[1] = info2.FullName;
                    row[2] = info2.Extension.Replace(".", "");
                    row[3] = 2;
                    row[4] = info2.DirectoryName + @"\";
                    row[5] = info2.CreationTime;
                    row[6] = info2.Length;
                    parent.Rows.Add(row);
                }
            }
            return parent;
        }

        public static DataTable GetDirectoryAllInfos(string dir, FsoMethod method)
        {
            DataTable directoryAllInfo;
            try
            {
                DirectoryInfo d = new DirectoryInfo(dir);
                directoryAllInfo = GetDirectoryAllInfo(d, method);
            }
            catch (Exception exception)
            {
                throw new FileNotFoundException(exception.ToString());
            }
            return directoryAllInfo;
        }

        public static DataTable GetDirectoryInfos(string dir, FsoMethod method)
        {
            DataRow row;
            DataTable table = new DataTable();
            table.Columns.Add("name", typeof(string));
            table.Columns.Add("type");
            table.Columns.Add("size", typeof(int));
            table.Columns.Add("content_type");
            table.Columns.Add("createTime", typeof(DateTime));
            table.Columns.Add("lastWriteTime", typeof(DateTime));
            if (method != FsoMethod.File)
            {
                for (int i = 0; i < getDirs(dir).Length; i++)
                {
                    row = table.NewRow();
                    DirectoryInfo d = new DirectoryInfo(getDirs(dir)[i]);
                    long[] numArray = DirInfo(d);
                    row[0] = d.Name;
                    row[1] = 1;
                    row[2] = numArray[0];
                    row[3] = "";
                    row[4] = d.CreationTime;
                    row[5] = d.LastWriteTime;
                    table.Rows.Add(row);
                }
            }
            if (method != FsoMethod.Folder)
            {
                for (int j = 0; j < getFiles(dir).Length; j++)
                {
                    row = table.NewRow();
                    FileInfo info2 = new FileInfo(getFiles(dir)[j]);
                    row[0] = info2.Name;
                    row[1] = 2;
                    row[2] = info2.Length;
                    row[3] = info2.Extension.Replace(".", "");
                    row[4] = info2.CreationTime;
                    row[5] = info2.LastWriteTime;
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        public static long[] GetDirInfos(string dir)
        {
            long[] numArray = new long[3];
            DirectoryInfo d = new DirectoryInfo(dir);
            return DirInfo(d);
        }

        private static string[] getDirs(string dir)
        {
            return Directory.GetDirectories(dir);
        }

        private static string[] getFiles(string dir)
        {
            return Directory.GetFiles(dir);
        }

        public static string GetFileSize(string filePath)
        {
            FileInfo info = new FileInfo(filePath);
            float num = info.Length / 0x400L;
            return (num.ToString() + "KB");
        }


        /// <summary>
        /// �����ļ��Ƿ����
        /// </summary>
        /// <param name="filename">�ļ���</param>
        /// <returns>�Ƿ����</returns>
        public static bool FileExists(string filename)
        {
            return File.Exists(filename);
        }
        /// <summary>
        /// ����Ŀ¼�Ƿ����
        /// </summary>
        /// <param name="filename">�ļ�Ŀ¼</param>
        /// <returns>�Ƿ����</returns>
        public static bool DirIsExist(string file)
        {
            return  Directory.Exists(file);
        }


        public static bool IsExistCategoryDirAndCreate(string categorDir, HttpContext context)
        {
            if (context != null)
            {
                string file = Path.Combine(context.Request.PhysicalApplicationPath, categorDir);
                if (DirIsExist(file))
                {
                    return true;
                }
                Create(file, FsoMethod.Folder);
            }
            return false;
        }

        public static void Move(string oldFile, string newFile, FsoMethod method)
        {
            if (method == FsoMethod.File)
            {
                File.Move(oldFile, newFile);
            }
            if (method == FsoMethod.Folder)
            {
                Directory.Move(oldFile, newFile);
            }
        }

        public static string ReadFile(string file)
        {
            string str = "";
            using (FileStream stream = new FileStream(file, FileMode.Open, FileAccess.Read))
            {
                StreamReader reader = new StreamReader(stream, Encoding.Default);
                try
                {
                    return reader.ReadToEnd();
                }
                catch
                {
                    return str;
                }
                finally
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }
            }
        }

        public static void ReplaceFileContent(string dir, string originalContent, string newContent)
        {
            DirectoryInfo info = new DirectoryInfo(dir);
            foreach (FileInfo info2 in info.GetFiles("*.*", SearchOption.AllDirectories))
            {
                StreamReader reader = info2.OpenText();
                string str = reader.ReadToEnd();
                reader.Dispose();
                if (str.Contains(originalContent))
                {
                    WriteFile(info2.FullName, str.Replace(originalContent, newContent));
                }
            }
        }

        public static DataTable SearchFileContent(string dir, string searchPattern)
        {
            DataTable table = new DataTable();
            DirectoryInfo info = new DirectoryInfo(dir);
            table.Columns.Add("name");
            table.Columns.Add("type");
            table.Columns.Add("size", typeof(int));
            table.Columns.Add("content_type");
            table.Columns.Add("createTime", typeof(DateTime));
            table.Columns.Add("lastWriteTime", typeof(DateTime));
            foreach (FileInfo info2 in info.GetFiles("*.*", SearchOption.AllDirectories))
            {
                DataRow row = table.NewRow();
                StreamReader reader = info2.OpenText();
                string str = reader.ReadToEnd();
                reader.Dispose();
                if (str.Contains(searchPattern))
                {
                    row[0] = info2.FullName.Remove(0, info.FullName.Length);
                    row[1] = 2;
                    row[2] = info2.Length;
                    row[3] = info2.Extension.Replace(".", "");
                    row[4] = info2.CreationTime;
                    row[5] = info2.LastWriteTime;
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        public static DataTable SearchFiles(string dir, string searchPattern)
        {
            DataTable table = new DataTable();
            DirectoryInfo info = new DirectoryInfo(dir);
            table.Columns.Add("name");
            table.Columns.Add("type");
            table.Columns.Add("size", typeof(int));
            table.Columns.Add("content_type");
            table.Columns.Add("createTime", typeof(DateTime));
            table.Columns.Add("lastWriteTime", typeof(DateTime));
            foreach (FileInfo info2 in info.GetFiles(searchPattern, SearchOption.AllDirectories))
            {
                DataRow row = table.NewRow();
                row[0] = info2.FullName.Remove(0, info.FullName.Length);
                row[1] = 2;
                row[2] = info2.Length;
                row[3] = info2.Extension.Replace(".", "");
                row[4] = info2.CreationTime;
                row[5] = info2.LastWriteTime;
                table.Rows.Add(row);
            }
            return table;
        }

        public static DataTable SearchTemplateFiles(string dir, string searchPattern)
        {
            DataTable table = new DataTable();
            DirectoryInfo info = new DirectoryInfo(dir);
            string str = searchPattern;
            string str2 = searchPattern.ToLower();
            int length = searchPattern.Length;
            if (length < 4)
            {
                str = "*" + str + "*.html";
            }
            else if ((str2.Substring(length - 4, 4) != ".html") || (str2.Substring(length - 3, 3) != ".htm"))
            {
                str = "*" + str + "*.html";
            }
            table.Columns.Add("name");
            table.Columns.Add("type");
            table.Columns.Add("size", typeof(int));
            table.Columns.Add("content_type");
            table.Columns.Add("createTime", typeof(DateTime));
            table.Columns.Add("lastWriteTime", typeof(DateTime));
            try
            {
                foreach (FileInfo info2 in info.GetFiles(str, SearchOption.AllDirectories))
                {
                    DataRow row = table.NewRow();
                    row[0] = info2.FullName.Remove(0, info.FullName.Length).Replace("/", "\"");
                    row[1] = 2;
                    row[2] = info2.Length;
                    row[3] = info2.Extension.Replace(".", "");
                    row[4] = info2.CreationTime;
                    row[5] = info2.LastWriteTime;
                    table.Rows.Add(row);
                }
            }
            catch (ArgumentException)
            {
            }
            return table;
        }

        public static string WriteAppend(string file, string fileContent)
        {
            string str;
            FileInfo info = new FileInfo(file);
            if (!Directory.Exists(info.DirectoryName))
            {
                Directory.CreateDirectory(info.DirectoryName);
            }
            FileStream stream = new FileStream(file, FileMode.Append, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding("utf-8"));
            try
            {
                writer.Write(fileContent);
                str = fileContent;
            }
            catch (Exception exception)
            {
                throw new FileNotFoundException(exception.ToString());
            }
            finally
            {
                writer.Flush();
                stream.Flush();
                writer.Close();
                stream.Close();
            }
            return str;
        }

        public static string WriteFile(string file, string fileContent)
        {
            string str;
            FileInfo info = new FileInfo(file);
            if (!Directory.Exists(info.DirectoryName))
            {
                Directory.CreateDirectory(info.DirectoryName);
            }
            FileStream stream = new FileStream(file, FileMode.Create, FileAccess.Write);
            StreamWriter writer = new StreamWriter(stream, Encoding.UTF8);
            try
            {
                writer.Write(fileContent);
                str = fileContent;
            }
            catch (Exception exception)
            {
                throw new FileNotFoundException(exception.ToString());
            }
            finally
            {
                writer.Flush();
                stream.Flush();
                writer.Close();
                stream.Close();
            }
            return str;
        }

        public static void WriteFile(string file, string fileContent, bool append)
        {
            FileInfo info = new FileInfo(file);
            if (!Directory.Exists(info.DirectoryName))
            {
                Directory.CreateDirectory(info.DirectoryName);
            }
            StreamWriter writer = new StreamWriter(file, append, Encoding.GetEncoding("utf-8"));
            try
            {
                writer.Write(fileContent);
            }
            catch (Exception exception)
            {
                throw new FileNotFoundException(exception.ToString());
            }
            finally
            {
                writer.Flush();
                writer.Close();
            }
        }
    }

    public enum FsoMethod
    {
        Folder,
        File,
        All
    }


