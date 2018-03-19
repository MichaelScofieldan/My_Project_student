using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using HotelBaseSystem.DBUtility;

namespace HotelBaseSystem.Common
{
    /// <summary>
    /// ファイルアップロード
    /// </summary>
    public class UpLoadFile : BaseFile
    {
        /// <summary>
        /// ファイルをアップロードする
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="fileType"></param>
        /// <returns></returns>
        public string UpLoad(byte[] fs, string fileType)
        {
            string path = GetFileRootPath(PathType.PlanMST);
            string FileName = Guid.NewGuid().ToString() + "." + fileType;
            MemoryStream memoryStream = null;
            FileStream fileStream = null;
            try
            {
                memoryStream = new MemoryStream(fs);

                fileStream = new FileStream(path + "\\" + FileName, FileMode.Create);

                memoryStream.WriteTo(fileStream);
                memoryStream.Close();
                fileStream.Close();
                fileStream = null;
                memoryStream = null;
                return FileName;
            }
            catch (Exception ex)
            {
                if (memoryStream != null)
                {
                    memoryStream.Close();
                    memoryStream = null;
                }
                if (fileStream != null)
                {
                    fileStream.Close();
                    fileStream = null;
                }
                throw ex;
            }
        }

    }
}