namespace ShopCourse.UIForms.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using ShopCourse.UIForms.Views;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public ICommand LoginCommand => new RelayCommand(this.Login);

        public LoginViewModel()
        {
            this.Email = "admin@shop.com";
            this.Password = "admin";
        }
        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "You must enter an email", "Accept");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "You must enter a password", "Accept");
                return;
            }

            if (!this.Email.Equals("admin@shop.com") || !this.Password.Equals("admin"))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", "Incorrect user or password", "Accept");
                return;
            }

            //await Application.Current.MainPage.DisplayAlert(
            //    "Success", "Fuck yeah!!!", "Accept");

            MainViewModel.GetInstance().Products = new ProductsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new ProductsPage());
        }
    }
}
