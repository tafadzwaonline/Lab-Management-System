using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace DevExpress.Web.Demos
{
	// Token: 0x0200004D RID: 77
	public static class PhotoUtils
	{
		// Token: 0x06000308 RID: 776 RVA: 0x00003C70 File Offset: 0x00001E70
		public static Image Inscribe(Image image, int size)
		{
			return PhotoUtils.Inscribe(image, size, size);
		}

		// Token: 0x06000309 RID: 777 RVA: 0x00019E90 File Offset: 0x00018090
		public static Image Inscribe(Image image, int width, int height)
		{
			Bitmap bitmap = new Bitmap(width, height);
			using (Graphics graphics = Graphics.FromImage(bitmap))
			{
				double num = 1.0 * (double)width / (double)image.Width;
				if ((double)image.Height * num < (double)height)
				{
					num = 1.0 * (double)height / (double)image.Height;
				}
				Size size = new Size((int)((double)width / num), (int)((double)height / num));
				Point location = new Point((image.Width - size.Width) / 2, (image.Height - size.Height) / 2);
				PhotoUtils.SmoothGraphics(graphics);
				graphics.DrawImage(image, new Rectangle(0, 0, width, height), new Rectangle(location, size), GraphicsUnit.Pixel);
			}
			return bitmap;
		}

		// Token: 0x0600030A RID: 778 RVA: 0x00003C7A File Offset: 0x00001E7A
		private static void SmoothGraphics(Graphics g)
		{
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
			g.PixelOffsetMode = PixelOffsetMode.HighQuality;
		}

		// Token: 0x0600030B RID: 779 RVA: 0x00003C91 File Offset: 0x00001E91
		public static void SaveToJpeg(Image image, Stream output)
		{
			image.Save(output, ImageFormat.Jpeg);
		}

		// Token: 0x0600030C RID: 780 RVA: 0x00003C9F File Offset: 0x00001E9F
		public static void SaveToJpeg(Image image, string fileName)
		{
            //image.Save("C:\\test.jpg");
            //var bytes = PhotoEditor.ConvertImageToByteArray(image);
            //string gg = Path.Combine(fileName, "wadi");
            //Bitmap img = new Bitmap(image);
            //Bitmap img2 = new Bitmap(img);
            //img.Dispose();
            //img2.Save(fileName);
            image.Save(fileName, ImageFormat.Jpeg);
            //image.Save(fileName);
        }
	}
}
