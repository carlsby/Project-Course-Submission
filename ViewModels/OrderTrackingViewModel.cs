namespace Project_Course_Submission.Models
{
    public class OrderTrackingViewModel
    {
        public List<OrderTrackingStatus> TrackingStatuses { get; set; }
    }

    public class OrderTrackingStatus
    {
        public string Status { get; set; }
        public string TrackDescription { get; set; }
        public string EstimatedDate { get; set; }
        public bool IsDot { get; set; }
    }
}
    