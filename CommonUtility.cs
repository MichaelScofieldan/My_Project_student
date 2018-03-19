using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBaseSystem.Common
{
    public static class CommonUtility
    {
        public static DateTime ConvertDateTime(string value)
        {
            string str = value;
            string[] strArr = str.Split(new char[] { '-', ' ', ':' });
            DateTime dateTime = new DateTime(int.Parse(strArr[0]),
            int.Parse(strArr[1]),
            int.Parse(strArr[2]),
            int.Parse(strArr[3]),
            int.Parse(strArr[4]),
            int.Parse(strArr[5]),
            int.Parse(strArr[6]));

            return dateTime;
        }

        /// <summary>
        /// Convert Object to string
        /// </summary>
        /// <param name="in_val"></param>
        /// <returns></returns>
        public static string ConvertToString(object in_val)
        {
            string out_val = "";
            try
            {

                if (in_val == null) { return out_val; }

                if (in_val is DBNull) { return out_val; }

                out_val = in_val.ToString();

            }
            catch (Exception)
            {
                out_val = "";
            }

            return out_val;
        }

        /// <summary>
        /// Convert Object to string
        /// </summary>
        /// <param name="in_val"></param>
        /// <returns></returns>
        public static int ConvertToInt(object in_val, int defaul_val = 0)
        {
            int out_val = defaul_val;
            try
            {

                if (in_val == null) { return out_val; }

                if (in_val is DBNull) { return out_val; }

                out_val = Convert.ToInt32(in_val);

            }
            catch (Exception)
            {
                out_val = defaul_val;
            }

            return out_val;
        }

        /// <summary>
        /// Convert Object to string
        /// </summary>
        /// <param name="in_val"></param>
        /// <returns></returns>
        public static decimal ConvertToDecimal(object in_val, int defaul_val = 0)
        {
            decimal out_val = defaul_val;
            try
            {

                if (in_val == null) { return out_val; }

                if (in_val is DBNull) { return out_val; }

                out_val = Convert.ToDecimal(in_val);

            }
            catch (Exception)
            {
                out_val = defaul_val;
            }

            return out_val;
        }

        /// <summary>
        /// Convert Object to double
        /// </summary>
        /// <param name="in_val"></param>
        /// <returns></returns>
        public static double ConvertToDouble(object in_val, int defaul_val = 0)
        {
            double out_val = defaul_val;
            try
            {

                if (in_val == null) { return out_val; }

                if (in_val is DBNull) { return out_val; }

                out_val = Convert.ToDouble(in_val);

            }
            catch (Exception)
            {
                out_val = defaul_val;
            }

            return out_val;
        }
    }
}
