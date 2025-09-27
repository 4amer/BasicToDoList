using Microsoft.AspNetCore.Mvc;
using ToDoListBackend.Models;

namespace ToDoListBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        [HttpGet("GetToDoInfos")]
        public IActionResult GetToDoInfos()
        {
            List<ToDoInfo> toDoInfos = new ();

            ToDoInfo toDoInfo = new ToDoInfo
            {
                Id = 1,
                Title = "To do",
                Discription = "Something",
                IsDone = false
            };

            toDoInfos.Add(toDoInfo);
            toDoInfos.Add(toDoInfo);
            toDoInfos.Add(toDoInfo);

            ToDoInfo[] ArrayOfInfos = toDoInfos.ToArray();

            return Ok(ArrayOfInfos);
        }
    }
}
