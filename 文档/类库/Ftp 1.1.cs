using System;
using System.Net;
using System.IO;
using System.Text;
using System.Net.Sockets;
using System.Web;


namespace aaa
{
    public class FTPClient
    {
        #region ���캯��
        /// <summary>
        /// ȱʡ���캯��
        /// </summary>
        public FTPClient()
        {
            strRemoteHost = "";
            strRemotePath = "";
            strRemoteUser = "";
            strRemotePass = "";
            strRemotePort = 21;
            bConnected = false;
        }

        /// <summary>
        /// ���캯��
        /// </summary>
        /// <param name="remoteHost"></param>
        /// <param name="remotePath"></param>
        /// <param name="remoteUser"></param>
        /// <param name="remotePass"></param>
        /// <param name="remotePort"></param>
        public FTPClient(string remoteHost, string remotePath, string remoteUser, string remotePass, int remotePort)
        {
            strRemoteHost = remoteHost;
            strRemotePath = remotePath;
            strRemoteUser = remoteUser;
            strRemotePass = remotePass;
            strRemotePort = remotePort;
            Connect();
        }
        #endregion

        #region ��½
        /// <summary>
        /// FTP������IP��ַ
        /// </summary>
        private string strRemoteHost;
        public string RemoteHost
        {
            get
            {
                return strRemoteHost;
            }
            set
            {
                strRemoteHost = value;
            }
        }
        /// <summary>
        /// FTP�������˿�
        /// </summary>
        private int strRemotePort;
        public int RemotePort
        {
            get
            {
                return strRemotePort;
            }
            set
            {
                strRemotePort = value;
            }
        }
        /// <summary>
        /// ��ǰ������Ŀ¼
        /// </summary>
        private string strRemotePath;
        public string RemotePath
        {
            get
            {
                return strRemotePath;
            }
            set
            {
                strRemotePath = value;
            }
        }
        /// <summary>
        /// ��¼�û��˺�
        /// </summary>
        private string strRemoteUser;
        public string RemoteUser
        {
            set
            {
                strRemoteUser = value;
            }
        }
        /// <summary>
        /// �û���¼����
        /// </summary>
        private string strRemotePass;
        public string RemotePass
        {
            set
            {
                strRemotePass = value;
            }
        }

        /// <summary>
        /// �Ƿ��¼
        /// </summary>
        private Boolean bConnected;
        public bool Connected
        {
            get
            {
                return bConnected;
            }
        }
        #endregion

        #region ��/�ر�����
        /// <summary>
        /// ��������
        /// </summary>
        public void Connect()
        {
            socketControl = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(RemoteHost), strRemotePort);
            // ����
            try
            {
                socketControl.Connect(ep);
            }
            catch (Exception)
            {
                throw new IOException("Couldn't connect to remote server");
            }

            // ��ȡӦ����
            ReadReply();
            if (iReplyCode != 220)
            {
                DisConnect();
                throw new IOException(strReply.Substring(4));
            }

            // ��½
            SendCommand("USER " + strRemoteUser);
            if (!(iReplyCode == 331 || iReplyCode == 230))
            {
                CloseSocketConnect();//�ر�����
                throw new IOException(strReply.Substring(4));
            }
            if (iReplyCode != 230)
            {
                SendCommand("PASS " + strRemotePass);
                if (!(iReplyCode == 230 || iReplyCode == 202))
                {
                    CloseSocketConnect();//�ر�����
                    throw new IOException(strReply.Substring(4));
                }
            }
            bConnected = true;

            // �л���Ŀ¼
            ChangeDirect(strRemotePath);
        }


        /// <summary>
        /// �ر�����
        /// </summary>
        public void DisConnect()
        {
            if (socketControl != null)
            {
                SendCommand("QUIT");
            }
            CloseSocketConnect();
        }

        #endregion

        #region ����ģʽ
        /// <summary>
        /// ����ģʽ:���������͡�ASCII����
        /// </summary>
        public enum TransferType { Binary, ASCII };

        /// <summary>
        /// ���ô���ģʽ
        /// </summary>
        /// <param name="ttType">����ģʽ</param>
        public void SetTransferType(TransferType ttType)
        {
            if (ttType == TransferType.Binary)
            {
                SendCommand("TYPE I");//binary���ʹ���
            }
            else
            {
                SendCommand("TYPE A");//ASCII���ʹ���
            }
            if (iReplyCode != 200)
            {
                throw new IOException(strReply.Substring(4));
            }
            else
            {
                trType = ttType;
            }
        }


