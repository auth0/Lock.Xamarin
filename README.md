# Lock

[Auth0](https://auth0.com) is an authentication broker that supports social identity providers as well as enterprise identity providers such as Active Directory, LDAP, Google Apps and Salesforce.

Lock makes it easy to integrate SSO in your app. You won't have to worry about:

* Having a professional looking login dialog that displays well on any device.
* Finding the right icons for popular social providers.
* Solving the home realm discovery challenge with enterprise users (i.e.: asking the enterprise user the email, and redirecting to the right enterprise identity provider).
* Implementing a standard sign in protocol (OpenID Connect / OAuth2 Login)

## Key features

* **Integrates** your iOS app with **Auth0** (OS X coming soon).
* Provides a **beautiful native UI** to log your users in.
* Provides support for **Social Providers** (Facebook, Twitter, etc.), **Enterprise Providers** (AD, LDAP, etc.) and **Username & Password**.
* Provides the ability to do **SSO** with 2 or more mobile apps similar to Facebook and Messenger apps.
* Passwordless authentication using **TouchID** and **SMS**.

## Requierements

iOS 7+. If you need to use it in an earlier version or in Android please use [Xamarin.Auth0Client](https://github.com/auth0/Xamarin.Auth0Client).

## Install

First you'll need to download the Objetive-C binding project from here: [Lock.Xamarin](https://github.com/auth0/Lock.Xamarin/releases/download/1.0.0/Lock.Xamarin.zip) and unzip it inside your project's folder.

The next step is to import the project to your app's solution, just open it in Xamarin Studio and right-click on the solution, `Add > Add Existing Project...` and select the file `Lock.Xamarin.iOS.csproj`. Then edit your app's project references and add the recently added `Lock.Xamarin.iOS` project.

After adding Lock to your project, its time to configure it for your iOS app, in your project's `Info.plist` file add the following entries:

* __Auth0ClientId__: The client ID of your application in __Auth0__.
* __Auth0Domain__: Your account's domain in __Auth0__.

> You can find these values in your app's settings in [Auth0 dashboard](https://app.auth0.com/#/applications).

For example:

[![Auth0 plist](http://assets.auth0.com/mobile-sdk-lock/example-plist.png)](http://auth0.com)

Also you need to register a Custom URL type, it must have a custom scheme with the following format `a0<Your Client ID>`. For example if your Client ID is `Exe6ccNagokLH7mBmzFejP` then the custom scheme should be `a0Exe6ccNagokLH7mBmzFejP`.

Then you'll need to handle that custom scheme, so in your `AppDelegate.cs` import Lock

```c#
using Auth0.iOS;
```

and override the following method:

```c#
public override Boolean OpenUrl (UIApplication application, Foundation.NSUrl url, string sourceApplication, Foundation.NSObject annotation) {
  return A0IdentityProviderAuthenticator.SharedInstance.HandleURL (url, sourceApplication);
}
```

> This is required to be able to return back to your application when authenticating with Safari (or native integration with FB or Twitter if used). This call checks the URL and handles all that have the custom scheme defined before.

## Usage

### Email/Password, Enterprise & Social authentication

`A0LockViewController` will handle Email/Password, Enterprise & Social authentication based on your Application's connections enabled in your Auth0's Dashboard.

First instantiate `A0LockViewController` and register the authentication callback that will receive the authenticated user's credentials. Finally present it as a modal view controller:

```c#
A0AuthenticationBlock authenticationAction = (profile, token) => {
  Console.WriteLine ("Logged in with user " + profile.Name);
};
var controller = new A0LockViewController ();
controller.Closable = true;
controller.OnAuthenticationBlock = authenticationAction;
this.PresentViewController (controller, true, null);
```
And you'll see our native login screen

[![Lock.png](http://blog.auth0.com.s3.amazonaws.com/Lock-Widget-Screenshot.png)](https://auth0.com)

> By default all social authentication will be done using Safari, if you want native integration please check this [wiki page](https://github.com/auth0/Lock.Xamarin/wiki/Native-Social-Authentication).

Also you can check our [Example App](https://github.com/auth0/Lock.Xamarin/tree/master/iOS/Sample)

### TouchID

`A0TouchIDLockViewController` authenticates without using a password with TouchID. In order to be able to authenticate the user, your application must have a Database connection enabled.

First instantiate `A0TouchIDLockViewController` and register the authentication callback that will receive the authenticated user's credentials. Finally present it as a modal view controller embedded in a UINavigationController:
```c#
A0AuthenticationBlock authenticationAction = (profile, token) => {
  Console.WriteLine ("Logged in with user " + profile.Name);
};
var touchID = new A0TouchIDLockViewController();
touchID.Closable = true;
touchID.OnAuthenticationBlock = authenticationAction;
var navigation = new UINavigationController(touchID);
this.PresentViewController (navigation, true, null);
```
And you'll see TouchID login screen

[![Lock.png](http://blog.auth0.com.s3.amazonaws.com/Lock-TouchID-Screenshot.png)](https://auth0.com)

> Because it uses a Database connection, the user can change it's password and authenticate using email/password whenever needed. For example when you change your device.

### SMS

`A0SMSLockViewController` authenticates without using a password with SMS. In order to be able to authenticate the user, your application must have the SMS connection enabled and configured in your [dashboard](https://app.auth0.com/#/connections/passwordless).

First instantiate `A0SMSLockViewController` and register the authentication callback that will receive the authenticated user's credentials.

The next step is register a block to return an API Token used to register the  phone number and send the login code with SMS. This token can be generated in  [Auth0 API v2 page](https://docs.auth0.com/apiv2), just select the scope `create:users` and copy the generated API Token.

Finally present it as a modal view controller embedded in a UINavigationController:
```c#
A0AuthenticationBlock authenticationAction = (profile, token) => {
  Console.WriteLine ("Logged in with user " + profile.Name);
};
var sms = new A0SMSLockViewController();
sms.Closable = true;
sms.Auth0APIToken = () => (NSString) "API V2 TOKEN";
sms.OnAuthenticationBlock = authenticationAction;
var navigation = new UINavigationController(sms);
this.PresentViewController (navigation, true, null);
```
And you'll see SMS login screen

[![Lock.png](http://blog.auth0.com.s3.amazonaws.com/Lock-SMS-Screenshot.png)](https://auth0.com)

## Issue Reporting

If you have found a bug or if you have a feature request, please report them at this repository issues section. Please do not report security vulnerabilities on the public GitHub issue tracker. The [Responsible Disclosure Program](https://auth0.com/whitehat) details the procedure for disclosing security issues.

## What is Auth0?

Auth0 helps you to:

* Add authentication with [multiple authentication sources](https://docs.auth0.com/identityproviders), either social like **Google, Facebook, Microsoft Account, LinkedIn, GitHub, Twitter, Box, Salesforce, amont others**, or enterprise identity systems like **Windows Azure AD, Google Apps, Active Directory, ADFS or any SAML Identity Provider**.
* Add authentication through more traditional **[username/password databases](https://docs.auth0.com/mysql-connection-tutorial)**.
* Add support for **[linking different user accounts](https://docs.auth0.com/link-accounts)** with the same user.
* Support for generating signed [Json Web Tokens](https://docs.auth0.com/jwt) to call your APIs and **flow the user identity** securely.
* Analytics of how, when and where users are logging in.
* Pull data from other sources and add it to the user profile, through [JavaScript rules](https://docs.auth0.com/rules).

## Create a free account in Auth0

1. Go to [Auth0](https://auth0.com) and click Sign Up.
2. Use Google, GitHub or Microsoft Account to login.

## Author

Auth0

## License

Lock is available under the MIT license. See the [LICENSE file](LICENSE) for more info.
