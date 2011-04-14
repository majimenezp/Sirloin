using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sirloin.Domain
{
    public class MediaFile
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string Path { get; set; }
        public string ImageURL { get; set; }
        public string ThumbNailUrl { get; set; }
    }
}
