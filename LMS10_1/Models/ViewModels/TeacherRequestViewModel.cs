namespace LMS10_1.Models.ViewModels
{
    public class TeacherRequestViewModel
    {
        public List<TeacherRequests> PendingRequests { get; set; }
        public List<TeacherRequests> AcceptedRequests { get; set; }
        public List<TeacherRequests> RejectedRequests { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }


    }
}