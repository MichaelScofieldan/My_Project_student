using System;
using System.Configuration;
namespace HotelBaseSystem.DBUtility
{
    /// <summary>
    /// Web.config�̕������擾������
    /// </summary>
    public class PubConstant
    {
        /// <summary>
        /// SQL�ڑ�����
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
        /// Web.config�ɐݒ蕶��
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
        /// Web.config�ɐݒ蕶��
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
