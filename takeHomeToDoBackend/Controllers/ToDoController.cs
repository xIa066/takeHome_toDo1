using Microsoft.AspNetCore.Mvc;
using takeHome_toDo.Server;
using ToDoApi.Services;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDosController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(ToDoManager.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var todo = ToDoManager.Get(id);
            if (todo != null)
                return Ok(todo);
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create(ToDo todo)
        {
            var createdTodo = ToDoManager.Add(todo);
            return CreatedAtAction(nameof(Get), new { id = createdTodo.Id }, createdTodo);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, ToDo todo)
        {
            if (id != todo.Id)
                return BadRequest("ToDo ID mismatch");

            var existingToDo = ToDoManager.Get(id);
            if (existingToDo == null)
                return NotFound();

            ToDoManager.Update(todo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var success = ToDoManager.Delete(id);
            if (success)
                return NoContent();
            return NotFound();
        }
    }
}
