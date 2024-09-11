namespace LogixCIS.Auth.API.Models
{
    public class ResponseModel
    {
        public  string Version { get; set; }
        public  bool Status { get; set; }
        public  string Message { get; set; }
        public  object Result { get; set; }
    }
}
