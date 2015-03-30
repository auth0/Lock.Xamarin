// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace Lock.Xamarin.Sample
{
	[Register ("Lock_Xamarin_SampleViewController")]
	partial class Lock_Xamarin_SampleViewController
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel JWTLabel { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UIButton ShowLockButton { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel WelcomeLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (JWTLabel != null) {
				JWTLabel.Dispose ();
				JWTLabel = null;
			}
			if (ShowLockButton != null) {
				ShowLockButton.Dispose ();
				ShowLockButton = null;
			}
			if (WelcomeLabel != null) {
				WelcomeLabel.Dispose ();
				WelcomeLabel = null;
			}
		}
	}
}
