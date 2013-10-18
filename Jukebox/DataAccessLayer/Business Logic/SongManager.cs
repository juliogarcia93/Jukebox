using DataAccessLayer.Repositories;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.BusinessLogic
{
    //public class SongManager
    //{
    //    private SongRepository ImageRepository;
    //    public ImageManager()
    //    {
    //        ImageRepository = new SongRepository();
    //    }

    //    public IQueryable<ImageModel> GetImageList(string category)
    //    {
    //        int categoryId = ImageRepository.GetCategoriesList().First(c => c.CategoryName == category).Id;
    //        return ImageRepository.GetImageList(categoryId);
    //    }

    //    public void UploadImage(ImageModel model)
    //    {
    //        ImageRepository.Add(model);
    //    }

    //    public string FirstActiveCategory()
    //    {
    //        return ImageRepository.GetActiveCategories().First();
    //    }

    //    public string[] GetCategories()
    //    {
    //        return ImageRepository.GetCategories();
    //    }

    //    public int ActiveCategoriesCount()
    //    {
    //        return ImageRepository.GetActiveCategories().Count();
    //    }
    //}
}
