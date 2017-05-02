using System;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Collections;
using System.Threading;

public partial class _Default : System.Web.UI.Page 
{
    private int[] valueArray;
    private Random randomNumber = new Random();
    private static volatile bool swaped = true;
    private DateTime startTime;
    private DateTime endTime;
    private static volatile string strng = "";
    private Hashtable threadHolder = new Hashtable();
    private static long threadCounter = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Application["ThreadAndTime"] != null || Application["ThreadAndTime"].ToString() != string.Empty)
        {
            tbResult.Text = Application["ThreadAndTime"].ToString();
            tbOut.Text = Application["OutTxt"].ToString();
        }
    }

    public void Sort()
    {
        try
        {
            while (true)
            {
                swaped = false;
                for (int j = 0; j < valueArray.Length - 1; j++)
                {
                    lock (typeof(Thread))
                    {	/* If the left-hand side value is greater swap values*/
                        if (valueArray[j] > valueArray[j + 1])
                        {
                            int T = valueArray[j];
                            valueArray[j] = valueArray[j + 1];
                            valueArray[j + 1] = T;
                            swaped = true;
                        }
                    }
                }
                Thread.Sleep(1);
                if (!swaped) { break; }
            }
            Thread.CurrentThread.Abort();
        }
        catch (Exception ex)
        {
            if (Interlocked.Increment(ref threadCounter) == Convert.ToInt64(ddlThreadNum.SelectedItem.Text.ToString().Trim()))
                Display();
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(), "", "<script>location.href=location.href;</script>");
    }

    public void Display()
    {
        lbMsg.Text = "排序结束..";
        strng = "";
        endTime = DateTime.Now;
        for (int i = 0; i < valueArray.Length; i++)
        { strng += valueArray[i].ToString() + " "; }
        btnSort.Enabled = true;
        TimeSpan ts = endTime - startTime;
        Application["ThreadAndTime"] += "Threads: " + ddlThreadNum.SelectedItem.Text.ToString().Trim() + " 所用毫秒数：" + Convert.ToString(ts.TotalMilliseconds) + "\r\n";
        Application["OutTxt"] = strng + "\r\n";
        //			tbResult.Text +="Threads: "+ddlThreadNum.SelectedItem.Text.ToString().Trim()+" 所用毫秒数："+Convert.ToString(ts.TotalMilliseconds)+"\r\n";
        //			tbOut.Text = strng+"\r\n";

    }
    protected void btnSort_Click(object sender, EventArgs e)
    {
        btnSort.Enabled = false;
        valueArray = new int[Convert.ToInt32(ddlNum.SelectedItem.Text.Trim())];
        threadHolder.Clear();
        valueArray.Initialize();
        threadCounter = 0;
        lbMsg.Text = "排序进行中...";
        /* Insert value in to the valueArray */
        for (int i = 0; i < valueArray.Length; i++)
        {
            valueArray[i] = valueArray.Length - i;
            //valueArray[i] = Convert.ToInt32(randomNumber.Next(1000));
        }
        /*	Start a timer to check the time to sort the array */
        startTime = DateTime.Now;
        /* Start threads to sort the values in the arry */
        for (int t = 0; t < Convert.ToInt32(ddlThreadNum.SelectedItem.Text.Trim()); t++)
        {
            Thread thread = new Thread(new ThreadStart(Sort));
            thread.Name = Convert.ToString(t);
            thread.Start();
        }
        Page.ClientScript.RegisterStartupScript(this.GetType(),"", "<script>window.setTimeout('location.href=location.href',5000);</script>");
    }

    protected void btnClearOut_Click(object sender, System.EventArgs e)
    {
        Application["OutTxt"] = "";
        tbOut.Text = "";
        Application["ThreadAndTime"] = "";
        tbResult.Text = "";

    }

    protected void btnClearTime_Click(object sender, System.EventArgs e)
    {
        Application["OutTxt"] = null;
        tbResult.Text = "";
        Application["ThreadAndTime"] = null;
        tbResult.Text = "";
    }
}
