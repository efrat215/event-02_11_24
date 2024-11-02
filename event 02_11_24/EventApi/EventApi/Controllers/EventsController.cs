using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;
using System.Diagnostics.Tracing;
using System.Security.Cryptography;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EventApi.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        public static List<EventClass> events = new List<EventClass>();
        // GET: api/<EventsController>
        [HttpGet]
        public IEnumerable<EventClass> Get()
        {

            return events;
        }



        // POST api/<EventsController>
        [HttpPost]
        public void Post([FromBody] EventClass e)
        {
            int i = events.Count;
            e.id = i+1;
            events.Add(e);
        }

        // PUT api/<EventsController>/5
        [HttpPut("{id}")]
        public void Put( int id,[FromBody]EventClass elemant)
        {
            EventClass eid = new EventClass();
            foreach (EventClass e in events)
            {
                if (id == e.id)
                {
                    eid = e;
                    break;
                }
            }
            if(elemant.titel!=null)
                eid.titel = elemant.titel;
            if (elemant.start != null)
                eid.start = elemant.start;
            if (elemant.end != null)
                eid.end = elemant.end;
        }

        // DELETE api/<EventsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            EventClass eid = new EventClass();
            foreach(EventClass e in events) 
            { if (id == e.id) { 
                    eid = e;
                break;}
                    };
            events.Remove(eid);
        }
    }
}
