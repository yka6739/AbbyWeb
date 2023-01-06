
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;
[BindProperties]

public class EditModel : PageModel
{
    private readonly IUnitOfWork _unitOfWork;
    [BindProperty]
    public FoodType FoodType { get; set; }

    public EditModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork= unitOfWork;

    }


    public void OnGet(int id)
    {
        FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == id);
        //we can do the same thing with following type
        //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        //Category = _db.Category.SingleOrDefault(u => u.Id == id);
        //Category = _db.Category.where(u=>u.Id==id).FirstOrDefault();

    }
    public async Task<IActionResult> Onpost()
    {
        if (ModelState.IsValid)
        {
            


                _unitOfWork.FoodType.Update(FoodType);
            _unitOfWork.Save();
            TempData["Success"] = "Category Updated Successfully";

            return RedirectToPage("Index");
        }
        return Page();
    }
}

