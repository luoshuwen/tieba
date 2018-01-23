using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

/// <summary>
/// 用于执行的 SQL 语句并返回结果
/// </summary>
public static class SqlHelper
{
    
    /// <summary>
    /// 数据库的连接
    /// </summary>
    private static SqlConnection conn;

    /// <summary>
    /// 表示能否正常连接数据库
    /// </summary>
    public static bool Connectable
    {
        set;
        get;
    }

    /// <summary>
    /// 自此类初始化以来所发生的异常的信息记录
    /// </summary>
    public static string ExceptionMessage
    {
        set;
        get;
    }

    /// <summary>
    /// 发生异常，添加异常信息记录
    /// </summary>
    /// <param name="exception">发生的异常</param>
    /// <param name="sqlExp">发生异常时的 SQL 语句</param>
    [System.Diagnostics.Conditional("DEBUG")]
    private static void ExceptionOccur(Exception exception, string sqlExp = "")
    {
        ExceptionMessage += exception.ToString() + "\n";
        if (sqlExp != "")
        {
            ExceptionMessage += "\n执行的 SQL 语句：\n" + sqlExp + "\n";
        }
    }

    /// <summary>
    /// 执行语句cmdexecutereader
    /// </summary>
    /// <param name="a">sql语句</param>
    /// <returns>reader的结果</returns>
    public static SqlDataReader cmdexecutereader(string a)
    {
            string s = ConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
            SqlConnection conn;
            conn = new SqlConnection(s);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = a;
            SqlDataReader reader = cmd.ExecuteReader();//SqlDataReader 
            return reader;
       
    }

    public static DataSet link(string a)
    {
        SqlConnection conn;
        string s = ConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
        conn = new SqlConnection(s);
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = conn;
        cmd.CommandType = CommandType.Text;
        string mid = a;
        SqlDataAdapter sda = new SqlDataAdapter(mid, conn);
        DataSet ds = new DataSet();
        sda.Fill(ds);
        return ds;

    }
    /// <summary>
    /// 初始化数据库的连接
    /// </summary>
    static SqlHelper()
    {
        try
        {
            ExceptionMessage = "";
            string connStr = ConfigurationManager.ConnectionStrings["SqlConnStr"].ConnectionString;
            conn = new SqlConnection(connStr);
            conn.Open();
            Connectable = true;
        }
        catch (Exception ex)
        {
            conn = new SqlConnection();
            Connectable = false;
            ExceptionOccur(ex);
        }
        finally
        {
            conn.Close();
        }
    }

    /// <summary>
    /// 执行查询，并返回查询所返回的结果集中第一行的第一列，忽略其他列或行
    /// </summary>
    /// <param name="sqlExp">查询的 SQL 语句</param>
    /// <returns>结果集中第一行的第一列，如果结果集为空则为空引用</returns>
    public static object ExecuteScalar(string sqlExp)
    {
        object result = null;
        try
        {
            using (SqlCommand cmd = new SqlCommand(sqlExp, conn))
            {
                conn.Open();
                result = cmd.ExecuteScalar();
            }
        }
        catch (Exception ex)
        {
            ExceptionOccur(ex, sqlExp);
        }
        finally
        {
            conn.Close();
        }
        return result;
    }

    /// <summary>
    /// 执行查询，并返回查询所返回的结果集中第一个表，忽略其他表
    /// </summary>
    /// <param name="sqlExp">查询的 SQL 语句</param>
    /// <returns>结果集中第一个表，如果结果集为空则为空表</returns>
    public static DataTable ExecuteAdapter(string sqlExp)
    {
        DataTable dt = new DataTable();
        try
        {
            using (SqlDataAdapter da = new SqlDataAdapter(sqlExp, conn))
            {
                conn.Open();
                da.Fill(dt);
            }
        }
        catch (Exception ex)
        {
            ExceptionOccur(ex, sqlExp);
        }
        finally
        {
            conn.Close();
        }
        return dt;
    }

    /// <summary>
    /// 执行 SQL 语句，并返回受影响的行数
    /// </summary>
    /// <param name="sqlExp">执行的 SQL 语句</param>
    /// <returns>受影响的行数，发生异常时返回 -1 </returns>
    public static int ExecuteNonQuery(string sqlExp)
    {
        int result = -1;
        try
        {
            using (SqlCommand cmd = new SqlCommand(sqlExp, conn))
            {
                conn.Open();
                result = cmd.ExecuteNonQuery();
            }
        }
        catch (Exception ex)
        {
            ExceptionOccur(ex, sqlExp);
        }
        finally
        {
            conn.Close();
        }
        return result;
    }
}