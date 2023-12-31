﻿using Microsoft.EntityFrameworkCore;
using Project_Course_Submission.Models.Entities;
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

        public async Task<ProductEntity> GetProductByArticleNumberAsync(string articleNumber)
        {
            var product = await _prodRepo.GetAsync(x => x.ArticleNumber == articleNumber);

            return product;
        }


        #region GetCategoriesAsync
        public async Task<IEnumerable<string>> GetCategoriesAsync()
        {
            var items = await _prodRepo.GetAllAsync();

            var categoryList = items
                .Where(item => item.Categories != null)
                .SelectMany(item => item.Categories)
                .Where(category => category != null && category.Category != null)
                .Select(category => category.Category.CategoryName)
                .Where(categoryName => !string.IsNullOrEmpty(categoryName))
                .Distinct()
                .ToList();

            return categoryList;
        }
        #endregion

        #region GetCategoryImagesAsync 
        public async Task<IEnumerable<(int CategoryId, int ImageId)>> GetCategoryImagesAsync()
        {
            var items = await _prodRepo.GetAllAsync();

            var imageList = items
                .SelectMany(item => item.Categories)
                .SelectMany(category => category.Category.Images.Select(image => (category.Category.Id, image.Image.Id)))
                .Distinct()
                .ToList();

            return imageList;
        }




        #endregion





    }

}




