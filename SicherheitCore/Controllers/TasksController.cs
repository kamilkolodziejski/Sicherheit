using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;
using SicherheitCore.Models.Requests;
using SicherheitCore.Services;
using SicherheitCore.Services.Abstract;

namespace SicherheitCore.Controllers
{
    public class TasksController : Controller
    {
        private readonly ITaskService _taskService;
        private readonly IUserService _userService;

        public TasksController(ITaskService taskService, IUserService userService)
        {
            _taskService = taskService;
            _userService = userService;
        }

        // GET: Tasks
        public async Task<IActionResult> Index()
        {
            Guid? id = _userService.CurrentUser().Id;
            if (id == null)
                throw new ArgumentNullException();
            var tasks = await _taskService.GetUserTasks(id.Value);
            return View(tasks);
        }

        // GET: Tasks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var taskId = id.GetValueOrDefault();
            if (taskId == null)
                throw new ArgumentNullException("Internal error exception!");
            var task = await _taskService.GetTaskAndUser(taskId);
            if (task == null)
                throw new Exception("No existing task for this ID!");
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
        public async Task<IActionResult> Create(CreateOrUpdateTaskRequest request)
        {
            if (ModelState.IsValid)
            {
                PlannedTask task = await _taskService.CreateTask(request);
                return RedirectToAction(nameof(Index));
            }
            return View("Details",request);
        }
        
        // GET: Tasks/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null || !id.HasValue)
            {
                return NotFound();
            }
            var task = _taskService.GetTaskAndUser(id.Value);
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
        public async Task<IActionResult> Edit(Guid id, [Bind("UserId,Title,Description,Deadline,Type,Priority,Id,UpdatedAt,CreatedAt")] PlannedTask task)
        {
            if (id != task.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _taskService.Update(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(Guid id)
        {
            if (id == null)
            {
                return NotFound();
            }

            await _taskService.Delete(id);

            return View();
        }
        // POST: Tasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _taskService.Delete(id);
            return RedirectToAction(nameof(Index));
        }
     }
}
