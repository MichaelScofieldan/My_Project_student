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
    /// �f�[�^�A�N�Z�X�x�[�X�N���X
    /// </summary>
    public class DbHelperSQL
    {
        // �f�[�^�x�[�X�ڑ�������
        public static string connectionString = PubConstant.ConnectionString;
        public static string scsConnectionString = PubConstant.SCSConnectionString;
        private SqlConnection tranConnection = null;
        private SqlTransaction transaction = null;
        public SqlCommand TranCommand = null;
        public DbHelperSQL()
        {

        }

        #region �����g�����U�N�V����SQL      
        /// <summary>
        /// �f�[�^�x�[�X�g�����U�N�V�������J�n����
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
        /// �g�����U�N�V���������[���o�b�N����
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
        /// �f�[�^�x�[�X �g�����U�N�V�������R�~�b�g����
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
        /// �p�����[�^�N�G�������s����
        /// </summary>
        /// <param name="SQLString">SQL��</param>
        /// <returns>�e�����󂯂�s�̐�</returns>
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
        /// �p�����[�^�N�G�������s����
        /// </summary>
        /// <param name="strSQL">SQL��</param>
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
        /// �p�����[�^�N�G�������s����
        /// </summary>
        /// <param name="SQLString">SQL��</param>
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

        #region  ����SQL

        /// <summary>
        /// �I�u�W�F�N�g���݃`�F�b�N
        /// </summary>
        /// <param name="strSql">SQL��</param>
        /// <param name="cmdParms">�p�����[�^</param>
        /// <returns>���R�[�h�����݂���ꍇ:true,���R�[�h�����݂��Ȃ��ꍇ:false</returns>
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
        /// ����SQL
        /// </summary>
        /// <param name="SQLString">SQL��</param>
        /// <returns>���������s</returns>
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
        /// �N�G���̎��s
        /// </summary>
        /// <param name="strSQL">SQL��</param>
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
        /// �N�G���̎��s
        /// </summary>
        /// <param name="SQLString">SQL��</param>
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

        #region �p�����[�^�N�G�������s����

        /// <summary>
        /// �p�����[�^�N�G�������s����
        /// </summary>
        /// <param name="SQLString">SQL��</param>
        /// <returns>�e�����󂯂�s�̐�</returns>
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
        /// �N�G�������s���A�N�G���ɂ���ĕԂ��ꂽ���ʃZ�b�g�̍ŏ��̍s�̍ŏ��̗��Ԃ��܂��B
        /// </summary>
        /// <param name="SQLString">SQL��</param>
        /// <returns>�N�G������</returns>
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
        /// �p�����[�^�N�G�������s����
        /// </summary>
        /// <param name="strSQL">SQL��</param>
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
        /// �p�����[�^�N�G�������s����
        /// </summary>
        /// <param name="SQLString">SQL��</param>
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
        /// SqlParameter��ǉ�����
        /// </summary>
        /// <param name="cmd">SqlCommand�I�u�W�F�N�g</param>
        /// <param name="conn">SqlConnection�I�u�W�F�N�g</param>
        /// <param name="trans">SqlTransaction�I�u�W�F�N�g</param>
        /// <param name="cmdText">SQL</param>
        /// <param name="cmdParms">SqlParameter�I�u�W�F�N�g</param>
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
        /// �N�G���̎��s
        /// </summary>
        /// <param name="SQLString">SQL��</param>
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
        /// <param name="SQLString">SQL��</param>
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
