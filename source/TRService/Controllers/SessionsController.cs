using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace TRService.Controllers
{
    public class SessionsController: ApiController
    {
        // GET api/sessions
        public IEnumerable<string> Get()
        {
            var tempList = new List<String>();
            tempList.Add("TempItem");

            return tempList;
        }
    }
}
