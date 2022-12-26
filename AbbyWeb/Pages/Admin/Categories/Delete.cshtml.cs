
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories;
[BindProperties]

    public class DeleteModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(ApplicationDBContext db)
        {
            _db = db;
           
        }

        public void OnGet(int id)
        {
        Category = _db.Category.Find(id);
        //we can do the same thing with following type
        //Category = _db.Category.FirstOrDefault(u=>u.Id==id);
        //Category = _db.Category.SingleOrDefault(u => u.Id == id);
        //Category = _db.Category.where(u=>u.Id==id).FirstOrDefault();

    }
        public  async Task<IActionResult> Onpost()
        {
       
            var categoryFromDb=_db.Category.Find(Category.Id);
            if(categoryFromDb!=null)
            {

           
            _db.Category.Remove(categoryFromDb);
            await _db.SaveChangesAsync();
            TempData["Success"] = "Record Deleted Successfully";
            return RedirectToPage("Index");
        }
        return Page();
            
        }
    }

