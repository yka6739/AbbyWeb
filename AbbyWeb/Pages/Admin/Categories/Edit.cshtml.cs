
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories;
[BindProperties]

public class EditModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
   // private readonly ApplicationDBContext _db;
    [BindProperty]
    public Category Category { get; set; }

  //  public EditModel(ApplicationDBContext db)
    public EditModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }

    public void OnGet(int id)
    {
       // Category = _db.Category.Find(id);
        Category = _unitOfWork.Category.GetFirstOrDefault(u=>u.Id==id);
        //we can do the same thing with following type
        //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        //Category = _db.Category.SingleOrDefault(u => u.Id == id);
        //Category = _db.Category.where(u=>u.Id==id).FirstOrDefault();

    }
    public async Task<IActionResult> Onpost()
    {
        if (ModelState.IsValid)
        {



            // _db.Category.Update(Category);
            _unitOfWork.Category.Update(Category);
                _unitOfWork.Save();
                //await _db.SaveChangesAsync();
            TempData["Success"] = "Category Updated Successfully";

            return RedirectToPage("Index");
        }
        return Page();
    }
}

