namespace ShopCourse.Web.Data.Repositories
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using ShopCourse.Web.Data.Entities;
    using System.Collections.Generic;
    using System.Linq;

    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboProducts();
    }
}
