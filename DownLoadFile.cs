using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using HotelBaseSystem.DBUtility;

namespace HotelBaseSystem.Common
{
    /// <summary>
    /// ファイルをダウンロード
    /// </summary>
    public class DownLoadFile : BaseFile
    {
        /// <summary>
        /// byte[]を取得する
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public byte[] getBinaryFile(string filename)
        {
            filename = GetFileRootPath(PathType.PlanMST) + "\\" + filename;
            byte[] temp = null;
            if (File.Exists(filename))
            {
                FileStream stream = null;
                try
                {
                    stream = File.OpenRead(filename);
                    temp = ConvertStreamToByteBuffer(stream);
                    stream.Close();
                }
                catch (Exception e)
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    throw e;
                }
            }
            return temp;
        }
        /// <summary>
        ///  byte[]を取得する
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public byte[] getBinaryFileByPath(string filename)
        {

            byte[] temp = null;
            if (File.Exists(filename))
            {
                FileStream stream = null;
                try
                {
                    stream = File.OpenRead(filename);
                    temp = ConvertStreamToByteBuffer(stream);
                    stream.Close();
                }
                catch (Exception e)
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    throw e;
                }
            }
            return temp;
        }
        /// <summary>
        ///  byte[]を取得する
        /// </summary>
        /// <param name="theStream"></param>
        /// <returns></returns>
        public byte[] ConvertStreamToByteBuffer(System.IO.Stream theStream)
        {
            byte[] temp = null;
            int b1;
            System.IO.MemoryStream tempStream = new System.IO.MemoryStream();
            try
            {
                while ((b1 = theStream.ReadByte()) != -1)
                {
                    tempStream.WriteByte(((byte)b1));
                }
                temp = tempStream.ToArray();
                tempStream.Close();
            }
            catch(Exception ex)
            {
                tempStream.Close();
                throw ex;
            }
            return temp;

        }
    }
}