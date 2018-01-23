using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;
using SicherheitCore.Models.Requests;
using SicherheitCore.Repository.SqlConcret;
using SicherheitCore.Services;
using SicherheitCore.Services.Abstract;

namespace SicherheitCore.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        // GET: Tasks
        public IActionResult Index()
        {
            var modelTasks = _taskService.GetAll();
            if(modelTasks == null) { 
}
            return View(_taskService.GetAll());
        }

        // GET: Tasks/Details/5
        public IActionResult Details(Guid? id)
        {
            var taskId = id.GetValueOrDefault();
            if (taskId == null)
            {
                throw new ArgumentNullException("No task ID!");
            }

            var task = _taskService.GetTask(taskId);
            if (task == null)
            {
                throw new Exception("Internal error exception!");
            }

            return View(task);
        }

        
        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }
        
        // POST: Tasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTaskRequest request)
        {
            if (ModelState.IsValid)
            {
                Task task = new Task();
                task.Title = request.Title;
                task.Priority = request.Priority;
                task.Deadline = request.Deadline;
                task.Description = request.Description;
                var userId = _userService.CurrentUser().Id;
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }
        /*
        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.SingleOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        // POST: Tasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("UserId,Title,Description,Deadline,Type,Priority,Id,UpdatedAt,CreatedAt")] Models.Task task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(task);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskExists(task.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            return View(task);
        }
        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var task = await _context.Tasks.SingleOrDefaultAsync(m => m.Id == id);
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskExists(Guid id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }*/
    }
}
