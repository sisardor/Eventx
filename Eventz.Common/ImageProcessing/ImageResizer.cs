using System;
using System.Linq;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Web;

namespace Eventz.Common.ImageProcessing
{

    public class ImageResizer
    {
        public Image ChangeImageSize(Image imgPhoto, int Width, int Height)
        {
            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;
            int destX = 0;
            int destY = 0;

            if (Width == Height)
            {
                if (sourceHeight > sourceWidth)
                {
                    sourceY = Convert.ToInt32((sourceHeight - sourceWidth) / 2);
                }
                else if (sourceHeight <= sourceWidth)
                {
                    sourceX = Convert.ToInt32((sourceWidth - sourceHeight) / 2);
                }
            }

            int destWidth = Width;
            int destHeight = Height;

            if (Width != Height)
            {
                if (sourceWidth <= Width && sourceHeight <= Height)
                {
                    destHeight = sourceHeight;
                    destWidth = sourceWidth;
                }
                else
                {
                    float percentage = (float)sourceWidth / (float)Width;
                    destHeight = Convert.ToInt32(sourceHeight / percentage);
                }
            }

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
                              PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                             imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.Clear(Color.AliceBlue);
            grPhoto.InterpolationMode =
                    InterpolationMode.Default;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth - sourceX * 2, sourceHeight - sourceY * 2),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            bmPhoto.MakeTransparent(Color.AliceBlue);
            return bmPhoto;
        }
    }

}
