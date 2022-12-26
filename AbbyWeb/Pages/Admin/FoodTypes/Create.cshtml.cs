
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes;
[BindProperties]

    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public FoodType FoodType { get; set; }

        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
           
        }

        public void OnGet()
        {

        }
        public  async Task<IActionResult> Onpost()
        {
       
            await _db.FoodType.AddAsync(FoodType);
        TempData["Success"] = "Record Insert Sucessfully";
            await _db.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }

