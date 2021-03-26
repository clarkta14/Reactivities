using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Activities;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ActivitiesController : BaseApiController
    {
        [HttpGet] // [url]/api/activities
        public async Task<ActionResult<List<Activity>>> GetActivites()
        {
            return await Mediator.Send(new List.Query());
        }

        [HttpGet("{id}")] // [url]/api/activites/7485dd41-caca-4f08-9c22-d9afadef3031 (an id)
        public async Task<ActionResult<Activity>> GetActivity(Guid id)
        {
            return await Mediator.Send(new Details.Query{Id = id});
        }

        [HttpPost] //IActionResult is response ~ Ok(), BadRequest(), NotFound() etc.
        public async Task<IActionResult> CreateActivity(Activity activity) // Due to [ApiController] in BaseApiController Its smart enough to look in the reqest body and match it to type Activity.
        {                                                                  // Adding [FromBody] before Activity activity would be a "hint" at this point
            return Ok(await Mediator.Send(new Create.Command{Activity = activity}));
        }

        [HttpPut("{id}")] //used for updates
        public async Task<IActionResult> EditActivity(Guid id, Activity activity) // The Activity in the body will not have an id. It is still interpreted
        {                                                                         // as an activity as it takes the id from the url (Guid id).
            activity.Id = id;
            return Ok(await Mediator.Send(new Edit.Command{Activity = activity}));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new Delete.Command{Id = id}));
        }
    }
}