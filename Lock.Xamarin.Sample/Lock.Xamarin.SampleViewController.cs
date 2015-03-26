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

		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}

		#region View lifecycle

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
		}

		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}

		public override void ViewDidDisappear (bool animated)
		{
			base.ViewDidDisappear (animated);
		}


		partial void UIButton5_TouchUpInside (UIButton sender)
		{
			var controller = new A0LockViewController ();
			controller.Closable = true;
			controller.OnAuthenticationBlock = (profile, token) => {
				Console.WriteLine ("Logged in with user " + profile.Name);
				this.DismissViewController (true, null);
			};
			this.PresentViewController(controller, true, null);
		}
		#endregion
	}
}

