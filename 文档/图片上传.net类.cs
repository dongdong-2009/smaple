using System;
using System.Drawing;

namespace ImgNoSkComp
{
	/// <summary>
	/// Pic ��ժҪ˵����
	/// </summary>
	public class Pic
	{
		public Pic()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		}

		#region Web ͼƬѹ���뱣��
		/// <summary>
		/// 
		/// </summary>
		/// <param name="InStream">ͼƬ������</param>
		/// <param name="iW">���</param>
		/// <param name="iH">�߶�</param>
		/// <param name="fileName">�����ļ���</param>
		public void ShrinkSavePic(System.IO.Stream InStream,double iW,double iH,string fileName)
		{
			//����ȡ��ͼƬ����
			System.Drawing.Image image = System.Drawing.Image.FromStream(InStream);
			//��С�ı���
			double iScale = 1;
			double iScaleW = 1;
			double iScaleH = 1;
			iScaleW = Math.Round(image.Width/iW,2);
			iScaleH = Math.Round(image.Height/iH,2);
			if (iScaleW >= iScaleH)
			{
				iScale = iScaleW;
			}
			else if (iScaleW < iScaleH)
			{
				iScale = iScaleH;
			}
			//ȡ��ͼƬ��С
			System.Drawing.Size size = new Size(Convert.ToInt32(image.Width / iScale) , Convert.ToInt32(image.Height / iScale));
			//�½�һ��bmpͼƬ
			System.Drawing.Image bitmap = new System.Drawing.Bitmap(size.Width,size.Height);
			//�½�һ������
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
			//���ø�������ֵ��
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
			//���ø�����,���ٶȳ���ƽ���̶�
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			//���һ�»���
			g.Clear(Color.White);
			//��ָ��λ�û�ͼ
			g.DrawImage(image, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 
				new System.Drawing.Rectangle(0, 0, image.Width,image.Height),
				System.Drawing.GraphicsUnit.Pixel);
			//����������ȵ�����ͼ
			bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
			g.Dispose();
		}

		#endregion

	}
}
