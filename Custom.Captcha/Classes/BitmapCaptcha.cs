using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.MCaptcha.Classes
{
    public class BitmapCaptcha : BaseCaptcha
    {
        public Bitmap Bitmap { get; set; }
    }
}
