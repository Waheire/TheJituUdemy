namespace JituUdemy.Response
{
    public class UserSuccess
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public UserSuccess(int code, string message)
        {
            this.Message = message;
            this.Code = code;
        }
    }
}