        /// <summary>
        /// ��ô���ģʽ
        /// </summary>
        /// <returns>����ģʽ</returns>
        public TransferType GetTransferType()
        {
            return trType;
        }

        #endregion

        #region �ļ�����
        /// <summary>
        /// ����ļ�(��)�б�
        /// </summary>
        /// <param name="strMask">�ļ�����ƥ���ַ���</param>
        /// <returns></returns>
        public string[] GetList(string strMask)
        {
            // ��������
            if (!bConnected)
            {
                Connect();
            }

            //���������������ӵ�socket
            Socket socketData = CreateDataSocket();

            //��������
            SendCommand("NLST " + strMask);

            //����Ӧ�����
            if (!(iReplyCode == 150 || iReplyCode == 125 || iReplyCode == 226))
            {
                throw new IOException(strReply.Substring(4));
            }

            //��ý��
            strMsg = "";
            while (true)
            {
                int iBytes = socketData.Receive(buffer, buffer.Length, 0);
                strMsg += ASCII.GetString(buffer, 0, iBytes);
                if (iBytes < buffer.Length)
                {
                    break;
                }
            }
            char[] seperator = { '\n' };
            string[] strsFileList = strMsg.Split(seperator);
            socketData.Close();//����socket�ر�ʱҲ���з�����
            if (iReplyCode != 226)
            {
                ReadReply();
                if (iReplyCode != 226)
                {
                    throw new IOException(strReply.Substring(4));
                }
            }
            return strsFileList;
        }

        /// <summary>
        /// ����ļ�(��)�б�
        /// </summary>
        /// <returns>�ļ�����ƥ���ַ���</returns>
        public string[] GetList()
        {
            return GetList(string.Empty);
        }

        /// <summary>
        /// ��ȡ�ļ���С
        /// </summary>
        /// <param name="strFileName">�ļ���</param>
        /// <returns>�ļ���С</returns>
        private long GetFileSize(string strFileName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("SIZE " + Path.GetFileName(strFileName));
            long lSize = 0;
            if (iReplyCode == 213)
            {
                lSize = Int64.Parse(strReply.Substring(4));
            }
            else
            {
                throw new IOException(strReply.Substring(4));
            }
            return lSize;
        }


        /// <summary>
        /// ɾ���ļ�
        /// </summary>
        /// <param name="strFileName">��ɾ���ļ���</param>
        public void DeleteFile(string strFileName)
        {
            if (strFileName == string.Empty)
            {
                return;
            }
            if (!bConnected)
            {
                Connect();
            }

            if (!ExsistFloderOrFile(strFileName))
            {
                return;
            }

            SendCommand("DELE " + strFileName);
            if (iReplyCode != 250)
            {
                throw new IOException(strReply.Substring(4));
            }
        }




        /// <summary>
        /// �������ļ�(��)(������ļ����������ļ�����,�����������ļ�)
        /// </summary>
        /// <param name="strOldName">���ļ���</param>
        /// <param name="strNewName">���ļ���</param>
        public void Rename(string strOldName, string strNewName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SendCommand("RNFR " + strOldName);
            if (iReplyCode != 350)
            {
                throw new IOException(strReply.Substring(4));
            }
            //  ������ļ�����ԭ���ļ�����,������ԭ���ļ�
            SendCommand("RNTO " + strNewName);
            if (iReplyCode != 250)
            {
                throw new IOException(strReply.Substring(4));
            }
        }
        #endregion

        #region �ϴ�������
        /// <summary>
        /// ����һ���ļ�
        /// </summary>
        /// <param name="strFileNameMask">�ļ�����ƥ���ַ���</param>
        /// <param name="strFolder">����Ŀ¼(������\����)</param>
        public void Get(string strFileNameMask, string strFolder)
        {
            if (!bConnected)
            {
                Connect();
            }
            string[] strFiles = GetList(strFileNameMask);
            foreach (string strFile in strFiles)
            {
                if (!strFile.Equals(""))//һ����˵strFiles�����һ��Ԫ�ؿ����ǿ��ַ���
                {
                    Get(strFile, strFolder, strFile);
                }
            }
        }


