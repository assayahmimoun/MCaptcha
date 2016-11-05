using Custom.MCaptcha.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom.MCaptcha.Classes;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;

namespace Custom.MCaptcha
{
    public class Captcha : ICaptcha
    {
        public BaseCaptcha GenerateStreamCaptcha(int height = 30, int width = 100, RectangleCaptcha rectf = null)
        {
            string generatedValue = GenerateStringCaptcha();
            Stream stream = GenerateStreamCaptcha(generatedValue, height, width, rectf);
            return new StreamCaptcha()
            {
                GeneratedValue = generatedValue,
                Stream = stream
            };
        }

        public BaseCaptcha GenerateBitmapCaptcha(int height = 30, int width = 100, RectangleCaptcha rectf = null)
        {
            string generatedValue = GenerateStringCaptcha();
            Stream stream = GenerateStreamCaptcha(generatedValue, height, width, rectf);
            return new StreamCaptcha()
            {
                GeneratedValue = generatedValue,
                Stream = stream
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public BaseCaptcha GenerateCaptcha(int height = 30, int width = 100, RectangleCaptcha rectf = null)
        {
            string generatedValue = GenerateStringCaptcha();
            byte[] byteArr = GenerateStreamCaptcha(generatedValue, height, width, rectf).ToArray();
            string binStr = Convert.ToBase64String(byteArr);
            return new Base64Captcha()
            {
                GeneratedValue = generatedValue,
                GeneratedImageBase64 = binStr
            };
        }

        public string GenerateStringCaptcha()
        {
            Random random = new Random();
            string combination = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            StringBuilder captcha = new StringBuilder();
            for (int i = 0; i < 6; i++)
                captcha.Append(combination[random.Next(combination.Length)]);

            return captcha.ToString();
        }

        public MemoryStream GenerateStreamCaptcha(string stringCaptcha, int height = 30, int width = 100, RectangleCaptcha rectf = null)
        {
            Bitmap bmp = GenerateBitmapCaptcha(stringCaptcha, height, width, rectf);
            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, ImageFormat.Jpeg);
            bmp.Dispose();
            memoryStream.Dispose();
            return memoryStream;
        }

        public Bitmap GenerateBitmapCaptcha(string stringCaptcha, int height = 30, int width = 100, RectangleCaptcha rectf = null)
        {
            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(stringCaptcha, new Font("Thaoma", 15, FontStyle.Strikeout), Brushes.Green, RectangleCaptcha.ToRectangleF(rectf));
            g.DrawRectangle(new Pen(Brushes.LemonChiffon), 1, 1, width - 8, height - 2);
            g.Flush();
            g.Dispose();
            return bmp;
        }
    }
}
