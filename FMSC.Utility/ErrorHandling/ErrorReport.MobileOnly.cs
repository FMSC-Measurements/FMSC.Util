using System;

using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace FMSC.Utility.ErrorHandling
{
    public partial class ErrorReport
    {
        enum RasterOperation : uint { SRC_COPY = 0x00CC0020 }

        [DllImport("coredll.dll")]
        static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, RasterOperation rasterOperation);

        [DllImport("coredll.dll")]
        private static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("coredll.dll")]
        private static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

        //public void GenerateScreenShot(String directory)
        //{
        //    Rectangle bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        //    IntPtr hdc = GetDC(IntPtr.Zero); //zero will get the dc for the entire screen 
        //    using(Bitmap img = new Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format16bppRgb565))
        //    using (Graphics g = Graphics.FromImage(img))
        //    {
        //        IntPtr destHdc = g.GetHdc();
        //        BitBlt(destHdc, 0, 0, bounds.Width, bounds.Height, hdc, 0, 0, RasterOperation.SRC_COPY);
        //        img.Save(directory + "\\ScreenShot.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
        //        ReleaseDC(IntPtr.Zero, hdc);
        //    }

        //}

    }
}
