using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom.MCaptcha.Classes
{
    public class StreamCaptcha : BaseCaptcha
    {
        public Stream Stream { get; set; }
    }
}
