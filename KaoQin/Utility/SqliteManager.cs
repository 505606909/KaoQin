using System;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;

namespace KaoQin.Utility
{
    public  class SqlLiteManager
    {
        #region 变量  
        #region 数据库连接字符串 
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public  string ConnString = "";
        /// <summary>
        /// 数据库连接对象
        /// </summary>
        private readonly SQLiteConnection conn = new SQLiteConnection();
        /// <summary>
        /// cmd对象
        /// </summary>
        private readonly SQLiteCommand comm = new SQLiteCommand();
        #endregion
        #region IsOpen 
        /// <summary>
        /// 连接是否打开
        /// </summary>
        public bool IsOpen
        {
            get
            {
                return conn.State == ConnectionState.Open;
            }
        }
        #endregion

        #region IsClosed 
        /// <summary>
        /// 连接是否关闭
        /// </summary>
        public bool IsClosed
        {
            get
            {
                return conn.State == ConnectionState.Closed;
            }
        }
        #endregion

        #endregion

        #region  打开数据库连接
        /// <summary>
        /// 打开数据库
        /// </summary>
        public bool Open(string connectionString)
        {
            if (IsClosed)
            { 
                conn.ConnectionString = connectionString;
                comm.Connection = conn;
                try
                {
                    conn.Open();
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }

            }
            return true;

        }
        #endregion

        #region 关闭数据库 
        /// <summary>
        /// 关闭数据库
        /// </summary>
        public void Close()
        {
            if (IsOpen)
            {
                conn.Close();
                conn.Dispose();
                comm.Dispose();
            }
        }
        #endregion

        #region  获取DataTable
        /// <summary>
        /// 获取DataTable
        /// </summary>
        /// <param name="sSQL">sql语句</param>
        /// <returns></returns>
        public  DataTable SelectDataTable( string sSQL)
        {
            return this.SelectDataSet(sSQL).Tables[0];
        }
        #endregion
         
        #region 获取dataset
        /// <summary>
        /// 获取dataset
        /// </summary>
        /// <param name="sSQL">sql数据库</param>
        /// <returns></returns>
        public DataSet SelectDataSet(string sSQL)
        {
            DataSet ds = null;
            comm.CommandText = sSQL;
            SQLiteDataAdapter dao = new SQLiteDataAdapter(comm);
            ds = new DataSet();
            dao.Fill(ds);

            return ds;
        }
        #endregion
         
        #region 获取单一元素
        /// <summary>
        /// 获取单一元素
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        public object GetSingle(string sSQL)
        {
            DataTable dt = SelectDataTable(sSQL);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0];
            }
            return null;
        }
        #endregion

        #region 执行sql语句 
        /// <summary>
        /// 执行sql语句
        /// </summary>
        /// <param name="sSQL">sql语句</param>
        /// <param name="bUseTransaction">是否启动事务</param>
        /// <returns></returns>
        public bool Exec(string sSQL, bool bUseTransaction = false)
        {
            int iResult = 0;
            if (!bUseTransaction)
            {
                try
                {
                    comm.CommandText = sSQL;
                    iResult = comm.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    iResult = -1;
                }
            }
            else // 使用事务
            {
                DbTransaction trans = null;
                try
                { 
                    trans = conn.BeginTransaction(); 
                    comm.CommandText = sSQL;
                    iResult = comm.ExecuteNonQuery();
                    trans.Commit();
                }
                catch (Exception)
                {
                    iResult = -1;
                    if (trans != null)
                    {
                        trans.Rollback();
                    }
                }
            }

            return iResult > 0;
        }
        #endregion


    }
}

