using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DataAccessLayer.Models
{
    public class SongList : List<Song>
    {
        //SongList ImageManager = new SongList();
        //public SongList()
        //    : this(1, 50)
        //{
        //}

        //private List<Song> GetAllImages(string category)
        //{
            
        //    string imagesDir = HttpContext.Current.Server.MapPath("~/Music/");

        //    var images = ImageManager.SongList(category);

        //    TotalCount = images.Count();

        //    return images.ToList();
        //}

        //public int TotalCount { get; set; }
        //public int CurrentPage { get; set; }
        //public int PageSize { get; set; }
        //public SongList(int pageNum, int pageSize)
        //{
        //    CurrentPage = pageNum;
        //    PageSize = pageSize;

        //    var images = GetAllImages(category);

        //    this.AddRange(images.Skip((pageNum - 1) *
        //        pageSize).Take(pageSize).ToList());
        //}

        //public void Add(Song image, HttpPostedFileBase file)
        //{
        //    string imagesDir = HttpContext.Current.Server.MapPath("~/images/");
        //    file.SaveAs(imagesDir + image.Path);
        //    ImageManager.UploadImage(image);
        //}
    
    }
}
