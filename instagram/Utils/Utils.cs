﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace instagram
{
    public static class Utils
    {

        public static void Save(Image image, string path, string fileName)
        {
            image = image.Resize();

            if (!Directory.Exists(path))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(path);

                image.Save(path + "/" + fileName);
            }
        }

        public static Image Resize(this Image image)
        {
            int width = image.Width;
            int height = image.Height;
            int newWidth = image.Width > 500 ? 500 : image.Width;
            int newHeight = (newWidth * height) / width;

            return Resize(image, newWidth, newHeight);
        }

        public static Image Resize(this Image current, int maxWidth, int maxHeight)
        {
            int width, height;
            #region reckon size 
            if (current.Width > current.Height)
            {
                width = maxWidth;
                height = Convert.ToInt32(current.Height * maxHeight / (double)current.Width);
            }
            else
            {
                width = Convert.ToInt32(current.Width * maxWidth / (double)current.Height);
                height = maxHeight;
            }
            #endregion

            #region get resized bitmap 
            var canvas = new Bitmap(width, height);

            using (var graphics = Graphics.FromImage(canvas))
            {
                graphics.CompositingQuality = CompositingQuality.HighSpeed;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.DrawImage(current, 0, 0, width, height);
            }

            return canvas;
            #endregion
        }

        public static byte[] ToByteArray(this Image current)
        {
            using (var stream = new MemoryStream())
            {
                current.Save(stream, current.RawFormat);
                return stream.ToArray();
            }
        }
    }
}
