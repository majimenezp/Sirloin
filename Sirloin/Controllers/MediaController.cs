using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Sirloin.Models;
using System.IO;
using System.Drawing;

namespace Sirloin.Controllers
{
    public class MediaController : ApplicationController
    {
        //
        // GET: /Media/
        [Authorize]
        public ActionResult Index()
        {
            List<Domain.MediaFile> filelist = new List<Domain.MediaFile>();
            MediaModel modelo;
            FileInfo[] files;

            DirectoryInfo dir = new DirectoryInfo(Request.MapPath(Request.ApplicationPath) + @"\Content\Media");
            files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (!file.Name.Contains("_thmb"))
                {
                    filelist.Add(new Domain.MediaFile()
                    {
                        FileName = file.Name,
                        Path = file.FullName,
                        Extension = file.Extension,
                        ThumbNailUrl = CreateThumbnail(file.FullName),
                        ImageURL = GetVirtualPath(file.FullName)
                    });
                }
            }
            modelo = new MediaModel(filelist);
            return View(modelo);
        }

        public string GetVirtualPath(string physicalPath)
        {
            string vpath = physicalPath.Remove(0, Request.PhysicalApplicationPath.Length);
            return "~/" + vpath;
        }

        public string CreateThumbnail(string Imagepath)
        {
            string thmbImagePath = Path.GetDirectoryName(Imagepath) + "\\" + Path.GetFileNameWithoutExtension(Imagepath) + "_thmb" + Path.GetExtension(Imagepath);
            if (!System.IO.File.Exists(thmbImagePath))
            {
                Image imagen = Image.FromFile(Imagepath);
                Image thumbimage = imagen.GetThumbnailImage(80, 80, new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
                thumbimage.Save(thmbImagePath);
            }
            return thmbImagePath;
        }
        public bool ThumbnailCallback()
        {
            return true;
        }
    }
}
