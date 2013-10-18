using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Entities;

namespace DataAccessLayer.Repositories
{
    public class SongRepository
    {
        //private ImageGalleryContainer _context { get; set; }

        //public SongRepository()
        //{
        //    _context = new ImageGalleryContainer();
        //}

        //public IQueryable<CategoryModel> GetCategoriesList()
        //{
        //    return _context.Categories.Select(c => new CategoryModel
        //    {
        //        CategoryName = c.sCategoryName,
        //        Id = c.Id
        //    });
        //}
        //public string[] GetCategories()
        //{
        //    return _context.Categories.Select(c => c.sCategoryName).ToArray();
        //}

        //public string[] GetActiveCategories()
        //{
        //    return _context.Categories.Where(c => c.Images.Count() > 0).Select(c => c.sCategoryName).ToArray();
        //}

        //public string[] GetCategories(int categoryId)
        //{
        //    return _context.Categories.Where(c => c.Id == categoryId)
        //        .Select(c => c.sCategoryName).ToArray();
        //}

        //public IQueryable<ImageModel> GetImageList(int categoryId)
        //{
        //    return _context.Categories.First(c => c.Id == categoryId).Images.AsQueryable()
        //        .Select(i => new ImageModel()
        //        {
        //            Description = i.sDescription,
        //            Path = i.sPath
        //        });
        //}

        //public void Add(ImageModel model)
        //{
        //    Image entity = Conversion.ModelConversions.ImageModelToEntity(model);
        //    Category category = GetCategory(model.Category);
        //    entity.Categories.Add(category);
        //    _context.Images.Add(entity);
        //    _context.SaveChanges();

        //}

        //private Category GetCategory(string category)
        //{
        //    return _context.Categories.First(c => c.sCategoryName == category);
        //}
    }
}
