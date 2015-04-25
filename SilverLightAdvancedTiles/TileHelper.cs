using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace SilverLightAdvancedTiles
{
    public static class TileHelper
    {
        public static Color GetRandomColor()
        {
            var rnd = new Random();
            var col = Color.FromArgb(255, (byte)rnd.Next(255), (byte)rnd.Next(255), (byte)rnd.Next(255));
            return col;
        }

        public static void SaveAsImageToIsolatedStorage(this UserControl control, string filename, Size controlSize = new Size(), Size imageSize = new Size())
        {
            var controlWidth = (int)control.Width;
            var controlHeight = (int)control.Height;

            // resize the control if its not null
            if (controlSize != new Size())
            {
                controlWidth = (int)controlSize.Width;
                controlHeight = (int)controlSize.Height;

                control.Height = controlHeight;
                control.Width = controlWidth;
            }

            control.Arrange(new Rect(0, 0, controlWidth, controlHeight));

            // Create writeable bitmap to save as image
            var bitmapWidth = controlWidth;
            var bitmapHeight = controlHeight;

            // If we passed in a size to scale to, calculate scaling factor and create a transform
            var sc = new ScaleTransform();
            if (imageSize != new Size())
            {
                bitmapHeight = (int)imageSize.Height;
                bitmapWidth = (int)imageSize.Width;

                var heightScaleFactor = imageSize.Height / controlSize.Height;
                var widthScaleFactor = imageSize.Width / controlSize.Width;
                sc = new ScaleTransform { ScaleX = widthScaleFactor, ScaleY = heightScaleFactor };
            }

            var wb = new WriteableBitmap(bitmapWidth, bitmapHeight);

            // Position child objects
            control.Arrange(new Rect(0, 0, controlWidth, controlHeight));

            // Render element to bitmap
            if (imageSize != new Size())
            {
                // Render with scaling
                wb.Render(control, sc);
            }
            else
            {
                // Render native size
                wb.Render(control, new CompositeTransform());
            }

            // Draw
            wb.Invalidate();

            // Save to isolated storage
            try
            {
                using (var isfs = new IsolatedStorageFileStream(string.Format("/Shared/ShellContent/{0}.jpg", filename), FileMode.Create,
                        IsolatedStorageFile.GetUserStoreForApplication()))
                {
                    wb.SaveJpeg(isfs, controlWidth, controlHeight, 0, 100);
                }
            }
            catch (Exception ex)
            {
                var t = ex;
            }
        }
    }
}
