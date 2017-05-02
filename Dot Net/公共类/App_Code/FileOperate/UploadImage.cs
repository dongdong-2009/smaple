using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;

/// <summary>
/// UploadImage 的摘要说明
/// </summary>
public class UploadImage
{
    /// <summary>
    /// 上传图片文件
    /// </summary>
    /// <param name="flie">上传文件控件</param>
    /// <param name="path">上传文件路径 如 "ImgUpload/"</param>
    /// <param name="watermark">水印文件名</param>
    /// <param name="ThumbnailWidth">缩略图宽</param>
    /// <param name="ThumbnailHeight">缩略图高</param>
    /// <returns>上传结果信息</returns>
    public static string Upload(FileUpload upflie, string path, string watermark, int ThumbnailWidth, int ThumbnailHeight)
    {
        string outTxt = "";                                               // 上传结果信息
        if (upflie.HasFile)
        {
            string fileContentType = upflie.PostedFile.ContentType;
            if (fileContentType == "image/bmp" || fileContentType == "image/gif" || fileContentType == "image/pjpeg")
            {
                string name = upflie.PostedFile.FileName;                  // 客户端文件路径

                //生成随机数
                Random oRandom = new Random();
                string oStringRandom = oRandom.Next(9999).ToString();

                //格式化日期作为文件名
                DateTime oDateTime = new DateTime();
                oDateTime = DateTime.Now;
                string oStringTime = oDateTime.ToString();
                oStringTime = oStringTime.Replace("-", null);
                oStringTime = oStringTime.Replace(" ", null);
                oStringTime = oStringTime.Replace(":", null);

                //以日期做为存放图片的目录
                string pDateTime = oDateTime.Year.ToString() + oDateTime.Month.ToString() + oDateTime.Day.ToString();

                //如果指定目录不存在,将建立新的文件夹
                string oSavePath = path + pDateTime + "\\";
                if (!Directory.Exists(oSavePath))
                {
                    Directory.CreateDirectory(oSavePath);
                }

                FileInfo file = new FileInfo(name);
                string fileName = file.Name;                                    // 文件名称
                string fileName_s = "c_" + file.Name;                           // 缩略图文件名称
                string fileName_sy = "text_" + file.Name;                         // 水印图文件名称（文字）
                string fileName_syp = "water_" + file.Name;                     // 水印图文件名称（图片）
                string webFilePath = oSavePath + oStringRandom + fileName;        // 服务器端文件路径
                string webFilePath_s = oSavePath + oStringRandom + fileName_s;　　// 服务器端缩略图路径
                string webFilePath_sy = oSavePath + oStringRandom + fileName_sy;　// 服务器端带水印图路径(文字)
                string webFilePath_syp = oSavePath + oStringRandom + fileName_syp;　// 服务器端带水印图路径(图片)
                string webFilePath_sypf = path + watermark;　// 服务器端水印图路径(图片)

                if (!File.Exists(webFilePath))
                {
                    try
                    {
                        upflie.SaveAs(webFilePath);                                // 使用 SaveAs 方法保存文件
                        AddWater(webFilePath, webFilePath_sy);
                        AddWaterPic(webFilePath, webFilePath_syp, webFilePath_sypf);
                        MakeThumbnail(webFilePath, webFilePath_s, ThumbnailWidth, ThumbnailHeight, "Cut");     // 生成缩略图方法
                        //outTxt = "提示：文件“" + fileName + "”成功上传，并生成“" + fileName_s + "”缩略图，文件类型为：" + upflie.PostedFile.ContentType + "，文件大小为：" + upflie.PostedFile.ContentLength + "B";
                        outTxt = webFilePath_s;
                    }
                    catch (Exception ex)
                    {
                        outTxt = "提示：文件上传失败，失败原因：" + ex.Message;
                    }
                }
                else
                {
                    outTxt = "提示：文件已经存在，请重命名后上传";
                }
            }
            else
            {
                outTxt = "提示：文件类型不符";
            }
        }
        return outTxt;
    }

