using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShiftNotificationClass;
using LeaRun.DataAccess;
using LeaRun.Utilities;
using System.Configuration;

namespace ShiftNotificationConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            DbHelper.DbType = (DatabaseType)Enum.Parse(typeof(DatabaseType), ConfigHelper.AppSettings("ComponentDbType"), true);

            ShiftNotification sc = new ShiftNotification();

           Console.WriteLine("成型廠");
           sc.ShiftNotificationL5Attachment("9ec70487-04fa-4db0-b94f-a56ae33f5f0b");

            Console.WriteLine("塗裝廠");
           sc.ShiftNotificationL5Attachment("9e47fd67-c49d-484a-af95-99dbcae53926");

            Console.WriteLine("組裝廠");
            sc.ShiftNotificationL5Attachment("aee13547-83bb-4ba2-bf3c-015ff05e200b");

            Console.WriteLine("運籌");
           sc.ShiftNotificationL5Attachment("e947bc3f-6746-459c-8dfe-f598c99348a3");

            Console.WriteLine("沖壓廠");
            sc.ShiftNotificationL5Attachment("d3e561bb-1ace-41d4-9b59-cd838793d91b");

            Console.WriteLine("EMD");
            sc.ShiftNotificationL6Attachment("2a3eee8c-9f84-4b73-8382-bc127e96542c");


        }
    }

    
}
