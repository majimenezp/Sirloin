using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sirloin.Models
{
    public class MediaModel
    {
        public List<Domain.MediaFile> MediaFiles { get; set; }

        public MediaModel()
        {
            MediaFiles = new List<Domain.MediaFile>();
        }

        public MediaModel(List<Domain.MediaFile> FileList)
        {

            MediaFiles = FileList;
        }
    }
}