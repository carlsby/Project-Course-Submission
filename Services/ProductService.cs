using Project_Course_Submission.Migrations.Data;
using Project_Course_Submission.Services.Repositories;
using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Services
{
    public class ProductService
    {
        private readonly ProductRepository _prodRepo;

        public ProductService(ProductRepository prodRepo)
        {
            _prodRepo = prodRepo;
        }

        public async Task<IEnumerable<string>> GetCategoriesAsync()
        {
            var items = await _prodRepo.GetAllAsync();

            var categoryList = items
                .SelectMany(item => item.Categories)
                .Select(category => category.Category.CategoryName)
                .Distinct()
                .ToList();

            return categoryList;
        }
    }
        //public async Task<List<string>> GetCategoryListAsync()
        //{
        //    var items = await _prodRepo.GetAllAsync();
        //    var categoryList = new List<string>();

        //    foreach (var item in items)
        //    {
        //        foreach (var category in item.Categories)
        //        {
        //            categoryList.Add(category.Category.CategoryName);
        //        }
        //    }

        //    return categoryList;
        //}

    }

