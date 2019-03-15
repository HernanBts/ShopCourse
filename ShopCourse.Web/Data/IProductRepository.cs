namespace ShopCourse.Web.Data
{
    using ShopCourse.Web.Data.Entities;
    using System.Linq;

    public interface IProductRepository : IGenericRepository<Product>
    {
        IQueryable GetAllWithUsers();
    }
}
