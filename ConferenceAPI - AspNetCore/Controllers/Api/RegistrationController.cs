using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ConferenceAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConferenceAPI.Controllers.Api
{   
    public class RegistrationController : ApiController
    {
        private readonly IDataStore _dataStore;

        public RegistrationController(IDataStore dataStore)
        {
            _dataStore = dataStore;
        }

        [HttpGet]
        public HttpResponseMessage List()
        {
            var results = _dataStore.GetRegistrants();
            if (results.Any()) return Request.CreateResponse(HttpStatusCode.OK, results);

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nobody Registered :(" );
        }
    }
}