using Foundation;
using ShopCourse.Common.Models;
using ShopCourse.Common.Services;
using System;
using UIKit;

namespace ShopCourse.UIClassic.iOS
{
    public partial class ViewController : UIViewController
    {
        private ApiService apiService;
        public ViewController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad ()
        {
            base.ViewDidLoad ();
            this.apiService = new ApiService();
            // Perform any additional setup after loading the view, typically from a nib.
        }

        public override void DidReceiveMemoryWarning ()
        {
            base.DidReceiveMemoryWarning ();
            // Release any cached data, images, etc that aren't in use.
        }

        partial void LoginBtn_TouchUpInside(UIButton sender)
        {
            if (string.IsNullOrEmpty(this.emailField.Text))
            {
                var alert = UIAlertController.Create("Error", "You must enter an email.", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Accept", UIAlertActionStyle.Default, null));
                this.PresentViewController(alert, true, null);
                return;
            }

            if (string.IsNullOrEmpty(this.pwField.Text))
            {
                var alert = UIAlertController.Create("Error", "You must enter a password.", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Accept", UIAlertActionStyle.Default, null));
                this.PresentViewController(alert, true, null);
                return;
            }

            //var ok = UIAlertController.Create("Ok", "Fuck yeah!", UIAlertControllerStyle.Alert);
            //ok.AddAction(UIAlertAction.Create("Accept", UIAlertActionStyle.Default, null));
            //this.PresentViewController(ok, true, null);

            this.DoLogin();
        }

        private async void DoLogin()
        {
            this.activityIndicator.StartAnimating();
            var request = new TokenRequest
            {
                Username = this.emailField.Text,
                Password = this.pwField.Text
            };

            var response = await this.apiService.GetTokenAsync(
                "https://shopbts.azurewebsites.net",
                "/Account",
                "/CreateToken",
                request);

            if (!response.IsSuccess)
            {
                this.activityIndicator.StopAnimating();
                var alert = UIAlertController.Create("Error", "User or password incorrect.", UIAlertControllerStyle.Alert);
                alert.AddAction(UIAlertAction.Create("Accept", UIAlertActionStyle.Default, null));
                this.PresentViewController(alert, true, null);
                return;
            }

            var token = (TokenResponse)response.Result;
            this.activityIndicator.StopAnimating();
            var ok = UIAlertController.Create("Ok", "Fuck yeah!", UIAlertControllerStyle.Alert);
            ok.AddAction(UIAlertAction.Create("Accept", UIAlertActionStyle.Default, null));
            this.PresentViewController(ok, true, null);
        }

    }
}