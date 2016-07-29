using EpicAppModels;
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
        public IEnumerable<Session> Get()
        {
            var tempList = new List<Session>();
            Session s = new Session()
            {
                SessionId = 1,
                SessionCode = "AZR01",
                SessionName = "Azure is AWESOME",
                SessionDescription = "Some description of the session",
                SessionRoom = new Room(),
                SessionTime = DateTime.Now,
                SessionTrack = new Track()
            };

            tempList.Add(s);

            return tempList;
        }
    }
}
