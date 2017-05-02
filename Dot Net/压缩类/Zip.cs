/// <summary>
/// 压缩文件
/// </summary>

using System;
using System.IO;

using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.GZip;
using System.Collections.Generic;

namespace Compression
{
    public class ZipClass
    {

        public static void ZipFile(string FileToZip, string ZipedFile, int CompressionLevel, int BlockSize)
        {
            //如果文件没有找到，则报错
            if (!System.IO.File.Exists(FileToZip))
            {
                throw new System.IO.FileNotFoundException("The specified file " + FileToZip + " could not be found. Zipping aborderd");
            }

            System.IO.FileStream StreamToZip = new System.IO.FileStream(FileToZip, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.FileStream ZipFile = System.IO.File.Create(ZipedFile);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry("ZippedFile");
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(CompressionLevel);
            byte[] buffer = new byte[BlockSize];
            System.Int32 size = StreamToZip.Read(buffer, 0, buffer.Length);
            ZipStream.Write(buffer, 0, size);
            try
            {
                while (size < StreamToZip.Length)
                {
                    int sizeRead = StreamToZip.Read(buffer, 0, buffer.Length);
                    ZipStream.Write(buffer, 0, sizeRead);
                    size += sizeRead;
                }
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            ZipStream.Finish();
            ZipStream.Close();
            StreamToZip.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="floder">待压缩文件目录</param>
        /// <param name="zipname">压缩后的目标文件</param>
        public static void ZipFile(string folder, string zipname)
        {
            string[] filenames = Directory.GetFiles(folder);

            Crc32 crc = new Crc32();
            ZipOutputStream s = new ZipOutputStream(File.Create(zipname));

            s.SetLevel(6); // 0 - store only to 9 - means best compression

            foreach (string file in filenames)
            {
                //打开压缩文件
                FileStream fs = File.OpenRead(file);

                byte[] buffer = new byte[fs.Length];
                fs.Read(buffer, 0, buffer.Length);
                ZipEntry entry = new ZipEntry(file);

                entry.DateTime = DateTime.Now;

                // set Size and the crc, because the information
                // about the size and crc should be stored in the header
                // if it is not set it is automatically written in the footer.
                // (in this case size == crc == -1 in the header)
                // Some ZIP programs have problems with zip files that don't store
                // the size and crc in the header.
                entry.Size = fs.Length;
                fs.Close();

                crc.Reset();
                crc.Update(buffer);

                entry.Crc = crc.Value;

                s.PutNextEntry(entry);

                s.Write(buffer, 0, buffer.Length);

            }

            s.Finish();
            s.Close();
        }


        /// <summary>
        /// 文件流列表
        /// </summary>
        /// <param name="folder"></param>
        /// <param name="zipname"></param>
        public static void ZipFile(List<FileEntity> list, string zipname)
        {
            Crc32 crc = new Crc32();
            ZipOutputStream s = new ZipOutputStream(File.Create(zipname));
            
            s.SetLevel(6); // 0 - store only to 9 - means best compression

            foreach (FileEntity entity in list)
            {
                ZipEntry entry = new ZipEntry(entity.FileName);

                entry.DateTime = DateTime.Now;

                // set Size and the crc, because the information
                // about the size and crc should be stored in the header
                // if it is not set it is automatically written in the footer.
                // (in this case size == crc == -1 in the header)
                // Some ZIP programs have problems with zip files that don't store
                // the size and crc in the header.
                entry.Size = entity.ContentLength;                

                crc.Reset();
                crc.Update(entity.Buffer);

                entry.Crc = crc.Value;

                s.PutNextEntry(entry);

                s.Write(entity.Buffer, 0, entity.ContentLength);
            }
                        
            s.Finish();
            s.Close();
        }
    }


    public class FileEntity
    {
        private byte[] buffer;
        /// <summary>
        /// 文件流
        /// </summary>
        public byte[] Buffer
        {
            get { return buffer; }
            set { buffer = value; }
        }

        private string fileName;
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

                
        public int ContentLength
        {
            get { return buffer.Length; }            
        }
    }
}