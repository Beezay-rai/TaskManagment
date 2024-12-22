namespace TaskManagementApi.Common
{
    public class ApiResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }
    }
}
