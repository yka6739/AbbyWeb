using Abby.DataAccess.Data;
using Abby.DataAccess.Repository.IRepository;
using Abby.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abby.DataAccess.Repository
{
    public class CategoryRepository :Repository<Category>, ICategoryRepository
    {
        private readonly ApplicationDBContext _db;
        public CategoryRepository(ApplicationDBContext db):base(db)
        {
            _db = db;
        }

        //public void Save()
        //{
        //    _db.SaveChanges();
        //}

        public void Update(Category category)
        {
            var ObjFromDb = _db.Category.FirstOrDefault(u => u.Id == category.Id);

            if (ObjFromDb != null)
            {
                ObjFromDb.Name = category.Name;
                ObjFromDb.DisplayOrder = category.DisplayOrder;

            }
        }
    }
}
