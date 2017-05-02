using Foxconn_QM.WebService.Email;
using LeaRun.DataAccess;
using LeaRun.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using LeaRun.Business;
using LeaRun.Repository;
using System.Linq;
using LeaRun.Entity;
using Mes.Net.CMail;
using System.IO;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;


//D:\ShiftNotification    production   06:00 AM  per day

namespace ShiftNotificationClass
{
    public class ShiftNotification: RepositoryFactory<MES_Shift_Operator>
    {
        public void test()
        {
            string s = mailHandle.sendMail(Guid.NewGuid().ToString(), ConfigHelper.AppSettings("SampleEmailSender"), "john.wq.liu@mail.foxconn.com,john.wq.liu@mail.foxconn.com", "", "", "subject", "body", @"c:\test.txt", null);
            //SendMailService SMS = new SendMailService(ConfigHelper.AppSettings("SendMailWebServiceUrl"));
            //string msginfo = string.Empty;
            //string mailid = string.Empty;

            //byte[] byteArray = System.Text.Encoding.Default.GetBytes("1234567890");

            //bool success = SMS.SendMail(ConfigHelper.AppSettings("AuthCode"), ConfigHelper.AppSettings("SampleEmailSender"), "john.wq.liu@mail.foxconn.com", null, null, "附件", "附件", byteArray, out msginfo, out mailid);
        }

        public void ShiftNotificationL5(string companyid)
        {
            MES_Shift_ScheduleMainBll bll = new MES_Shift_ScheduleMainBll();
            DataTable dtHR = GetHRlineList(companyid);

            for (int k = 0; k < dtHR.Rows.Count; k++)
            {
                string line = dtHR.Rows[k]["HRLineId"].ToString();
                DataTable dt = bll.GetHRLineInfo(line);
                if (dt == null || dt.Rows.Count == 0) continue;

                string hrlinename = dt.Rows[0]["hrlinename"].ToString();
                string hrlinefzr = "john.wq.liu@mail.foxconn.com";// dt.Rows[0]["hrlinefzr"].ToString();

                if (string.IsNullOrEmpty(hrlinefzr)) continue;

                SendMailService SMS = new SendMailService(ConfigHelper.AppSettings("SendMailWebServiceUrl"));
                string msginfo = string.Empty;
                string mailid = string.Empty;

                string subject = string.Format("排班通知 - {0}", hrlinename);
                DataTable temp = bll.GetRankClassInfo(line);

                if (temp != null && temp.Rows.Count == 0) continue;

                string body = "<table border =1><tr><td>日期</td><td>班次</td><td>需求人数</td><td>排班人数</td></tr>";

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    body += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", temp.Rows[i]["recorddate"].ToString(), temp.Rows[i]["TeamName"].ToString(), temp.Rows[i]["OprtRequire"].ToString(), temp.Rows[i]["OprtPlan"].ToString());
                }

                body += "</table>";

                //bool success = SMS.SendMail(ConfigHelper.AppSettings("AuthCode"), ConfigHelper.AppSettings("SampleEmailSender"), hrlinefzr, null, null, subject, body, null, out msginfo, out mailid);
            }
        }

