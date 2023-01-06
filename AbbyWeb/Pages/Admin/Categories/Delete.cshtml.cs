
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
                                               
namespace AbbyWeb.Pages.Admin.Categories;
[BindProperties]

    public class DeleteModel : PageModel
    {
    //private readonly ApplicationDBContext _db;
    private readonly IUnitOfWork _unitOfWork;

    [BindProperty]
        public Category Category { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
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
        public  async Task<IActionResult> Onpost()
        {
       
          //  var categoryFromDb=_db.Category.Find(Category.Id);
        var categoryFromDb = _unitOfWork.Category.GetFirstOrDefault(u => u.Id == Category.Id);
        if (categoryFromDb!=null)
            {


            // _db.Category.Remove(categoryFromDb);
            _unitOfWork.Category.Remove(categoryFromDb);
            //await _db.SaveChangesAsync();
             _unitOfWork.Save();
            TempData["Success"] = "Record Deleted Successfully";
            return RedirectToPage("Index");
        }
        return Page();
            
        }
    }

