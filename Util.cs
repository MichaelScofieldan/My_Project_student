using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HotelBaseSystem.DBUtility
{
    public static class Util
    {
        public enum ModeType
        {
            Mode_tabRers = 1,
            Mode_tabArriva = 2,
            Mode_chkOut = 3,
            Mode_ChkIn = 4,
            Mode_UserSearch = 5,
            Mode_Booking = 6,
        }
        #region GetGuestStatus
        /// <summary>
        /// get GuestStatus
        /// </summary>
        public static string GetGuestStatus(string StatusCode)
        {
            string GuestStatus = "";

            try
            {
                switch (StatusCode)
                {
                    case DBBaseConst.GuestStatus_Register:
                        GuestStatus = "予約";
                        break;
                    case DBBaseConst.GuestStatus_CheckIn:
                        GuestStatus = "イン済み";
                        break;
                    case DBBaseConst.GuestStatus_CheckOut:
                        GuestStatus = "アウト済み";
                        break;
                    default:
                        GuestStatus = "なし";
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return GuestStatus;
        }

        #endregion

        #region GetPlanGender
        /// <summary>
        /// get PlanGender From Plan Male:001 Female:002: Male_Female:000
        /// </summary>
        public static string GetPlanGender(string planType)
        {
            string PlanGender = "";

            try
            {
                switch (planType)
                {
                    case "M":
                        PlanGender = DBBaseConst.Sex_Male;
                        break;
                    case "F":
                        PlanGender = DBBaseConst.Sex_Female;
                        break;
                    case "K":
                        PlanGender = DBBaseConst.Sex_Code;
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return PlanGender;
        }

        #endregion
        //public static DateTime CnvDateTime(string value)
        //{
        //    string str = value;
        //    string[] strArr = str.Split(new char[] { '-', ' ', ':' });
        //    DateTime dateTime = new DateTime(int.Parse(strArr[0]),
        //    int.Parse(strArr[1]),
        //    int.Parse(strArr[2]),
        //    int.Parse(strArr[3]),
        //    int.Parse(strArr[4]),
        //    int.Parse(strArr[5]),
        //    int.Parse(strArr[6]));

        //    return dateTime;
        //}

        /// <summary>
        /// convert datetime to string yyyy/MM/dd
        /// </summary>
        /// <param name="dtp"></param>
        /// <returns></returns>
        public static string CnvDateToString(DateTime? dtp)
        {
            string strDate = "";
            try
            {
                if (dtp != null)
                {
                    DateTime tmp = (DateTime)dtp;
                    strDate = tmp.ToString("yyyy/MM/dd");
                }
            }
            catch (Exception)
            {
                strDate = "";
            }
            return strDate;
        }

        /// <summary>
        /// Convert Object to string
        /// </summary>
        /// <param name="in_val"></param>
        /// <returns></returns>
        public static string CnvString(object in_val)
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
        /// Convert Date yyyy/mm/dd to string
        /// </summary>
        /// <param name="in_val"></param>
        /// <returns></returns>
        public static string CnvDateTimeToString(string date)
        {
            string outDate = "";
            try
            {
                if (string.IsNullOrEmpty(date))
                {
                    outDate = "00000000";
                    return outDate;
                }
                else if (date.Length == 8)
                {
                    outDate = date;
                }
                else
                {
                    string[] temp = date.Split('/');
                    outDate = temp[0] + temp[1] + temp[2];
                }
            }
            catch (Exception)
            {
                outDate = "00000000";
            }

            return outDate;
        }

        /// <summary>
        /// Convert Time hh:mm to string
        /// </summary>
        /// <param name="in_val"></param>
        /// <returns></returns>
        public static string CnvTimeToString(string time)
        {
            string outTime = "";
            try
            {
                if (string.IsNullOrEmpty(time))
                {
                    outTime = "0000";
                    return outTime;
                }
                else
                {
                    string[] temp = time.Split(':');
                    outTime = temp[0] + temp[1];
                }
            }
            catch (Exception)
            {
                outTime = "0000";
            }

            return outTime;
        }

        /// <summary>
        /// Convert Object to string
        /// </summary>
        /// <param name="in_val"></param>
        /// <returns></returns>
        public static int CnvInt(object in_val, int defaul_val = 0)
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
        public static decimal CnvDecimal(object in_val, int defaul_val = 0)
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
        public static double CnvDouble(object in_val, int defaul_val = 0)
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
        /// <summary>
        /// Convert String to DateTime
        /// </summary>
        /// <param name="objInput"></param>
        /// <returns></returns>
        public static System.DateTime CnvDatetime(object objInput, string strDataFormat = "")
        {
            System.DateTime dtmResult = default(System.DateTime);

            try
            {
                if (Convert.IsDBNull(objInput) || objInput == null)
                {
                    return dtmResult;
                }

                if (string.IsNullOrEmpty(CnvString(objInput)))
                {
                    return dtmResult;
                }

                if (IsDate(objInput, strDataFormat))
                {
                    if (string.IsNullOrEmpty(strDataFormat))
                    {
                        return Convert.ToDateTime(objInput);
                    }
                    else
                    {
                        return DateTime.ParseExact(Convert.ToString(objInput), strDataFormat, CultureInfo.CurrentCulture);
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtmResult;
        }

        /// <summary>
        /// Check object is datetime
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsDate(Object obj, string format = "")
        {
            string strDate = obj.ToString();
            try
            {
                DateTime dt = new DateTime();
                if (string.IsNullOrEmpty(format))
                {
                    dt = DateTime.Parse(strDate);
                }
                else
                {
                    dt = DateTime.ParseExact(strDate, format, null);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Convert string to TimeSpan
        /// </summary>
        /// <returns></returns>
        public static TimeSpan CnvTimeSpan(object time)
        {
            TimeSpan tspTime = new TimeSpan();
            string strTime = "";
            try
            {
                if (time == null) { return tspTime; }

                if (time is DBNull) { return tspTime; }

                strTime = Util.CnvString(time);
                TimeSpan.TryParse(strTime, out tspTime);
            }
            catch (Exception)
            {
            }
            return tspTime;
        }

        /// <summary>
        /// Convert string to TimeSpan
        /// </summary>
        /// <returns></returns>
        public static TimeSpan CnvTimeSpanWithFormat(object time, string strFormat)
        {
            TimeSpan tspTime = new TimeSpan();
            string strTime = "";
            try
            {
                if (time == null) { return tspTime; }

                if (time is DBNull) { return tspTime; }

                strTime = Util.CnvString(time);
                TimeSpan.TryParseExact(strTime, strFormat, null, out tspTime);
            }
            catch (Exception)
            {
            }
            return tspTime;
        }

        /// <summary>
        /// Get SexCode
        /// </summary>
        /// <param name="strSexCode"></param>
        /// <returns></returns>
        public static string GetSexCodeString(string strSexCode)
        {
            string strResult = Util.CnvString(strSexCode);
            try
            {
                if (strSexCode == DBBaseConst.Sex_Male_MFK || strSexCode == DBBaseConst.Sex_Male_Num)
                {
                    strResult = DBBaseConst.Sex_Male;
                }
                else if (strSexCode == DBBaseConst.Sex_Female_MFK || strSexCode == DBBaseConst.Sex_Female_Num)
                {
                    strResult = DBBaseConst.Sex_Male;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return strResult;
        }

        /// <summary>
        /// Get SexCode number
        /// </summary>
        /// <param name="SexCode"></param>
        /// <returns></returns>
        public static string GetSexCodeNumber(string SexCode)
        {
            try
            {
                string result = "";
                if (SexCode == DBBaseConst.Sex_Male_MFK || SexCode == DBBaseConst.Sex_Male)
                {
                    result = DBBaseConst.Sex_Male_Num;
                }
                else if (SexCode == DBBaseConst.Sex_Female_MFK || SexCode == DBBaseConst.Sex_Female)
                {
                    result = DBBaseConst.Sex_Female_Num;
                }
                else
                {
                    result = DBBaseConst.Sex_Other_Num;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Convert 25:00--> 01:00
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="timeHouse"></param>
        /// <param name="timeMinute"></param>
        /// <returns></returns>
        public static DateTime GetTimeCheckIn(string strDate, string strTime)
        {
            try
            {
                //Convert Date
                DateTime dtmDate = Util.CnvDatetime(strDate, DBBaseConst.FormatDate);

                string[] arrTime = strTime.Split(':');
                int intHour = Util.CnvInt(arrTime[0]);
                int intMinute = arrTime.Count() > 0 ? Util.CnvInt(arrTime[1]) : 0;
                TimeSpan tspTime = TimeSpan.FromHours(intHour).Add(TimeSpan.FromMinutes(intMinute));

                //Get date
                dtmDate = dtmDate.AddHours(intHour).AddMinutes(intMinute);

                //Return value
                return dtmDate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Convert 01:00--> 25:00
        /// </summary>
        /// <param name="strDate"></param>
        /// <param name="timeHouse"></param>
        /// <param name="timeMinute"></param>
        /// 
        /// <returns></returns>
        public static void SetTimeCheckIn(string strUseType, ref string strDate, ref string strTime)
        {
            try
            {
                double dboHour = 0;
                double dboMinute = 0;

                DateTime dtmTime = CnvDatetime(strDate + " " + strTime, DBBaseConst.FormatDateTime);

                TimeSpan tspTime = CnvTimeSpan(strTime);
                dboHour = tspTime.Hours;
                dboMinute = tspTime.Minutes;

                //28:45
                if (dboHour < 5 && strUseType == DBBaseConst.UseType_Stay)
                {
                    dtmTime = dtmTime.AddDays(-1);
                    dboHour += 24;
                }

                strDate = dtmTime.ToString(DBBaseConst.FormatDate);
                tspTime = TimeSpan.FromMinutes(dboHour * 60 + dboMinute);
                strTime = Math.Floor(tspTime.TotalHours).ToString("00") + ":" + tspTime.Minutes.ToString("00");

            }
            catch (Exception ex)
            {
                //throw ex;
            }

        }

        /// <summary>
        /// setDateCheckIn
        /// </summary>
        /// <param name="strUseType"></param>
        /// <param name="strTime"></param>
        /// <param name="strDate"></param>
        public static string setDateTimeCheckIn(string strUseType, string strTime)
        {
            try
            {

                double dboHour = 0;
                double dboMinute = 0;
                //string[] arrTime = strTime.Split(':');
                TimeSpan tspTime = CnvTimeSpan(strTime);

                dboHour = tspTime.Hours;
                dboMinute = tspTime.Minutes;

                if (dboHour < 5 && strUseType == DBBaseConst.UseType_Stay)
                {
                    dboHour += 24;
                }

                return strTime = dboHour.ToString() + ":" + tspTime.Minutes.ToString("00");
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Check Excel File is Open
        /// </summary>
        /// <param name="strFilePath"></param>
        /// <returns></returns>
        public static bool IsFileOpen(string strFilePath)
        {
            FileStream streamOpenFile = null;
            FileInfo infoFilePath = null;
            int intErrorCode;

            try
            {
                infoFilePath = new FileInfo(strFilePath);
                streamOpenFile = infoFilePath.Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                streamOpenFile.Close();

                return false;
            }
            catch (Exception ex)
            {
                if (ex is IOException)
                {
                    intErrorCode = Marshal.GetHRForException(ex) & ((1 << 16) - 1);
                    if (intErrorCode == 32 || intErrorCode == 33)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        /// <summary>
        /// Get Japan Phone Number
        /// </summary>
        /// <param name="PhoneNumber"></param>
        /// <returns></returns>
        public static void GetJapanPhoneNumber(string PhoneNumber, out string Phone1, out string Phone2)
        {
            const string StartJapanCode = "0";
            const string RegionJapanPhoneNumber = "+81";

            string result = "";
            try
            {
                if(string.IsNullOrEmpty(PhoneNumber))
                {
                    Phone1 = "";
                    Phone2 = "";
                    return;
                }

                result = PhoneNumber;

                if (result.StartsWith(StartJapanCode))
                {
                    //Start with 0
                    Phone1 = result;
                    Phone2 = RegionJapanPhoneNumber + result.Substring(StartJapanCode.Length);
                }
                else if (result.StartsWith(RegionJapanPhoneNumber))
                {
                    //Start with +81
                    Phone1 = StartJapanCode + PhoneNumber.Substring(RegionJapanPhoneNumber.Length);
                    Phone2 = result;
                }
                else
                {
                    Phone1 = result;
                    Phone2 = RegionJapanPhoneNumber + result;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }

    public static class DBBaseConst
    {
        public const string Lang_JA = "ja";
        public const string Lang_EN = "en";

        public const string UseType_Stay = "001";
        public const string UseType_Break = "002";

        public const string CheckInTime = "17:00";
        public const string CheckOutTime = "10:00";

        public const string Sex_Male = "001";
        public const string Sex_Female = "002";
        public const string Sex_Code = "003";
        public const string Sex_Male_Num = "1";
        public const string Sex_Female_Num = "2";
        public const string Sex_Other_Num = "3";
        public const string Sex_Male_MFK = "M";
        public const string Sex_Female_MFK = "F";

        public const string Pay_NotSales = "000";

        public const string Locker_Mode_CheckIn = "1";
        public const string Locker_Mode_CheckOut = "2";

        public const string FormatDate = "yyyy/MM/dd";
        public const string FormatDateTime = "yyyy/MM/dd HH:mm";
        public const string FormatTime = "HH:mm";
        public const string StartTimeNewDay = "05:00";
        public const string EndTimeOfDay = "04:59";

        public const string StageCode_Under = "001";
        public const string StageCode_Up = "002";
        public const string StageCode_All = "003";

        public const int PayUserFlag_Unset = 0;
        public const int PayUserFlag_Setting = 1;

        public const string GuestStatus_Register = "001";
        public const string GuestStatus_CheckIn = "003";
        public const string GuestStatus_CheckOut = "004";

        public const string RoomStatus_InUse_Stay = "ST003";
        public const string RoomStatus_InUse_Break = "ST012";
        public const string RoomStatus_Cleaning = "ST009";
        public const string RoomStatus_Free = "ST010";
        public const string RoomStatus_UnderRepair = "ST008";
        public const string RoomStatus_Assiging = "ST016";

        public const string Status_Regist = "001";
        public const string Status_Cancel = "002";
        public const string Status_ChkIn = "003";
        public const string Status_ChkOut = "004";
        public const string Status_PartChkIn = "005";
        public const string Status_PartChkOut = "006";
        public const string Status_Assign = "007";

        public const string RoomTypeDefault = "TP0001";
        public const string SexCodeDefault = "002";
        public const string StageCodeDefault = "003";

        public const string XMLCreateBooking = "NewBookReport";
        public const string XMLEditBooking = "ModificationReport";
        public const string XMLCancelBooking = "CancellationReport";

        public const string Message_NoDataBooking = "対象データがありません。";
        public const string Message_NoRoomAsinged = "部屋番号が割り当てられていません。（口座番号=[{0}],部屋番号=[{1}]）";
    }

    public static class DBBaseFloorSexCode
    {
        public const string Male = "1";
        public const string FeMale = "2";
    }
}
