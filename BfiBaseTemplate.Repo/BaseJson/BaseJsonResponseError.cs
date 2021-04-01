namespace BfiBaseTemplate.Repo.Models.BaseJson
{
    public class BaseJsonResponseError
    {
        public string Message { get; set; }
        public string Cause { get; set; }
        public string Code { get; set; }

        public BaseJsonResponseError(string message, string cause, string code)
        {
            Message = message;
            Cause = cause;
            Code = code;
        }
    }
}
