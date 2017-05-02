using System;
using System.Threading;
using System.Collections;
namespace ASPNETThread
{
	//������һ���ṹ
	public struct User
	{
		public string name;
		public DateTime lasttime;  
		public DateTime curtime;
		public string sessionid;
		public string iswhere;
	}
    
	//���������û���
	public class OnLineUser
	{
		private static ArrayList _alluser ;        //�����û�
        
		public ArrayList alluser
		{
			get{return _alluser;}
			set{_alluser=value;}
		}
        
		public OnLineUser()        //���캯��
		{
			if(_alluser==null)
			{
				_alluser=new ArrayList();    
			}
		}

		//����˵��������ǰ�û����������б�
		//������û������ݵ�ǰ��Ȼ�������б��У�����ʱ�Ȳ��ø��û���½,��ʾ�û�����
		public bool  AddUserToOnLine(User user)
		{
			//��Ҫ���ж��û��Ƿ��Ѿ����û��б�����
			if(_alluser==null)
			{
				_alluser.Add(user);
				return (true);
			}
			else
			{
				for ( int i = 0 ; i < _alluser.Count ; i ++)
				{
					//ѭ���ж��û��Ƿ��Ѿ�����
					User tempuser = (User)_alluser[i] ;

					if(tempuser.sessionid.Equals(user.sessionid) && tempuser.name.Equals(user.name))
					{
						return(false);    //�û��Ѿ����ڣ���ֱ���˳�
					}
				}
				_alluser.Add(user);
				return (true);
			}
		}  
        
		//����˵��:�ж�ĳ�û��Ƿ�����
		//����ֵ��TRUE�������ߣ�FALSE����
		public  Boolean IsUserOnLine(string name)
		{
			//��Ҫ���ж��û��Ƿ��Ѿ����û��б�����
			if(_alluser==null)
			{
				return (false);
			}
			else
			{
				for ( int i = 0 ; i < _alluser.Count ; i ++)
				{
					//ѭ���ж��û��Ƿ��Ѿ�����
					User tempuser = (User)_alluser[i] ;
					if(tempuser.name.Equals(name))
					{
						return(true)    ;
					}
				}
				return (false);
			}
		}
        
		//����˵���������û�����ʱ��
		//����ֵ�����µ������û��б�
		public Boolean CheckUserOnLine(string name)
		{
			//��Ҫ���ж��û��Ƿ��Ѿ����û��б�����
			if(_alluser!=null)
			{
				for ( int i = 0 ; i < _alluser.Count ; i ++)
				{
					User  tempuser = (User)_alluser[i] ;
					//���жϵ�ǰ�û��Ƿ����Լ�
					if(tempuser.name.Equals(name))
					{
						//�����û�����ʱ��
						tempuser.curtime=DateTime.Now;
						alluser[i]=tempuser;
						return(true);
					}
				}
			}
			return(false);
		}
	}

	public class CheckOnline 
	{
		const int DELAY_TIMES = 5000 ;                //����ִ�е�ʱ����Ϊ5��
		const int DELAY_SECONDS=30;                    //���û�����ʱ������Ϊ30��
        
		private Thread thread ;                        //�����ڲ��߳�
		private static bool _flag=false;                    //����Ψһ��־
        
		public CheckOnline()
		{
			if (!_flag)
			{
				_flag= true;
				this.thread = new Thread(new ThreadStart(ThreadProc)) ;
				thread.Name = "online user" ;
				thread.Start() ;
			}
		}
        
        
		internal void ThreadProc()
		{
			while(true)        
			{
				OnLineUser temp=new OnLineUser();        //����һ���û�����
				for (int i=0 ;i< temp.alluser.Count;i++)
				{
					User tmpuser=(User)temp.alluser[i];
					if(tmpuser.curtime.AddSeconds(DELAY_SECONDS).CompareTo(DateTime.Now)<0)    
					{
						temp.alluser.RemoveAt(i);
					}
				}
				Thread.Sleep(DELAY_TIMES) ;
                
			}
		}
	}

}
