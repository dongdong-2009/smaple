using System;
using System.Drawing;

namespace ImgNoSkComp
{
	/// <summary>
	/// Pic 的摘要说明。
	/// </summary>
	public class Pic
	{
		public Pic()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		#region Web 图片压缩与保存
		/// <summary>
		/// 
		/// </summary>
		/// <param name="InStream">图片数据流</param>
		/// <param name="iW">宽度</param>
		/// <param name="iH">高度</param>
		/// <param name="fileName">保存文件名</param>
		public void ShrinkSavePic(System.IO.Stream InStream,double iW,double iH,string fileName)
		{
			//从流取得图片对象
			System.Drawing.Image image = System.Drawing.Image.FromStream(InStream);
			//缩小的倍数
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
			//取得图片大小
			System.Drawing.Size size = new Size(Convert.ToInt32(image.Width / iScale) , Convert.ToInt32(image.Height / iScale));
			//新建一个bmp图片
			System.Drawing.Image bitmap = new System.Drawing.Bitmap(size.Width,size.Height);
			//新建一个画板
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmap);
			//设置高质量插值法
			g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
			//设置高质量,低速度呈现平滑程度
			g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
			//清空一下画布
			g.Clear(Color.White);
			//在指定位置画图
			g.DrawImage(image, new System.Drawing.Rectangle(0, 0, bitmap.Width, bitmap.Height), 
				new System.Drawing.Rectangle(0, 0, image.Width,image.Height),
				System.Drawing.GraphicsUnit.Pixel);
			//保存高清晰度的缩略图
			bitmap.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
			g.Dispose();
		}

		#endregion

	}
}
