using Microsoft.AspNetCore.Mvc;
using ToDoListBackend.Models;
using ToDoListBackend.Services.Interfaces;

namespace ToDoListBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly IToDoListService _toDoListService;
        private readonly ILogger<ToDoController> _logger;
        public ToDoController(IToDoListService toDoListService, ILogger<ToDoController> logger) 
        {
            _toDoListService = toDoListService;
            _logger = logger;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Invalid ID");

                ToDoItems[] toDoItems = await _toDoListService.GetItemsByIdAsync(id);

                if (toDoItems == null)
                    return NotFound($"No items found for id {id}");

                return Ok(toDoItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retriving todo item by id {id}");
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

                await _toDoListService.CreateAndAddItemAsync(toDoInfo);

                return CreatedAtAction(nameof(GetById), new { id = toDoInfo.Id }, toDoInfo);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Error creating todo item");
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
