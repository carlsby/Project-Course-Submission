using Project_Course_Submission.ViewModels;

namespace Project_Course_Submission.Services
{
    public class CategoriesService
    {
        #region CategoriesViewModel
        private readonly CategoryImagesViewModel _categoryImages = new()
        {


            CategoryItems = new List<CategoryImageItemsViewModel>
        {
            new CategoryImageItemsViewModel { Id = "1", ImageUrl = "images/categories/accessories.jpg", CategoryName = "Accessories" },
            new CategoryImageItemsViewModel { Id = "2", ImageUrl = "images/categories/home.jpg", CategoryName = "Home" },
            new CategoryImageItemsViewModel { Id = "3", ImageUrl = "images/categories/kids.jpg", CategoryName = "Kids"},
            new CategoryImageItemsViewModel { Id = "4", ImageUrl = "images/categories/men.jpg", CategoryName = "Men"},
            new CategoryImageItemsViewModel { Id = "5", ImageUrl = "images/categories/shoes.jpg", CategoryName = "Shoes"},
            new CategoryImageItemsViewModel { Id = "6", ImageUrl = "images/categories/sport.jpg", CategoryName = "Sport"},
            new CategoryImageItemsViewModel { Id = "7", ImageUrl = "images/categories/women.jpg", CategoryName = "Women"},

        }
        };
        #endregion
        public List<CategoryImageItemsViewModel> GetCategoryImagesId()
        {
            return _categoryImages.CategoryItems.ToList();
        }


        public CategoryImagesViewModel GetCategoryImages()
        {
            return _categoryImages;
        }


    }
}
