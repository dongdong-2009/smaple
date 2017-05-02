using System;
using System.IO;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Text.RegularExpressions;

/*
 * 使用方法
using (Bitmap bmpAvatar = ThumbImage.Thumbnail(new Bitmap(this.FileUpload1.PostedFile.InputStream), new Size(96, 96), ThumbImage.ThumbMode.Full, ContentAlignment.MiddleCenter))
{
    ThumbImage.SaveIamge(bmpAvatar, 95L, Server.MapPath("~/Avatar.jpg"));
}
*/


/// <summary>
// 生成缩略图
// http://www.hulaka.com/
// (c) 2008 Dao
/// </summary>
public class ThumbImage
{
    /// <summary>
    /// 缩略模式。
    /// </summary>
    public enum ThumbMode : byte
    {
        /// <summary>
        /// 完整模式
        /// </summary>
        Full = 1,
        /// <summary>
        /// 最大尺寸
        /// </summary>
        Max
    }

    /// <summary>
    /// 缩略图。
    /// </summary>
    /// <param name="image">要缩略的图片</param>
    /// <param name="size">要缩放的尺寸</param>
    /// <param name="mode">缩略模式</param>
    /// <param name="contentAlignment">对齐方式</param>
    /// <returns>返回已经缩放的图片。</returns>
    public static Bitmap Thumbnail(Bitmap image, Size size, ThumbMode mode, ContentAlignment contentAlignment)
    {
        if (!size.IsEmpty && !image.Size.IsEmpty && !size.Equals(image.Size))
        {
            //先取一个宽比例。
            double scale = (double)image.Width / (double)size.Width;
            //缩略模式
            switch (mode)
            {
                case ThumbMode.Full:
                    if (image.Height > image.Width)
                        scale = (double)image.Height / (double)size.Height;
                    break;
                case ThumbMode.Max:
                    if (image.Height / scale < size.Height)
                        scale = (double)image.Height / (double)size.Height;
                    break;
            }
            SizeF newSzie = new SizeF((float)(image.Width / scale), (float)(image.Height / scale));
            Bitmap result = new Bitmap(size.Width, size.Height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.FillRectangle(Brushes.White, new Rectangle(new Point(0, 0), size));
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.CompositingMode = CompositingMode.SourceOver;
                g.CompositingQuality = CompositingQuality.HighQuality;
                g.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                //对齐方式
                RectangleF destRect;
                switch (contentAlignment)
                {
                    case ContentAlignment.TopCenter:
                        destRect = new RectangleF(new PointF(-(float)((newSzie.Width - size.Width) * 0.5), 0), newSzie);
                        break;
                    case ContentAlignment.TopRight:
                        destRect = new RectangleF(new PointF(-(float)(newSzie.Width - size.Width), 0), newSzie);
                        break;
                    case ContentAlignment.MiddleLeft:
                        destRect = new RectangleF(new PointF(0, -(float)((newSzie.Height - size.Height) * 0.5)), newSzie);
                        break;
                    case ContentAlignment.MiddleCenter:
                        destRect = new RectangleF(new PointF(-(float)((newSzie.Width - size.Width) * 0.5), -(float)((newSzie.Height - size.Height) * 0.5)), newSzie);
                        break;
                    case ContentAlignment.MiddleRight:
                        destRect = new RectangleF(new PointF(-(float)(newSzie.Width - size.Width), -(float)((newSzie.Height - size.Height) * 0.5)), newSzie);
                        break;
                    case ContentAlignment.BottomLeft:
                        destRect = new RectangleF(new PointF(0, -(float)(newSzie.Height - size.Height)), newSzie);
                        break;
                    case ContentAlignment.BottomCenter:
                        destRect = new RectangleF(new PointF(-(float)((newSzie.Width - size.Width) * 0.5), -(float)(newSzie.Height - size.Height)), newSzie);
                        break;
                    case ContentAlignment.BottomRight:
                        destRect = new RectangleF(new PointF(-(float)(newSzie.Width - size.Width), -(float)(newSzie.Height - size.Height)), newSzie);
                        break;
                    default:
                        destRect = new RectangleF(new PointF(0, 0), newSzie);
                        break;
                }
                g.DrawImage(image, destRect, new RectangleF(new PointF(0F, 0F), image.Size), GraphicsUnit.Pixel);
                image.Dispose();
            }
            return result;
        }
        else
            return image;
    }

    /// <summary>
    /// 保存图片。
    /// </summary>
    /// <param name="image">要保存的图片</param>
    /// <param name="quality">品质（1L~100L之间，数值越大品质越好）</param>
    /// <param name="filename">保存路径</param>
    public static void SaveIamge(Bitmap image, long quality, string filename)
    {
        using (EncoderParameters encoderParams = new EncoderParameters(1))
        {
            using (EncoderParameter parameter = (encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, quality)))
            {
                ImageCodecInfo encoder = null;
                //取得扩展名
                string ext = Path.GetExtension(filename);
                if (string.IsNullOrEmpty(ext))
                    ext = ".jpg";
                //根据扩展名得到解码、编码器
                foreach (ImageCodecInfo codecInfo in ImageCodecInfo.GetImageEncoders())
                {
                    if (Regex.IsMatch(codecInfo.FilenameExtension, string.Format(@"(;|^)\*\{0}(;|$)", ext), RegexOptions.IgnoreCase))
                    {
                        encoder = codecInfo;
                        break;
                    }
                }
                Directory.CreateDirectory(Path.GetDirectoryName(filename));
                image.Save(filename, encoder, encoderParams);
            }
        }
    }

    /// <summary>
    /// 保存图片。
    /// </summary>
    /// <param name="stream">要保存的流</param>
    /// <param name="quality">品质（1L~100L之间，数值越大品质越好）</param>
    /// <param name="filename">保存路径</param>
    public static void SaveIamge(Stream stream, long quality, string filename)
    {
        using (Bitmap bmpTemp = new Bitmap(stream))
        {
            SaveIamge(bmpTemp, quality, filename);
        }
    }
}