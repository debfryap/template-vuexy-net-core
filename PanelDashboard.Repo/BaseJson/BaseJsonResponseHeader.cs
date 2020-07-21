using System.Collections.Generic;

namespace PanelDashboard.Repo.Models.BaseJson
{
    public class BaseJsonResponseHeader
    {
        public IList<BaseJsonResponseError> Errors = new List<BaseJsonResponseError>();
    }
}