    /// <summary>
    /// 生成缩略图
    /// </summary>
    /// <param name="originalImagePath">源图路径（物理路径）</param>
    /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
    /// <param name="width">缩略图宽度</param>
    /// <param name="height">缩略图高度</param>
    /// <param name="mode">生成缩略图的方式</param>    
    public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
    {
        System.Drawing.Image originalImage = System.Drawing.Image.FromFile(originalImagePath);

        int towidth = width;
        int toheight = height;

        int x = 0;
        int y = 0;
        int ow = originalImage.Width;
        int oh = originalImage.Height;

        switch (mode)
        {
            case "HW"://指定高宽缩放（可能变形）                
                break;
            case "W"://指定宽，高按比例                    
                toheight = originalImage.Height * width / originalImage.Width;
                break;
            case "H"://指定高，宽按比例
                towidth = originalImage.Width * height / originalImage.Height;
                break;
            case "Cut"://指定高宽裁减（不变形）                
                if ((double)originalImage.Width / (double)originalImage.Height > (double)towidth / (double)toheight)
                {
                    oh = originalImage.Height;
                    ow = originalImage.Height * towidth / toheight;
                    y = 0;
                    x = (originalImage.Width - ow) / 2;
                }
                else
                {
                    ow = originalImage.Width;
                    oh = originalImage.Width * height / towidth;
                    x = 0;
                    y = (originalImage.Height - oh) / 2;
                }
                break;
            default:
                break;
        }

        //新建一个bmp图片
        System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

        //新建一个画板
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);

        //设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

        //设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

        //清空画布并以透明背景色填充
        g.Clear(System.Drawing.Color.Transparent);

        //在指定位置并且按指定大小绘制原图片的指定部分
        g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
            new System.Drawing.Rectangle(x, y, ow, oh),
            System.Drawing.GraphicsUnit.Pixel);

        try
        {
            //以jpg格式保存缩略图
            bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
            originalImage.Dispose();
            bitmap.Dispose();
            g.Dispose();
        }
    }

    /// <summary>
    /// 在图片上增加文字水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_sy">生成的带文字水印的图片路径</param>
    public static void AddWater(string Path, string Path_sy)
    {
        string addText = "conjure.cn";
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(image, 0, 0, image.Width, image.Height);
        System.Drawing.Font f = new System.Drawing.Font("Verdana", 14);
        System.Drawing.Brush b = new System.Drawing.SolidBrush(System.Drawing.Color.Green);

        g.DrawString(addText, f, b, 35, 35);
        g.Dispose();

        image.Save(Path_sy);
        image.Dispose();
    }

    /// <summary>
    /// 在图片上生成图片水印
    /// </summary>
    /// <param name="Path">原服务器图片路径</param>
    /// <param name="Path_syp">生成的带图片水印的图片路径</param>
    /// <param name="Path_sypf">水印图片路径</param>
    public static void AddWaterPic(string Path, string Path_syp, string Path_sypf)
    {
        System.Drawing.Image image = System.Drawing.Image.FromFile(Path);
        System.Drawing.Image copyImage = System.Drawing.Image.FromFile(Path_sypf);
        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(image);
        g.DrawImage(copyImage, new System.Drawing.Rectangle(image.Width - copyImage.Width, image.Height - copyImage.Height, copyImage.Width, copyImage.Height), 0, 0, copyImage.Width, copyImage.Height, System.Drawing.GraphicsUnit.Pixel);
        g.Dispose();

        image.Save(Path_syp);
        image.Dispose();
    }

    /// <summary>
    /// 自动上传文本中的图片
    /// </summary>
    /// <param name="content">文本内容</param>
    /// <param name="path">上传路径</param>
    /// <returns>上传结果信息</returns>
    public static string AutoUpload(string content, string path)
    {
        //自动保存远程图片
        WebClient client = new WebClient();
        //备用Reg:<img.*?src=([\"\'])(http:\/\/.+\.(jpg|gif|bmp|bnp))\1.*?>
        Regex reg = new Regex("IMG[^>]*?src\\s*=\\s*(?:\"(?<1>[^\"]*)\"|'(?<1>[^\']*)')", RegexOptions.IgnoreCase);
        MatchCollection m = reg.Matches(content);

        foreach (Match math in m)
        {
            string imgUrl = math.Groups[1].Value;

            //在原图片名称前加YYMMDD重名名并上传

            Regex regName = new Regex(@"\w+.(?:jpg|gif|bmp|png)", RegexOptions.IgnoreCase);

            string strNewImgName = DateTime.Now.ToShortDateString().Replace("-", "") + regName.Match(imgUrl).ToString();

            try
            {
                //保存图片
                client.DownloadFile(imgUrl, (path + strNewImgName));
            }
            catch
            {
            }
            finally
            {

            }
            client.Dispose();
        }
        return "远程图片保存成功，保存路径为ImgUpload/auto";
    }
}
