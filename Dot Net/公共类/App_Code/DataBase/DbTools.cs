using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


  /// <summary>
  /// DbTools 的摘要说明。
  /// </summary>
  public class DbTools
  {

      private static string strConnection = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/").ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString;

    public DbTools()
    {

    }
    /// <summary>
    /// 用于执行非查询存储过程，包括Update,Insert,Delete
    /// </summary>
    /// <param name="pstrStoreProcedureName">存储过程名</param>
    /// <param name="pParams">存储过程的参数数组</param>
    /// <returns>执行结果：-1失败；其他：影响的行数</returns>
    public static int ExectueNoQuery(string pstrStoreProcedureName, SqlParameter[] pParams)
    {
      SqlConnection sqlcon = new SqlConnection(strConnection);
      SqlCommand sqlcmd = new SqlCommand();
      int Result;
      try
      {
        sqlcon.Open();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = pstrStoreProcedureName;
        for (int intCounter = 0; intCounter < pParams.GetLength(0); intCounter++)
        {
          sqlcmd.Parameters.Add(pParams[intCounter]);
        }
        Result=sqlcmd.ExecuteNonQuery();
      }
      catch (SqlException)
      {
        return -1;
      }
      finally
      {
        sqlcmd.Dispose();
        sqlcon.Close();
        sqlcon.Dispose();
      }
      return Result;
    }
    /// <summary>
    /// 执行有参数的查询类存储过程
    /// </summary>
    /// <param name="pstrStoreProcedure">存储过程名</param>
    /// <param name="pParms">存储过程的参数数组</param>
    /// <returns>查询得到的结果集</returns>
    public static DataSet ExecuteQuery(string pstrStoreProcedure, SqlParameter[] pParms)
    {
      SqlConnection sqlcon = new SqlConnection(strConnection);
      SqlCommand sqlcmd = new SqlCommand();
      DataSet dsResult = new DataSet();
      SqlDataAdapter sda = new SqlDataAdapter();
      int intCounter;
      try
      {
        sqlcon.Open();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = pstrStoreProcedure;
        for (intCounter = 0; intCounter < pParms.GetLength(0); intCounter++)
        {
          sqlcmd.Parameters.Add(pParms[intCounter]);
        }
        sda.SelectCommand = sqlcmd;
        sda.Fill(dsResult);
      }
      catch (SqlException)
      {
        return null;
      }
      finally
      {
        sda.Dispose();
        sqlcmd.Dispose();
        sqlcon.Close();
        sqlcon.Dispose();
      }
      return dsResult;
    }
    /// <summary>
    /// 执行无参数的查询类存储过程
    /// </summary>
    /// <param name="pstrStoreProcedure">存储过程名</param>
    /// <returns>查询得到的结果集</returns>
    public static DataSet ExecuteQuery(string pstrStoreProcedure)
    {
      SqlConnection sqlcon = new SqlConnection(strConnection);
      SqlCommand sqlcmd = new SqlCommand();
      DataSet dsResult = new DataSet();
      SqlDataAdapter sda = new SqlDataAdapter();
      try
      {
        sqlcon.Open();
        sqlcmd.Connection = sqlcon;
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = pstrStoreProcedure;
        sda.SelectCommand = sqlcmd;
        sda.Fill(dsResult);
      }
      catch (SqlException)
      {
        return null;
      }
      finally
      {
        sda.Dispose();
        sqlcmd.Dispose();
        sqlcon.Close();
        sqlcon.Dispose();
      }
      return dsResult;
    }
    /// <summary>
    /// 执行事务类型存储过程
    /// </summary>
    /// <param name="pstrStoreProcedure">存储过程名</param>
    /// <param name="pParms">存储过程的参数数组</param>
    /// <returns>true成功；false失败</returns>
    public static bool ExecuteTrans(string pstrStoreProcedure, SqlParameter[] pParms)
    {
      SqlConnection sqlcon = new SqlConnection(strConnection);
      SqlTransaction sqltrans = null; ;
      try
      {
        sqlcon.Open();
        sqlcon.BeginTransaction(); //使用New新生成一个事务
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.Transaction = sqltrans;
        sqlcmd.CommandText = pstrStoreProcedure;
        sqlcmd.ExecuteNonQuery();
        sqltrans.Commit();
      }
      catch (Exception)
      {
        sqltrans.Rollback();
        return false;
      }
      finally
      {
        sqlcon.Close();
      }
      return true;
    }
  }

