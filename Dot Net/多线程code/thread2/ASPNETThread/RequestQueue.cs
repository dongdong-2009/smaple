using System;

namespace ASPNETThread
{
	public struct FileInfo
	{
		public string fName;
		//public int status;
	}

	public class RequestQueue
	{
		FileInfo[] m_Info;
		int head;
		int tail;
		int length;
		public RequestQueue()
		{
			head = tail = length =0;
		}
		public void empty()
		{
			head = tail = 0;
		}
		public Object getFile()
		{
			if ( head == tail )
				return 0;
			return m_Info[head];
		}
		public void remove()
		{
			head++;
			if( head>=length)
			{
				head =0;
			}
		}
		public int add(FileInfo Info)
		{
			int newTail = tail;
			newTail++;
			if( newTail >=length)
				newTail =  0;
			if( newTail == head )
				return 0;
			m_Info[tail].fName = Info.fName;
			tail = newTail;
			return 1;
		}
		public bool isEmpty()
		{
			int newTail = tail;
			newTail++;
			if( newTail >=length)
				newTail = 0;
			if( newTail==head )
				return false;
			else
				return true;
		}
		public void setSize(int size)
		{
			length = size;
			m_Info = new FileInfo[size];
			for(int i =0;i<size;i++)
				m_Info[i] = new FileInfo();
		}
		public int getSize()
		{
			return length;
		}
	}
}
