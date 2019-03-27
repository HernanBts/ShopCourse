﻿namespace ShopCourse.UIForms.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using ShopCourse.Common.Models;
    using ShopCourse.UIForms.Views;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    public class MainViewModel
    {
        private static MainViewModel instance;

        public LoginViewModel Login { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public ProductsViewModel Products { get; set; }

        public EditProductViewModel EditProduct { get; set; }

        public TokenResponse Token { get; set; }

        public ObservableCollection<MenuItemViewModel> Menus { get; set; }

        public AddProductViewModel AddProduct { get; set; }

        public ICommand AddProductCommand => new RelayCommand(this.GoAddProduct);


        public MainViewModel()
        {
            instance = this;
            this.LoadMenus();
        }

        private async void GoAddProduct()
        {
            this.AddProduct = new AddProductViewModel();
            await App.Navigator.PushAsync(new AddProductPage());
        }

        private void LoadMenus()
        {
            var menus = new List<Menu>
            {
                new Menu
                {
                    Icon = "ic_info_outline",
                    PageName = "AboutPage",
                    Title = "About"
                },

                new Menu
                {
                    Icon = "ic_settings",
                    PageName = "SetupPage",
                    Title = "Setup"
                },

                new Menu
                {
                    Icon = "ic_exit_to_app",
                    PageName = "LoginPage",
                    Title = "Close session"
                }
             };


            this.Menus = new ObservableCollection<MenuItemViewModel>(
                menus.Select(m => new MenuItemViewModel
                {
                    Icon = m.Icon,
                    PageName = m.PageName,
                    Title = m.Title
                }).ToList());
        }


        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }


    }
}