        public void ShiftNotificationL6(string companyid)
        {
            MES_Shift_ScheduleMainBll bll = new MES_Shift_ScheduleMainBll();
            DataTable dtHR = GetlineList(companyid);

            for (int k = 0; k < dtHR.Rows.Count; k++)
            {
                string line = dtHR.Rows[k]["CompanyId"].ToString();
                string hrlinefzr = bll.GetLineInfo(line);

                string hrlinename = dtHR.Rows[k]["FullName"].ToString();
                hrlinefzr = "john.wq.liu@mail.foxconn.com";// dt.Rows[0]["hrlinefzr"].ToString();

                if (string.IsNullOrEmpty(hrlinefzr)) continue;

                SendMailService SMS = new SendMailService(ConfigHelper.AppSettings("SendMailWebServiceUrl"));
                string msginfo = string.Empty;
                string mailid = string.Empty;

                string subject = string.Format("排班通知 - {0}", hrlinename);
                DataTable temp = bll.GetRankClassInfo(line);

                if (temp != null && temp.Rows.Count == 0) continue;

                string body = "<table border =1><tr><td>日期</td><td>班次</td><td>需求人数</td><td>排班人数</td></tr>";

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    body += string.Format("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", temp.Rows[i]["recorddate"].ToString(), temp.Rows[i]["TeamName"].ToString(), temp.Rows[i]["OprtRequire"].ToString(), temp.Rows[i]["OprtPlan"].ToString());
                }

                body += "</table>";

                bool success = SMS.SendMail(ConfigHelper.AppSettings("AuthCode"), ConfigHelper.AppSettings("SampleEmailSender"), hrlinefzr, null, null, subject, body, null, out msginfo, out mailid);
            }
        }

        public void ShiftNotificationL6Attachment(string companyid)
        {
            //L6
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            IRow headerRow = sheet.CreateRow(0);
            IRow headerRow1 = sheet.CreateRow(1);
            DateTime today = DateTime.Now;
            string hrlinefzr = string.Empty;

            for (int i = 0, q = 1; i < 8; i++, q = q + 6)
            {
                headerRow.CreateCell(q).SetCellValue("人力需求");
                headerRow.CreateCell(q + 1).SetCellValue("排配人数");
                headerRow.CreateCell(q + 2).SetCellValue("差额");
                headerRow.CreateCell(q + 3).SetCellValue("人力需求");
                headerRow.CreateCell(q + 4).SetCellValue("排配人数");
                headerRow.CreateCell(q + 5).SetCellValue("差额");


                headerRow1.CreateCell(q).SetCellValue(today.ToString("yyyy-MM-dd") + "(白班)");
                headerRow1.CreateCell(q + 3).SetCellValue(today.ToString("yyyy-MM-dd") + "(晚班)");

                today = today.AddDays(1);
            }

            MES_Shift_ScheduleMainBll sbl = new MES_Shift_ScheduleMainBll();
            DataTable dtHR = GetlineList(companyid);


            for (int k = 0; k < dtHR.Rows.Count; k++)
            {
                string line = dtHR.Rows[k]["CompanyId"].ToString();
                string s = sbl.GetLineInfo(line);
                if (s != string.Empty) {
                    hrlinefzr = hrlinefzr + "," + sbl.GetLineInfo(line);
                }

                string hrlinename = dtHR.Rows[k]["FullName"].ToString();

                DataTable temp = sbl.GetRankClassInfo(line);

                NPOI.SS.UserModel.IRow rowtemp = sheet.CreateRow(k + 2);
                rowtemp.CreateCell(0).SetCellValue(hrlinename);

                if (temp != null && temp.Rows.Count == 0) continue;

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    int GapDays = Convert.ToInt32((Convert.ToDateTime(temp.Rows[i]["recorddate"]) - DateTime.Now.Date).TotalDays);
                    int start = 6 * GapDays + 1;
                    if (temp.Rows[i]["teamname"].ToString() == "晚班")
                    {
                        start = start + 3;
                    }

                    rowtemp.CreateCell(start).SetCellValue(temp.Rows[i]["OprtRequire"].ToString());
                    rowtemp.CreateCell(start + 1).SetCellValue(temp.Rows[i]["OprtPlan"].ToString());
                    rowtemp.CreateCell(start + 2).SetCellValue(Convert.ToInt32(temp.Rows[i]["OprtPlan"]) - Convert.ToInt32(temp.Rows[i]["OprtRequire"]));
                }
            }
            //hrlinefzr = "john.wq.liu@mail.foxconn.com";

            QMBLL qbl = new QMBLL();
            string companyname = qbl.GetCompanyNameByCompanyId(companyid);
            string filename = companyname + "-排班结果" +DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx";
            string path = Environment.CurrentDirectory + "\\attachment\\" + filename;
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                workbook.Write(fs);               

                //SendMailService SMS = new SendMailService(ConfigHelper.AppSettings("SendMailWebServiceUrl"));
                string msginfo = string.Empty;
                string mailid = string.Empty;
                string subject = companyname + "-排班通知";

                //ms.Flush();
                //fs.Write(ms.ToArray(),0,(int)ms.Length);
                //fs.Flush();     //流会缓冲，此行代码指示流不要缓冲数据，立即写入到文件。
                //fs.Close();     //关闭流并释放所有资源，同时将缓冲区的没有写入的数据，写入然后再关闭。
                //fs.Dispose();

                //bool success = SMS.SendMail(ConfigHelper.AppSettings("AuthCode"), ConfigHelper.AppSettings("SampleEmailSender"), hrlinefzr, null, null, subject, "排班通知", ms.ToArray(), out msginfo, out mailid);
                string status = mailHandle.sendMail(Guid.NewGuid().ToString(), ConfigHelper.AppSettings("SampleEmailSender"), hrlinefzr, null, null, subject, "排班通知", path, null);
            }
        }

        public void ShiftNotificationL5Attachment(string companyid)
        {
            XSSFWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Sheet1");
            IRow headerRow = sheet.CreateRow(0);
            IRow headerRow1 = sheet.CreateRow(1);
            DateTime today = DateTime.Now;
            string hrlinefzr = string.Empty;

            for (int i = 0, q = 1; i < 8; i++, q = q + 6)
            {
                headerRow.CreateCell(q).SetCellValue("人力需求");
                headerRow.CreateCell(q + 1).SetCellValue("排配人数");
                headerRow.CreateCell(q + 2).SetCellValue("差额");
                headerRow.CreateCell(q + 3).SetCellValue("人力需求");
                headerRow.CreateCell(q + 4).SetCellValue("排配人数");
                headerRow.CreateCell(q + 5).SetCellValue("差额");


                headerRow1.CreateCell(q).SetCellValue(today.ToString("yyyy-MM-dd") + "(白班)");
                headerRow1.CreateCell(q + 3).SetCellValue(today.ToString("yyyy-MM-dd") + "(晚班)");

                today = today.AddDays(1);
            }

            MES_Shift_ScheduleMainBll sbl = new MES_Shift_ScheduleMainBll();
            DataTable dtHR = GetHRlineList(companyid);


            for (int k = 0; k < dtHR.Rows.Count; k++)
            {
                string line = dtHR.Rows[k]["HRLineId"].ToString();
                string s = sbl.GetLineInfo(line);
                if (s != string.Empty)
                {
                    hrlinefzr = hrlinefzr + "," + sbl.GetLineInfo(line);
                }

                string hrlinename = dtHR.Rows[k]["hrlinename"].ToString();

                DataTable temp = sbl.GetRankClassInfo(line);

                NPOI.SS.UserModel.IRow rowtemp = sheet.CreateRow(k + 2);
                rowtemp.CreateCell(0).SetCellValue(hrlinename);

                if (temp != null && temp.Rows.Count == 0) continue;

                for (int i = 0; i < temp.Rows.Count; i++)
                {
                    int GapDays = Convert.ToInt32((Convert.ToDateTime(temp.Rows[i]["recorddate"]) - DateTime.Now.Date).TotalDays);
                    int start = 6 * GapDays + 1;
                    if (temp.Rows[i]["teamname"].ToString() == "晚班")
                    {
                        start = start + 3;
                    }

                    rowtemp.CreateCell(start).SetCellValue(temp.Rows[i]["OprtRequire"].ToString());
                    rowtemp.CreateCell(start + 1).SetCellValue(temp.Rows[i]["OprtPlan"].ToString());
                    rowtemp.CreateCell(start + 2).SetCellValue(Convert.ToInt32(temp.Rows[i]["OprtPlan"]) - Convert.ToInt32(temp.Rows[i]["OprtRequire"]));
                }
            }
            //hrlinefzr = "john.wq.liu@mail.foxconn.com";
            QMBLL qbl = new QMBLL();
            string companyname = qbl.GetCompanyNameByCompanyId(companyid);
            string filename = companyname + "-排班结果" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xlsx";
            string path = Environment.CurrentDirectory + "\\attachment\\" + filename;
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                workbook.Write(fs);

                //SendMailService SMS = new SendMailService(ConfigHelper.AppSettings("SendMailWebServiceUrl"));
                string msginfo = string.Empty;
                string mailid = string.Empty;
                string subject = companyname + "-排班通知";
                string status = mailHandle.sendMail(Guid.NewGuid().ToString(), ConfigHelper.AppSettings("SampleEmailSender"), hrlinefzr, null, null, subject, "排班通知", path, null);
            }
        }

        public DataTable GetHRlineList(string companyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select * from dbo.MES_HRLine where (CompanyId = @CompanyId or L6DepartmentId = @CompanyId or DepartmentId = @CompanyId)  order by HRLineName ");
            List<DbParameter> parameter = new List<DbParameter>();
            parameter.Add(DbFactory.CreateDbParameter("@CompanyId", companyId));
            return Repository().FindTableBySql(strSql.ToString(), parameter.ToArray());
        }

        public DataTable GetlineList(string companyId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@"select * from Base_Company where ParentId = '2a3eee8c-9f84-4b73-8382-bc127e96542c' and Category = '产线' ");
            return Repository().FindTableBySql(strSql.ToString());
        }
    }
}
