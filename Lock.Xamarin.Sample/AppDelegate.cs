using System;
using System.Linq;
using System.Collections.Generic;

using Foundation;
using UIKit;
using Auth0;

namespace Lock.Xamarin.Sample
{
	// The UIApplicationDelegate for the application. This class is responsible for launching the
	// User Interface of the application, as well as listening (and optionally responding) to
	// application events from iOS.
	[Register ("AppDelegate")]
	public partial class AppDelegate : UIApplicationDelegate
	{
		// class-level declarations
		
		public override UIWindow Window {
			get;
			set;
		}

		public override void FinishedLaunching(UIApplication application) {
			var authenticator = A0IdentityProviderAuthenticator.SharedInstance ();
			var facebook = A0FacebookAuthenticator.NewAuthenticatorWithDefaultPermissions();
			authenticator.RegisterAuthenticationProviders (new [] { facebook });
		}


		public override Boolean OpenUrl (UIApplication application, Foundation.NSUrl url, string sourceApplication, Foundation.NSObject annotation) {
			return A0IdentityProviderAuthenticator.SharedInstance ().HandleURL (url, sourceApplication);
		}
	}
}

