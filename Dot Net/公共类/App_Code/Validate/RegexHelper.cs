using System.Globalization;
using System.Text.RegularExpressions;


    /// <summary>
    /// ������ʽ������
    /// </summary>
    public sealed class RegexHelper
    {
        /// <summary>
        /// �������'�ַ���
        /// </summary>
        public const string CLEAN_STRING = @"[']";

        /// <summary>
        /// ��֤�ַ����Ƿ�Ϊ�ַ�begin-end֮��
        /// </summary>
        public const string IS_VALID_BYTE = @"^[A-Za-z0-9]{#0#,#1#}$";

        /// <summary>
        /// ��֤�ַ����Ƿ�Ϊ������
        /// </summary>
        public const string IS_VALID_DATE =
            @"^2\d{3}-(?:0?[1-9]|1[0-2])-(?:0?[1-9]|[1-2]\d|3[0-1])(?:0?[1-9]|1\d|2[0-3]):(?:0?[1-9]|[1-5]\d):(?:0?[1-9]|[1-5]\d)$";

        /// <summary>
        /// ��֤�ַ����Ƿ�ΪС��
        /// </summary>
        public const string IS_VALID_DECIMAL = @"[0].\d{1,2}|[1]";

        /// <summary>
        /// ��֤�ַ����Ƿ�ΪEMAIL
        /// </summary>
        public const string IS_VALID_EMAIL =
            @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        /// <summary>
        /// ��֤�ַ����Ƿ�ΪIP
        /// </summary>
        public const string IS_VALID_IP =
            @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";

        /// <summary>
        /// ��֤�ַ����Ƿ�Ϊ��׺��
        /// </summary>
        public const string IS_VALID_POSTFIX = @"\.(?i:{0})$";

        /// <summary>
        /// ��֤�ַ����Ƿ�Ϊ�绰����
        /// </summary>
        public const string IS_VALID_TEL = @"(\d+-)?(\d{4}-?\d{7}|\d{3}-?\d{8}|^\d{7,8})(-\d+)?";

        /// <summary>
        /// ��֤�ַ����Ƿ�ΪURL
        /// </summary>
        public const string IS_VALID_URL = @"^[a-zA-z]+://(\\w+(-\\w+)*)(\\.(\\w+(-\\w+)*))*(\\?\\S*)?$";

        #region �滻�ַ���
        /// <summary>
        /// �滻�ַ���
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <param name="regex">������ʽ</param>
        /// <returns>�滻���ַ���</returns>
        public static string ReplaceInput(string input, string regex)
        {
            return Regex.Replace(input, regex, string.Empty);
        }

        /// <summary>
        /// �滻�ַ���
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <param name="regex">������ʽ</param>
        /// <param name="replace">�滻�ַ���</param>
        /// <returns>�滻���ַ���</returns>
        public static string ReplaceInput(string input, string regex, string replace)
        {
            return Regex.Replace(input, regex, replace);
        }

        #endregion

        #region ��֤�ַ���

        /// <summary>
        /// ��֤�ַ���
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <param name="regex">������ʽ</param>
        /// <returns>�Ƿ���֤ͨ��</returns>
        public static bool CheckInput(string input, string regex)
        {
            return Regex.IsMatch(input, regex);
        }

        #endregion

        #region ���÷���

        /// <summary>
        /// ��֤�ַ���
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <param name="regex">������ʽ</param>
        /// <param name="begin">��ʼ����</param>
        /// <param name="end">��β����</param>
        /// <returns>�Ƿ���֤ͨ��</returns>
        public static bool ValidByte(string input, string regex, int begin, int end)
        {
            bool ret = false;
            if (!string.IsNullOrEmpty(regex))
            {
                string rep = regex.Replace("#0#", begin.ToString(CultureInfo.InvariantCulture));
                rep = rep.Replace("#1#", end.ToString(CultureInfo.InvariantCulture));
                ret = CheckInput(input, rep);
            }
            return ret;
        }

        /// <summary>
        /// ��֤�ַ���
        /// </summary>
        /// <param name="input">�����ַ���</param>
        /// <param name="regex">������ʽ</param>
        /// <param name="fix">��׺��</param>
        /// <returns>�Ƿ���֤ͨ��</returns>
        public static bool ValidPostfix(string input, string regex, string fix)
        {
            string ret = string.Format(CultureInfo.InvariantCulture, regex, fix);
            return CheckInput(input, ret);
        }

        #endregion

        private RegexHelper()
        {
        }
    }
