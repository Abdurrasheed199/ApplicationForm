namespace ApplicationForm.DTOs
{
    public class BaseResponse<T>
    {
        public string Message { get; set; }
        public bool Status { get; set; } = false;
        public T Data { get; set; }
       
    }
}
