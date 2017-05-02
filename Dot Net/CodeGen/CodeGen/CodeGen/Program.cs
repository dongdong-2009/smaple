using System;
using System.Collections.Generic;
using System.Text;

namespace CodeGen
{
    class Program
    {
        const string path = @"C:\aaa";
        const string path1 = @"C:\bbb";
        static void Main(string[] args)
        {
            List<string> list = new List<string>();            
            
            //list.Add("FAQ");
            list.Add("Information");
            list.Add("Category");
            list.Add("Attachment");
            list.Add("T_Userinfo");
            list.Add("BrowseCount");
            //list.Add("OperationLog");

            //list.Add("InvestAnswer");
            //list.Add("InvestReply");
            //list.Add("InvestQuestion");
            //list.Add("Invest");

            Generator.GenerateProcOracle(list, path1);
            //Generator.GenerateCSFile(list, path, GenType.Entity);
            //Generator.GenerateCSFile(list, path, GenType.AbstractCommand);
            //Generator.GenerateCSFile(list, path, GenType.Bussiness);
            //Generator.GenerateCSFile(list, path, GenType.OracleCommand);
            //Generator.GenerateCSFile(list, path, GenType.Server);
            //Generator.GenerateCSFile(list, path, GenType.SqlServerCommand);
        }
    }
}
