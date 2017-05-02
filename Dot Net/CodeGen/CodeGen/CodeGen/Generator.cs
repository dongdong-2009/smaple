using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Data;
using System.Data.OracleClient;

namespace CodeGen
{
    public struct GenType
    { 
        public const string Entity = "Entity";
        public const string Server = "Server";
        public const string Bussiness = "Bussiness";
        public const string AbstractCommand = "Command";
        public const string SqlServerCommand = "SqlServerCommand";
        public const string OracleCommand = "OracleCommand";
    }

    public struct ProcType
    {
        public const string SelectBy = "SelectBy";
        public const string Update = "Update";
        public const string Delete = "Delete";
        public const string Insert = "Insert";
    }

    public sealed class Generator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="list">表名集合</param>
        /// <param name="path">生成后的文件存放路径</param>
        /// <param name="type">类型（entity、server等）</param>
        public static void GenerateCSFile(List<string> list, string path, string type)
        { 
            string ENTITYPATH = @"\template\"+type+"Template.txt";
            string TemplatePath = Environment.CurrentDirectory + ENTITYPATH;

            GenerateFolder(path, (type != GenType.AbstractCommand) ? type : "Abstract"+type);
            bool hasFile = File.Exists(TemplatePath);

            if (!hasFile)
            {
                throw new Exception("文件：" + TemplatePath +"不存在");
            }

            path = path + @"\" + ((type != GenType.AbstractCommand) ? type : "Abstract" + type);
            foreach (string s in list)
	        {
                string FileFullName = path +@"\"+s+type+".cs";
                string template = ReadFile(TemplatePath);
                template = template.Replace("<%TableName%>", s);
                template = template.Replace("<%Data%>", DateTime.Now.ToString("yyyy-MM-dd HH:mm"));
                #region sql
                string sql = "select"
                           + " column_name,"
                            + " data_type,  "
                            + " data_length,  "
                            + " nullable,  "
                            + " data_default,  "
                            + " low_value,  "
                            + " high_value, "
                            + " case when  "
                            + " (select   column_name    "
                            + " from   user_constraints   c, user_cons_columns   col   "
                            + " where   c.constraint_name=col.constraint_name   and   c.constraint_type='P'   "
                            + " and   c.table_name=upper('" + s + "')  "
                            + " and b.column_name in "
                            + " ( "
                             + " select   column_name    "
                             + " from   user_constraints   c, user_cons_columns   col    "
                             + " where   c.constraint_name=col.constraint_name   and   c.constraint_type='P'   "
                             + " and   c.table_name=upper('" + s + "')  "
                            + " )) =  "
                            + " ( "
                            + " select   column_name    "
                            + " from   user_constraints   c, user_cons_columns   col    "
                            + " where   c.constraint_name=col.constraint_name   and   c.constraint_type='P'   "
                            + " and   c.table_name=upper('" + s + "'))  "
                            + " THEN 'Y' "
                            + " ELSE 'N' "
                            + " end as key "
                            + " from all_tab_cols b "
                            + " where table_name = upper('" + s + "')"
                            + " and owner = '" + owner + "' ";
                #endregion
                DataTable dt = GetTable(sql);
                string fields = string.Empty;
                string id = string.Empty;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string column_name = dt.Rows[i]["COLUMN_NAME"].ToString();
                    if (dt.Rows[i]["KEY"].ToString() == "Y")
                    {
                        //added for override string IDName
                        template = template.Replace("<%ID%>", "\"" + column_name + "\"");

                    }
                    else
                    {
                        switch (dt.Rows[i]["DATA_TYPE"].ToString().ToUpper())
                        {
                            case "VARCHAR2":
                                {
                                    fields += Environment.NewLine + "       public string " + column_name.ToUpper() + " = string.Empty;";
                                    break;
                                }
                            case "NUMBER":
                                {
                                    fields += Environment.NewLine + "       public int " + column_name.ToUpper() +";";
                                    break;
                                }
                            case "DATE":
                                {
                                    fields += Environment.NewLine + "       public DateTime " + column_name.ToUpper() + ";";
                                    break;
                                }
                            case "LONG":
                                {
                                    fields += Environment.NewLine + "       public long " + column_name.ToUpper() + ";";
                                    break;
                                }
                            case "CLOB":
                                {
                                    fields += Environment.NewLine + "       public string " + column_name.ToUpper() + "= string.Empty;";
                                    break;
                                }
                            case "BLOB":
                                {
                                    fields += Environment.NewLine + "       public byte[] " + column_name.ToUpper() + ";";
                                    break;
                                }
                            default:
                                {
                                    throw new Exception("未知类型：" + dt.Rows[i]["DATA_TYPE"].ToString().ToUpper());
                                }

                        }
                    }
                }

                template = template.Replace("<%Fields%>", fields);
                WriteFile(template, FileFullName);
	        }            
        }

        private static void GenerateFolder(string path, string type)
        {
            path = path + @"\"+type;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private static string ReadFile(string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs,Encoding.GetEncoding("gb2312"));
            try
            {
                string s = sr.ReadToEnd();
                return s;
            }
            finally
            { 
                sr.Close();
                fs.Close();
            }           
        }

        private static void WriteFile(string content, string filepath)
        {
            FileStream fs = new FileStream(filepath, FileMode.Create, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs,Encoding.GetEncoding("gb2312"));
            try
            {
                sw.Write(content);
            }
            finally
            {
                sw.Close();
                fs.Close();
            }
        }


        private const string profix = "pm";
        private const string seq = "DFG_seq";
        private const string connectionstring = "UID=dfg;PWD=dfg;data source=pvpt";
        private const string owner = "dfg";
        private const string Cursor = "";
        private const string Package = "";
        /// <summary>
        /// Oracle
        /// </summary>
        /// <param name="list">表名集合</param>
        /// <param name="path">生成后的文件存放路径</param>
        public static void GenerateProcOracle(List<string> list, string path)
        {
            GenerateFolder(path, null);
            string template = @"\template\OracleInsert.txt";
            string TemplatePath = Environment.CurrentDirectory + template;
            for (int i = 0; i < list.Count; i++)
            {
                string InsertTemplatePath = Environment.CurrentDirectory + @"\template\OracleInsert.txt";
                string UpdateTemplatePath = Environment.CurrentDirectory + @"\template\OracleUpdate.txt";
                string DeleteTemplatePath = Environment.CurrentDirectory + @"\template\OracleDelete.txt";
                string SelectByTemplatePath = Environment.CurrentDirectory + @"\template\OracleSelectBy.txt";
                
                string InsertTemplate = ReadFile(InsertTemplatePath);
                string UpdateTemplate = ReadFile(UpdateTemplatePath);
                string DeleteTemplate = ReadFile(DeleteTemplatePath);
                string SelectByTemplate = ReadFile(SelectByTemplatePath);
                #region sql
                string sql = "select"
                           + " column_name,"
                            + " data_type,  "
                            + " data_length,  "
                            + " nullable,  "
                            + " data_default,  "
                            + " low_value,  "
                            + " high_value, "
                            + " case when  "
                            + " (select   column_name    "
                            + " from   user_constraints   c, user_cons_columns   col   "
                            + " where   c.constraint_name=col.constraint_name   and   c.constraint_type='P'   "
                            + " and   c.table_name=upper('" + list[i] + "')  "
                            + " and b.column_name in "
                            + " ( "
                             + " select   column_name    "
                             + " from   user_constraints   c, user_cons_columns   col    "
                             + " where   c.constraint_name=col.constraint_name   and   c.constraint_type='P'   "
                             + " and   c.table_name=upper('" + list[i] + "')  "
                            + " )) =  "
                            + " ( "
                            + " select   column_name    "
                            + " from   user_constraints   c, user_cons_columns   col    "
                            + " where   c.constraint_name=col.constraint_name   and   c.constraint_type='P'   "
                            + " and   c.table_name=upper('" + list[i] + "'))  "
                            + " THEN 'Y' "
                            + " ELSE 'N' "
                            + " end as key "
                            + " from all_tab_cols b "
                            + " where table_name = upper('" + list[i] + "')"
                            + " and upper(owner) = '" + owner.ToUpper() + "' ";
                #endregion

                DataTable dt = GetTable(sql);

                #region insert
                string insertparam = string.Empty;
                string insertsourcecolumns = string.Empty;
                string insertcolumns = string.Empty;
                string insertkeyparam = string.Empty;
                #endregion

                #region update
                string updateParam = string.Empty;
                string updatecolumns = string.Empty;
                string updatetiaojian = string.Empty;
                #endregion

                #region delete
                string deleteid = string.Empty;

                #endregion

                #region select
                string selectcolumns = string.Empty;
                string target = string.Empty;

                #endregion
                string InsertProc = string.Empty;
                string UpdateProc = string.Empty;
                string DeleteProc = string.Empty;
                string SelectProc = string.Empty;
                string AllProc = string.Empty;

                for (int k = 0; k < dt.Rows.Count; k++)
                {
                    string column_name = dt.Rows[k]["COLUMN_NAME"].ToString();
                    if (dt.Rows[k]["KEY"].ToString() == "Y")
                    {
                        #region insert
                        insertkeyparam = profix + column_name;
                        insertparam += profix + column_name + " out " + list[i] + "." + column_name+"%type,";
                        #endregion

                        #region update
                        updatetiaojian = column_name + "=" + profix + column_name;
                        #endregion

                        #region delete
                        deleteid = column_name;
                        #endregion
                    }
                    else
                    {
                        #region insert
                        insertcolumns += profix + column_name + ",";
                        insertparam +=  Environment.NewLine + profix + column_name + "  " + list[i].ToString() + "." + column_name + "%type,";
                        #endregion

                        #region update
                        updatecolumns += column_name + "=" + profix + column_name + ",";
                        #endregion
                    }
                    #region insert
                    insertsourcecolumns += column_name + ",";
                    #endregion

                    #region update
                    updateParam += Environment.NewLine + profix+ column_name+" " + list[i]+"."+column_name+"%type,";
                    #endregion

                    #region select
                    selectcolumns += column_name + ",";
                    #endregion

                    if (dt.Rows[k]["DATA_TYPE"].ToString().ToUpper() == "VARCHAR2")
                    {
                        target += Environment.NewLine + "Target :=Replace(upper(Target),upper('" + column_name+"'),'upper("+column_name+")');";
                    }

                }

                #region insert
                insertparam = DelLastChar(insertparam, ",");
                insertsourcecolumns = DelLastChar(insertsourcecolumns, ",");
                insertcolumns = DelLastChar(insertcolumns, ",");
                InsertProc = InsertTemplate.Replace("<%Param%>", insertparam).Replace("<%Columns%>", insertsourcecolumns).Replace("<%InsertColumns%>", insertcolumns).Replace("<%KeyParam%>", insertkeyparam);
                #endregion 

                #region update
                updateParam = DelLastChar(updateParam, ",");
                updatecolumns = DelLastChar(updatecolumns, ",");
                UpdateProc = UpdateTemplate.Replace("<%Param%>", updateParam).Replace("<%UpdateColumns%>", updatecolumns).Replace("<%Tiaojian%>", updatetiaojian);
                #endregion

                #region delete
                DeleteProc = DeleteTemplate.Replace("<%Id%>", deleteid);
                #endregion

                #region select
                selectcolumns = DelLastChar(selectcolumns, ",");
                SelectProc = SelectByTemplate.Replace("<%Columns%>", selectcolumns).Replace("<%Target%>", target);
                #endregion

                AllProc = InsertProc + Environment.NewLine + UpdateProc + Environment.NewLine + DeleteProc + Environment.NewLine + SelectProc;
                AllProc = AllProc.Replace("<%Seq%>", seq).Replace("<%TableName%>", list[i]).Replace("<%DateTime%>", DateTime.Now.ToString("yyyy-MM-dd HH:mm")).Replace("<%profix%>", profix).Replace("<%Package%>", Package).Replace("<%Cursor%>", Cursor);
                WriteFile(AllProc, path+@"\"+list[i]+".txt");
            }
        }


        private static DataTable GetTable(string sql)
        {
            OracleConnection con = new OracleConnection(connectionstring);
            OracleCommand cmd = new OracleCommand(sql, con);
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public static string DelLastChar(string s, string _char)
        {
            if (s.EndsWith(_char))
            {
                s = s.Substring(0, s.Length - 1);
            }
            return s;
        }
    }
}