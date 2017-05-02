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
            appt.Subject = "һ������Ҫ�����";
            appt.MeetingStatus = Outlook.OlMeetingStatus.olMeeting;
            appt.Location = "�人�����������޹�˾303������";
            appt.Start = DateTime.Parse("10/20/2008 10:00 AM");
            appt.End = DateTime.Parse("10/20/2008 11:00 AM");

            //���������
            Outlook.Recipient recipRequired = appt.Recipients.Add("qikw@dfl.com.cn");
            //��ʾ�û��������Ϊ����μӵ���Ա
            recipRequired.Type =
                (int)Outlook.OlMeetingRecipientType.olRequired;

            //��ѡ�������
            //Outlook.Recipient recipOptional =
            //    appt.Recipients.Add("Peter Allenspach");

            //recipOptional.Type =
            //    (int)Outlook.OlMeetingRecipientType.olOptional;

            //����Ļ�����Դ
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
