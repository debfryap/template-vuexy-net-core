
namespace BfiBaseTemplate.Repo.Models.BaseJson
{
    public class BaseJsonResponse<T>
    {
        public BaseJsonResponseHeader Header { set; get; }
        public T Data { set; get; }

        public BaseJsonResponse()
        {
            Header = new BaseJsonResponseHeader();
        }
    }
}
