using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.SessionState;

/// <summary>
/// DBClass 的摘要说明
/// </summary>
public class SqlServerDB
{
    public static SqlConnection myConnection;
    public static SqlCommand myCommand;
    public static  DataSet ds;
    public static DataTable dt;
    public static DataRow dr;
    public static SqlDataAdapter myAdapter;
    public static SqlDataAdapter myAdapter1;
    public static SqlDataReader myReader;
    protected static HttpResponse Response;
    protected static HttpSessionState Session;

    public SqlServerDB()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /*
     * 打开数据库的连接用力判断数据库是否处于关闭或打开状态
     * 采用webconfig的连接机制。 
     * 
    */
    #region 打开数据库操作
    public static void Open()
    {
        string strConnection;
        if (myConnection == null)
        {
            //strConnection = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString());
            myConnection.Open();
        }
        else
        {
            if (myConnection.State == ConnectionState.Closed)
            {
                if (myConnection.ConnectionString == "" || myConnection.ConnectionString == null)
                {
                    strConnection = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
                    myConnection.ConnectionString = strConnection;
                }
                myConnection.Open();
            }
        }
    }
    #endregion 关闭数据库操作

    /*
	* 关闭数据库的连接状态,清除dataset中的数据
	*/
    #region 关闭数据库
    public static  void Close()
    {
        if (ds != null)
        {
            ds.Clear();
            ds.Dispose();
        }
        if (myConnection.State == ConnectionState.Open)
        {
            try
            {
                myAdapter.Dispose();
            }
            catch (Exception)
            {

            }
            myConnection.Close();
            myConnection.Dispose();
        }
    }
    /*
    *关闭数据连接，清除数据适配器中的数据，取消填充数据
    * 
    */
    public static void CloseConnection()
    {
        if (myConnection.State == ConnectionState.Open)
        {
            try
            {
                myAdapter.Dispose();
            }
            catch (Exception)
            {

            }
            myConnection.Close();
            myConnection.Dispose();
        }
    }
    #endregion
    # region 释放资源
    public static  void Dispose()
    {
        if (ds != null)
        {
            ds.Dispose();
        }
        if (myAdapter != null)
        {
            myAdapter.Dispose();
        }
        if (myAdapter1 != null)
        {
            myAdapter.Dispose();
        }
        if (myCommand != null)
        {
            myCommand.Dispose();
        }
        if (myReader != null)
        {
            if (myReader.IsClosed)
            {
                myReader.Close();
            }
        }
    }
    #endregion 

    //sqlconnetion的方法用于数据的连接
    public static SqlConnection getconn()
    {
        SqlConnection conn;
        string connections = System.Configuration.ConfigurationSettings.AppSettings["Connectionstring"];
        conn = new SqlConnection(connections);
        return conn;
    }
    //对数据库执行sql操作
    public static SqlCommand getCommand()
    {
        SqlCommand myCmd = new SqlCommand();
        return myCmd;
    }

    public static SqlCommand getCommand(string strArg)
    {
        SqlCommand myCmd = new SqlCommand(strArg);
        return myCmd;
    }

