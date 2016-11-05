using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.MCaptcha.Classes
{
    public class RectangleCaptcha
    {
        public int Width { get; set; }

        public int Heigth { get; set; }

        public float X { get; set; }

        public float Y { get; set; }

        public static RectangleCaptcha DefaultRectangleCaptcha
        {
            get
            {
                return new RectangleCaptcha()
                {
                    Width = 0,
                    Heigth = 0,
                    X = 5,
                    Y = 5
                };
            }
        }

        public static RectangleF ToRectangleF(RectangleCaptcha rect)
        {
            if (rect == null)
                return new RectangleF();

            return new RectangleF()
            {
                X = rect.X,
                Y = rect.Y,
                Width = rect.Width,
                Height = rect.Heigth
            };
        }
    }
}
