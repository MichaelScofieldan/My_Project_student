using System;
using System.Collections;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Collections.Generic;
namespace HotelBaseSystem.DBUtility
{
    /// <summary>
    /// データアクセスベースクラス
    /// </summary>
    public class DbHelperSQL
    {
        // データベース接続文字列
        public static string connectionString = PubConstant.ConnectionString;
        public static string scsConnectionString = PubConstant.SCSConnectionString;
        private SqlConnection tranConnection = null;
        private SqlTransaction transaction = null;
        public SqlCommand TranCommand = null;
        public DbHelperSQL()
        {

        }

        #region 実装トランザクションSQL      
        /// <summary>
        /// データベーストランザクションを開始する
        /// </summary>
        /// <returns></returns>
        public bool BeginTransaction()
        {
            bool result = true;
            try
            {
                tranConnection = new SqlConnection(connectionString);
                tranConnection.Open();
                if (tranConnection.State == ConnectionState.Open)
                {
                    transaction = tranConnection.BeginTransaction();
                    TranCommand = new SqlCommand();
                    TranCommand.Connection = tranConnection;
                    TranCommand.Transaction = transaction;
                }
                else
                {
                    result = false;
                }
            }
            catch (Exception ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                if (tranConnection != null)
                {
                    tranConnection.Close();
                }
                throw ex;
            }
            return result;
        }
        /// <summary>
        /// トランザクションをロールバックする
        /// </summary>
        public void Rollback()
        {

            try
            {
                if (tranConnection != null)
                {
                    if (tranConnection.State == ConnectionState.Open && transaction != null)
                    {
                        transaction.Rollback();
                        tranConnection.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                if (tranConnection != null)
                {
                    tranConnection.Close();
                }
                throw ex;
            }

        }
        /// <summary>
        /// データベース トランザクションをコミットする
        /// </summary>
        public void Commit()
        {

            try
            {
                if (tranConnection != null)
                {
                    if (tranConnection.State == ConnectionState.Open && transaction != null)
                    {
                        transaction.Commit();
                        tranConnection.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                if (tranConnection != null)
                {
                    transaction.Rollback();
                    tranConnection.Close();
                }
                throw ex;
            }

        }
        /// <summary>
        /// パラメータクエリを実行する
        /// </summary>
        /// <param name="SQLString">SQL文</param>
        /// <returns>影響を受ける行の数</returns>
        public int ExecuteTransactionSql(string SQLString, params SqlParameter[] cmdParms)
        {
            try
            {
                if (TranCommand != null)
                {
                    PrepareCommand(TranCommand, tranConnection, null, SQLString, cmdParms);
                    int rows = TranCommand.ExecuteNonQuery();
                    TranCommand.Parameters.Clear();
                    return rows;
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
        }

        /// <summary>
        /// パラメータクエリを実行する
        /// </summary>
        /// <param name="strSQL">SQL文</param>
        /// <returns>SqlDataReader</returns>
        public SqlDataReader ExecuteTransactionReader(string SQLString, params SqlParameter[] cmdParms)
        {                       
            try
            {
                if (TranCommand != null)
                {
                    PrepareCommand(TranCommand, tranConnection, null, SQLString, cmdParms);
                    SqlDataReader myReader = TranCommand.ExecuteReader(CommandBehavior.CloseConnection);
                    TranCommand.Parameters.Clear();
                    return myReader;
                }
                else
                {
                    return null;
                }
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }


        }


        /// <summary>
        /// パラメータクエリを実行する
        /// </summary>
        /// <param name="SQLString">SQL文</param>
        /// <returns>DataSet</returns>
        public DataSet TransactionQuery(string SQLString, params SqlParameter[] cmdParms)
        {
            DataSet ds = new DataSet();
            if (TranCommand != null)
            {
                PrepareCommand(TranCommand, tranConnection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(TranCommand))
                {

                    try
                    {
                        da.Fill(ds, "ds");
                        TranCommand.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    
                }

            }
            return ds;
        }
        #endregion

        #region  実装SQL

        /// <summary>
        /// オブジェクト存在チェック
        /// </summary>
        /// <param name="strSql">SQL文</param>
        /// <param name="cmdParms">パラメータ</param>
        /// <returns>レコードが存在する場合:true,レコードが存在しない場合:false</returns>
        public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        {
            object obj = GetSingle(strSql, cmdParms);
            int cmdresult;
            if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
            {
                cmdresult = 0;
            }
            else
            {
                cmdresult = int.Parse(obj.ToString());
            }
            if (cmdresult == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 実装SQL
        /// </summary>
        /// <param name="SQLString">SQL文</param>
        /// <returns>成功した行</returns>
        public static int ExecuteSql(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        int rows = cmd.ExecuteNonQuery();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }


        /// <summary>
        /// クエリの実行
        /// </summary>
        /// <param name="strSQL">SQL文</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string strSQL)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(strSQL, connection);
            try
            {
                connection.Open();
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }

        }
        /// <summary>
        /// クエリの実行
        /// </summary>
        /// <param name="SQLString">SQL文</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (System.Data.SqlClient.SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }



        #endregion

        #region パラメータクエリを実行する

        /// <summary>
        /// パラメータクエリを実行する
        /// </summary>
        /// <param name="SQLString">SQL文</param>
        /// <returns>影響を受ける行の数</returns>
        public static int ExecuteSql(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        int rows = cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                        return rows;
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }



        /// <summary>
        /// クエリを実行し、クエリによって返された結果セットの最初の行の最初の列を返します。
        /// </summary>
        /// <param name="SQLString">SQL文</param>
        /// <returns>クエリ結果</returns>
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    try
                    {
                        PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        object obj = cmd.ExecuteScalar();
                        cmd.Parameters.Clear();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        throw e;
                    }
                }
            }
        }

        /// <summary>
        /// パラメータクエリを実行する
        /// </summary>
        /// <param name="strSQL">SQL文</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader ExecuteReader(string SQLString, params SqlParameter[] cmdParms)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            try
            {
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                SqlDataReader myReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                cmd.Parameters.Clear();
                return myReader;
            }
            catch (System.Data.SqlClient.SqlException e)
            {
                throw e;
            }


        }

        /// <summary>
        /// パラメータクエリを実行する
        /// </summary>
        /// <param name="SQLString">SQL文</param>
        /// <returns>DataSet</returns>
        public static DataSet Query(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }

        /// <summary>
        /// SqlParameterを追加する
        /// </summary>
        /// <param name="cmd">SqlCommandオブジェクト</param>
        /// <param name="conn">SqlConnectionオブジェクト</param>
        /// <param name="trans">SqlTransactionオブジェクト</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="cmdParms">SqlParameterオブジェクト</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
        {
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = CommandType.Text;//cmdType;
            if (cmdParms != null)
            {


                foreach (SqlParameter parameter in cmdParms)
                {
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    cmd.Parameters.Add(parameter);
                }
            }
        }

        #endregion

        #region SCS Query
        /// <summary>
        /// クエリの実行
        /// </summary>
        /// <param name="SQLString">SQL文</param>
        /// <returns>DataSet</returns>
        public static DataSet SCSQuery(string SQLString)
        {
            using (SqlConnection connection = new SqlConnection(scsConnectionString))
            {
                DataSet ds = new DataSet();
                try
                {
                    connection.Open();
                    SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                    command.Fill(ds, "ds");
                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                return ds;
            }
        }

        /// <summary>

        /// </summary>
        /// <param name="SQLString">SQL文</param>
        /// <returns>DataSet</returns>
        public static DataSet SCSQuery(string SQLString, params SqlParameter[] cmdParms)
        {
            using (SqlConnection connection = new SqlConnection(scsConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        da.Fill(ds, "ds");
                        cmd.Parameters.Clear();
                    }
                    catch (SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
        }
        #endregion
    }

}
