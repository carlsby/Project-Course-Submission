﻿using Microsoft.EntityFrameworkCore;

namespace Project_Course_Submission.Models.Entities;

[PrimaryKey("ArticleNumber", "CategoryId")]
public class ProductCategoryEntity
{
	public string ArticleNumber = null!;
	public ProductEntity Product { get; set; } = null!;
	public int CategoryId { get; set; }
	public CategoryEntity Category { get; set; } = null!;
}
