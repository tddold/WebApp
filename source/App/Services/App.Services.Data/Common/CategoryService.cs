using App.Services.Data.Common.Contracts;
using System;
using System.Linq;
using App.Data.Models;
using App.Data.Common.Contracts;

namespace App.Services.Data.Common
{
    public class CategoryService : BaseDataService<Category>, ICategoryService
    {
        private readonly IRepository<Category> category;

        public CategoryService(IRepository<Category> category)
            : base(category)
        {
            this.category = category;
        }
        public bool IsDeleted { get; set; }

        public IQueryable<Category> AllCategory(int count)
        {
            return this.category
                .All
                .OrderBy(a => Guid.NewGuid());
        }

    }
}
