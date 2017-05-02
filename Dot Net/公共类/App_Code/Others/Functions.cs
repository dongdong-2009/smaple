using System;
using System.Text;
using System.Web.Security;


	/// <summary>
	/// functions
	/// </summary>
	public class Functions
	{
		public Functions()
		{
			//
			// TODO: Add constructor logic here
			//
		}

		/// <summary>
		/// HTML encode
		/// </summary>
		/// <param name="str">string</param>
		/// <returns></returns>
		public static string Encode(string str)
		{			
			str = str.Replace("&","&amp;");
			str = str.Replace("'","''");
			str = str.Replace("\"","&quot;");
			str = str.Replace(" ","&nbsp;");
			str = str.Replace("<","&lt;");
			str = str.Replace(">","&gt;");
			str = str.Replace("\n","<br>");
			return str;
		}


		/// <summary>
		/// decode
		/// </summary>
		/// <param name="str">string</param>
		/// <returns></returns>
		public static string Decode(string str)
		{			
			str = str.Replace("<br>","\n");
			str = str.Replace("&gt;",">");
			str = str.Replace("&lt;","<");
			str = str.Replace("&nbsp;"," ");
			str = str.Replace("&quot;","\"");
			return str;
		}


		/// <summary>
		/// encrypting string
		/// </summary>
		/// <returns></returns>
		public static string Encrypt(string Password)
		{
			string str = "";
			FormsAuthenticationTicket ticket = new System.Web.Security.FormsAuthenticationTicket(Password,true,2);
			str = FormsAuthentication.Encrypt(ticket).ToString();
			return str;
		}



		/// <summary>
		/// encrypting string
		/// </summary>
		/// <param name="Password">encrypting string</param>
		/// <param name="Format">format,0 is SHA1,1 is MD5</param>
		/// <returns></returns>
		public static string Encrypt(string Password,int Format)
		{
			string str = "";
			switch(Format)
			{
				case 0:
					str = FormsAuthentication.HashPasswordForStoringInConfigFile(Password,"SHA1");
					break;
				case 1:
					str = FormsAuthentication.HashPasswordForStoringInConfigFile(Password,"MD5");
					break;
			}
			return str;
		}



		/// <summary>
		/// decrypt string
		/// </summary>
		/// <param name="Passowrd">encrypted string</param>
		/// <returns></returns>
		public static string Decrypt(string Passowrd)
		{
			string str="";
			str= FormsAuthentication.Decrypt(Passowrd).Name.ToString();
			return str;
		}


		/// <summary>
		/// Encrypt Cookie
		/// </summary>
		/// <param name="str">Target cookie string</param>
		/// <returns></returns>
		public static string EncryptCookie(string strCookie,int type)
		{
			string str=En(strCookie,type);
			StringBuilder sb = new StringBuilder();
			foreach(char a in str)
			{		
				sb.Append(Convert.ToString(a,16).PadLeft(4,'0'));
			}
			return sb.ToString();
		}


		/// <summary>
		/// Decrypt Cookie
		/// </summary>
		/// <param name="str">Target cookie string</param>
		/// <returns></returns>
		public static string DecryptCookie(string strCookie,int type)
		{
			StringBuilder sb = new StringBuilder();
			string [] strarr = new String[255]; 
			int i,j,count=strCookie.Length/4;
			string strTmp;

			for(i=0;i<count;i++)
			{
				for(j=0;j<4;j++)
				{
					sb.Append(strCookie.Substring(i*4+j,1));
				}
				strarr[i] = sb.ToString();
				sb.Remove(0,sb.Length);
			}

			for(i=0;i<count;i++)
			{		
				strTmp = uint.Parse(strarr[i],System.Globalization.NumberStyles.AllowHexSpecifier).ToString("D");
				char ch = (char)uint.Parse(strTmp);
				sb.Append(ch);
			}

			return De(sb.ToString(),type);
		}


		private static string En(string strCookie,int type)
		{
			string str;
			if(type % 2==0)
			{
				str = Transform1(strCookie);
			}
			else
			{
				str = Transform3(strCookie);
			}
			
			str = Transform2(strCookie);
			return str;
		}

		private static string De(string strCookie,int type)
		{
			string str;
			if(type % 2==0)
			{
				str = DeTransform1(strCookie);
			}
			else
			{
				str = DeTransform3(strCookie);
			}

			str = Transform2(strCookie);	
			return str;
		}


		/// <summary>
		/// methods 1
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>decrypted string</returns>
		public static string DeTransform1(string str)
		{			
			int i=0;
			StringBuilder sb = new StringBuilder();
			
			foreach(char a in str)
			{						
				switch(i % 6)
				{
					case 0:
						sb.Append((char)(a-1));
						break;
					case 1:
						sb.Append((char)(a-5));
						break;
					case 2:
						sb.Append((char)(a-7));
						break;
					case 3:
						sb.Append((char)(a-2));
						break;
					case 4:
						sb.Append((char)(a-4));
						break;
					case 5:
						sb.Append((char)(a-9));
						break;
				}
				i++;
			}

			return sb.ToString();
		}



		/// <summary>
		/// method1
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>encrypted string</returns>
		public static string Transform1(string str)
		{			
			int i=0;
			StringBuilder sb = new StringBuilder();
			
			foreach(char a in str)
			{						
				switch(i % 6)
				{
					case 0:
						sb.Append((char)(a+1));
						break;
					case 1:
						sb.Append((char)(a+5));
						break;
					case 2:
						sb.Append((char)(a+7));
						break;
					case 3:
						sb.Append((char)(a+2));
						break;
					case 4:
						sb.Append((char)(a+4));
						break;
					case 5:
						sb.Append((char)(a+9));
						break;
				}
				i++;
			}

			return sb.ToString();
		}

		/// <summary>
		/// method1
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>encrypted string</returns>
		public static string Transform2(string str)
		{
			uint j=0;
			StringBuilder sb = new StringBuilder();
			
			str=Reverse(str);
			foreach(char a in str)
			{	
				j=a;		
				if(j>255)
				{
					j=(uint)((a>>8) + ((a&0x0ff)<<8));
				}
				else
				{					
					j=(uint)((a>>4) + ((a&0x0f)<<4));
				}				
				sb.Append((char)j);
			}

			return sb.ToString();
		}



		/// <summary>
		/// methods 1
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>decrypted string</returns>
		public static string DeTransform3(string str)
		{			
			int i=0;
			StringBuilder sb = new StringBuilder();
			
			foreach(char a in str)
			{						
				switch(i % 6)
				{
					case 0:
						sb.Append((char)(a-3));
						break;
					case 1:
						sb.Append((char)(a-6));
						break;
					case 2:
						sb.Append((char)(a-8));
						break;
					case 3:
						sb.Append((char)(a-7));
						break;
					case 4:
						sb.Append((char)(a-5));
						break;
					case 5:
						sb.Append((char)(a-2));
						break;
				}
				i++;
			}

			return sb.ToString();
		}



		/// <summary>
		/// method1
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>encrypted string</returns>
		public static string Transform3(string str)
		{			
			int i=0;
			StringBuilder sb = new StringBuilder();
			
			foreach(char a in str)
			{						
				switch(i % 6)
				{
					case 0:
						sb.Append((char)(a+3));
						break;
					case 1:
						sb.Append((char)(a+6));
						break;
					case 2:
						sb.Append((char)(a+8));
						break;
					case 3:
						sb.Append((char)(a+7));
						break;
					case 4:
						sb.Append((char)(a+5));
						break;
					case 5:
						sb.Append((char)(a+2));
						break;
				}
				i++;
			}

			return sb.ToString();
		}



		/// <summary>
		/// reverse
		/// </summary>
		/// <param name="str">string</param>
		/// <returns>reversed string</returns>
		public static string Reverse(string str)
		{
			int i;
			StringBuilder sb = new StringBuilder();

			for(i=str.Length-1;i>=0;i--)
			{
				sb.Append(str[i]);
			}

			return sb.ToString();
		}

		/// <summary>
		/// 用于截断字符串
		/// </summary>
		public static string Cut(string sOrig, int iLen)
		{
			StringBuilder sbTemp = new StringBuilder();
			char[] acTemp = sOrig.ToCharArray();
			foreach(char cTemp in acTemp)
			{
				if(iLen<0)
					break;
				if((int)cTemp>255)
					iLen -= 2;
				else
					iLen --;
				sbTemp.Append(cTemp);
			}
			if(iLen>0)
				return sbTemp.ToString();
			else
				return sbTemp.ToString()+"...";
		}

		/// <summary>
		/// 返回字符串的字节长度，如中文字符串每个字符占2个长度
		/// </summary>
		public static int LenB(string sOrig)
		{
			int iLenB = 0;
			char[] acTemp;
			acTemp = sOrig.ToCharArray();
			foreach(char cTemp in acTemp)
				if((int)cTemp>255)
					iLenB += 2;
				else
					iLenB ++;
			return iLenB;
		}
	}

