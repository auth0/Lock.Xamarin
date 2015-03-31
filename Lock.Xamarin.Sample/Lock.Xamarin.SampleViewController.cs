using System;
using System.Drawing;

using Foundation;
using UIKit;
using Auth0;

namespace Lock.Xamarin.Sample
{
	public partial class Lock_Xamarin_SampleViewController : UIViewController
	{
		public Lock_Xamarin_SampleViewController (IntPtr handle) : base (handle)
		{
		}
		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Action clearAction = () => {
				JWTLabel.Font = UIFont.ItalicSystemFontOfSize (17);
				JWTLabel.Text = "Please login first to get a JWT token";
				WelcomeLabel.Text = "Welcome to Lock Xamarin";
			};
			A0AuthenticationBlock authenticationAction = (profile, token) => {
				Console.WriteLine ("Logged in with user " + profile.Name);
				WelcomeLabel.Text = "Welcome " + profile.Name;
				JWTLabel.Font = UIFont.SystemFontOfSize (17);
				JWTLabel.Text = token.IdToken;
				this.DismissViewController (true, null);
			};
			clearAction ();
			ShowLockButton.TouchUpInside += (object sender, EventArgs e) => {
				var controller = new A0LockViewController ();
				controller.Closable = true;
				controller.OnAuthenticationBlock = authenticationAction;
				controller.OnUserDismissBlock = clearAction;
				this.PresentViewController(controller, true, null);
			};
			ShowTouchIDButton.TouchUpInside += (object sender, EventArgs e) => {
				var touchID = new A0TouchIDLockViewController();
				touchID.Closable = true;
				touchID.OnAuthenticationBlock = authenticationAction;
				var navigation = new UINavigationController(touchID);
				this.PresentViewController(navigation, true, null);
			};
			ShowSMSButton.TouchUpInside += (object sender, EventArgs e) => {
				var sms = new A0SMSLockViewController();
				sms.Closable = true;
				sms.Auth0APIToken = () => (NSString) NSBundle.MainBundle.InfoDictionary["Auth0SMSToken"];
				sms.OnAuthenticationBlock = authenticationAction;
				var navigation = new UINavigationController(sms);
				this.PresentViewController(navigation, true, null);
			};
		}
		#endregion
	}
}

