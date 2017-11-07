using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace Memory_Game_Project
{
    class Utils
    {
        public static Bitmap ResizeImage(Image image, int width, int height)
        {//resizes plaatjes
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);
			
            if (image.Width != width || image.Height != height)
            {
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

                using (var graphics = Graphics.FromImage(destImage))
                {
                    graphics.CompositingMode = CompositingMode.SourceCopy;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = SmoothingMode.HighQuality;
                    graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                    using (var wrapMode = new ImageAttributes())
                    {
                        wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                        graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                    }
                }
            }
            else
            {
                return (Bitmap)image;
            }


            return destImage;
        }

        public static string get_bestanden_dir()
        {
            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }
            path += @"\Documents\memory game\";
            Directory.CreateDirectory(path);
            return path;
        }

        public static string get_themas_dir()
        {
            string path = get_bestanden_dir();
            path += @"themas\";
            Directory.CreateDirectory(path);
            return path;
        }

        public static string get_saves_dir()
        {
            string path = get_bestanden_dir();
            path += @"saves\";
            Directory.CreateDirectory(path);
            return path;
        }
    }
}