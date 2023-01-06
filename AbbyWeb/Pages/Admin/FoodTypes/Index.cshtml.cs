
using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public IEnumerable<FoodType> FoodType { get; set; }

        //public CreateModel(ApplicationDBContext db)
        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

        }

        public void OnGet()
        {
            FoodType = _unitOfWork.FoodType.GetAll();
        }
    }
}
