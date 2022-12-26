
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;
[BindProperties]

public class EditModel : PageModel
{
    private readonly ApplicationDBContext _db;
    [BindProperty]
    public FoodType FoodType { get; set; }

    public EditModel(ApplicationDBContext db)
    {
        _db = db;

    }

    public void OnGet(int id)
    {
        FoodType = _db.FoodType.Find(id);
        //we can do the same thing with following type
        //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        //Category = _db.Category.SingleOrDefault(u => u.Id == id);
        //Category = _db.Category.where(u=>u.Id==id).FirstOrDefault();

    }
    public async Task<IActionResult> Onpost()
    {
        if (ModelState.IsValid)
        {
            


                _db.FoodType.Update(FoodType);
                await _db.SaveChangesAsync();
            TempData["Success"] = "Category Updated Successfully";

            return RedirectToPage("Index");
        }
        return Page();
    }
}

