using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class IssueInfo_RefreshServe : System.Web.UI.Page
{
    //private static ILog log = LogManager.GetLogger(typeof(RefreshServe));

    private readonly string REFRESH_TICKET_NAME = "__RefreshTicketArray";
    private readonly string HIDDEN_FIELD_NAME = "__RefreshHiddenField";
    private readonly string HIDDEN_PAGE_GUID = "__RefreshPageGuid";

    /// <summary>
    /// 为True表示页面刷新,False为正常提交
    /// </summary>
    public bool IsPageRefreshed
    {
        get
        {
            if (IsPostBack && !CheckRefreshFlag())
            {
                //log.Debug("刷新了页面");
                return true;
            }
            else
            {
                //log.Debug("正常提交");
                return false;
            }
        }
    }

    /// <summary>
    /// 呈现前更新标识
    /// </summary>
    /// <param name="e"></param>
    protected override void OnPreRender(EventArgs e)
    {
        //log.Debug("执行OnPreRender");
        base.OnPreRender(e);
        UpdateRefreshFlag();
    }

    /// <summary>
    /// 更新标识,正常提交都删除该次提交的时间,并生产当前新的时间
    /// </summary>
    private void UpdateRefreshFlag()
    {

        #region Session模式

        ////设置页面唯一标识
        //SetCurPageGuid();

        //DataTable RefreshSign = GetRefreshSession();
        //string pageGuid = GetCurPageGuid();
        //DataRow newRow;

        //if (RefreshSign.Rows.Count > 0)
        //{
        //    DataRow[] existRow = RefreshSign.Select("GUID='none'");
        //    if (existRow.Length > 0)
        //    {
        //        foreach (DataRow row in existRow)
        //            row.Delete();
        //        log.Debug("找到为none标识的行并删除");
        //    }

        //    existRow = RefreshSign.Select("GUID='" + pageGuid + "'");
        //    if (existRow.Length > 0)
        //    {
        //        foreach (DataRow row in existRow)
        //            row.Delete();
        //        log.Debug("找到为" + pageGuid + "标识的行并删除");
        //    }
        //}

        //string submitTime = DateTime.Now.ToString("hhmmss.fffff");
        ////当前提交时间保存到隐藏域
        //ClientScript.RegisterHiddenField(HIDDEN_FIELD_NAME, submitTime);


        ////同时添加到DataTable列表中
        //newRow = RefreshSign.NewRow();
        //newRow["submitTime"] = submitTime;
        //newRow["GUID"] = pageGuid;
        //log.Debug("即将要新增的票证:submitTime:" + submitTime + "  Guid:" + pageGuid.ToString());
        //RefreshSign.Rows.Add(newRow);

        //log.Debug("UpdateRefreshFlag中当前DataTable中存在的记录数为:" + RefreshSign.Rows.Count);
        //foreach (DataRow row in RefreshSign.Rows)
        //{
        //    log.Info("row['submitTime']:" + row["submitTime"] + "    row['GUID']:" + row["GUID"]);
        //}
        #endregion

        #region Cookie模式

        //注册页面唯一标识并返回
        string pageGuid = SetCurPageGuid();

        HttpCookie cookie = GetRefreshTicket();

        if (cookie.Values.Count > 0)
        {
            cookie.Values.Remove(pageGuid);
            //log.Debug("当前清除的cookie变是:" + pageGuid);
        }

        string submitTime = DateTime.Now.ToString("hhmmss.fffff");
        //当前提交时间保存到隐藏域
        ClientScript.RegisterHiddenField(HIDDEN_FIELD_NAME, submitTime);


        //log.Debug("即将要新增的时间:submitTime:" + submitTime + "  Guid:" + pageGuid.ToString());
        cookie.Values.Add(pageGuid, submitTime);

        //log.Debug("UpdateRefreshFlag中当前Cookie中存在的记录数为:" + cookie.Values.Count);
        //for (int i = 0; i < cookie.Values.Count; i++)
            //log.Info("cookie[" + cookie.Values.GetKey(i) + "]:" + cookie.Values[i]);

        Response.AppendCookie(cookie);

        #endregion

    }

    /// <summary>
    /// 验证是否刷新
    /// </summary>
    /// <returns></returns>
    private bool CheckRefreshFlag()
    {
        #region Session模式
        //DataTable RefreshSign = GetRefreshSession();

        //if (RefreshSign.Rows.Count == 0)//第一次访问页面
        //{
        //    log.Debug("第一次访问页面");
        //    return true;
        //}
        //else
        //{
        //    bool flag = RefreshSign.Rows.IndexOf(RefreshSign.Rows.Find(GetCurSubmitTime())) > -1;//当前提交时间是否存在
        //    if (flag)
        //        log.Debug("提交时间存在");
        //    else
        //        log.Debug("无效的提交时间");
        //    return flag;
        //}
        #endregion

        HttpCookie cookie = GetRefreshTicket();
        string pageGuid = GetCurPageGuid();
        if (cookie.Values.Count > 0)
        {
            bool flag;
            if (cookie.Values[pageGuid] != null)
                flag = cookie.Values[pageGuid].IndexOf(GetCurSubmitTime()) > -1;
            else
                flag = true;//防止出现异常,总是可以提交
            //if (flag)
                //log.Debug("提交时间存在,可以提交");
            //else
                //log.Debug("无效的提交时间");
            return flag;
        }
        return true;
    }



    /// <summary>
    /// 得到已保存的提交时间,没有新建,有返回
    /// </summary>
    /// <returns></returns>
    private HttpCookie GetRefreshTicket()
    {
        #region Session模式,返回值改为DataTable

        //DataTable RefreshSession;
        //if (Session[REFRESH_TICKET_NAME] == null)
        //{
        //    RefreshSession = new DataTable("RefreshSession");
        //    DataColumn newColumn;

        //    newColumn = new DataColumn("submitTime", System.Type.GetType("System.String"));
        //    RefreshSession.Columns.Add(newColumn);

        //    DataColumn[] columnArray = new DataColumn[1];
        //    columnArray[0] = newColumn;
        //    RefreshSession.PrimaryKey = columnArray;


        //    newColumn = new DataColumn("GUID", System.Type.GetType("System.String"));
        //    RefreshSession.Columns.Add(newColumn);

        //    Session[REFRESH_TICKET_NAME] = RefreshSession;

        //    log.Debug("Session不存在，初始化");
        //}
        //else
        //{
        //    RefreshSession = Session[REFRESH_TICKET_NAME] as DataTable;

        //    log.Debug("读取已存在的Session,当前DataTable中存在的记录数为:" + RefreshSession.Rows.Count);
        //    foreach (DataRow row in RefreshSession.Rows)
        //    {
        //        log.Info("row['submitTime']:" + row["submitTime"] + "    row['GUID']:" + row["GUID"]);
        //    }              
        //}           
        //return RefreshSession;
        #endregion

        #region Cookie模式,返回值为Cookie

        HttpCookie cookie;
        if (Request.Cookies[REFRESH_TICKET_NAME] == null)
        {
            cookie = new HttpCookie(REFRESH_TICKET_NAME);
            Response.AppendCookie(cookie);
            //log.Debug("Cookie不存在，初始化");
        }
        else
        {
            cookie = Request.Cookies[REFRESH_TICKET_NAME];

            //log.Debug("读取已存在的Cookie,当前Cookie中存在的记录数为:" + cookie.Values.Count + "具体有如下几条:");

            //for (int i = 0; i < cookie.Values.Count; i++)
                //log.Info("cookie[" + cookie.Values.GetKey(i) + "]:" + cookie.Values[i]);
        }
        return cookie;
        #endregion
    }

    /// <summary>
    /// 获取当前提交时间
    /// </summary>
    /// <returns></returns>
    private string GetCurSubmitTime()
    {
        string submitTime = Request.Params[HIDDEN_FIELD_NAME] == null ? "" : Request.Params[HIDDEN_FIELD_NAME].ToString();
        //log.Debug("执行GetCurSubmitTime:submitTime为:" + submitTime);
        return submitTime;
    }


    /// <summary>
    /// 设置页面唯一标识,通过Guid标识来区分每个页面自己的提交时间
    /// </summary>
    private string SetCurPageGuid()
    {
        string guid;
        if (!IsPostBack)
        {
            if (Request.Params[HIDDEN_PAGE_GUID] == null)
            {
                guid = System.Guid.NewGuid().ToString();
                //log.Debug("SetCurPageGuid注册了一个新的标识:" + guid);
            }
            else
                guid = GetCurPageGuid();

        }
        else
        {
            guid = GetCurPageGuid();
        }

        ClientScript.RegisterHiddenField(HIDDEN_PAGE_GUID, guid);
        return guid;
    }

    /// <summary>
    /// 得到当前页面的唯一标识
    /// </summary>
    /// <returns></returns>
    private string GetCurPageGuid()
    {
        string pageGuid = Request.Params[HIDDEN_PAGE_GUID] == null ? "none" : Request.Params[HIDDEN_PAGE_GUID].ToString();
        //log.Debug("执行GetCurPageGuid()后Page_GUID为:" + pageGuid);
        return pageGuid;
    }

//需要刷新判断功能时新页面只需继续该类就可,通过引用属性IsPageRefreshed识别"为真表示刷新,假则是正常提交",将数据库的操作写在
//if(!IsPageRefreshed)
//{
//   数据库操作
//}
//即可,如果是刷新他不会执行

}
