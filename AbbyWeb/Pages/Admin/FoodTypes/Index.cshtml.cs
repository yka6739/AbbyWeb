
using Abby.DataAccess.Data;
using Abby.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AbbyWeb.Pages.Admin.FoodTypes
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _db;

        public IEnumerable<FoodType> FoodTypes { get; set; }

        public IndexModel(ApplicationDBContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
            FoodTypes = _db.FoodType;
        }
    }
}
