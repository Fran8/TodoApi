//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using TodoApi;

//namespace TodoApi.Controllers
//{
//    [Produces("application/json")]
//    [Route("api/List")]
//    public class ListController : Controller
//    {
//        private readonly TodoContext _context;

//        public ListController(TodoContext context)
//        {
//            _context = context;

//            //if (_context.Lists.Count() == 0)
//            //{
//            //    var list1 = new TodoList { Name = "Compras" };
//            //    _context.Lists.Add(list1);
//            //    _context.SaveChanges();

//            //    _context.Items.Add(new TodoItem { ParentList = list1, Name = "probando" });
//            //    _context.SaveChanges();
//            //}
//        }

//        // GET: api/List
//        [HttpGet]
//        public IEnumerable<TodoList> GetLists()
//        {
//            return _context.Lists;
//        }

//        // GET: api/List/5
//        [HttpGet("{id}")]
//        public async Task<IActionResult> GetTodoList([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var todoList = await _context.Lists.SingleOrDefaultAsync(m => m.Id == id);

//            if (todoList == null)
//            {
//                return NotFound();
//            }

//            return Ok(todoList);
//        }

//        // PUT: api/List/5
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutTodoList([FromRoute] int id, [FromBody] TodoList todoList)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            if (id != todoList.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(todoList).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!TodoListExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/List
//        [HttpPost]
//        public async Task<IActionResult> PostTodoList([FromBody] TodoList todoList)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            _context.Lists.Add(todoList);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetTodoList", new { id = todoList.Id }, todoList);
//        }

//        // DELETE: api/List/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteTodoList([FromRoute] int id)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }

//            var todoList = await _context.Lists.SingleOrDefaultAsync(m => m.Id == id);
//            if (todoList == null)
//            {
//                return NotFound();
//            }

//            _context.Lists.Remove(todoList);
//            await _context.SaveChangesAsync();

//            return Ok(todoList);
//        }

//        private bool TodoListExists(int id)
//        {
//            return _context.Lists.Any(e => e.Id == id);
//        }
//    }
//}