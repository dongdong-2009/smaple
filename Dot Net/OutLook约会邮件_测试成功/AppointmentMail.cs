using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Net.Mail;

namespace test
{
    public class AppointmentMail
    {
        static void Main()
        {
            Outlook.AppointmentItem appt = new Outlook.Application().CreateItem(Outlook.OlItemType.olAppointmentItem) as Outlook.AppointmentItem;
            appt.Subject = "一个会议要求测试";
            appt.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;
            appt.Location = "武汉东风汽车有限公司303会议室";
            appt.Start = DateTime.Parse("10/20/2008 10:00 AM");
            appt.End = DateTime.Parse("10/20/2008 11:00 AM");

            //会议接收者
            Outlook.Recipient recipRequired = appt.Recipients.Add("qikw@dfl.com.cn");
            //表示该会议接收者为比许参加的人员
            recipRequired.Type =
                (int)Outlook.OlMeetingRecipientType.olRequired;

            //可选的与会者
            //Outlook.Recipient recipOptional =
            //    appt.Recipients.Add("Peter Allenspach");

            //recipOptional.Type =
            //    (int)Outlook.OlMeetingRecipientType.olOptional;

            //请求的会议资源
            //Outlook.Recipient recipConf =
            //   appt.Recipients.Add("Conf Room 36/2021 (14) AV");

            //recipConf.Type =
            //    (int)Outlook.OlMeetingRecipientType.olResource;
            appt.Subject = "subject";
            appt.Body = "<font color='red'>body</font>";
            appt.Recipients.ResolveAll();
            appt.Display(false);
            appt.Send();
        }
    }
}
