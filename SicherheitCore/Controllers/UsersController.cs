using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SicherheitCore.Models;
using SicherheitCore.Models.Requests;
using SicherheitCore.Repository.SqlConcret;
using SicherheitCore.Services;

namespace SicherheitCore.Controllers
{

    ////[Authorize(Roles = "Admin")]
    ////[Route("users")]
    //public class UsersController : Controller
    //{
    //    private readonly IUserService _userService;

    //    public UsersController(IUserService userService)
    //    {
    //        _userService = userService;
    //    }
       
    //    //[HttpGet]
    //    public async Task<IActionResult> Index()
    //    {
    //        return View(await _userService.GetUsers());
    //    }
        
    //    //[HttpGet("id")]
    //    public async Task<IActionResult> Details(Guid? id)
    //    {
    //        var userId = id.GetValueOrDefault();
    //        if (userId == null)
    //        {
    //            return NotFound();
    //        }
    //        var user = await _userService.GetUser(userId);
    //        if (user == null)
    //        {
    //            return NotFound();
    //        }
    //        return View(user);
    //    }

    //    //[HttpGet("users/create")]
    //    public IActionResult Create()
    //    {
    //        return View();
    //    }

    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create(RegisterOrUpdateUserRequest request)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            var user = new User();
    //            user.EmailAddress = request.Email;
    //            user.Password = request.Password;
    //            user.Name = request.Name;
    //            user.IsActive = true;
    //            await _userService.Register(request.Email, request.Password, request.Name);
    //            return RedirectToAction(nameof(Index));
    //        }
    //        return View(request);
    //    }

    //    // GET: Users/Edit/5
    //    //public async Task<IActionResult> Edit(Guid? id)
    //    //{
    //    //    if (id == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
    //    //    if (user == null)
    //    //    {
    //    //        return NotFound();
    //    //    }
    //    //    return View(user);
    //    //}

    //    // POST: Users/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    //[HttpPost]
    //    //[ValidateAntiForgeryToken]
    //    //public async Task<IActionResult> Edit(Guid id, [Bind("EmailAddress,EncryptPassword,IsActive,Name,Id,UpdatedAt,CreatedAt")] User user)
    //    //{
    //    //    if (id != user.Id)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    if (ModelState.IsValid)
    //    //    {
    //    //        try
    //    //        {
    //    //            _context.Update(user);
    //    //            await _context.SaveChangesAsync();
    //    //        }
    //    //        catch (DbUpdateConcurrencyException)
    //    //        {
    //    //            if (!UserExists(user.Id))
    //    //            {
    //    //                return NotFound();
    //    //            }
    //    //            else
    //    //            {
    //    //                throw;
    //    //            }
    //    //        }
    //    //        return RedirectToAction(nameof(Index));
    //    //    }
    //    //    return View(user);
    //    //}

    //    // GET: Users/Delete/5
    //    //public async Task<IActionResult> Delete(Guid? id)
    //    //{
    //    //    if (id == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    var user = await _context.Users
    //    //        .SingleOrDefaultAsync(m => m.Id == id);
    //    //    if (user == null)
    //    //    {
    //    //        return NotFound();
    //    //    }

    //    //    return View(user);
    //    //}

    //    // POST: Users/Delete/5
    //    //[HttpPost, ActionName("Delete")]
    //    //[ValidateAntiForgeryToken]
    //    //public async Task<IActionResult> DeleteConfirmed(Guid id)
    //    //{
    //    //    var user = await _context.Users.SingleOrDefaultAsync(m => m.Id == id);
    //    //    _context.Users.Remove(user);
    //    //    await _context.SaveChangesAsync();
    //    //    return RedirectToAction(nameof(Index));
    //    //}

    //    //private bool UserExists(Guid id)
    //    //{
    //    //    return _context.Users.Any(e => e.Id == id);
    //    //}
    //}
}
