
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;
[BindProperties]

    public class DeleteModel : PageModel
    {
    private readonly IUnitOfWork _unitOfWork;


    public FoodType FoodType { get; set; }

    //public CreateModel(ApplicationDBContext db)
    public DeleteModel(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;

    }

    public void OnGet(int id)
        {
        FoodType= _unitOfWork.FoodType.GetFirstOrDefault(u=>u.Id==id);
//        FoodType = _unitOfWork.FoodType.GetFirstOrDefault(u=>u.Id==id);
        //we can do the same thing with following type
        //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        //Category = _db.Category.SingleOrDefault(u => u.Id == id);
        //Category = _db.Category.where(u=>u.Id==id).FirstOrDefault();

    }
        public  async Task<IActionResult> Onpost()
        {
       
            var foodTypeFromDb= _unitOfWork.FoodType.GetFirstOrDefault(u => u.Id == FoodType.Id);
        if (foodTypeFromDb!=null)
            {
            _unitOfWork.FoodType.Remove(foodTypeFromDb);
            _unitOfWork.Save();
            TempData["Success"] = "FoodType Deleted Successfully";
            return RedirectToPage("Index");
        }
        return Page();
            
        }
    }

