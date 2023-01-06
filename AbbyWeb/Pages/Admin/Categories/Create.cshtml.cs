
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories;
[BindProperties]

    public class CreateModel : PageModel
    {
    //  private readonly ApplicationDBContext _db;
    // private readonly ICategoryRepository _dbCategory;
    private readonly IUnitOfWork _unitOfWork;
    [BindProperty]
        public Category Category { get; set; }

        //public CreateModel(ApplicationDBContext db)
        //public CreateModel(ICategoryRepository dbCategory)
        public CreateModel(IUnitOfWork unitOfWork)
        {
        // _db = db;
        _unitOfWork = unitOfWork;
           
        }

        public void OnGet()
        {

        }
        public  async Task<IActionResult> Onpost()
        {
        if(Category.Name==Category.DisplayOrder.ToString())
        {
            ModelState.AddModelError(string.Empty, "The DisplayOrder cannot exactly math the name.");
        }
        if(ModelState.IsValid)
        {
            _unitOfWork.Category.Add(Category);
            _unitOfWork.Save();
           // await _db.Category.AddAsync(Category);
           // _dbCategory.Add(Category);
        //TempData["Success"] = "Record Insert Sucessfully";
           // await _db.SaveChangesAsync();
           // _dbCategory.Save();
            TempData["Success"] = "Record Insert Sucessfully";
            return RedirectToPage("Index");
        }
        return Page();
        
        }
    }

