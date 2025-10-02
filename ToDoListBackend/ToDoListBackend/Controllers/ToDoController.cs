using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ToDoListBackend.Models;
using ToDoListBackend.Services.Interfaces;

namespace ToDoListBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        //TODO: think about that all controllers has similareties
        //and we could use inheritens to minimize code copy/pasting

        private readonly IToDoListService _toDoListService;
        private readonly ILogger<ToDoController> _logger;
        public ToDoController(IToDoListService toDoListService,
            ILogger<ToDoController> logger) 
        {
            _toDoListService = toDoListService;
            _logger = logger;
        }


        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            try
            {
                int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                if (id <= 0)
                    return BadRequest("Invalid ID");

                List<ToDoItems> toDoItems = await _toDoListService.GetItemsByIdAsync(id);

                if (toDoItems == null)
                    return NotFound($"No items found for id {id}");

                return Ok(toDoItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retriving todo items");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ToDoItems toDoInfo)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                int id = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                toDoInfo.UserId = id;

                ToDoItems createItem = await _toDoListService.CreateAndAddItemAsync(toDoInfo);

                return CreatedAtAction(nameof(GetById), new { id = createItem.Id }, createItem);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Error creating todo item");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
