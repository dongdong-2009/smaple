using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// TimeParser 的摘要说明
/// </summary>
public class TimeParser
{
	public TimeParser()
	{
		//
		// TODO: 在此处添加构造函数逻辑
		//
	}
    /// <summary>
    /// 把秒转换成分钟
    /// </summary>
    /// <returns></returns>
    public static int SecondToMinute(int Second)
    {
        decimal mm = (decimal)((decimal)Second / (decimal)60);
        return Convert.ToInt32(Math.Ceiling(mm));
    }
}
