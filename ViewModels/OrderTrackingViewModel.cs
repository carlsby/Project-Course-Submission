namespace Project_Course_Submission.Models
{
    public class OrderTrackingViewModel
    {
        public int OrderId { get; set; }
        public List<OrderTrackingStatus> TrackingStatuses { get; set; }
    }

    public class OrderTrackingStatus
    {
        public string Status { get; set; }
        public string TrackLabel { get; set; }
        public string TrackDescription { get; set; }
        public bool IsDot { get; set; }
        public bool IsLine { get; set; }
    }
}
    