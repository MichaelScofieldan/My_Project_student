using System;
using System.Configuration;
namespace HotelBaseSystem.DBUtility
{
    /// <summary>
    /// Web.configの文字を取得すする
    /// </summary>
    public class PubConstant
    {
        /// <summary>
        /// SQL接続文字
        /// </summary>
        public static string ConnectionString
        {           
            get 
            {
                string _connectionString = ConfigurationManager.AppSettings["ConnectionString"]; 
                return _connectionString; 
            }
        }

        /// <summary>
        /// Web.configに設定文字
        /// </summary>
        public static string SCSConnectionString
        {
            get
            {
                string _connectionString = ConfigurationManager.AppSettings["SCSConnectionString"];
                return _connectionString;
            }
        }

        /// <summary>
        /// Web.configに設定文字
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public static string GetConfigString(string configName)
        {
            string tempString = ConfigurationManager.AppSettings[configName];
            return tempString;
        }
    }
}
