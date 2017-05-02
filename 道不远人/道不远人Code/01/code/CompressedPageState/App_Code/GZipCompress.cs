using System;
using System.IO;
using System.IO.Compression;
using System.Web.UI;

/// <summary>
/// GZipCompress 的摘要说明
/// </summary>
public class GZipCompress
{
    //序列化工具，LosFormatter是页面默认的序列器
    private static LosFormatter _formatter = new LosFormatter();
    /// <summary>
    /// 解压并反序列化状态内容
    /// </summary>
    /// <param name="stateString">从客户端取回的页面状态字符串</param>
    /// <returns>还原后的页面状态Pair对象</returns>
    public static object Decompress(string stateString)
    {
        //先把取回的状态字符串转回压缩后的数组
        byte[] buffer = Convert.FromBase64String(stateString);
        //解压
        MemoryStream ms = new MemoryStream(buffer);
        GZipStream zipStream = new GZipStream(ms, CompressionMode.Decompress);
        MemoryStream msReader = new MemoryStream();
        buffer = new byte[0x1000];
        while (true)
        {
            int read = zipStream.Read(buffer, 0, buffer.Length);
            if (read <= 0)
            {
                break;
            }
            msReader.Write(buffer, 0, read);
        }
        zipStream.Close();
        ms.Close();
        msReader.Position = 0;
        buffer = msReader.ToArray();
        stateString = Convert.ToBase64String(buffer);
        //反序列化
        return _formatter.Deserialize(stateString);
    }
    /// <summary>
    /// 序列化并压缩状态内容
    /// </summary>
    /// <param name="state">页面状态</param>
    /// <returns>结果字符串</returns>
    public static string Compress(object state)
    {
        StringWriter writer = new StringWriter();
        //序列化状态
        _formatter.Serialize(writer, state);
        //取得序列化结果
        string stateString = writer.ToString();
        writer.Close();        
        //压缩序列化状态
        byte[] buffer = Convert.FromBase64String(stateString);
        MemoryStream ms = new MemoryStream();
        GZipStream zipStream = new GZipStream(ms, CompressionMode.Compress, true);
        zipStream.Write(buffer, 0, buffer.Length);
        zipStream.Close();
        buffer = new byte[ms.Length];
        ms.Position = 0;
        ms.Read(buffer, 0, buffer.Length);
        ms.Close();
        //将压缩结果转成Base64字符串,以便存到页面中
        stateString = Convert.ToBase64String(buffer);
        return stateString;
    }
}
