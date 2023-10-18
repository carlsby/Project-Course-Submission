namespace Project_Course_Submission.ViewModels
{
public class OrderHistoryViewModel
{
    public int OrderNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string OrderStatus { get; set; }
    public decimal TotalAmount { get; set; }
    public List<OrderItemViewModel> OrderItems { get; set; }
}

public class OrderItemViewModel
{
    public string ProductName { get; set; }
    public string Size { get; set; }
    public string Color { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}
}