        /// <summary>
        /// ����һ���ļ�
        /// </summary>
        /// <param name="strRemoteFileName">Ҫ���ص��ļ���</param>
        /// <param name="strFolder">����Ŀ¼(������\����)</param>
        /// <param name="strLocalFileName">�����ڱ���ʱ���ļ���</param>
        public void Get(string strRemoteFileName, string strFolder, string strLocalFileName)
        {
            if (!bConnected)
            {
                Connect();
            }
            SetTransferType(TransferType.Binary);
            if (strLocalFileName.Equals(""))
            {
                strLocalFileName = strRemoteFileName;
            }
            if (!File.Exists(strLocalFileName))
            {
                Stream st = File.Create(strLocalFileName);
                st.Close();
            }
            FileStream output = new
                FileStream(strFolder + "\\" + strLocalFileName, FileMode.Create);
            Socket socketData = CreateDataSocket();
            SendCommand("RETR " + strRemoteFileName);
            if (!(iReplyCode == 150 || iReplyCode == 125
                || iReplyCode == 226 || iReplyCode == 250))
            {
                throw new IOException(strReply.Substring(4));
            }
            while (true)
            {
                int iBytes = socketData.Receive(buffer, buffer.Length, 0);
                output.Write(buffer, 0, iBytes);
                if (iBytes <= 0)
                {
                    break;
                }
            }
            output.Close();
            if (socketData.Connected)
            {
                socketData.Close();
            }
            if (!(iReplyCode == 226 || iReplyCode == 250))
            {
                ReadReply();
                if (!(iReplyCode == 226 || iReplyCode == 250))
                {
                    throw new IOException(strReply.Substring(4));
                }
            }
        }

