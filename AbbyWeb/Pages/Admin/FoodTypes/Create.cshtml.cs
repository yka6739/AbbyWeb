
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;
[BindProperties]

    public class CreateModel : PageModel
    {
    private readonly IUnitOfWork _unitOfWork;

    [BindProperty]
    public FoodType FoodType { get; set; }

        //public CreateModel(ApplicationDBContext db)
        public CreateModel(IUnitOfWork unitOfWork)
        {
        _unitOfWork = unitOfWork;
           
        }

        public void OnGet()
        {

        }
        public  async Task<IActionResult> Onpost()
        {

        if (ModelState.IsValid)
        {
            _unitOfWork.FoodType.Add(FoodType);
            _unitOfWork.Save();
            
       
      //  await _db.FoodType.AddAsync(FoodType);
       // await _db.FoodType.AddAsync(FoodType);
        TempData["Success"] = "Food Type Created  Sucessfully";
           // await _db.SaveChangesAsync();
             
            return RedirectToPage("Index");
        }
        return Page();
    }

    }

