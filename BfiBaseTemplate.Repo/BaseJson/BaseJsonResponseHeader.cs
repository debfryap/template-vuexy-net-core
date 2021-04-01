using System.Collections.Generic;

namespace BfiBaseTemplate.Repo.Models.BaseJson
{
    public class BaseJsonResponseHeader
    {
        public IList<BaseJsonResponseError> Errors = new List<BaseJsonResponseError>();
    }
}
