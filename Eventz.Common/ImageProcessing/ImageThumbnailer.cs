using System;
using System.Linq;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;

namespace Eventz.Common.ImageProcessing
{
    public class ImageThumbnailer
    {
        private Bitmap _thumb = null;

        public Bitmap CreateThumbnail(Bitmap SourceImage,
            Int32 Width, Int32 Height, Boolean KeepRatio)
        {
            if (SourceImage.Width < Width && SourceImage.Height < Height)
                return SourceImage;

            try
            {
                Int32 _Width = 0;
                Int32 _Height = 0;

                _Width = Width;
                _Height = Height;

                if (KeepRatio)
                {
                    if (SourceImage.Width > SourceImage.Height)
                    {
                        _Width = Width;
                        _Height = (Int32)(SourceImage.Height *
                            ((Decimal)Width / SourceImage.Width));
                    }
                    else
                    {
                        _Height = Height;
                        _Width = (Int32)(SourceImage.Width *
                            ((Decimal)Height / SourceImage.Height));
                    }
                }

                _thumb = new Bitmap(_Width, _Height);
                using (Graphics g = Graphics.FromImage(_thumb))
                {
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.FillRectangle(Brushes.White, 0, 0, _Width, _Height);
                    g.DrawImage(SourceImage, 0, 0, _Width, _Height);
                }
            }
            catch
            {
                _thumb = null;
            }
            return _thumb;
        }

        public void Save(Stream stream)
        {
            // JPEG Optimizing
            EncoderParameters encoderParams = new EncoderParameters();
            long[] quality = new long[1];
            quality[0] = 75;
            EncoderParameter encoderParam = new EncoderParameter(Encoder.Quality, quality);
            encoderParams.Param[0] = encoderParam;

            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            ImageCodecInfo codec = encoders.Where(
                p => p.FormatDescription.Equals("JPEG")).SingleOrDefault();

            // Save to Specified Stream
            _thumb.Save(stream, codec, encoderParams);
        }
    }
}
