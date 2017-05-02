using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


  /// <summary>
  /// DbTools ��ժҪ˵����
  /// </summary>
  public class DbTools
  {

      private static string strConnection = System.Web.Configuration.WebConfigurationManager.OpenWebConfiguration("~/").ConnectionStrings.ConnectionStrings["ConnectionString"].ConnectionString;

    public DbTools()
    {

    }
    /// <summary>
    /// ����ִ�зǲ�ѯ�洢���̣�����Update,Insert,Delete
    /// </summary>
    /// <param name="pstrStoreProcedureName">�洢������</param>
    /// <param name="pParams">�洢���̵Ĳ�������</param>
    /// <returns>ִ�н����-1ʧ�ܣ�������Ӱ�������</returns>
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
    /// ִ���в����Ĳ�ѯ��洢����
    /// </summary>
    /// <param name="pstrStoreProcedure">�洢������</param>
    /// <param name="pParms">�洢���̵Ĳ�������</param>
    /// <returns>��ѯ�õ��Ľ����</returns>
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
    /// ִ���޲����Ĳ�ѯ��洢����
    /// </summary>
    /// <param name="pstrStoreProcedure">�洢������</param>
    /// <returns>��ѯ�õ��Ľ����</returns>
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
    /// ִ���������ʹ洢����
    /// </summary>
    /// <param name="pstrStoreProcedure">�洢������</param>
    /// <param name="pParms">�洢���̵Ĳ�������</param>
    /// <returns>true�ɹ���falseʧ��</returns>
    public static bool ExecuteTrans(string pstrStoreProcedure, SqlParameter[] pParms)
    {
      SqlConnection sqlcon = new SqlConnection(strConnection);
      SqlTransaction sqltrans = null; ;
      try
      {
        sqlcon.Open();
        sqlcon.BeginTransaction(); //ʹ��New������һ������
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