    public static SqlCommand getCommand(string strArg, SqlConnection connArg)
    {
        Open();
        SqlCommand myCmd = new SqlCommand(strArg, connArg);
        return myCmd;
    }
    //执行 Transact-SQL INSERT、DELELE、UPDATE 及 SET 语句等命令。
    public static  void ExeSql(string str_Sql)
    {
        if (myConnection.State == ConnectionState.Closed)
        {
            Open();
        }
        myCommand = new SqlCommand(str_Sql, myConnection);
        myCommand.ExecuteNonQuery();
        myCommand.Dispose();
        CloseConnection();
    }
    //读取数据
    public static void Fill(string str_Sql)
    {
        myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString());
        if (myConnection.State == ConnectionState.Closed)
        {
            Open();
        }
        myAdapter = new SqlDataAdapter(str_Sql, myConnection);
        ds = new DataSet();
        myAdapter.Fill(ds);
    }

    public static void FillAdd(string tabname, string str_Sql)
    {
        myConnection = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"].ToString());
        if (myConnection.State == ConnectionState.Closed)
        {
            Open();
        }
        myAdapter = new SqlDataAdapter(str_Sql, myConnection);
        if (ds == null)
            ds = new DataSet();
        myAdapter.Fill(ds, tabname);

    }

    //dataset的数据绑定
    public static int GetRowCount(string str_Sql)
    {
        int intCount;
        Fill(str_Sql);
        if (ds.Tables.Count < 1)
        {
            Close();
            intCount = 0;
        }
        else
        {
            intCount = ds.Tables[0].Rows.Count;
        }
        return intCount;
    }

    public static void GetRowRecord(string str_Sql)
    {
        Fill(str_Sql);
        if (ds.Tables.Count > 0)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                dr = ds.Tables[0].Rows[0];
            }
        }
        myConnection.Close();
        myConnection.Dispose();
    }

    /*
    * 服务器控件数据的绑定
    * */
    public static void BindDataList(string sql, DataList mydatalist)
    {
        Fill(sql);
        mydatalist.DataSource = ds.Tables[0].DefaultView;
        mydatalist.DataBind();
    }
    public static void BindRepeater(string sql, Repeater myrepeater)
    {
        Fill(sql);
        myrepeater.DataSource = ds.Tables[0].DefaultView;
        myrepeater.DataBind();
    }

    public static void BindDropDownList(string str_Text, string sql, DropDownList myDropDownList)
    {
        // 绑定DropDownList控件（注：四个函数,该函数需要一个字段名，分别绑定Value和Text两值，默认表名）
        //Open();
        if (ds != null)
        {
            FillAdd("binddropdownlist" + sql.ToString(), sql);
            myDropDownList.DataSource = ds.Tables["binddropdownlist" + sql.ToString()].DefaultView;
        }
        else
        {
            Fill(sql);
            myDropDownList.DataSource = ds.Tables[0].DefaultView;
        }

        myDropDownList.DataValueField = str_Text;
        myDropDownList.DataTextField = str_Text;
        myDropDownList.DataBind();
    }

    /// <summary>
    /// 绑定DropDownList控件并显示数据,DropDownList控件Value,Text值将分别等于等于str_Value,str_Text值
    /// </summary>
    /// <param name="str_Value">绑定DropDownList控件Value值相对应数据库表字段名</param>
    /// <param name="str_Text">绑定DropDownList控件Text值相对应数据库表字段名</param>
    /// <param name="sql">Select-SQL语句</param>
    /// <param name="myDropDownList">DropDownList控件id值</param>
    public static void BindDropDownList(string str_Value, string str_Text, string sql, DropDownList myDropDownList)
    {

        try
        {
            if (myConnection.State == ConnectionState.Closed)
            {
                Open();
            }
            if (ds != null)
            {
                FillAdd("binddropdownlist" + sql.ToString(), sql);
                myDropDownList.DataSource = ds.Tables["binddropdownlist" + sql.ToString()].DefaultView;
            }
            else
            {
                Fill(sql);
                myDropDownList.DataSource = ds.Tables[0].DefaultView;
            }
            myDropDownList.DataValueField = str_Value;
            myDropDownList.DataTextField = str_Text;
            myDropDownList.DataBind();
            if (myDropDownList.Items.Count == 0)
            {
                ListItem li_null = new ListItem("无", "无");
                myDropDownList.Items.Add(li_null);
            }
        }
        catch (Exception e)
        {
            WriteMessage(e.Message.ToString().Trim(), true, true);
        }
        finally
        {
            Close();
            Dispose();
        }

    }

    public static void BindDropDownList(string str_Value, string str_Text, string sql, DropDownList myDropDownList, bool all)
    {

        if (ds != null)
        {
            FillAdd("binddropdownlist" + sql.ToString(), sql);
            if (all)
            {
                DataRow drL = ds.Tables["binddropdownlist" + sql.ToString()].NewRow();
                drL[str_Text] = "";
                drL[str_Value] = "";
                ds.Tables["binddropdownlist" + sql.ToString()].Rows.InsertAt(drL, 0);
            }
            myDropDownList.DataSource = ds.Tables["binddropdownlist" + sql.ToString()].DefaultView;
        }
        else
        {
            Fill(sql);
            if (all)
            {
                DataRow drL = ds.Tables[0].NewRow();
                drL[str_Text] = "";
                drL[str_Value] = "";
                ds.Tables[0].Rows.InsertAt(drL, 0);
            }
            myDropDownList.DataSource = ds.Tables[0].DefaultView;
        }
        myDropDownList.DataValueField = str_Value;
        myDropDownList.DataTextField = str_Text;
        myDropDownList.DataBind();
        //Close();
    }

    /// <summary>
    /// 绑定DropDownList控件，取得选中值
    /// </summary>
    /// <param name="str_Value">数据库表示Value值字段</param>
    /// <param name="str_Text">数据库表示Text值字段</param>
    /// <param name="str_Value_Field">选中项目的值</param>
    /// <param name="str_Sql">绑定数据的SQL语句</param>
    /// <param name="myDropDownList">下拉列表框的名称</param>
    public static void SelectBindDropDownListValue(string str_Value, string str_Text, string str_Value_Field, string str_Sql, DropDownList myDropDownList)
    {
        BindDropDownList(str_Value, str_Text, str_Sql, myDropDownList);// 绑定myDropDownList控件
        myDropDownList.Items[0].Selected = false;
        for (int i = 0; i < myDropDownList.Items.Count; i++)
        {
            if (str_Value_Field == myDropDownList.Items[i].Value)
            {
                myDropDownList.Items[i].Selected = true;
                break;
            }
        }
    }
    //以javascript的windous.alert()方法输出提示信息
    //strmsg 表示要输出的信息
    //back 表示输出后是否要history.back()
    //end 表示输出后是否要Response.End()
    public static void WriteMessage(string strMsg, bool Back, bool End)
    {
        Response = HttpContext.Current.Response;
        //将单引号替换,防止js出错
        strMsg = strMsg.Replace("'", "");
        //将回车符号换掉,防止js出错
        strMsg = strMsg.Replace("\r\n", "");
        Response.Write("<script language=javascript>alert('" + strMsg + "')</script>");
        if (Back)
        {
            Response.Write("<script language=javascript>history.back();</script)");
        }
        if (End)
        {
            Response.End();
        }
    }


}
