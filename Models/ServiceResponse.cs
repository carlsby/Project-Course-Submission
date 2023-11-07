using Project_Course_Submission.Enums;

namespace Project_Course_Submission.Models
{
    public class ServiceResponse<T>
    {
        public StatusCode StatusCode { get; set; }
        public T? Content { get; set; }

    }
}
