﻿namespace Project_Course_Submission.ViewModels;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Home";

    public List<CategoryItemViewModel> Categories { get; set; } = new List<CategoryItemViewModel>();

    public BestSellersViewModel BestSellers { get; set; } = null!;

    public FeaturedViewModel FeaturedProducts { get; set; } = null!;
}