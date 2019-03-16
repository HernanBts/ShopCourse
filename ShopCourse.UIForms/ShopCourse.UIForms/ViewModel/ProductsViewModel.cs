namespace ShopCourse.UIForms.ViewModel
{
    using ShopCourse.Common.Models;
    using ShopCourse.Common.Services;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Xamarin.Forms;

    public class ProductsViewModel : BaseViewModel
    {
        private ApiService apiService;
        private ObservableCollection<Product> products;

        public ObservableCollection<Product> Products
        {
            get { return this.products; }
            set { this.SetValue(ref this.products, value); }
        }

        public ProductsViewModel()
        {
            this.apiService = new ApiService();
            this.LoadProducts();
        }

        private async void LoadProducts()
        {
            var response = await this.apiService.GetListAsync<Product>(
                "https://shopcourse-web.conveyor.cloud",
                "/api",
                "/Products");

            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    response.Message,
                    "OK");
                return;
            }

            var myProducts = (List<Product>)response.Result;

            this.Products = new ObservableCollection<Product>(myProducts);
        }
    }
}
