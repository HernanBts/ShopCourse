namespace ShopCourse.UIForms.ViewModel
{
    public class MainViewModel
    {
        static private MainViewModel instance;

        public LoginViewModel Login { get; set; }

        public ProductsViewModel Products { get; set; }

        public MainViewModel()
        {
            instance = this;
        }

        static public MainViewModel GetInstance()
        {
            if(instance == null)
            {
                return new MainViewModel();
            }

            return instance;
        }
    }
}
