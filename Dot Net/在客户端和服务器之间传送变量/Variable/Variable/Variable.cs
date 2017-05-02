using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.Xml;
using System.Data;

namespace LUCC
{
	using Properties;

	[DefaultProperty("Text")]
	[ToolboxData("<{0}:Variable runat=server></{0}:Variable>")]
	public class Variable : Control
	{
		static string func = "function(){{refreshVariableXML('{0}_XML',{1})}}";
		object _value = null;

		[Browsable(false)]
		[DefaultValue("")]
		public object Value
		{
			get
			{
				return _value;
			}
			set
			{
				_value = value;
			}
		}

		public string ValueJS
		{
			get { return GenerateObjectScript(this.ID, Value); }
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			string xml = Page.Request.Params[this.ClientID + "_XML"];
			if (xml != null)
			{
				Value = RenderVariable(HttpUtility.UrlDecode(xml));
			}
			this.Page.ClientScript.RegisterClientScriptBlock(
				typeof(string),
				"Variable_JavaScript",
				Resources.Variable_Script,
				true
			);
			this.Page.ClientScript.RegisterStartupScript(
				 typeof(string),
				 string.Format("{0}_Startup_JavaScript", this.ClientID),
				 string.Format("AttachSubmitEvent('{0}_XML',{1})\r\n", this.ClientID, string.Format(func, this.ClientID, this.ID)),
				 true
			);
		}

		protected override void Render(HtmlTextWriter writer)
		{
			if (DesignMode)
			{
				writer.Write(this.ID);
			}
			else
			{
				writer.Write("\r\n<script language='javascript' type='text/javascript'>\r\n");
				if (Value == null)
					writer.Write("{0}=null", this.ID);
				else
				{
					string script = GenerateObjectScript(this.ID, Value);
					writer.Write(script);
				}
				writer.Write("\r\n");
				writer.Write("</script>\r\n");
				writer.Write("<input id='{0}_XML' name='{0}_XML' type='hidden' />\r\n", this.ClientID);
			}
		}

		string GenerateObjectScript(string name, Object value)
		{
			StringBuilder scriptBuilder = new StringBuilder();
			GenerateObjectScript(scriptBuilder, name, value, "");
			scriptBuilder.Append("\r\n");
			return scriptBuilder.ToString();
		}

