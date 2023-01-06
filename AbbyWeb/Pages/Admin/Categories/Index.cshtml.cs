
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.Categories
{
    public class IndexModel : PageModel
    {
        // private readonly ApplicationDBContext _db;
       // private readonly ICategoryRepository _dbCategory;
        private readonly IUnitOfWork _unitOfWork;

        public IEnumerable<Category> Categories { get; set; }

      //  public IndexModel(ApplicationDBContext db)
       // public IndexModel(ICategoryRepository dbCategory)
        public IndexModel(IUnitOfWork unitOfWork )
        {
            // _dbCategory = dbCategory;
            _unitOfWork = unitOfWork;
        }

        public void OnGet()
        {
            Categories = _unitOfWork.Category.GetAll();
        }
    }
}
