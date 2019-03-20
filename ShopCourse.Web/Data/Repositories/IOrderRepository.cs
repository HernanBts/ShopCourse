namespace ShopCourse.Web.Data.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using ShopCourse.Web.Models;

    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<Order> GetOrdersAsync(int id);

        Task<IQueryable<Order>> GetOrdersAsync(string userName);

        Task DeliverOrder(DeliverViewModel model);

        Task<IQueryable<OrderDetailTemp>> GetDetailTempsAsync(string userName);

        Task AddItemToOrderAsync(AddItemViewModel model, string userName);

        Task ModifyOrderDetailTempQuantityAsync(int id, double quantity);

        Task DeleteDetailTempAsync(int id);

        Task<bool> ConfirmOrderAsync(string userName);

    }
}