		void GenerateObjectScript(StringBuilder scriptBuilder, string name, Object objValue, string indent)
		{
			if (!string.IsNullOrEmpty(name)) scriptBuilder.AppendFormat("{1}{0}=", name, indent);

			if (objValue == null)
			{
				scriptBuilder.Append("null");
				return;
			}

			Type type = objValue.GetType();
			if (objValue is IList)
			{
				IList list = objValue as IList;
				scriptBuilder.AppendFormat("new Array(");
				if (list.Count > 0)
				{
					scriptBuilder.AppendFormat("\r\n");
					scriptBuilder.AppendFormat(indent + "\t");
					GenerateObjectScript(scriptBuilder, "", list[0], indent + "\t");
					for (int i = 1; i < list.Count; i++)
					{
						scriptBuilder.AppendFormat(",\r\n");
						scriptBuilder.AppendFormat(indent + "\t");
						GenerateObjectScript(scriptBuilder, "", list[i], indent + "\t");
					}
				}
				scriptBuilder.Append("\r\n");
				scriptBuilder.Append(indent);
				scriptBuilder.Append(")");
			}
			else if (objValue is IDictionary)
			{
				int count = 0;
				scriptBuilder.Append("{");
				foreach (DictionaryEntry ent in objValue as IDictionary)
				{
					if (count > 0) scriptBuilder.AppendFormat(",");
					scriptBuilder.Append("\r\n");
					scriptBuilder.Append(indent);
					scriptBuilder.Append("\t'");
					scriptBuilder.Append(ent.Key);
					scriptBuilder.Append("':");
					GenerateObjectScript(scriptBuilder, "", ent.Value, indent + "\t");
					count++;
				}
				scriptBuilder.Append("\r\n" + indent + "}");
			}
			else if (type == typeof(DateTime))
			{
				DateTime val = (DateTime)objValue;
				scriptBuilder.AppendFormat("new Date({0},{1},{2},{3},{4},{5})", val.Year, val.Month - 1, val.Day, val.Hour, val.Minute, val.Second);
			}
			else if (type == typeof(DataTable))
			{
				DataTable val = objValue as DataTable;

				scriptBuilder.AppendFormat("new DataTable(\r\n{0}\tnew Array(", indent);
				for (int i = 0; i < val.Rows.Count; i++)
				{
					if (i > 0) scriptBuilder.Append(",");
					scriptBuilder.AppendFormat("\r\n\t\t{0}{{", indent);
					for (int j = 0; j < val.Columns.Count; j++)
					{
						if (j > 0) scriptBuilder.Append(",");
						scriptBuilder.AppendFormat("\r\n{0}\t\t\t'{1}':", indent, val.Columns[j].ColumnName);
						GenerateObjectScript(scriptBuilder, "", val.Rows[i][j], indent + "\t\t\t");
					}
					scriptBuilder.AppendFormat("\r\n{0}\t\t}}", indent);
				}
				scriptBuilder.AppendFormat("\r\n{0}\t)", indent);
				scriptBuilder.AppendFormat(",\r\n{0}\tnew Array(", indent);
				for (int i = 0; i < val.Columns.Count; i++)
				{
					if (i > 0) scriptBuilder.Append(",");
					scriptBuilder.Append("'");
					scriptBuilder.Append(val.Columns[i].ColumnName);
					scriptBuilder.Append("'");
				}
				scriptBuilder.Append(")");
				scriptBuilder.AppendFormat(",\r\n{0}\t'{1}'", indent, val.TableName);
				scriptBuilder.AppendFormat("\r\n{0})", indent);
			}
			else
			{
				scriptBuilder.AppendFormat("'{0}'", objValue.ToString());
			}
		}

		object RenderVariable(string xml)
		{
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(xml);
			return RenderVariable(doc.FirstChild as XmlElement);
		}

		object RenderVariable(XmlElement xmlElem)
		{
			switch (xmlElem.Name)
			{
			case "O":
				{
					Hashtable val = new Hashtable();
					foreach (XmlElement subElem in xmlElem.ChildNodes)
					{
						val.Add(subElem.GetAttribute("K"), RenderVariable(subElem));
					}
					return val;
				}
			case "A":
				{
					Object[] val = new object[int.Parse(xmlElem.GetAttribute("L"))];
					int i = 0;
					foreach (XmlElement subElem in xmlElem.ChildNodes)
					{
						val[i] = RenderVariable(subElem);
						i++;
					}
					return val;
				}
			case "N":
				{
					Double val = Double.Parse(xmlElem.GetAttribute("V"));
					return val;
				}
			case "S":
				{
					string val = xmlElem.GetAttribute("V");
					return val;
				}
			case "D":
				{
					return DateTime.ParseExact(xmlElem.GetAttribute("V"), "yyyy-M-d H:m:s", null);
				}
			case "T":
				{
					DataTable dt = new DataTable();
					dt.TableName = xmlElem.GetAttribute("N");
					foreach (string c in xmlElem.GetAttribute("C").Split(','))
					{
						dt.Columns.Add(c);
					}
					foreach (XmlElement rowElem in xmlElem.ChildNodes)
					{
						DataRow newRow = dt.NewRow();
						foreach (XmlElement tdElem in rowElem.ChildNodes)
						{
							newRow[tdElem.GetAttribute("K")] = RenderVariable(tdElem);
						}
						dt.Rows.Add(newRow);
					}
					return dt;
				}
			case "NULL":
				{
					return null;
				}
			default:
				return null;
			}
		}
	}
}
