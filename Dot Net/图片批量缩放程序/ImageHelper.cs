using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;

namespace ThumbnailImages
{
    public static class ImageHelper
    {
 
        public static Image GetThumbnailImage(Image image, int width, int height)
        {
            if (image == null || width < 1 || height < 1)
                return null;

            // �½�һ��bmpͼƬ
            //
            Image bitmap = new System.Drawing.Bitmap(width, height);

            // �½�һ������
            //
            using (Graphics g = System.Drawing.Graphics.FromImage(bitmap))
            {

                // ���ø�������ֵ��
                //
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                // ���ø�����,���ٶȳ���ƽ���̶�
                //
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                
                // �����������ٶȸ���
                //
                g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

                // ��ջ�������͸������ɫ���
                //
                g.Clear(Color.Transparent);

                // ��ָ��λ�ò��Ұ�ָ����С����ԭͼƬ��ָ������
                //
                g.DrawImage(image, new Rectangle(0, 0, width, height),
                    new Rectangle(0, 0, image.Width, image.Height),
                    GraphicsUnit.Pixel);

                return bitmap;
            }

        }

        /// <summary>
        /// ��ȡͼ���������������������Ϣ
        /// </summary>
        /// <param name="mimeType">��������������Ķ���;�����ʼ�����Э�� (MIME) ���͵��ַ���</param>
        /// <returns>����ͼ���������������������Ϣ</returns>
        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] CodecInfo = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo ici in CodecInfo)
            {
                if (ici.MimeType == mimeType) return ici;
            }
            return null;
        }

        public static ImageCodecInfo GetImageCodecInfo(ImageFormat format)
        {
            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

            foreach (ImageCodecInfo icf in encoders)
            {
                if (icf.FormatID == format.Guid)
                {
                    return icf;
                }
            }

            return null;
        }

        /// <summary>
        /// ����������ͼƬ
        /// </summary>
        /// <param name="image"></param>
        /// <param name="savePath"></param>
        /// <param name="ici"></param>
        public static void SaveImage(Image image, string savePath, ImageCodecInfo ici)
        {
            // ���� ԭͼƬ ����� EncoderParameters ����
            //
            EncoderParameters parms = new EncoderParameters(1);
            EncoderParameter parm = new EncoderParameter(Encoder.Quality, ((long)95));
            parms.Param[0] = parm;

            image.Save(savePath, ici, parms);
            parms.Dispose();
        }

    }
}