        /// <summary>
        /// �Ƿ�����ļ�(��)
        /// </summary>
        /// <param name="strName"></param>
        /// <returns></returns>
        public bool ExsistFloderOrFile(string strName)
        {
            string[] s = GetList();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] != string.Empty)
                {
                    if (strName == s[i].Replace("\r", ""))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// �ϴ��ļ� ����ļ�ͬ���򸲸ǡ�
        /// </summary>
        /// <param name="FileName">�ϴ�����ļ���</param>
        /// <param name="input">�ļ���</param>
        public void UpLoadFile(string FileName, Stream input)
        {
            if (!bConnected)
            {
                Connect();
            }
            Socket socketData = CreateDataSocket();

            SendCommand("STOR " + FileName);
            if (!(iReplyCode == 125 || iReplyCode == 150))
            {
                throw new IOException(strReply.Substring(4));
            }

            int iBytes = 0;
            decimal mBytes = 0;
            BinaryReader binread = new BinaryReader(input);
            while ((iBytes = binread.Read(buffer, 0, buffer.Length)) > 0)
            {
                socketData.Send(buffer, iBytes, 0);
                mBytes += buffer.Length;
                stats = mBytes / input.Length;
                //ǧ�ֱ�
                stats = stats * 1000;
                //��ǰ�ֽ�   
                buff_stats = mBytes;

                if (stats >= 1000)
                {
                    stats = 1000;
                }
                if (stats < 0)
                {
                    stats = 0;
                }
            }

            //����
            stats = 1000;
            buff_stats = input.Length;

            input.Close();
            if (socketData.Connected)
            {
                socketData.Close();
            }
            if (!(iReplyCode == 226 || iReplyCode == 250))
            {
                ReadReply();
                if (!(iReplyCode == 226 || iReplyCode == 250))
                {
                    throw new IOException(strReply.Substring(4));
                }
            }
        }
        #endregion



        #region Ŀ¼����
        /// <summary>
        /// ����Ŀ¼
        /// </summary>
        /// <param name="strDirName">Ŀ¼��</param>
        public void CreateFloder(string strDirName)
        {
            if (!bConnected)
            {
                Connect();
            }

            if (ExsistFloderOrFile(strDirName))
            {
                return;
            }

            SendCommand("MKD " + strDirName);
            if (iReplyCode != 257)
            {
                throw new IOException(strReply.Substring(4));
            }
        }


        /// <summary>
        /// ɾ��Ŀ¼
        /// </summary>
        /// <param name="strDirName">Ŀ¼��</param>
        public void DeleteFloder(string strDirName)
        {
            if (!bConnected)
            {
                Connect();
            }

            if (!ExsistFloderOrFile(strDirName))
            {
                return;
            }

            SendCommand("RMD " + strDirName);
            if (iReplyCode != 250)
            {
                throw new IOException(strReply.Substring(4));
            }
        }


        /// <summary>
        /// �ı�Ŀ¼
        /// </summary>
        /// <param name="DirName">�µĹ���Ŀ¼��</param>
        public void ChangeDirect(string DirName)
        {
            if (DirName.Equals(".") || DirName.Equals(""))
            {
                return;
            }
            if (!bConnected)
            {
                Connect();
            }
            SendCommand(@"CWD \" + DirName);
            if (iReplyCode != 250)
            {
                throw new IOException(strReply.Substring(4));
            }
            this.strRemotePath = DirName;
        }

        #endregion

        #region �ڲ�����

        /// <summary>
        /// �������
        /// </summary>
        public decimal stats = 0;
        public decimal _stats
        {
            get { return stats; }
            set { stats = value; }
        }

        public decimal buff_stats = 0;
        public decimal _buff_stats
        {
            get { return buff_stats; }
            set { buff_stats = value; }
        }


        /// <summary>
        /// ���������ص�Ӧ����Ϣ(����Ӧ����)
        /// </summary>
        private string strMsg;
        /// <summary>
        /// ���������ص�Ӧ����Ϣ(����Ӧ����)
        /// </summary>
        private string strReply;
        /// <summary>
        /// ���������ص�Ӧ����
        /// </summary>
        private int iReplyCode;
        /// <summary>
        /// ���п������ӵ�socket
        /// </summary>
        private Socket socketControl;
        /// <summary>
        /// ����ģʽ
        /// </summary>
        private TransferType trType;
        /// <summary>
        /// ���պͷ������ݵĻ�����
        /// </summary>
        private static int BLOCK_SIZE = 512;
        Byte[] buffer = new Byte[BLOCK_SIZE];
        /// <summary>
        /// ���뷽ʽ
        /// </summary>
        Encoding ASCII = Encoding.UTF8;
        #endregion

        #region �ڲ�����
        /// <summary>
        /// ��һ��Ӧ���ַ�����¼��strReply��strMsg
        /// Ӧ�����¼��iReplyCode
        /// </summary>
        private void ReadReply()
        {
            strMsg = "";
            strReply = ReadLine();
            iReplyCode = Int32.Parse(strReply.Substring(0, 3));
        }

        /// <summary>
        /// ���������������ӵ�socket
        /// </summary>
        /// <returns>��������socket</returns>
        private Socket CreateDataSocket()
        {
            SendCommand("PASV");
            if (iReplyCode != 227)
            {
                throw new IOException(strReply.Substring(4));
            }
            int index1 = strReply.IndexOf('(');
            int index2 = strReply.IndexOf(')');
            string ipData =
                strReply.Substring(index1 + 1, index2 - index1 - 1);
            int[] parts = new int[6];
            int len = ipData.Length;
            int partCount = 0;
            string buf = "";
            for (int i = 0; i < len && partCount <= 6; i++)
            {
                char ch = Char.Parse(ipData.Substring(i, 1));
                if (Char.IsDigit(ch))
                    buf += ch;
                else if (ch != ',')
                {
                    throw new IOException("Malformed PASV strReply: " +
                        strReply);
                }
                if (ch == ',' || i + 1 == len)
                {
                    try
                    {
                        parts[partCount++] = Int32.Parse(buf);
                        buf = "";
                    }
                    catch (Exception)
                    {
                        throw new IOException("Malformed PASV strReply: " +
                            strReply);
                    }
                }
            }
            string ipAddress = parts[0] + "." + parts[1] + "." +
                parts[2] + "." + parts[3];
            int port = (parts[4] << 8) + parts[5];
            Socket s = new
                Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ep = new
                IPEndPoint(IPAddress.Parse(ipAddress), port);
            try
            {
                s.Connect(ep);
            }
            catch (Exception)
            {
                throw new IOException("Can't connect to remote server");
            }
            return s;
        }


        /// <summary>
        /// �ر�socket����(���ڵ�¼��ǰ)
        /// </summary>
        private void CloseSocketConnect()
        {
            if (socketControl != null)
            {
                socketControl.Close();
                socketControl = null;
            }
            bConnected = false;
        }

        /// <summary>
        /// ��ȡSocket���ص������ַ���
        /// </summary>
        /// <returns>����Ӧ������ַ�����</returns>
        private string ReadLine()
        {
            while (true)
            {
                int iBytes = socketControl.Receive(buffer, buffer.Length, 0);
                strMsg += ASCII.GetString(buffer, 0, iBytes);
                if (iBytes < buffer.Length)
                {
                    break;
                }
            }
            char[] seperator = { '\n' };
            string[] mess = strMsg.Split(seperator);
            if (strMsg.Length > 2)
            {
                strMsg = mess[mess.Length - 2];
                //seperator[0]��10,���з�����13��0��ɵ�,�ָ���10������û���ַ���,
                //��Ҳ�����Ϊ���ַ���������(Ҳ�����һ��)�ַ�������,
                //�������һ��mess��û�õĿ��ַ���
                //��Ϊʲô��ֱ��ȡmess[0],��Ϊֻ�����һ���ַ���Ӧ��������Ϣ֮���пո�
            }
            else
            {
                strMsg = mess[0];
            }
            if (!strMsg.Substring(3, 1).Equals(" "))//�����ַ�����ȷ������Ӧ����(��220��ͷ,�����һ�ո�,�ٽ��ʺ��ַ���)
            {
                return ReadLine();
            }
            return strMsg;
        }


        /// <summary>
        /// ���������ȡӦ��������һ��Ӧ���ַ���
        /// </summary>
        /// <param name="strCommand">����</param>
        private void SendCommand(String strCommand)
        {
            Byte[] cmdBytes =
                Encoding.Default.GetBytes((strCommand + "\r\n").ToCharArray());
            socketControl.Send(cmdBytes, cmdBytes.Length, 0);

            ReadReply();
        }

        #endregion

        #region ע��
        /*
		public void Put(string strFileName)
		{
			if(!bConnected)
			{
				Connect();
			}
			System.IO.FileInfo filei=new System.IO.FileInfo(strFileName);

			Socket socketData = CreateDataSocket();
			SendCommand("STOR "+Path.GetFileName(filei.FullName.GetHashCode().ToString()+filei.Extension.ToString()));
			if( !(iReplyCode == 125 || iReplyCode == 150))
			{
				throw new IOException(strReply.Substring(4));
			}
			FileStream input = new FileStream(strFileName,FileMode.Open);
			int iBytes = 0;
			decimal mBytes=0;
   
			while ((iBytes = input.Read(buffer,0,buffer.Length)) > 0)
			{
				socketData.Send(buffer, iBytes, 0);
				mBytes+=buffer.Length;
				stats=mBytes/filei.Length;
				//ǧ�ֱ�
				stats=stats*1000;
				//��ǰ�ֽ�   
				buff_stats=mBytes;

				if (stats>=1000)
				{      
					stats=1000;
				}
				if (stats<0)
				{      
					stats=0;
				}
			}

			//����
			stats=1000;
			buff_stats=filei.Length;

			input.Close();
			if (socketData.Connected)
			{
				socketData.Close();
			}
			if(!(iReplyCode == 226 || iReplyCode == 250))
			{
				ReadReply();
				if(!(iReplyCode == 226 || iReplyCode == 250))
				{
					throw new IOException(strReply.Substring(4));
				}
			}
		}         
         
         
		public void Put2(string newname, string strFileName)
		{
			if (!bConnected)
			{
				Connect();
			}
			System.IO.FileInfo filei = new System.IO.FileInfo(strFileName);
			Socket socketData = CreateDataSocket();

			SendCommand("STOR " + newname);
			if (!(iReplyCode == 125 || iReplyCode == 150))
			{
				throw new IOException(strReply.Substring(4));
			}
			FileStream input = new FileStream(strFileName, FileMode.Open);
			int iBytes = 0;
			decimal mBytes = 0;

			while ((iBytes = input.Read(buffer, 0, buffer.Length)) > 0)
			{
				socketData.Send(buffer, iBytes, 0);
				mBytes += buffer.Length;
				stats = mBytes / filei.Length;
				//ǧ�ֱ�
				stats = stats * 1000;
				//��ǰ�ֽ�   
				buff_stats = mBytes;

				if (stats >= 1000)
				{
					stats = 1000;
				}
				if (stats < 0)
				{
					stats = 0;
				}
			}

			//����
			stats = 1000;
			buff_stats = filei.Length;

			input.Close();
			if (socketData.Connected)
			{
				socketData.Close();
			}
			if (!(iReplyCode == 226 || iReplyCode == 250))
			{
				ReadReply();
				if (!(iReplyCode == 226 || iReplyCode == 250))
				{
					throw new IOException(strReply.Substring(4));
				}
			}
		}
		 * */
        #endregion
    }
}