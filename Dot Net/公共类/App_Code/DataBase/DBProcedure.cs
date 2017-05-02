using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.SessionState;

	/// <summary>
	/// ͨ�õ����ݿ⴦���࣬ͨ��ado.net�����ݿ�����
	/// </summary>
	public class DBProcedure {
		// ��������Դ
	public static  SqlConnection con;
	public DBProcedure()
        {
        }
		/// <summary>
		/// ִ�д洢����
		/// </summary>
		/// <param name="procName">�洢���̵�����</param>
		/// <returns>���ش洢���̷���ֵ</returns>
        public static int RunProc(string procName)
        {
			SqlCommand cmd = CreateCommand(procName, null);
			cmd.ExecuteNonQuery();
            con.Close();
			return (int)cmd.Parameters["ReturnValue"].Value;
		}

		/// <summary>
		/// ִ�д洢����
		/// </summary>
		/// <param name="procName">�洢��������</param>
		/// <param name="prams">�洢�����������</param>
		/// <returns>���ش洢���̷���ֵ</returns>
        public static int RunProc(string procName, SqlParameter[] prams)
        {
			SqlCommand cmd = CreateCommand(procName, prams);
			cmd.ExecuteNonQuery();
            con.Close();
			return (int)cmd.Parameters["ReturnValue"].Value;
		}

		/// <summary>
		/// ִ�д洢����
		/// </summary>
		/// <param name="procName">�洢���̵�����</param>
		/// <param name="dataReader">���ش洢���̷���ֵ</param>
        public static void RunProc(string procName, out SqlDataReader dataReader)
        {
			SqlCommand cmd = CreateCommand(procName, null);
			dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
			//return (int)cmd.Parameters["ReturnValue"].Value;
		}

		/// <summary>
		/// ִ�д洢����
		/// </summary>
		/// <param name="procName">�洢���̵�����</param>
		/// <param name="prams">�洢�����������</param>
		/// <param name="dataReader">�洢�����������</param>
        public static void RunProc(string procName, SqlParameter[] prams, out SqlDataReader dataReader)
        {
			SqlCommand cmd = CreateCommand(procName, prams);
			dataReader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
			//return (int)cmd.Parameters["ReturnValue"].Value;
		}
		
		/// <summary>
		/// ����һ��SqlCommand�����Դ���ִ�д洢����
		/// </summary>
		/// <param name="procName">�洢���̵�����</param>
		/// <param name="prams">�洢�����������</param>
		/// <returns>����SqlCommand����</returns>
        private static SqlCommand CreateCommand(string procName, SqlParameter[] prams)
        {
			// ȷ�ϴ�����
			Open();

			
			SqlCommand cmd = new SqlCommand(procName, con);
			cmd.CommandType = CommandType.StoredProcedure;

			// ���ΰѲ�������洢����
			if (prams != null) {
				foreach (SqlParameter parameter in prams)
					cmd.Parameters.Add(parameter);
			}
			
			// ���뷵�ز���
			cmd.Parameters.Add(
				new SqlParameter("ReturnValue", SqlDbType.Int, 4,ParameterDirection.ReturnValue, false, 0, 0,				string.Empty, DataRowVersion.Default, null));
			return cmd;
		}

		/// <summary>
		/// �����ݿ�����.
		/// </summary>
        private static void Open()
        {
			// �����ݿ�����
			if (con == null) {
				con = new SqlConnection(ConfigurationSettings.AppSettings["ConnectionString"]);				
			}				
			if(con.State ==System.Data.ConnectionState.Closed)
				con.Open();

		}

		/// <summary>
		/// �ر����ݿ�����
		/// </summary>
        public static void Close()
        {
			if (con != null)
				con.Close();
		}

		/// <summary>
		/// �ͷ���Դ
		/// </summary>
        public static void Dispose()
        {
			// ȷ�������Ƿ��Ѿ��ر�
			if (con != null) {
				con.Dispose();
				con = null;
			}				
		}

		/// <summary>
		/// �����������
		/// </summary>
		/// <param name="ParamName">�洢��������</param>
		/// <param name="DbType">��������</param></param>
		/// <param name="Size">������С</param>
		/// <param name="Value">����ֵ</param>
		/// <returns>�µ� parameter ����</returns>
        public static SqlParameter MakeInParam(string ParamName, SqlDbType DbType, int Size, object Value)
        {
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Input, Value);
		}		

		/// <summary>
		/// ���뷵��ֵ����
		/// </summary>
		/// <param name="ParamName">�洢��������</param>
		/// <param name="DbType">��������</param>
		/// <param name="Size">������С</param>
		/// <returns>�µ� parameter ����</returns>
        public static SqlParameter MakeOutParam(string ParamName, SqlDbType DbType, int Size)
        {
			return MakeParam(ParamName, DbType, Size, ParameterDirection.Output, null);
		}		

		/// <summary>
		/// ���뷵��ֵ����
		/// </summary>
		/// <param name="ParamName">�洢��������</param>
		/// <param name="DbType">��������</param>
		/// <param name="Size">������С</param>
		/// <returns>�µ� parameter ����</returns>
        public static SqlParameter MakeReturnParam(string ParamName, SqlDbType DbType, int Size) 
		{
			return MakeParam(ParamName, DbType, Size, ParameterDirection.ReturnValue, null);
		}	
	
		/// <summary>
		/// ���ɴ洢���̲���
		/// </summary>
		/// <param name="ParamName">�洢��������</param>
		/// <param name="DbType">��������</param>
		/// <param name="Size">������С</param>
		/// <param name="Direction">��������</param>
		/// <param name="Value">����ֵ</param>
		/// <returns>�µ� parameter ����</returns>
		public static SqlParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size, ParameterDirection Direction, object Value) {
			SqlParameter param;

			if(Size > 0)
				param = new SqlParameter(ParamName, DbType, Size);
			else
				param = new SqlParameter(ParamName, DbType);

			param.Direction = Direction;
			if (!(Direction == ParameterDirection.Output && Value == null))
				param.Value = Value;

			return param;
		}
	}
