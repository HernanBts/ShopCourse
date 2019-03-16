namespace ShopCourse.UIForms.Infrastructure
{
    using ShopCourse.UIForms.ViewModel;

    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}