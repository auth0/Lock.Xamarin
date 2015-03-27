﻿using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Auth0
{
	// @protocol A0APIRouter <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface A0APIRouter
	{
		// @required @property (readonly, nonatomic) NSString * clientId;
		[Export ("clientId")]
		string ClientId { get; }

		// @required @property (readonly, nonatomic) NSString * tenant;
		[Export ("tenant")]
		string Tenant { get; }

		// @required @property (readonly, nonatomic) NSURL * endpointURL;
		[Export ("endpointURL")]
		NSUrl EndpointURL { get; }

		// @required @property (readonly, nonatomic) NSURL * configurationURL;
		[Export ("configurationURL")]
		NSUrl ConfigurationURL { get; }

		// @required -(void)configureWithBundleInfo:(NSDictionary *)bundleInfo;
		[Abstract]
		[Export ("configureWithBundleInfo:")]
		void ConfigureWithBundleInfo (NSDictionary bundleInfo);

		// @required -(void)configureForDomain:(NSString *)domain clientId:(NSString *)clientId;
		[Abstract]
		[Export ("configureForDomain:clientId:")]
		void ConfigureForDomain (string domain, string clientId);

		// @required -(void)configureForDomain:(NSString *)domain configurationDomain:(NSString *)configurationDomain clientId:(NSString *)clientId;
		[Abstract]
		[Export ("configureForDomain:configurationDomain:clientId:")]
		void ConfigureForDomain (string domain, string configurationDomain, string clientId);

		// @required -(void)configureForTenant:(NSString *)tenant clientId:(NSString *)clientId;
		[Abstract]
		[Export ("configureForTenant:clientId:")]
		void ConfigureForTenant (string tenant, string clientId);

		// @required -(NSString *)loginPath;
		[Abstract]
		[Export ("loginPath")]
		string LoginPath { get; }

		// @required -(NSString *)signUpPath;
		[Abstract]
		[Export ("signUpPath")]
		string SignUpPath { get; }

		// @required -(NSString *)changePasswordPath;
		[Abstract]
		[Export ("changePasswordPath")]
		string ChangePasswordPath { get; }

		// @required -(NSString *)socialLoginPath;
		[Abstract]
		[Export ("socialLoginPath")]
		string SocialLoginPath { get; }

		// @required -(NSString *)userInfoPath;
		[Abstract]
		[Export ("userInfoPath")]
		string UserInfoPath { get; }

		// @required -(NSString *)tokenInfoPath;
		[Abstract]
		[Export ("tokenInfoPath")]
		string TokenInfoPath { get; }

		// @required -(NSString *)delegationPath;
		[Abstract]
		[Export ("delegationPath")]
		string DelegationPath { get; }

		// @required -(NSString *)unlinkPath;
		[Abstract]
		[Export ("unlinkPath")]
		string UnlinkPath { get; }

		// @required -(NSString *)usersPath;
		[Abstract]
		[Export ("usersPath")]
		string UsersPath { get; }

		// @required -(NSString *)userPublicKeyPathForUser:(NSString *)userId;
		[Abstract]
		[Export ("userPublicKeyPathForUser:")]
		string UserPublicKeyPathForUser (string userId);
	}

	// typedef void (^A0APIClientFetchAppInfoSuccess)(A0Application *);
	delegate void A0APIClientFetchAppInfoSuccess (A0Application application);

	// typedef void (^A0APIClientAuthenticationSuccess)(A0UserProfile *A0Token *);
	delegate void A0APIClientAuthenticationSuccess (A0UserProfile profile, A0Token token);

	// typedef void (^A0APIClientUserProfileSuccess)(A0UserProfile *);
	delegate void A0APIClientUserProfileSuccess (A0UserProfile profile);

	// typedef void (^A0APIClientError)(NSError *);
	delegate void A0APIClientError (NSError error);

	// typedef void (^A0APIClientNewIdTokenSuccess)(A0Token *);
	delegate void A0APIClientNewIdTokenSuccess (A0Token token);

	// typedef void (^A0APIClientNewDelegationTokenSuccess)(NSDictionary *);
	delegate void A0APIClientNewDelegationTokenSuccess (NSDictionary payload);

	// typedef void (^A0APIClientDelegationSuccess)(A0Token *);
	delegate void A0APIClientDelegationSuccess (A0Token token);

	// @interface A0APIClient : NSObject
	[BaseType (typeof(NSObject))]
	interface A0APIClient
	{
		// -(instancetype)initWithClientId:(NSString *)clientId andTenant:(NSString *)tenant;
		[Export ("initWithClientId:andTenant:")]
		IntPtr Constructor (string clientId, string tenant);

		// -(instancetype)initWithAPIRouter:(id<A0APIRouter>)router;
		[Export ("initWithAPIRouter:")]
		IntPtr Constructor (A0APIRouter router);

		// +(instancetype)sharedClient;
		[Static]
		[Export ("sharedClient")]
		A0APIClient SharedClient ();

		// -(void)logout;
		[Export ("logout")]
		void Logout ();

		// @property (nonatomic, strong) id<A0APIRouter> router;
		[Export ("router", ArgumentSemantic.Strong)]
		A0APIRouter Router { get; set; }

		// @property (readonly, nonatomic) NSString * clientId;
		[Export ("clientId")]
		string ClientId { get; }

		// @property (readonly, nonatomic) NSString * tenant;
		[Export ("tenant")]
		string Tenant { get; }

		// @property (readonly, nonatomic) NSURL * baseURL;
		[Export ("baseURL")]
		NSUrl BaseURL { get; }

		// @property (readonly, nonatomic) A0Application * application;
		[Export ("application")]
		A0Application Application { get; }

		// -(NSURLSessionDataTask *)fetchAppInfoWithSuccess:(A0APIClientFetchAppInfoSuccess)success failure:(A0APIClientError)failure;
		[Export ("fetchAppInfoWithSuccess:failure:")]
		NSUrlSessionDataTask FetchAppInfoWithSuccess (A0APIClientFetchAppInfoSuccess success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)loginWithUsername:(NSString *)username password:(NSString *)password parameters:(A0AuthParameters *)parameters success:(A0APIClientAuthenticationSuccess)success failure:(A0APIClientError)failure;
		[Export ("loginWithUsername:password:parameters:success:failure:")]
		NSUrlSessionDataTask LoginWithUsername (string username, string password, A0AuthParameters parameters, A0APIClientAuthenticationSuccess success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)signUpWithUsername:(NSString *)username password:(NSString *)password loginOnSuccess:(BOOL)loginOnSuccess parameters:(A0AuthParameters *)parameters success:(A0APIClientAuthenticationSuccess)success failure:(A0APIClientError)failure;
		[Export ("signUpWithUsername:password:loginOnSuccess:parameters:success:failure:")]
		NSUrlSessionDataTask SignUpWithUsername (string username, string password, bool loginOnSuccess, A0AuthParameters parameters, A0APIClientAuthenticationSuccess success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)changePassword:(NSString *)newPassword forUsername:(NSString *)username parameters:(A0AuthParameters *)parameters success:(void (^)())success failure:(A0APIClientError)failure;
		[Export ("changePassword:forUsername:parameters:success:failure:")]
		NSUrlSessionDataTask ChangePassword (string newPassword, string username, A0AuthParameters parameters, Action success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)loginWithIdToken:(NSString *)idToken deviceName:(NSString *)deviceName parameters:(A0AuthParameters *)parameters success:(A0APIClientAuthenticationSuccess)success failure:(A0APIClientError)failure;
		[Export ("loginWithIdToken:deviceName:parameters:success:failure:")]
		NSUrlSessionDataTask LoginWithIdToken (string idToken, string deviceName, A0AuthParameters parameters, A0APIClientAuthenticationSuccess success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)loginWithPhoneNumber:(NSString *)phoneNumber passcode:(NSString *)passcode parameters:(A0AuthParameters *)parameters success:(A0APIClientAuthenticationSuccess)success failure:(A0APIClientError)failure;
		[Export ("loginWithPhoneNumber:passcode:parameters:success:failure:")]
		NSUrlSessionDataTask LoginWithPhoneNumber (string phoneNumber, string passcode, A0AuthParameters parameters, A0APIClientAuthenticationSuccess success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)authenticateWithSocialConnectionName:(NSString *)connectionName credentials:(A0IdentityProviderCredentials *)socialCredentials parameters:(A0AuthParameters *)parameters success:(A0APIClientAuthenticationSuccess)success failure:(A0APIClientError)failure;
		[Export ("authenticateWithSocialConnectionName:credentials:parameters:success:failure:")]
		NSUrlSessionDataTask AuthenticateWithSocialConnectionName (string connectionName, A0IdentityProviderCredentials socialCredentials, A0AuthParameters parameters, A0APIClientAuthenticationSuccess success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)fetchNewIdTokenWithRefreshToken:(NSString *)refreshToken parameters:(A0AuthParameters *)parameters success:(A0APIClientNewIdTokenSuccess)success failure:(A0APIClientError)failure;
		[Export ("fetchNewIdTokenWithRefreshToken:parameters:success:failure:")]
		NSUrlSessionDataTask FetchNewIdTokenWithRefreshToken (string refreshToken, A0AuthParameters parameters, A0APIClientNewIdTokenSuccess success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)fetchNewIdTokenWithIdToken:(NSString *)idToken parameters:(A0AuthParameters *)parameters success:(A0APIClientNewIdTokenSuccess)success failure:(A0APIClientError)failure;
		[Export ("fetchNewIdTokenWithIdToken:parameters:success:failure:")]
		NSUrlSessionDataTask FetchNewIdTokenWithIdToken (string idToken, A0AuthParameters parameters, A0APIClientNewIdTokenSuccess success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)fetchDelegationTokenWithParameters:(A0AuthParameters *)parameters success:(A0APIClientNewDelegationTokenSuccess)success failure:(A0APIClientError)failure;
		[Export ("fetchDelegationTokenWithParameters:success:failure:")]
		NSUrlSessionDataTask FetchDelegationTokenWithParameters (A0AuthParameters parameters, A0APIClientNewDelegationTokenSuccess success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)fetchUserProfileWithIdToken:(NSString *)idToken success:(A0APIClientUserProfileSuccess)success failure:(A0APIClientError)failure;
		[Export ("fetchUserProfileWithIdToken:success:failure:")]
		NSUrlSessionDataTask FetchUserProfileWithIdToken (string idToken, A0APIClientUserProfileSuccess success, A0APIClientError failure);

		// -(NSURLSessionDataTask *)unlinkAccountWithUserId:(NSString *)userId accessToken:(NSString *)accessToken success:(void (^)())success failure:(A0APIClientError)failure;
		[Export ("unlinkAccountWithUserId:accessToken:success:failure:")]
		NSUrlSessionDataTask UnlinkAccountWithUserId (string userId, string accessToken, Action success, A0APIClientError failure);
	}

	// typedef void (^A0UserAPIClientUserProfileSuccess)(A0UserProfile *);
	delegate void A0UserAPIClientUserProfileSuccess (A0UserProfile arg0);

	// typedef void (^A0UserAPIClientError)(NSError *);
	delegate void A0UserAPIClientError (NSError arg0);

	// @interface A0UserAPIClient : NSObject
	[BaseType (typeof(NSObject))]
	interface A0UserAPIClient
	{
		// -(instancetype)initWithRouter:(id<A0APIRouter>)router accessToken:(NSString *)accessToken;
		[Export ("initWithRouter:accessToken:")]
		IntPtr Constructor (A0APIRouter router, string accessToken);

		// -(instancetype)initWithClientId:(NSString *)clientId tenant:(NSString *)tenant accessToken:(NSString *)accessToken;
		[Export ("initWithClientId:tenant:accessToken:")]
		IntPtr Constructor (string clientId, string tenant, string accessToken);

		// +(A0UserAPIClient *)clientWithAccessToken:(NSString *)accessToken;
		[Static]
		[Export ("clientWithAccessToken:")]
		A0UserAPIClient ClientWithAccessToken (string accessToken);

		// +(A0UserAPIClient *)clientWithIdToken:(NSString *)idToken;
		[Static]
		[Export ("clientWithIdToken:")]
		A0UserAPIClient ClientWithIdToken (string idToken);

		// -(void)fetchUserProfileSuccess:(A0UserAPIClientUserProfileSuccess)success failure:(A0UserAPIClientError)failure;
		[Export ("fetchUserProfileSuccess:failure:")]
		void FetchUserProfileSuccess (A0UserAPIClientUserProfileSuccess success, A0UserAPIClientError failure);

		// -(void)registerPublicKey:(NSData *)pubKey device:(NSString *)deviceName user:(NSString *)userId success:(void (^)())success failure:(A0UserAPIClientError)failure;
		[Export ("registerPublicKey:device:user:success:failure:")]
		void RegisterPublicKey (NSData pubKey, string deviceName, string userId, Action success, A0UserAPIClientError failure);

		// -(void)removePublicKeyOfDevice:(NSString *)deviceName user:(NSString *)userId success:(void (^)())success failure:(A0UserAPIClientError)failure;
		[Export ("removePublicKeyOfDevice:user:success:failure:")]
		void RemovePublicKeyOfDevice (string deviceName, string userId, Action success, A0UserAPIClientError failure);
	}

	// @interface A0Application : NSObject
	[BaseType (typeof(NSObject))]
	interface A0Application
	{
		// @property (readonly, nonatomic) NSString * identifier;
		[Export ("identifier")]
		string Identifier { get; }

		// @property (readonly, nonatomic) NSString * tenant;
		[Export ("tenant")]
		string Tenant { get; }

		// @property (readonly, nonatomic) NSURL * authorizeURL;
		[Export ("authorizeURL")]
		NSUrl AuthorizeURL { get; }

		// @property (readonly, nonatomic) NSArray * strategies;
		[Export ("strategies")]
		A0Strategy[] Strategies { get; }

		// @property (readonly, nonatomic) A0Strategy * databaseStrategy;
		[Export ("databaseStrategy")]
		A0Strategy DatabaseStrategy { get; }

		// @property (readonly, nonatomic) NSArray * socialStrategies;
		[Export ("socialStrategies")]
		A0Strategy[] SocialStrategies { get; }

		// @property (readonly, nonatomic) NSArray * enterpriseStrategies;
		[Export ("enterpriseStrategies")]
		A0Strategy[] EnterpriseStrategies { get; }

		// @property (readonly, nonatomic) A0Strategy * activeDirectoryStrategy;
		[Export ("activeDirectoryStrategy")]
		A0Strategy ActiveDirectoryStrategy { get; }

		// -(instancetype)initWithJSONDictionary:(NSDictionary *)JSONDict;
		[Export ("initWithJSONDictionary:")]
		IntPtr Constructor (NSDictionary JSONDict);

		// -(A0Strategy *)strategyByName:(NSString *)name;
		[Export ("strategyByName:")]
		A0Strategy StrategyByName (string name);

		// -(A0Strategy *)enterpriseStrategyWithConnection:(NSString *)connectionName;
		[Export ("enterpriseStrategyWithConnection:")]
		A0Strategy EnterpriseStrategyWithConnection (string connectionName);
	}

	partial interface Constants
	{
		// extern NSString *const A0StrategyNameGoogleOpenId;
		[Field ("A0StrategyNameGoogleOpenId")]
		NSString A0StrategyNameGoogleOpenId { get; }

		// extern NSString *const A0StrategyNameGoogleApps;
		[Field ("A0StrategyNameGoogleApps")]
		NSString A0StrategyNameGoogleApps { get; }

		// extern NSString *const A0StrategyNameGooglePlus;
		[Field ("A0StrategyNameGooglePlus")]
		NSString A0StrategyNameGooglePlus { get; }

		// extern NSString *const A0StrategyNameFacebook;
		[Field ("A0StrategyNameFacebook")]
		NSString A0StrategyNameFacebook { get; }

		// extern NSString *const A0StrategyNameWindowsLive;
		[Field ("A0StrategyNameWindowsLive")]
		NSString A0StrategyNameWindowsLive { get; }

		// extern NSString *const A0StrategyNameLinkedin;
		[Field ("A0StrategyNameLinkedin")]
		NSString A0StrategyNameLinkedin { get; }

		// extern NSString *const A0StrategyNameGithub;
		[Field ("A0StrategyNameGithub")]
		NSString A0StrategyNameGithub { get; }

		// extern NSString *const A0StrategyNamePaypal;
		[Field ("A0StrategyNamePaypal")]
		NSString A0StrategyNamePaypal { get; }

		// extern NSString *const A0StrategyNameTwitter;
		[Field ("A0StrategyNameTwitter")]
		NSString A0StrategyNameTwitter { get; }

		// extern NSString *const A0StrategyNameAmazon;
		[Field ("A0StrategyNameAmazon")]
		NSString A0StrategyNameAmazon { get; }

		// extern NSString *const A0StrategyNameVK;
		[Field ("A0StrategyNameVK")]
		NSString A0StrategyNameVK { get; }

		// extern NSString *const A0StrategyNameYandex;
		[Field ("A0StrategyNameYandex")]
		NSString A0StrategyNameYandex { get; }

		// extern NSString *const A0StrategyNameOffice365;
		[Field ("A0StrategyNameOffice365")]
		NSString A0StrategyNameOffice365 { get; }

		// extern NSString *const A0StrategyNameWaad;
		[Field ("A0StrategyNameWaad")]
		NSString A0StrategyNameWaad { get; }

		// extern NSString *const A0StrategyNameADFS;
		[Field ("A0StrategyNameADFS")]
		NSString A0StrategyNameADFS { get; }

		// extern NSString *const A0StrategyNameSAMLP;
		[Field ("A0StrategyNameSAMLP")]
		NSString A0StrategyNameSAMLP { get; }

		// extern NSString *const A0StrategyNamePingFederate;
		[Field ("A0StrategyNamePingFederate")]
		NSString A0StrategyNamePingFederate { get; }

		// extern NSString *const A0StrategyNameIP;
		[Field ("A0StrategyNameIP")]
		NSString A0StrategyNameIP { get; }

		// extern NSString *const A0StrategyNameMSCRM;
		[Field ("A0StrategyNameMSCRM")]
		NSString A0StrategyNameMSCRM { get; }

		// extern NSString *const A0StrategyNameActiveDirectory;
		[Field ("A0StrategyNameActiveDirectory")]
		NSString A0StrategyNameActiveDirectory { get; }

		// extern NSString *const A0StrategyNameCustom;
		[Field ("A0StrategyNameCustom")]
		NSString A0StrategyNameCustom { get; }

		// extern NSString *const A0StrategyNameAuth0;
		[Field ("A0StrategyNameAuth0")]
		NSString A0StrategyNameAuth0 { get; }

		// extern NSString *const A0StrategyNameAuth0LDAP;
		[Field ("A0StrategyNameAuth0LDAP")]
		NSString A0StrategyNameAuth0LDAP { get; }

		// extern NSString *const A0StrategyName37Signals;
		[Field ("A0StrategyName37Signals")]
		NSString A0StrategyName37Signals { get; }

		// extern NSString *const A0StrategyNameBox;
		[Field ("A0StrategyNameBox")]
		NSString A0StrategyNameBox { get; }

		// extern NSString *const A0StrategyNameSalesforce;
		[Field ("A0StrategyNameSalesforce")]
		NSString A0StrategyNameSalesforce { get; }

		// extern NSString *const A0StrategyNameSalesforceSandbox;
		[Field ("A0StrategyNameSalesforceSandbox")]
		NSString A0StrategyNameSalesforceSandbox { get; }

		// extern NSString *const A0StrategyNameFitbit;
		[Field ("A0StrategyNameFitbit")]
		NSString A0StrategyNameFitbit { get; }

		// extern NSString *const A0StrategyNameBaidu;
		[Field ("A0StrategyNameBaidu")]
		NSString A0StrategyNameBaidu { get; }

		// extern NSString *const A0StrategyNameRenRen;
		[Field ("A0StrategyNameRenRen")]
		NSString A0StrategyNameRenRen { get; }

		// extern NSString *const A0StrategyNameYahoo;
		[Field ("A0StrategyNameYahoo")]
		NSString A0StrategyNameYahoo { get; }

		// extern NSString *const A0StrategyNameAOL;
		[Field ("A0StrategyNameAOL")]
		NSString A0StrategyNameAOL { get; }

		// extern NSString *const A0StrategyNameYammer;
		[Field ("A0StrategyNameYammer")]
		NSString A0StrategyNameYammer { get; }

		// extern NSString *const A0StrategyNameWordpress;
		[Field ("A0StrategyNameWordpress")]
		NSString A0StrategyNameWordpress { get; }

		// extern NSString *const A0StrategyNameDwolla;
		[Field ("A0StrategyNameDwolla")]
		NSString A0StrategyNameDwolla { get; }

		// extern NSString *const A0StrategyNameShopify;
		[Field ("A0StrategyNameShopify")]
		NSString A0StrategyNameShopify { get; }

		// extern NSString *const A0StrategyNameMiicard;
		[Field ("A0StrategyNameMiicard")]
		NSString A0StrategyNameMiicard { get; }

		// extern NSString *const A0StrategyNameSoundcloud;
		[Field ("A0StrategyNameSoundcloud")]
		NSString A0StrategyNameSoundcloud { get; }

		// extern NSString *const A0StrategyNameEBay;
		[Field ("A0StrategyNameEBay")]
		NSString A0StrategyNameEBay { get; }

		// extern NSString *const A0StrategyNameEvernote;
		[Field ("A0StrategyNameEvernote")]
		NSString A0StrategyNameEvernote { get; }

		// extern NSString *const A0StrategyNameEvernoteSandbox;
		[Field ("A0StrategyNameEvernoteSandbox")]
		NSString A0StrategyNameEvernoteSandbox { get; }

		// extern NSString *const A0StrategyNameSharepoint;
		[Field ("A0StrategyNameSharepoint")]
		NSString A0StrategyNameSharepoint { get; }

		// extern NSString *const A0StrategyNameWeibo;
		[Field ("A0StrategyNameWeibo")]
		NSString A0StrategyNameWeibo { get; }

		// extern NSString *const A0StrategyNameInstagram;
		[Field ("A0StrategyNameInstagram")]
		NSString A0StrategyNameInstagram { get; }

		// extern NSString *const A0StrategyNameTheCity;
		[Field ("A0StrategyNameTheCity")]
		NSString A0StrategyNameTheCity { get; }

		// extern NSString *const A0StrategyNameTheCitySandbox;
		[Field ("A0StrategyNameTheCitySandbox")]
		NSString A0StrategyNameTheCitySandbox { get; }

		// extern NSString *const A0StrategyNamePlanningCenter;
		[Field ("A0StrategyNamePlanningCenter")]
		NSString A0StrategyNamePlanningCenter { get; }

		// extern NSString *const A0StrategyNameSMS;
		[Field ("A0StrategyNameSMS")]
		NSString A0StrategyNameSMS { get; }

		// extern NSString *const A0StrategySocialTokenParameter;
		[Field ("A0StrategySocialTokenParameter")]
		NSString A0StrategySocialTokenParameter { get; }

		// extern NSString *const A0StrategySocialTokenSecretParameter;
		[Field ("A0StrategySocialTokenSecretParameter")]
		NSString A0StrategySocialTokenSecretParameter { get; }

		// extern NSString *const A0StrategySocialUserIdParameter;
		[Field ("A0StrategySocialUserIdParameter")]
		NSString A0StrategySocialUserIdParameter { get; }
	}

	// @interface A0Strategy : NSObject
	[BaseType (typeof(NSObject))]
	interface A0Strategy
	{
		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSArray * connections;
		[Export ("connections")]
		A0Connection[] Connections { get; }

		// @property (readonly, nonatomic) A0StrategyType type;
		[Export ("type")]
		A0StrategyType Type { get; }

		// -(instancetype)initWithJSONDictionary:(NSDictionary *)JSONDictionary;
		[Export ("initWithJSONDictionary:")]
		IntPtr Constructor (NSDictionary JSONDictionary);

		// -(instancetype)initWithName:(NSString *)name connections:(NSArray *)connections type:(A0StrategyType)type;
		[Export ("initWithName:connections:type:")]
		IntPtr Constructor (string name, A0Connection[] connections, A0StrategyType type);

		// +(instancetype)newEnterpriseStrategyWithName:(NSString *)name connections:(NSArray *)connections;
		[Static]
		[Export ("newEnterpriseStrategyWithName:connections:")]
		A0Strategy NewEnterpriseStrategyWithName (string name, A0Connection[] connections);

		// +(instancetype)newDatabaseStrategyWithConnections:(NSArray *)connections;
		[Static]
		[Export ("newDatabaseStrategyWithConnections:")]
		A0Strategy NewDatabaseStrategyWithConnections (A0Connection[] connections);
	}

	// @interface A0Connection : NSObject
	[BaseType (typeof(NSObject))]
	interface A0Connection
	{
		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSDictionary * values;
		[Export ("values")]
		NSDictionary Values { get; }

		// -(instancetype)initWithJSONDictionary:(NSDictionary *)JSON;
		[Export ("initWithJSONDictionary:")]
		IntPtr Constructor (NSDictionary JSON);
	}

	partial interface Constants
	{
		// extern NSString *const A0JSONResponseSerializerErrorDataKey;
		[Field ("A0JSONResponseSerializerErrorDataKey")]
		NSString A0JSONResponseSerializerErrorDataKey { get; }
	}

	// @interface A0Errors : NSObject
	[BaseType (typeof(NSObject))]
	interface A0Errors
	{
		// +(NSError *)noConnectionNameFound;
		[Static]
		[Export ("noConnectionNameFound")]
		NSError NoConnectionNameFound { get; }

		// +(NSError *)notConnectedToInternetError;
		[Static]
		[Export ("notConnectedToInternetError")]
		NSError NotConnectedToInternetError { get; }

		// +(BOOL)isAuth0Error:(NSError *)error withCode:(A0ErrorCode)code;
		[Static]
		[Export ("isAuth0Error:withCode:")]
		bool IsAuth0Error (NSError error, A0ErrorCode code);

		// +(BOOL)isCancelledSocialAuthentication:(NSError *)error;
		[Static]
		[Export ("isCancelledSocialAuthentication:")]
		bool IsCancelledSocialAuthentication (NSError error);

		// +(NSError *)defaultLoginErrorFor:(NSError *)error;
		[Static]
		[Export ("defaultLoginErrorFor:")]
		NSError DefaultLoginErrorFor (NSError error);

		// +(NSError *)invalidLoginCredentialsUsingEmail:(BOOL)usesEmail;
		[Static]
		[Export ("invalidLoginCredentialsUsingEmail:")]
		NSError InvalidLoginCredentialsUsingEmail (bool usesEmail);

		// +(NSError *)invalidLoginUsernameUsingEmail:(BOOL)usesEmail;
		[Static]
		[Export ("invalidLoginUsernameUsingEmail:")]
		NSError InvalidLoginUsernameUsingEmail (bool usesEmail);

		// +(NSError *)invalidLoginPassword;
		[Static]
		[Export ("invalidLoginPassword")]
		NSError InvalidLoginPassword { get; }

		// +(NSError *)invalidSignUpCredentialsUsingEmail:(BOOL)usesEmail;
		[Static]
		[Export ("invalidSignUpCredentialsUsingEmail:")]
		NSError InvalidSignUpCredentialsUsingEmail (bool usesEmail);

		// +(NSError *)invalidSignUpUsernameUsingEmail:(BOOL)usesEmail;
		[Static]
		[Export ("invalidSignUpUsernameUsingEmail:")]
		NSError InvalidSignUpUsernameUsingEmail (bool usesEmail);

		// +(NSError *)invalidSignUpPassword;
		[Static]
		[Export ("invalidSignUpPassword")]
		NSError InvalidSignUpPassword { get; }

		// +(NSError *)invalidChangePasswordCredentialsUsingEmail:(BOOL)usesEmail;
		[Static]
		[Export ("invalidChangePasswordCredentialsUsingEmail:")]
		NSError InvalidChangePasswordCredentialsUsingEmail (bool usesEmail);

		// +(NSError *)invalidChangePasswordUsernameUsingEmail:(BOOL)usesEmail;
		[Static]
		[Export ("invalidChangePasswordUsernameUsingEmail:")]
		NSError InvalidChangePasswordUsernameUsingEmail (bool usesEmail);

		// +(NSError *)invalidChangePasswordPassword;
		[Static]
		[Export ("invalidChangePasswordPassword")]
		NSError InvalidChangePasswordPassword { get; }

		// +(NSError *)invalidChangePasswordRepeatPassword;
		[Static]
		[Export ("invalidChangePasswordRepeatPassword")]
		NSError InvalidChangePasswordRepeatPassword { get; }

		// +(NSError *)invalidChangePasswordRepeatPasswordAndPassword;
		[Static]
		[Export ("invalidChangePasswordRepeatPasswordAndPassword")]
		NSError InvalidChangePasswordRepeatPasswordAndPassword { get; }

		// +(NSError *)urlSchemeNotRegistered;
		[Static]
		[Export ("urlSchemeNotRegistered")]
		NSError UrlSchemeNotRegistered { get; }

		// +(NSError *)unkownProviderForStrategy:(NSString *)strategyName;
		[Static]
		[Export ("unkownProviderForStrategy:")]
		NSError UnkownProviderForStrategy (string strategyName);

		// +(NSError *)facebookCancelled;
		[Static]
		[Export ("facebookCancelled")]
		NSError FacebookCancelled { get; }

		// +(NSError *)twitterAppNotAuthorized;
		[Static]
		[Export ("twitterAppNotAuthorized")]
		NSError TwitterAppNotAuthorized { get; }

		// +(NSError *)twitterAppOauthNotAuthorized;
		[Static]
		[Export ("twitterAppOauthNotAuthorized")]
		NSError TwitterAppOauthNotAuthorized { get; }

		// +(NSError *)twitterCancelled;
		[Static]
		[Export ("twitterCancelled")]
		NSError TwitterCancelled { get; }

		// +(NSError *)twitterNotConfigured;
		[Static]
		[Export ("twitterNotConfigured")]
		NSError TwitterNotConfigured { get; }

		// +(NSError *)twitterInvalidAccount;
		[Static]
		[Export ("twitterInvalidAccount")]
		NSError TwitterInvalidAccount { get; }

		// +(NSError *)auth0CancelledForStrategy:(NSString *)strategyName;
		[Static]
		[Export ("auth0CancelledForStrategy:")]
		NSError Auth0CancelledForStrategy (string strategyName);

		// +(NSError *)auth0NotAuthorizedForStrategy:(NSString *)strategyName;
		[Static]
		[Export ("auth0NotAuthorizedForStrategy:")]
		NSError Auth0NotAuthorizedForStrategy (string strategyName);

		// +(NSError *)auth0InvalidConfigurationForStrategy:(NSString *)strategyName;
		[Static]
		[Export ("auth0InvalidConfigurationForStrategy:")]
		NSError Auth0InvalidConfigurationForStrategy (string strategyName);

		// +(NSError *)googleplusFailed;
		[Static]
		[Export ("googleplusFailed")]
		NSError GoogleplusFailed { get; }

		// +(NSError *)googleplusCancelled;
		[Static]
		[Export ("googleplusCancelled")]
		NSError GoogleplusCancelled { get; }

		// +(NSString *)localizedStringForSocialLoginError:(NSError *)error;
		[Static]
		[Export ("localizedStringForSocialLoginError:")]
		string LocalizedStringForSocialLoginError (NSError error);

		// +(NSString *)localizedStringForLoginError:(NSError *)error;
		[Static]
		[Export ("localizedStringForLoginError:")]
		string LocalizedStringForLoginError (NSError error);

		// +(NSString *)localizedStringForSMSLoginError:(NSError *)error;
		[Static]
		[Export ("localizedStringForSMSLoginError:")]
		string LocalizedStringForSMSLoginError (NSError error);

		// +(NSString *)localizedStringForSignUpError:(NSError *)error;
		[Static]
		[Export ("localizedStringForSignUpError:")]
		string LocalizedStringForSignUpError (NSError error);

		// +(NSString *)localizedStringForChangePasswordError:(NSError *)error;
		[Static]
		[Export ("localizedStringForChangePasswordError:")]
		string LocalizedStringForChangePasswordError (NSError error);
	}

	// @interface A0Token : NSObject
	[BaseType (typeof(NSObject))]
	interface A0Token
	{
		// @property (readonly, nonatomic) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, nonatomic) NSString * idToken;
		[Export ("idToken")]
		string IdToken { get; }

		// @property (readonly, nonatomic) NSString * tokenType;
		[Export ("tokenType")]
		string TokenType { get; }

		// @property (readonly, nonatomic) NSString * refreshToken;
		[Export ("refreshToken")]
		string RefreshToken { get; }

		// -(instancetype)initWithAccessToken:(NSString *)accessToken idToken:(NSString *)idToken tokenType:(NSString *)tokenType refreshToken:(NSString *)refreshToken;
		[Export ("initWithAccessToken:idToken:tokenType:refreshToken:")]
		IntPtr Constructor (string accessToken, string idToken, string tokenType, string refreshToken);

		// -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);
	}

	// @interface A0UserProfile : NSObject <NSCoding>
	[BaseType (typeof(NSObject))]
	interface A0UserProfile : INSCoding
	{
		// @property (readonly, nonatomic) NSString * userId;
		[Export ("userId")]
		string UserId { get; }

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSString * nickname;
		[Export ("nickname")]
		string Nickname { get; }

		// @property (readonly, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; }

		// @property (readonly, nonatomic) NSURL * picture;
		[Export ("picture")]
		NSUrl Picture { get; }

		// @property (readonly, nonatomic) NSDate * createdAt;
		[Export ("createdAt")]
		NSDate CreatedAt { get; }

		// @property (readonly, nonatomic) NSDictionary * extraInfo;
		[Export ("extraInfo")]
		NSDictionary ExtraInfo { get; }

		// @property (nonatomic, strong) NSArray * identities;
		[Export ("identities", ArgumentSemantic.Strong)]
		A0UserIdentity[] Identities { get; set; }

		// -(instancetype)initWithUserId:(NSString *)userId name:(NSString *)name nickname:(NSString *)nickname email:(NSString *)email picture:(NSURL *)picture createdAt:(NSDate *)createdAt;
		[Export ("initWithUserId:name:nickname:email:picture:createdAt:")]
		IntPtr Constructor (string userId, string name, string nickname, string email, NSUrl picture, NSDate createdAt);

		// -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);
	}

	// @interface A0IdentityProviderCredentials : NSObject
	[BaseType (typeof(NSObject))]
	interface A0IdentityProviderCredentials
	{
		// @property (readonly, nonatomic) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, nonatomic) NSDictionary * extraInfo;
		[Export ("extraInfo")]
		NSDictionary ExtraInfo { get; }

		// -(instancetype)initWithAccessToken:(NSString *)accessToken extraInfo:(NSDictionary *)extraInfo;
		[Export ("initWithAccessToken:extraInfo:")]
		IntPtr Constructor (string accessToken, NSDictionary extraInfo);

		// -(instancetype)initWithAccessToken:(NSString *)accessToken;
		[Export ("initWithAccessToken:")]
		IntPtr Constructor (string accessToken);
	}

	// @protocol A0AuthenticationProvider <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface IA0AuthenticationProvider
	{
		// @required -(NSString *)identifier;
		[Abstract]
		[Export ("identifier")]
		string Identifier { get; }

		// @required -(void)authenticateWithParameters:(A0AuthParameters *)parameters success:(void (^)(A0UserProfile *, A0Token *))success failure:(void (^)(NSError *))failure;
		[Abstract]
		[Export ("authenticateWithParameters:success:failure:")]
		void AuthenticateWithParameters (A0AuthParameters parameters, Action<A0UserProfile, A0Token> success, Action<NSError> failure);

		// @required -(void)clearSessions;
		[Abstract]
		[Export ("clearSessions")]
		void ClearSessions ();

		// @optional -(BOOL)handleURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Export ("handleURL:sourceApplication:")]
		bool HandleURL (NSUrl url, string sourceApplication);
	}

	// @interface A0IdentityProviderAuthenticator : NSObject
	[BaseType (typeof(NSObject))]
	interface A0IdentityProviderAuthenticator
	{
		// @property (assign, nonatomic) BOOL useWebAsDefault;
		[Export ("useWebAsDefault")]
		bool UseWebAsDefault { get; set; }

		// +(A0IdentityProviderAuthenticator *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		A0IdentityProviderAuthenticator SharedInstance { get; }

		// -(void)registerAuthenticationProviders:(NSArray *)authenticationProviders;
		[Export ("registerAuthenticationProviders:")]
		void RegisterAuthenticationProviders (NSObject[] authenticationProviders);

		// -(void)registerAuthenticationProvider:(id<A0AuthenticationProvider>)authenticationProvider;
		[Export ("registerAuthenticationProvider:")]
		void RegisterAuthenticationProvider (NSObject authenticationProvider);

		// -(void)configureForApplication:(A0Application *)application;
		[Export ("configureForApplication:")]
		void ConfigureForApplication (A0Application application);

		// -(void)authenticateForStrategy:(A0Strategy *)strategy parameters:(A0AuthParameters *)parameters success:(void (^)(A0UserProfile *, A0Token *))success failure:(void (^)(NSError *))failure;
		[Export ("authenticateForStrategy:parameters:success:failure:")]
		void AuthenticateForStrategy (A0Strategy strategy, A0AuthParameters parameters, Action<A0UserProfile, A0Token> success, Action<NSError> failure);

		// -(void)authenticateForStrategyName:(NSString *)strategyName parameters:(A0AuthParameters *)parameters success:(void (^)(A0UserProfile *, A0Token *))success failure:(void (^)(NSError *))failure;
		[Export ("authenticateForStrategyName:parameters:success:failure:")]
		void AuthenticateForStrategyName (string strategyName, A0AuthParameters parameters, Action<A0UserProfile, A0Token> success, Action<NSError> failure);

		// -(BOOL)canAuthenticateStrategy:(A0Strategy *)strategy;
		[Export ("canAuthenticateStrategy:")]
		bool CanAuthenticateStrategy (A0Strategy strategy);

		// -(BOOL)handleURL:(NSURL *)url sourceApplication:(NSString *)application;
		[Export ("handleURL:sourceApplication:")]
		bool HandleURL (NSUrl url, string application);

		// -(void)clearSessions;
		[Export ("clearSessions")]
		void ClearSessions ();
	}

	partial interface Constants
	{
		// extern NSString *const A0ParameterScope;
		[Field ("A0ParameterScope")]
		NSString A0ParameterScope { get; }

		// extern NSString *const A0ParameterDevice;
		[Field ("A0ParameterDevice")]
		NSString A0ParameterDevice { get; }

		// extern NSString *const A0ParameterProtocol;
		[Field ("A0ParameterProtocol")]
		NSString A0ParameterProtocol { get; }

		// extern NSString *const A0ParameterState;
		[Field ("A0ParameterState")]
		NSString A0ParameterState { get; }

		// extern NSString *const A0ParameterNonce;
		[Field ("A0ParameterNonce")]
		NSString A0ParameterNonce { get; }

		// extern NSString *const A0ParameterOfflineMode;
		[Field ("A0ParameterOfflineMode")]
		NSString A0ParameterOfflineMode { get; }

		// extern NSString *const A0ParameterConnectionScopes;
		[Field ("A0ParameterConnectionScopes")]
		NSString A0ParameterConnectionScopes { get; }

		// extern NSString *const A0ParameterAccessToken;
		[Field ("A0ParameterAccessToken")]
		NSString A0ParameterAccessToken { get; }

		// extern NSString *const A0ParameterMainAccessToken;
		[Field ("A0ParameterMainAccessToken")]
		NSString A0ParameterMainAccessToken { get; }

		// extern NSString *const A0ParameterConnection;
		[Field ("A0ParameterConnection")]
		NSString A0ParameterConnection { get; }

		// extern NSString *const A0ScopeOpenId;
		[Field ("A0ScopeOpenId")]
		NSString A0ScopeOpenId { get; }

		// extern NSString *const A0ScopeOfflineAccess;
		[Field ("A0ScopeOfflineAccess")]
		NSString A0ScopeOfflineAccess { get; }

		// extern NSString *const A0ScopeProfile;
		[Field ("A0ScopeProfile")]
		NSString A0ScopeProfile { get; }

		// extern NSString *const A0ParameterAPIType;
		[Field ("A0ParameterAPIType")]
		NSString A0ParameterAPIType { get; }

		// extern NSString *const A0ParameterTarget;
		[Field ("A0ParameterTarget")]
		NSString A0ParameterTarget { get; }
	}

	// @interface A0AuthParameters : NSObject <NSCopying>
	[BaseType (typeof(NSObject))]
	interface A0AuthParameters : INSCopying
	{
		// @property (copy, nonatomic) NSArray * scopes;
		[Export ("scopes", ArgumentSemantic.Copy)]
		NSString[] Scopes { get; set; }

		// @property (copy, nonatomic) NSString * device;
		[Export ("device")]
		string Device { get; set; }

		// @property (copy, nonatomic) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; set; }

		// @property (copy, nonatomic) NSString * protocol;
		[Export ("protocol")]
		string Protocol { get; set; }

		// @property (copy, nonatomic) NSString * nonce;
		[Export ("nonce")]
		string Nonce { get; set; }

		// @property (copy, nonatomic) NSString * offlineMode;
		[Export ("offlineMode")]
		string OfflineMode { get; set; }

		// @property (copy, nonatomic) NSString * state;
		[Export ("state")]
		string State { get; set; }

		// @property (copy, nonatomic) NSDictionary * connectionScopes;
		[Export ("connectionScopes", ArgumentSemantic.Copy)]
		NSDictionary ConnectionScopes { get; set; }

		// -(instancetype)initWithScopes:(NSArray *)scopes;
		[Export ("initWithScopes:")]
		IntPtr Constructor (NSString[] scopes);

		// -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// +(instancetype)newDefaultParams;
		[Static]
		[Export ("newDefaultParams")]
		A0AuthParameters NewDefaultParams ();

		// +(instancetype)newWithScopes:(NSArray *)scopes;
		[Static]
		[Export ("newWithScopes:")]
		A0AuthParameters NewWithScopes (NSString[] scopes);

		// +(instancetype)newWithDictionary:(NSDictionary *)dictionary;
		[Static]
		[Export ("newWithDictionary:")]
		A0AuthParameters NewWithDictionary (NSDictionary dictionary);

		// -(NSDictionary *)asAPIPayload;
		[Export ("asAPIPayload")]
		NSDictionary AsAPIPayload { get; }

		// -(void)setValue:(NSString *)value forKey:(NSString *)key;
		[Export ("setValue:forKey:")]
		void SetValue (string value, string key);

		// -(void)addValuesFromDictionary:(NSDictionary *)dictionary;
		[Export ("addValuesFromDictionary:")]
		void AddValuesFromDictionary (NSDictionary dictionary);

		// -(void)addValuesFromParameters:(A0AuthParameters *)parameters;
		[Export ("addValuesFromParameters:")]
		void AddValuesFromParameters (A0AuthParameters parameters);

		// -(NSString *)valueForKey:(NSString *)key;
		[Export ("valueForKey:")]
		string ValueForKey (string key);
	}

	// @interface A0UserIdentity : NSObject <NSCoding>
	[BaseType (typeof(NSObject))]
	interface A0UserIdentity : INSCoding
	{
		// @property (readonly, nonatomic) NSString * connection;
		[Export ("connection")]
		string Connection { get; }

		// @property (readonly, nonatomic) NSString * provider;
		[Export ("provider")]
		string Provider { get; }

		// @property (readonly, nonatomic) NSString * userId;
		[Export ("userId")]
		string UserId { get; }

		// @property (readonly, getter = isSocial, nonatomic) BOOL social;
		[Export ("social")]
		bool Social { [Bind ("isSocial")] get; }

		// @property (readonly, nonatomic) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, nonatomic) NSString * identityId;
		[Export ("identityId")]
		string IdentityId { get; }

		// @property (readonly, nonatomic) NSString * accessTokenSecret;
		[Export ("accessTokenSecret")]
		string AccessTokenSecret { get; }

		// @property (readonly, nonatomic) NSDictionary * profileData;
		[Export ("profileData")]
		NSDictionary ProfileData { get; }

		// -(instancetype)initWithJSONDictionary:(NSDictionary *)JSONDict;
		[Export ("initWithJSONDictionary:")]
		IntPtr Constructor (NSDictionary JSONDict);
	}

	// @interface A0LockLogger : NSObject
	[BaseType (typeof(NSObject))]
	interface A0LockLogger
	{
		// +(void)logAll;
		[Static]
		[Export ("logAll")]
		void LogAll ();

		// +(void)logError;
		[Static]
		[Export ("logError")]
		void LogError ();

		// +(void)logOff;
		[Static]
		[Export ("logOff")]
		void LogOff ();
	}

	partial interface Constants
	{
		// extern NSString *const A0LockNotificationLoginSuccessful;
		[Field ("A0LockNotificationLoginSuccessful")]
		NSString A0LockNotificationLoginSuccessful { get; }

		// extern NSString *const A0LockNotificationLoginFailed;
		[Field ("A0LockNotificationLoginFailed")]
		NSString A0LockNotificationLoginFailed { get; }

		// extern NSString *const A0LockNotificationSignUpSuccessful;
		[Field ("A0LockNotificationSignUpSuccessful")]
		NSString A0LockNotificationSignUpSuccessful { get; }

		// extern NSString *const A0LockNotificationSignUpFailed;
		[Field ("A0LockNotificationSignUpFailed")]
		NSString A0LockNotificationSignUpFailed { get; }

		// extern NSString *const A0LockNotificationChangePasswordSuccessful;
		[Field ("A0LockNotificationChangePasswordSuccessful")]
		NSString A0LockNotificationChangePasswordSuccessful { get; }

		// extern NSString *const A0LockNotificationChangePasswordFailed;
		[Field ("A0LockNotificationChangePasswordFailed")]
		NSString A0LockNotificationChangePasswordFailed { get; }

		// extern NSString *const A0LockNotificationLockDismissed;
		[Field ("A0LockNotificationLockDismissed")]
		NSString A0LockNotificationLockDismissed { get; }

		// extern NSString *const A0LockNotificationErrorParameterKey;
		[Field ("A0LockNotificationErrorParameterKey")]
		NSString A0LockNotificationErrorParameterKey { get; }

		// extern NSString *const A0LockNotificationEmailParameterKey;
		[Field ("A0LockNotificationEmailParameterKey")]
		NSString A0LockNotificationEmailParameterKey { get; }

		// extern NSString *const A0LockNotificationConnectionParameterKey;
		[Field ("A0LockNotificationConnectionParameterKey")]
		NSString A0LockNotificationConnectionParameterKey { get; }

		// extern NSString *const A0ThemePrimaryButtonNormalColor;
		[Field ("A0ThemePrimaryButtonNormalColor")]
		NSString A0ThemePrimaryButtonNormalColor { get; }

		// extern NSString *const A0ThemePrimaryButtonHighlightedColor;
		[Field ("A0ThemePrimaryButtonHighlightedColor")]
		NSString A0ThemePrimaryButtonHighlightedColor { get; }

		// extern NSString *const A0ThemePrimaryButtonNormalImageName;
		[Field ("A0ThemePrimaryButtonNormalImageName")]
		NSString A0ThemePrimaryButtonNormalImageName { get; }

		// extern NSString *const A0ThemePrimaryButtonHighlightedImageName;
		[Field ("A0ThemePrimaryButtonHighlightedImageName")]
		NSString A0ThemePrimaryButtonHighlightedImageName { get; }

		// extern NSString *const A0ThemePrimaryButtonFont;
		[Field ("A0ThemePrimaryButtonFont")]
		NSString A0ThemePrimaryButtonFont { get; }

		// extern NSString *const A0ThemePrimaryButtonTextColor;
		[Field ("A0ThemePrimaryButtonTextColor")]
		NSString A0ThemePrimaryButtonTextColor { get; }

		// extern NSString *const A0ThemeSecondaryButtonBackgroundColor;
		[Field ("A0ThemeSecondaryButtonBackgroundColor")]
		NSString A0ThemeSecondaryButtonBackgroundColor { get; }

		// extern NSString *const A0ThemeSecondaryButtonNormalImageName;
		[Field ("A0ThemeSecondaryButtonNormalImageName")]
		NSString A0ThemeSecondaryButtonNormalImageName { get; }

		// extern NSString *const A0ThemeSecondaryButtonHighlightedImageName;
		[Field ("A0ThemeSecondaryButtonHighlightedImageName")]
		NSString A0ThemeSecondaryButtonHighlightedImageName { get; }

		// extern NSString *const A0ThemeSecondaryButtonFont;
		[Field ("A0ThemeSecondaryButtonFont")]
		NSString A0ThemeSecondaryButtonFont { get; }

		// extern NSString *const A0ThemeSecondaryButtonTextColor;
		[Field ("A0ThemeSecondaryButtonTextColor")]
		NSString A0ThemeSecondaryButtonTextColor { get; }

		// extern NSString *const A0ThemeTextFieldFont;
		[Field ("A0ThemeTextFieldFont")]
		NSString A0ThemeTextFieldFont { get; }

		// extern NSString *const A0ThemeTextFieldTextColor;
		[Field ("A0ThemeTextFieldTextColor")]
		NSString A0ThemeTextFieldTextColor { get; }

		// extern NSString *const A0ThemeTextFieldPlaceholderTextColor;
		[Field ("A0ThemeTextFieldPlaceholderTextColor")]
		NSString A0ThemeTextFieldPlaceholderTextColor { get; }

		// extern NSString *const A0ThemeTextFieldIconColor;
		[Field ("A0ThemeTextFieldIconColor")]
		NSString A0ThemeTextFieldIconColor { get; }

		// extern NSString *const A0ThemeTitleFont;
		[Field ("A0ThemeTitleFont")]
		NSString A0ThemeTitleFont { get; }

		// extern NSString *const A0ThemeTitleTextColor;
		[Field ("A0ThemeTitleTextColor")]
		NSString A0ThemeTitleTextColor { get; }

		// extern NSString *const A0ThemeDescriptionFont;
		[Field ("A0ThemeDescriptionFont")]
		NSString A0ThemeDescriptionFont { get; }

		// extern NSString *const A0ThemeDescriptionTextColor;
		[Field ("A0ThemeDescriptionTextColor")]
		NSString A0ThemeDescriptionTextColor { get; }

		// extern NSString *const A0ThemeScreenBackgroundColor;
		[Field ("A0ThemeScreenBackgroundColor")]
		NSString A0ThemeScreenBackgroundColor { get; }

		// extern NSString *const A0ThemeScreenBackgroundImageName;
		[Field ("A0ThemeScreenBackgroundImageName")]
		NSString A0ThemeScreenBackgroundImageName { get; }

		// extern NSString *const A0ThemeIconImageName;
		[Field ("A0ThemeIconImageName")]
		NSString A0ThemeIconImageName { get; }

		// extern NSString *const A0ThemeIconBackgroundColor;
		[Field ("A0ThemeIconBackgroundColor")]
		NSString A0ThemeIconBackgroundColor { get; }

		// extern NSString *const A0ThemeSeparatorTextFont;
		[Field ("A0ThemeSeparatorTextFont")]
		NSString A0ThemeSeparatorTextFont { get; }

		// extern NSString *const A0ThemeSeparatorTextColor;
		[Field ("A0ThemeSeparatorTextColor")]
		NSString A0ThemeSeparatorTextColor { get; }

		// extern NSString *const A0ThemeCredentialBoxBorderColor;
		[Field ("A0ThemeCredentialBoxBorderColor")]
		NSString A0ThemeCredentialBoxBorderColor { get; }

		// extern NSString *const A0ThemeCredentialBoxSeparatorColor;
		[Field ("A0ThemeCredentialBoxSeparatorColor")]
		NSString A0ThemeCredentialBoxSeparatorColor { get; }

		// extern NSString *const A0ThemeCredentialBoxBackgroundColor;
		[Field ("A0ThemeCredentialBoxBackgroundColor")]
		NSString A0ThemeCredentialBoxBackgroundColor { get; }

		// extern NSString *const A0ThemeCloseButtonTintColor;
		[Field ("A0ThemeCloseButtonTintColor")]
		NSString A0ThemeCloseButtonTintColor { get; }
	}

	// @interface A0Theme : NSObject
	[BaseType (typeof(NSObject))]
	interface A0Theme
	{
		// +(A0Theme *)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		A0Theme SharedInstance { get; }

		// @property (assign, nonatomic) UIStatusBarStyle statusBarStyle;
		[Export ("statusBarStyle", ArgumentSemantic.Assign)]
		UIStatusBarStyle StatusBarStyle { get; set; }

		// @property (assign, nonatomic) BOOL statusBarHidden;
		[Export ("statusBarHidden")]
		bool StatusBarHidden { get; set; }

		// -(void)registerFont:(UIFont *)font forKey:(NSString *)key;
		[Export ("registerFont:forKey:")]
		void RegisterFont (UIFont font, string key);

		// -(void)registerColor:(UIColor *)color forKey:(NSString *)key;
		[Export ("registerColor:forKey:")]
		void RegisterColor (UIColor color, string key);

		// -(void)registerImageWithName:(NSString *)name bundle:(NSBundle *)bundle forKey:(NSString *)key;
		[Export ("registerImageWithName:bundle:forKey:")]
		void RegisterImageWithName (string name, NSBundle bundle, string key);

		// -(UIImage *)imageForKey:(NSString *)key;
		[Export ("imageForKey:")]
		UIImage ImageForKey (string key);

		// -(UIFont *)fontForKey:(NSString *)key defaultFont:(UIFont *)defaultFont;
		[Export ("fontForKey:defaultFont:")]
		UIFont FontForKey (string key, UIFont defaultFont);

		// -(UIColor *)colorForKey:(NSString *)key;
		[Export ("colorForKey:")]
		UIColor ColorForKey (string key);

		// -(UIColor *)colorForKey:(NSString *)key defaultColor:(UIColor *)defaultColor;
		[Export ("colorForKey:defaultColor:")]
		UIColor ColorForKey (string key, UIColor defaultColor);

		// -(UIFont *)fontForKey:(NSString *)key;
		[Export ("fontForKey:")]
		UIFont FontForKey (string key);

		// -(UIImage *)imageForKey:(NSString *)key defaultImage:(UIImage *)image;
		[Export ("imageForKey:defaultImage:")]
		UIImage ImageForKey (string key, UIImage image);

		// -(void)configurePrimaryButton:(UIButton *)button;
		[Export ("configurePrimaryButton:")]
		void ConfigurePrimaryButton (UIButton button);

		// -(void)configureSecondaryButton:(UIButton *)button;
		[Export ("configureSecondaryButton:")]
		void ConfigureSecondaryButton (UIButton button);

		// -(void)configureTextField:(UITextField *)textField;
		[Export ("configureTextField:")]
		void ConfigureTextField (UITextField textField);

		// -(void)configureLabel:(UILabel *)label;
		[Export ("configureLabel:")]
		void ConfigureLabel (UILabel label);

		// -(void)registerTheme:(A0Theme *)theme;
		[Export ("registerTheme:")]
		void RegisterTheme (A0Theme theme);

		// -(void)registerDefaultTheme;
		[Export ("registerDefaultTheme")]
		void RegisterDefaultTheme ();
	}

	// @protocol A0KeyboardEnabledView <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface A0KeyboardEnabledView
	{
		// @required -(CGRect)rectToKeepVisibleInView:(UIView *)view;
		[Abstract]
		[Export ("rectToKeepVisibleInView:")]
		CGRect RectToKeepVisibleInView (UIView view);

		// @required -(void)hideKeyboard;
		[Abstract]
		[Export ("hideKeyboard")]
		void HideKeyboard ();
	}

	// @interface A0ContainerViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface A0ContainerViewController
	{
		// -(void)displayController:(UIViewController<A0KeyboardEnabledView> *)controller;
		[Export ("displayController:")]
		void DisplayController (A0KeyboardEnabledView controller);

		// -(void)displayController:(UIViewController<A0KeyboardEnabledView> *)controller layout:(A0ContainerLayoutVertical)layout;
		[Export ("displayController:layout:")]
		void DisplayController (A0KeyboardEnabledView controller, A0ContainerLayoutVertical layout);
	}

	// typedef void (^A0AuthenticationBlock)(A0UserProfile *A0Token *);
	delegate void A0AuthenticationBlock (A0UserProfile arg0, A0Token arg1);

	// @interface A0LockViewController : A0ContainerViewController
	[BaseType (typeof(A0ContainerViewController))]
	interface A0LockViewController
	{
		// @property (copy, nonatomic) A0AuthenticationBlock onAuthenticationBlock;
		[Export ("onAuthenticationBlock", ArgumentSemantic.Copy)]
		A0AuthenticationBlock OnAuthenticationBlock { get; set; }

		// @property (copy, nonatomic) void (^onUserDismissBlock)();
		[Export ("onUserDismissBlock", ArgumentSemantic.Copy)]
		Action OnUserDismissBlock { get; set; }

		// @property (assign, nonatomic) BOOL usesEmail;
		[Export ("usesEmail")]
		bool UsesEmail { get; set; }

		// @property (assign, nonatomic) BOOL closable;
		[Export ("closable")]
		bool Closable { get; set; }

		// @property (assign, nonatomic) BOOL loginAfterSignUp;
		[Export ("loginAfterSignUp")]
		bool LoginAfterSignUp { get; set; }

		// @property (assign, nonatomic) BOOL defaultADUsernameFromEmailPrefix;
		[Export ("defaultADUsernameFromEmailPrefix")]
		bool DefaultADUsernameFromEmailPrefix { get; set; }

		// @property (nonatomic, strong) UIView * signUpDisclaimerView;
		[Export ("signUpDisclaimerView", ArgumentSemantic.Strong)]
		UIView SignUpDisclaimerView { get; set; }

		// @property (assign, nonatomic) BOOL useWebView;
		[Export ("useWebView")]
		bool UseWebView { get; set; }

		// @property (nonatomic, strong) A0AuthParameters * authenticationParameters;
		[Export ("authenticationParameters", ArgumentSemantic.Strong)]
		A0AuthParameters AuthenticationParameters { get; set; }

		// @property (nonatomic, strong) NSArray * connections;
		[Export ("connections", ArgumentSemantic.Strong)]
		A0Connection[] Connections { get; set; }

		// @property (copy, nonatomic) NSString * defaultDatabaseConnectionName;
		[Export ("defaultDatabaseConnectionName")]
		string DefaultDatabaseConnectionName { get; set; }
	}

	// @interface A0LockSignUpViewController : A0ContainerViewController
	[BaseType (typeof(A0ContainerViewController))]
	interface A0LockSignUpViewController
	{
		// @property (copy, nonatomic) void (^onAuthenticationBlock)(A0UserProfile *A0Token *);
		[Export ("onAuthenticationBlock", ArgumentSemantic.Copy)]
		Action<A0UserProfile, A0Token> OnAuthenticationBlock { get; set; }

		// @property (copy, nonatomic) void (^onUserDismissBlock)();
		[Export ("onUserDismissBlock", ArgumentSemantic.Copy)]
		Action OnUserDismissBlock { get; set; }

		// @property (assign, nonatomic) BOOL loginAfterSignUp;
		[Export ("loginAfterSignUp")]
		bool LoginAfterSignUp { get; set; }

		// @property (assign, nonatomic) BOOL useWebView;
		[Export ("useWebView")]
		bool UseWebView { get; set; }

		// @property (nonatomic, strong) A0AuthParameters * authenticationParameters;
		[Export ("authenticationParameters", ArgumentSemantic.Strong)]
		A0AuthParameters AuthenticationParameters { get; set; }

		// @property (nonatomic, strong) NSArray * connections;
		[Export ("connections", ArgumentSemantic.Strong)]
		A0Connection[] Connections { get; set; }

		// @property (copy, nonatomic) NSString * defaultDatabaseConnectionName;
		[Export ("defaultDatabaseConnectionName")]
		string DefaultDatabaseConnectionName { get; set; }
	}

	// @interface A0FacebookAuthenticator : NSObject <A0AuthenticationProvider>
	[BaseType (typeof(NSObject))]
	interface A0FacebookAuthenticator : IA0AuthenticationProvider
	{
		// +(A0FacebookAuthenticator *)newAuthenticatorWithPermissions:(NSArray *)permissions;
		[Static]
		[Export ("newAuthenticatorWithPermissions:")]
		A0FacebookAuthenticator NewAuthenticatorWithPermissions (NSString[] permissions);

		// +(A0FacebookAuthenticator *)newAuthenticatorWithDefaultPermissions;
		[Static]
		[Export ("newAuthenticatorWithDefaultPermissions")]
		A0FacebookAuthenticator NewAuthenticatorWithDefaultPermissions ();
	}

	// @interface A0TwitterAuthenticator : NSObject <A0AuthenticationProvider>
	[BaseType (typeof(NSObject))]
	interface A0TwitterAuthenticator : IA0AuthenticationProvider
	{
		// +(A0TwitterAuthenticator *)newAuthenticatorWithKey:(NSString *)key andSecret:(NSString *)secret;
		[Static]
		[Export ("newAuthenticatorWithKey:andSecret:")]
		A0TwitterAuthenticator NewAuthenticatorWithKey (string key, string secret);
	}
		
	partial interface Constants
	{
		// extern NSString *const A0ThemeTouchIDLockButtonImageNormalName;
		[Field ("A0ThemeTouchIDLockButtonImageNormalName")]
		NSString A0ThemeTouchIDLockButtonImageNormalName { get; }

		// extern NSString *const A0ThemeTouchIDLockButtonImageHighlightedName;
		[Field ("A0ThemeTouchIDLockButtonImageHighlightedName")]
		NSString A0ThemeTouchIDLockButtonImageHighlightedName { get; }

		// extern NSString *const A0ThemeTouchIDLockContainerBackgroundColor;
		[Field ("A0ThemeTouchIDLockContainerBackgroundColor")]
		NSString A0ThemeTouchIDLockContainerBackgroundColor { get; }
	}

	// @interface A0TouchIDLockViewController : UIViewController
	[BaseType (typeof(UIViewController))]
	interface A0TouchIDLockViewController
	{
		// @property (assign, nonatomic) BOOL closable;
		[Export ("closable")]
		bool Closable { get; set; }

		// @property (copy, nonatomic) void (^onAuthenticationBlock)(A0UserProfile *A0Token *);
		[Export ("onAuthenticationBlock", ArgumentSemantic.Copy)]
		Action<A0UserProfile, A0Token> OnAuthenticationBlock { get; set; }

		// @property (copy, nonatomic) void (^onUserDismissBlock)();
		[Export ("onUserDismissBlock", ArgumentSemantic.Copy)]
		Action OnUserDismissBlock { get; set; }

		// @property (nonatomic, strong) A0AuthParameters * authenticationParameters;
		[Export ("authenticationParameters", ArgumentSemantic.Strong)]
		A0AuthParameters AuthenticationParameters { get; set; }
	}

	// @interface A0SMSLockViewController : A0ContainerViewController
	[BaseType (typeof(A0ContainerViewController))]
	interface A0SMSLockViewController
	{
		// @property (assign, nonatomic) BOOL closable;
		[Export ("closable")]
		bool Closable { get; set; }

		// @property (copy, nonatomic) void (^onAuthenticationBlock)(A0UserProfile *A0Token *);
		[Export ("onAuthenticationBlock", ArgumentSemantic.Copy)]
		Action<A0UserProfile, A0Token> OnAuthenticationBlock { get; set; }

		// @property (copy, nonatomic) void (^onUserDismissBlock)();
		[Export ("onUserDismissBlock", ArgumentSemantic.Copy)]
		Action OnUserDismissBlock { get; set; }

		// @property (nonatomic, strong) A0AuthParameters * authenticationParameters;
		[Export ("authenticationParameters", ArgumentSemantic.Strong)]
		A0AuthParameters AuthenticationParameters { get; set; }

		// @property (copy, nonatomic) NSString * (^auth0APIToken)();
		[Export ("auth0APIToken", ArgumentSemantic.Copy)]
		Func<NSString> Auth0APIToken { get; set; }
	}

	// typedef void (^A0LoginInfoBlock)(NSString *NSString *);
	delegate void A0LoginInfoBlock (string arg0, string arg1);

	// @interface A0PasswordManager : NSObject
	[BaseType (typeof(NSObject))]
	interface A0PasswordManager
	{
		// @property (copy, nonatomic) NSString * loginURLString;
		[Export ("loginURLString")]
		string LoginURLString { get; set; }

		// +(instancetype)sharedInstance;
		[Static]
		[Export ("sharedInstance")]
		A0PasswordManager SharedInstance ();

		// +(BOOL)hasPasswordManagerInstalled;
		[Static]
		[Export ("hasPasswordManagerInstalled")]
		bool HasPasswordManagerInstalled { get; }

		// -(void)fillLoginInformationForViewController:(UIViewController *)controller sender:(id)sender completion:(A0LoginInfoBlock)completion;
		[Export ("fillLoginInformationForViewController:sender:completion:")]
		void FillLoginInformationForViewController (UIViewController controller, NSObject sender, A0LoginInfoBlock completion);

		// -(void)saveLoginInformationForUsername:(NSString *)username password:(NSString *)password loginInfo:(NSDictionary *)loginInfo controller:(UIViewController *)controller sender:(id)sender completion:(A0LoginInfoBlock)completion;
		[Export ("saveLoginInformationForUsername:password:loginInfo:controller:sender:completion:")]
		void SaveLoginInformationForUsername (string username, string password, NSDictionary loginInfo, UIViewController controller, NSObject sender, A0LoginInfoBlock completion);

		// +(UIImage *)iconImage;
		[Static]
		[Export ("iconImage")]
		UIImage IconImage { get; }
	}
}
