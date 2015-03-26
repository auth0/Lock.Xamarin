using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Auth0 {

	// @protocol A0APIRouter <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface A0APIRouter {

		// @property (readonly, nonatomic) NSString * clientId;
		[Export ("clientId")]
		string ClientId { get; }

		// @property (readonly, nonatomic) NSString * tenant;
		[Export ("tenant")]
		string Tenant { get; }

		// @property (readonly, nonatomic) NSURL * endpointURL;
		[Export ("endpointURL")]
		NSUrl EndpointURL { get; }

		// @property (readonly, nonatomic) NSURL * configurationURL;
		[Export ("configurationURL")]
		NSUrl ConfigurationURL { get; }

		// @required -(void)configureWithBundleInfo:(NSDictionary *)bundleInfo;
		[Export ("configureWithBundleInfo:")]
		[Abstract]
		void ConfigureWithBundleInfo (NSDictionary bundleInfo);

		// @required -(void)configureForDomain:(NSString *)domain clientId:(NSString *)clientId;
		[Export ("configureForDomain:clientId:")]
		[Abstract]
		void ConfigureForDomain (string domain, string clientId);

		// @required -(void)configureForDomain:(NSString *)domain configurationDomain:(NSString *)configurationDomain clientId:(NSString *)clientId;
		[Export ("configureForDomain:configurationDomain:clientId:")]
		[Abstract]
		void ConfigureForDomain (string domain, string configurationDomain, string clientId);

		// @required -(void)configureForTenant:(NSString *)tenant clientId:(NSString *)clientId;
		[Export ("configureForTenant:clientId:")]
		[Abstract]
		void ConfigureForTenant (string tenant, string clientId);

		// @required -(NSString *)loginPath;
		[Export ("loginPath")]
		[Abstract]
		string LoginPath ();

		// @required -(NSString *)signUpPath;
		[Export ("signUpPath")]
		[Abstract]
		string SignUpPath ();

		// @required -(NSString *)changePasswordPath;
		[Export ("changePasswordPath")]
		[Abstract]
		string ChangePasswordPath ();

		// @required -(NSString *)socialLoginPath;
		[Export ("socialLoginPath")]
		[Abstract]
		string SocialLoginPath ();

		// @required -(NSString *)userInfoPath;
		[Export ("userInfoPath")]
		[Abstract]
		string UserInfoPath ();

		// @required -(NSString *)tokenInfoPath;
		[Export ("tokenInfoPath")]
		[Abstract]
		string TokenInfoPath ();

		// @required -(NSString *)delegationPath;
		[Export ("delegationPath")]
		[Abstract]
		string DelegationPath ();

		// @required -(NSString *)unlinkPath;
		[Export ("unlinkPath")]
		[Abstract]
		string UnlinkPath ();

		// @required -(NSString *)usersPath;
		[Export ("usersPath")]
		[Abstract]
		string UsersPath ();

		// @required -(NSString *)userPublicKeyPathForUser:(NSString *)userId;
		[Export ("userPublicKeyPathForUser:")]
		[Abstract]
		string UserPublicKeyPathForUser (string userId);
	}

	// @interface A0APIClient : NSObject
	[BaseType (typeof (NSObject))]
	interface A0APIClient {

		// -(instancetype)initWithClientId:(NSString *)clientId andTenant:(NSString *)tenant;
		[Export ("initWithClientId:andTenant:")]
		IntPtr Constructor (string clientId, string tenant);

		// -(instancetype)initWithAPIRouter:(id<A0APIRouter>)router;
		[Export ("initWithAPIRouter:")]
		IntPtr Constructor (A0APIRouter router);

		// @property (nonatomic, strong) id<A0APIRouter> router;
		[Export ("router", ArgumentSemantic.Retain)]
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

		// +(instancetype)sharedClient;
		[Static, Export ("sharedClient")]
		A0APIClient SharedClient ();

		// -(void)logout;
		[Export ("logout")]
		void Logout ();

		// -(NSURLSessionDataTask *)fetchAppInfoWithSuccess:(A0APIClientFetchAppInfoSuccess)success failure:(A0APIClientError)failure;
		[Export ("fetchAppInfoWithSuccess:failure:")]
		NSUrlSessionDataTask FetchAppInfoWithSuccess (Action<A0Application> success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)loginWithUsername:(NSString *)username password:(NSString *)password parameters:(A0AuthParameters *)parameters success:(A0APIClientAuthenticationSuccess)success failure:(A0APIClientError)failure;
		[Export ("loginWithUsername:password:parameters:success:failure:")]
		NSUrlSessionDataTask LoginWithUsername (string username, string password, A0AuthParameters parameters, Action<A0UserProfile, A0Token> success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)signUpWithUsername:(NSString *)username password:(NSString *)password loginOnSuccess:(BOOL)loginOnSuccess parameters:(A0AuthParameters *)parameters success:(A0APIClientAuthenticationSuccess)success failure:(A0APIClientError)failure;
		[Export ("signUpWithUsername:password:loginOnSuccess:parameters:success:failure:")]
		NSUrlSessionDataTask SignUpWithUsername (string username, string password, bool loginOnSuccess, A0AuthParameters parameters, Action<A0UserProfile, A0Token> success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)changePassword:(NSString *)newPassword forUsername:(NSString *)username parameters:(A0AuthParameters *)parameters success:(void (^)())success failure:(A0APIClientError)failure;
		[Export ("changePassword:forUsername:parameters:success:failure:")]
		NSUrlSessionDataTask ChangePassword (string newPassword, string username, A0AuthParameters parameters, Action success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)loginWithIdToken:(NSString *)idToken deviceName:(NSString *)deviceName parameters:(A0AuthParameters *)parameters success:(A0APIClientAuthenticationSuccess)success failure:(A0APIClientError)failure;
		[Export ("loginWithIdToken:deviceName:parameters:success:failure:")]
		NSUrlSessionDataTask LoginWithIdToken (string idToken, string deviceName, A0AuthParameters parameters, Action<A0UserProfile, A0Token> success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)loginWithPhoneNumber:(NSString *)phoneNumber passcode:(NSString *)passcode parameters:(A0AuthParameters *)parameters success:(A0APIClientAuthenticationSuccess)success failure:(A0APIClientError)failure;
		[Export ("loginWithPhoneNumber:passcode:parameters:success:failure:")]
		NSUrlSessionDataTask LoginWithPhoneNumber (string phoneNumber, string passcode, A0AuthParameters parameters, Action<A0UserProfile, A0Token> success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)authenticateWithSocialConnectionName:(NSString *)connectionName credentials:(A0IdentityProviderCredentials *)socialCredentials parameters:(A0AuthParameters *)parameters success:(A0APIClientAuthenticationSuccess)success failure:(A0APIClientError)failure;
		[Export ("authenticateWithSocialConnectionName:credentials:parameters:success:failure:")]
		NSUrlSessionDataTask AuthenticateWithSocialConnectionName (string connectionName, A0IdentityProviderCredentials socialCredentials, A0AuthParameters parameters, Action<A0UserProfile, A0Token> success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)fetchNewIdTokenWithRefreshToken:(NSString *)refreshToken parameters:(A0AuthParameters *)parameters success:(A0APIClientNewIdTokenSuccess)success failure:(A0APIClientError)failure;
		[Export ("fetchNewIdTokenWithRefreshToken:parameters:success:failure:")]
		NSUrlSessionDataTask FetchNewIdTokenWithRefreshToken (string refreshToken, A0AuthParameters parameters, Action<A0Token> success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)fetchNewIdTokenWithIdToken:(NSString *)idToken parameters:(A0AuthParameters *)parameters success:(A0APIClientNewIdTokenSuccess)success failure:(A0APIClientError)failure;
		[Export ("fetchNewIdTokenWithIdToken:parameters:success:failure:")]
		NSUrlSessionDataTask FetchNewIdTokenWithIdToken (string idToken, A0AuthParameters parameters, Action<A0Token> success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)fetchDelegationTokenWithParameters:(A0AuthParameters *)parameters success:(A0APIClientNewDelegationTokenSuccess)success failure:(A0APIClientError)failure;
		[Export ("fetchDelegationTokenWithParameters:success:failure:")]
		NSUrlSessionDataTask FetchDelegationTokenWithParameters (A0AuthParameters parameters, Action<NSDictionary> success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)fetchUserProfileWithIdToken:(NSString *)idToken success:(A0APIClientUserProfileSuccess)success failure:(A0APIClientError)failure;
		[Export ("fetchUserProfileWithIdToken:success:failure:")]
		NSUrlSessionDataTask FetchUserProfileWithIdToken (string idToken, Action<A0UserProfile> success, Action<NSError> failure);

		// -(NSURLSessionDataTask *)unlinkAccountWithUserId:(NSString *)userId accessToken:(NSString *)accessToken success:(void (^)())success failure:(A0APIClientError)failure;
		[Export ("unlinkAccountWithUserId:accessToken:success:failure:")]
		NSUrlSessionDataTask UnlinkAccountWithUserId (string userId, string accessToken, Action success, Action<NSError> failure);
	}

	// @interface A0UserAPIClient : NSObject
	[BaseType (typeof (NSObject))]
	interface A0UserAPIClient {

		// -(instancetype)initWithRouter:(id<A0APIRouter>)router accessToken:(NSString *)accessToken;
		[Export ("initWithRouter:accessToken:")]
		IntPtr Constructor (A0APIRouter router, string accessToken);

		// -(instancetype)initWithClientId:(NSString *)clientId tenant:(NSString *)tenant accessToken:(NSString *)accessToken;
		[Export ("initWithClientId:tenant:accessToken:")]
		IntPtr Constructor (string clientId, string tenant, string accessToken);

		// +(A0UserAPIClient *)clientWithAccessToken:(NSString *)accessToken;
		[Static, Export ("clientWithAccessToken:")]
		A0UserAPIClient ClientWithAccessToken (string accessToken);

		// +(A0UserAPIClient *)clientWithIdToken:(NSString *)idToken;
		[Static, Export ("clientWithIdToken:")]
		A0UserAPIClient ClientWithIdToken (string idToken);

		// -(void)fetchUserProfileSuccess:(A0UserAPIClientUserProfileSuccess)success failure:(A0UserAPIClientError)failure;
		[Export ("fetchUserProfileSuccess:failure:")]
		void FetchUserProfileSuccess (Action<A0UserProfile> success, Action<NSError> failure);

		// -(void)registerPublicKey:(NSData *)pubKey device:(NSString *)deviceName user:(NSString *)userId success:(void (^)())success failure:(A0UserAPIClientError)failure;
		[Export ("registerPublicKey:device:user:success:failure:")]
		void RegisterPublicKey (NSData pubKey, string deviceName, string userId, Action success, Action<NSError> failure);

		// -(void)removePublicKeyOfDevice:(NSString *)deviceName user:(NSString *)userId success:(void (^)())success failure:(A0UserAPIClientError)failure;
		[Export ("removePublicKeyOfDevice:user:success:failure:")]
		void RemovePublicKeyOfDevice (string deviceName, string userId, Action success, Action<NSError> failure);
	}

	// @interface A0Application : NSObject
	[BaseType (typeof (NSObject))]
	interface A0Application {

		// -(instancetype)initWithJSONDictionary:(NSDictionary *)JSONDict;
		[Export ("initWithJSONDictionary:")]
		IntPtr Constructor (NSDictionary JSONDict);

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
		NSObject [] Strategies { get; }

		// @property (readonly, nonatomic) A0Strategy * databaseStrategy;
		[Export ("databaseStrategy")]
		A0Strategy DatabaseStrategy { get; }

		// @property (readonly, nonatomic) NSArray * socialStrategies;
		[Export ("socialStrategies")]
		NSObject [] SocialStrategies { get; }

		// @property (readonly, nonatomic) NSArray * enterpriseStrategies;
		[Export ("enterpriseStrategies")]
		NSObject [] EnterpriseStrategies { get; }

		// @property (readonly, nonatomic) A0Strategy * activeDirectoryStrategy;
		[Export ("activeDirectoryStrategy")]
		A0Strategy ActiveDirectoryStrategy { get; }

		// -(A0Strategy *)strategyByName:(NSString *)name;
		[Export ("strategyByName:")]
		A0Strategy StrategyByName (string name);

		// -(A0Strategy *)enterpriseStrategyWithConnection:(NSString *)connectionName;
		[Export ("enterpriseStrategyWithConnection:")]
		A0Strategy EnterpriseStrategyWithConnection (string connectionName);
	}

	// @interface A0Strategy : NSObject
	[BaseType (typeof (NSObject))]
	interface A0Strategy {

		// -(instancetype)initWithJSONDictionary:(NSDictionary *)JSONDictionary;
		[Export ("initWithJSONDictionary:")]
		IntPtr Constructor (NSDictionary JSONDictionary);

		// -(instancetype)initWithName:(NSString *)name connections:(NSArray *)connections type:(A0StrategyType)type;
		[Export ("initWithName:connections:type:")]
		IntPtr Constructor (string name, NSObject [] connections, A0StrategyType type);

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSArray * connections;
		[Export ("connections")]
		NSObject [] Connections { get; }

		// @property (readonly, nonatomic) A0StrategyType type;
		[Export ("type")]
		A0StrategyType Type { get; }

		// +(instancetype)newEnterpriseStrategyWithName:(NSString *)name connections:(NSArray *)connections;
		[Static, Export ("newEnterpriseStrategyWithName:connections:")]
		A0Strategy NewEnterpriseStrategyWithName (string name, NSObject [] connections);

		// +(instancetype)newDatabaseStrategyWithConnections:(NSArray *)connections;
		[Static, Export ("newDatabaseStrategyWithConnections:")]
		A0Strategy NewDatabaseStrategyWithConnections (NSObject [] connections);
	}

	// @interface A0Connection : NSObject
	[BaseType (typeof (NSObject))]
	interface A0Connection {

		// -(instancetype)initWithJSONDictionary:(NSDictionary *)JSON;
		[Export ("initWithJSONDictionary:")]
		IntPtr Constructor (NSDictionary JSON);

		// @property (readonly, nonatomic) NSString * name;
		[Export ("name")]
		string Name { get; }

		// @property (readonly, nonatomic) NSDictionary * values;
		[Export ("values")]
		NSDictionary Values { get; }
	}

	// @interface A0Errors : NSObject
	[BaseType (typeof (NSObject))]
	interface A0Errors {

		// +(NSError *)noConnectionNameFound;
		[Static, Export ("noConnectionNameFound")]
		NSError NoConnectionNameFound ();

		// +(NSError *)notConnectedToInternetError;
		[Static, Export ("notConnectedToInternetError")]
		NSError NotConnectedToInternetError ();

		// +(BOOL)isAuth0Error:(NSError *)error withCode:(A0ErrorCode)code;
		[Static, Export ("isAuth0Error:withCode:")]
		bool IsAuth0Error (NSError error, A0ErrorCode code);

		// +(BOOL)isCancelledSocialAuthentication:(NSError *)error;
		[Static, Export ("isCancelledSocialAuthentication:")]
		bool IsCancelledSocialAuthentication (NSError error);

		// +(NSError *)defaultLoginErrorFor:(NSError *)error;
		[Static, Export ("defaultLoginErrorFor:")]
		NSError DefaultLoginErrorFor (NSError error);

		// +(NSError *)invalidLoginCredentialsUsingEmail:(BOOL)usesEmail;
		[Static, Export ("invalidLoginCredentialsUsingEmail:")]
		NSError InvalidLoginCredentialsUsingEmail (bool usesEmail);

		// +(NSError *)invalidLoginUsernameUsingEmail:(BOOL)usesEmail;
		[Static, Export ("invalidLoginUsernameUsingEmail:")]
		NSError InvalidLoginUsernameUsingEmail (bool usesEmail);

		// +(NSError *)invalidLoginPassword;
		[Static, Export ("invalidLoginPassword")]
		NSError InvalidLoginPassword ();

		// +(NSError *)invalidSignUpCredentialsUsingEmail:(BOOL)usesEmail;
		[Static, Export ("invalidSignUpCredentialsUsingEmail:")]
		NSError InvalidSignUpCredentialsUsingEmail (bool usesEmail);

		// +(NSError *)invalidSignUpUsernameUsingEmail:(BOOL)usesEmail;
		[Static, Export ("invalidSignUpUsernameUsingEmail:")]
		NSError InvalidSignUpUsernameUsingEmail (bool usesEmail);

		// +(NSError *)invalidSignUpPassword;
		[Static, Export ("invalidSignUpPassword")]
		NSError InvalidSignUpPassword ();

		// +(NSError *)invalidChangePasswordCredentialsUsingEmail:(BOOL)usesEmail;
		[Static, Export ("invalidChangePasswordCredentialsUsingEmail:")]
		NSError InvalidChangePasswordCredentialsUsingEmail (bool usesEmail);

		// +(NSError *)invalidChangePasswordUsernameUsingEmail:(BOOL)usesEmail;
		[Static, Export ("invalidChangePasswordUsernameUsingEmail:")]
		NSError InvalidChangePasswordUsernameUsingEmail (bool usesEmail);

		// +(NSError *)invalidChangePasswordPassword;
		[Static, Export ("invalidChangePasswordPassword")]
		NSError InvalidChangePasswordPassword ();

		// +(NSError *)invalidChangePasswordRepeatPassword;
		[Static, Export ("invalidChangePasswordRepeatPassword")]
		NSError InvalidChangePasswordRepeatPassword ();

		// +(NSError *)invalidChangePasswordRepeatPasswordAndPassword;
		[Static, Export ("invalidChangePasswordRepeatPasswordAndPassword")]
		NSError InvalidChangePasswordRepeatPasswordAndPassword ();

		// +(NSError *)urlSchemeNotRegistered;
		[Static, Export ("urlSchemeNotRegistered")]
		NSError UrlSchemeNotRegistered ();

		// +(NSError *)unkownProviderForStrategy:(NSString *)strategyName;
		[Static, Export ("unkownProviderForStrategy:")]
		NSError UnkownProviderForStrategy (string strategyName);

		// +(NSError *)facebookCancelled;
		[Static, Export ("facebookCancelled")]
		NSError FacebookCancelled ();

		// +(NSError *)twitterAppNotAuthorized;
		[Static, Export ("twitterAppNotAuthorized")]
		NSError TwitterAppNotAuthorized ();

		// +(NSError *)twitterAppOauthNotAuthorized;
		[Static, Export ("twitterAppOauthNotAuthorized")]
		NSError TwitterAppOauthNotAuthorized ();

		// +(NSError *)twitterCancelled;
		[Static, Export ("twitterCancelled")]
		NSError TwitterCancelled ();

		// +(NSError *)twitterNotConfigured;
		[Static, Export ("twitterNotConfigured")]
		NSError TwitterNotConfigured ();

		// +(NSError *)twitterInvalidAccount;
		[Static, Export ("twitterInvalidAccount")]
		NSError TwitterInvalidAccount ();

		// +(NSError *)auth0CancelledForStrategy:(NSString *)strategyName;
		[Static, Export ("auth0CancelledForStrategy:")]
		NSError Auth0CancelledForStrategy (string strategyName);

		// +(NSError *)auth0NotAuthorizedForStrategy:(NSString *)strategyName;
		[Static, Export ("auth0NotAuthorizedForStrategy:")]
		NSError Auth0NotAuthorizedForStrategy (string strategyName);

		// +(NSError *)auth0InvalidConfigurationForStrategy:(NSString *)strategyName;
		[Static, Export ("auth0InvalidConfigurationForStrategy:")]
		NSError Auth0InvalidConfigurationForStrategy (string strategyName);

		// +(NSError *)googleplusFailed;
		[Static, Export ("googleplusFailed")]
		NSError GoogleplusFailed ();

		// +(NSError *)googleplusCancelled;
		[Static, Export ("googleplusCancelled")]
		NSError GoogleplusCancelled ();

		// +(NSString *)localizedStringForSocialLoginError:(NSError *)error;
		[Static, Export ("localizedStringForSocialLoginError:")]
		string LocalizedStringForSocialLoginError (NSError error);

		// +(NSString *)localizedStringForLoginError:(NSError *)error;
		[Static, Export ("localizedStringForLoginError:")]
		string LocalizedStringForLoginError (NSError error);

		// +(NSString *)localizedStringForSMSLoginError:(NSError *)error;
		[Static, Export ("localizedStringForSMSLoginError:")]
		string LocalizedStringForSMSLoginError (NSError error);

		// +(NSString *)localizedStringForSignUpError:(NSError *)error;
		[Static, Export ("localizedStringForSignUpError:")]
		string LocalizedStringForSignUpError (NSError error);

		// +(NSString *)localizedStringForChangePasswordError:(NSError *)error;
		[Static, Export ("localizedStringForChangePasswordError:")]
		string LocalizedStringForChangePasswordError (NSError error);
	}

	// @interface A0Token : NSObject
	[BaseType (typeof (NSObject))]
	interface A0Token {

		// -(instancetype)initWithAccessToken:(NSString *)accessToken idToken:(NSString *)idToken tokenType:(NSString *)tokenType refreshToken:(NSString *)refreshToken;
		[Export ("initWithAccessToken:idToken:tokenType:refreshToken:")]
		IntPtr Constructor (string accessToken, string idToken, string tokenType, string refreshToken);

		// -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

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
	}

	// @interface A0UserProfile : NSObject <NSCoding>
	[BaseType (typeof (NSObject))]
	interface A0UserProfile : INSCoding {

		// -(instancetype)initWithUserId:(NSString *)userId name:(NSString *)name nickname:(NSString *)nickname email:(NSString *)email picture:(NSURL *)picture createdAt:(NSDate *)createdAt;
		[Export ("initWithUserId:name:nickname:email:picture:createdAt:")]
		IntPtr Constructor (string userId, string name, string nickname, string email, NSUrl picture, NSDate createdAt);

		// -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

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
		[Export ("identities", ArgumentSemantic.Retain)]
		NSObject [] Identities { get; set; }
	}

	// @interface A0IdentityProviderCredentials : NSObject
	[BaseType (typeof (NSObject))]
	interface A0IdentityProviderCredentials {

		// -(instancetype)initWithAccessToken:(NSString *)accessToken extraInfo:(NSDictionary *)extraInfo;
		[Export ("initWithAccessToken:extraInfo:")]
		IntPtr Constructor (string accessToken, NSDictionary extraInfo);

		// -(instancetype)initWithAccessToken:(NSString *)accessToken;
		[Export ("initWithAccessToken:")]
		IntPtr Constructor (string accessToken);

		// @property (readonly, nonatomic) NSString * accessToken;
		[Export ("accessToken")]
		string AccessToken { get; }

		// @property (readonly, nonatomic) NSDictionary * extraInfo;
		[Export ("extraInfo")]
		NSDictionary ExtraInfo { get; }
	}

	// @protocol A0AuthenticationProvider <NSObject>
	[Protocol, Model]
	[BaseType (typeof (NSObject))]
	interface A0AuthenticationProvider {

		// @required -(NSString *)identifier;
		[Export ("identifier")]
		[Abstract]
		string Identifier ();

		// @required -(void)authenticateWithParameters:(A0AuthParameters *)parameters success:(void (^)(A0UserProfile *, A0Token *))success failure:(void (^)(NSError *))failure;
		[Export ("authenticateWithParameters:success:failure:")]
		[Abstract]
		void AuthenticateWithParameters (A0AuthParameters parameters, Action<A0UserProfile, A0Token> success, Action<NSError> failure);

		// @required -(void)clearSessions;
		[Export ("clearSessions")]
		[Abstract]
		void ClearSessions ();

		// @optional -(BOOL)handleURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication;
		[Export ("handleURL:sourceApplication:")]
		bool HandleURL (NSUrl url, string sourceApplication);
	}

	// @interface A0IdentityProviderAuthenticator : NSObject
	[BaseType (typeof (NSObject))]
	interface A0IdentityProviderAuthenticator {

		// @property (assign, nonatomic) BOOL useWebAsDefault;
		[Export ("useWebAsDefault", ArgumentSemantic.UnsafeUnretained)]
		bool UseWebAsDefault { get; set; }

		// +(A0IdentityProviderAuthenticator *)sharedInstance;
		[Static, Export ("sharedInstance")]
		A0IdentityProviderAuthenticator SharedInstance ();

		// -(void)registerAuthenticationProviders:(NSArray *)authenticationProviders;
		[Export ("registerAuthenticationProviders:")]
		void RegisterAuthenticationProviders (NSObject [] authenticationProviders);

		// -(void)registerAuthenticationProvider:(id<A0AuthenticationProvider>)authenticationProvider;
		[Export ("registerAuthenticationProvider:")]
		void RegisterAuthenticationProvider (A0AuthenticationProvider authenticationProvider);

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

	// @interface A0AuthParameters : NSObject <NSCopying>
	[BaseType (typeof (NSObject))]
	interface A0AuthParameters : INSCopying {

		// -(instancetype)initWithScopes:(NSArray *)scopes;
		[Export ("initWithScopes:")]
		IntPtr Constructor (NSObject [] scopes);

		// -(instancetype)initWithDictionary:(NSDictionary *)dictionary;
		[Export ("initWithDictionary:")]
		IntPtr Constructor (NSDictionary dictionary);

		// @property (copy, nonatomic) NSArray * scopes;
		[Export ("scopes", ArgumentSemantic.Copy)]
		NSObject [] Scopes { get; set; }

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

		// +(instancetype)newDefaultParams;
		[Static, Export ("newDefaultParams")]
		A0AuthParameters NewDefaultParams ();

		// +(instancetype)newWithScopes:(NSArray *)scopes;
		[Static, Export ("newWithScopes:")]
		A0AuthParameters NewWithScopes (NSObject [] scopes);

		// +(instancetype)newWithDictionary:(NSDictionary *)dictionary;
		[Static, Export ("newWithDictionary:")]
		A0AuthParameters NewWithDictionary (NSDictionary dictionary);

		// -(NSDictionary *)asAPIPayload;
		[Export ("asAPIPayload")]
		NSDictionary AsAPIPayload ();

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
	[BaseType (typeof (NSObject))]
	interface A0UserIdentity : INSCoding {

		// -(instancetype)initWithJSONDictionary:(NSDictionary *)JSONDict;
		[Export ("initWithJSONDictionary:")]
		IntPtr Constructor (NSDictionary JSONDict);

		// @property (readonly, nonatomic) NSString * connection;
		[Export ("connection")]
		string Connection { get; }

		// @property (readonly, nonatomic) NSString * provider;
		[Export ("provider")]
		string Provider { get; }

		// @property (readonly, nonatomic) NSString * userId;
		[Export ("userId")]
		string UserId { get; }

		// @property (readonly, nonatomic, getter = isSocial) BOOL social;
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
	}

	// @interface A0LockLogger : NSObject
	[BaseType (typeof (NSObject))]
	interface A0LockLogger {

		// +(void)logAll;
		[Static, Export ("logAll")]
		void LogAll ();

		// +(void)logError;
		[Static, Export ("logError")]
		void LogError ();

		// +(void)logOff;
		[Static, Export ("logOff")]
		void LogOff ();
	}

	// @interface A0Theme : NSObject
	[BaseType (typeof (NSObject))]
	interface A0Theme {

		// @property (assign, nonatomic) UIStatusBarStyle statusBarStyle;
		[Export ("statusBarStyle", ArgumentSemantic.UnsafeUnretained)]
		UIStatusBarStyle StatusBarStyle { get; set; }

		// @property (assign, nonatomic) BOOL statusBarHidden;
		[Export ("statusBarHidden", ArgumentSemantic.UnsafeUnretained)]
		bool StatusBarHidden { get; set; }

		// +(A0Theme *)sharedInstance;
		[Static, Export ("sharedInstance")]
		A0Theme SharedInstance ();

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
	[BaseType (typeof (NSObject))]
	interface A0KeyboardEnabledView {

		// @required -(CGRect)rectToKeepVisibleInView:(UIView *)view;
		[Export ("rectToKeepVisibleInView:")]
		[Abstract]
		CGRect RectToKeepVisibleInView (UIView view);

		// @required -(void)hideKeyboard;
		[Export ("hideKeyboard")]
		[Abstract]
		void HideKeyboard ();
	}

	// @interface A0ContainerViewController : UIViewController
	[BaseType (typeof (UIViewController))]
	interface A0ContainerViewController {

		// -(void)displayController:(UIViewController<A0KeyboardEnabledView> *)controller;
		[Export ("displayController:")]
		void DisplayController (UIViewController controller);

		// -(void)displayController:(UIViewController<A0KeyboardEnabledView> *)controller layout:(A0ContainerLayoutVertical)layout;
		[Export ("displayController:layout:")]
		void DisplayController (UIViewController controller, A0ContainerLayoutVertical layout);
	}

	// @interface A0LockViewController : A0ContainerViewController
	[BaseType (typeof (A0ContainerViewController))]
	interface A0LockViewController {

		// @property (copy, nonatomic) A0AuthenticationBlock onAuthenticationBlock;
		[Export ("onAuthenticationBlock", ArgumentSemantic.Copy)]
		Action<A0UserProfile, A0Token> OnAuthenticationBlock { get; set; }

		// @property (copy, nonatomic) void (^)() onUserDismissBlock;
		[Export ("onUserDismissBlock", ArgumentSemantic.Copy)]
		Action OnUserDismissBlock { get; set; }

		// @property (assign, nonatomic) BOOL usesEmail;
		[Export ("usesEmail", ArgumentSemantic.UnsafeUnretained)]
		bool UsesEmail { get; set; }

		// @property (assign, nonatomic) BOOL closable;
		[Export ("closable", ArgumentSemantic.UnsafeUnretained)]
		bool Closable { get; set; }

		// @property (assign, nonatomic) BOOL loginAfterSignUp;
		[Export ("loginAfterSignUp", ArgumentSemantic.UnsafeUnretained)]
		bool LoginAfterSignUp { get; set; }

		// @property (assign, nonatomic) BOOL defaultADUsernameFromEmailPrefix;
		[Export ("defaultADUsernameFromEmailPrefix", ArgumentSemantic.UnsafeUnretained)]
		bool DefaultADUsernameFromEmailPrefix { get; set; }

		// @property (nonatomic, strong) UIView * signUpDisclaimerView;
		[Export ("signUpDisclaimerView", ArgumentSemantic.Retain)]
		UIView SignUpDisclaimerView { get; set; }

		// @property (assign, nonatomic) BOOL useWebView;
		[Export ("useWebView", ArgumentSemantic.UnsafeUnretained)]
		bool UseWebView { get; set; }

		// @property (nonatomic, strong) A0AuthParameters * authenticationParameters;
		[Export ("authenticationParameters", ArgumentSemantic.Retain)]
		A0AuthParameters AuthenticationParameters { get; set; }

		// @property (nonatomic, strong) NSArray * connections;
		[Export ("connections", ArgumentSemantic.Retain)]
		NSObject [] Connections { get; set; }

		// @property (copy, nonatomic) NSString * defaultDatabaseConnectionName;
		[Export ("defaultDatabaseConnectionName")]
		string DefaultDatabaseConnectionName { get; set; }
	}

	// @interface A0LockSignUpViewController : A0ContainerViewController
	[BaseType (typeof (A0ContainerViewController))]
	interface A0LockSignUpViewController {

		// @property (copy, nonatomic) void (^)(A0UserProfile *, A0Token *) onAuthenticationBlock;
		[Export ("onAuthenticationBlock", ArgumentSemantic.Copy)]
		Action<A0UserProfile, A0Token> OnAuthenticationBlock { get; set; }

		// @property (copy, nonatomic) void (^)() onUserDismissBlock;
		[Export ("onUserDismissBlock", ArgumentSemantic.Copy)]
		Action OnUserDismissBlock { get; set; }

		// @property (assign, nonatomic) BOOL loginAfterSignUp;
		[Export ("loginAfterSignUp", ArgumentSemantic.UnsafeUnretained)]
		bool LoginAfterSignUp { get; set; }

		// @property (assign, nonatomic) BOOL useWebView;
		[Export ("useWebView", ArgumentSemantic.UnsafeUnretained)]
		bool UseWebView { get; set; }

		// @property (nonatomic, strong) A0AuthParameters * authenticationParameters;
		[Export ("authenticationParameters", ArgumentSemantic.Retain)]
		A0AuthParameters AuthenticationParameters { get; set; }

		// @property (nonatomic, strong) NSArray * connections;
		[Export ("connections", ArgumentSemantic.Retain)]
		NSObject [] Connections { get; set; }

		// @property (copy, nonatomic) NSString * defaultDatabaseConnectionName;
		[Export ("defaultDatabaseConnectionName")]
		string DefaultDatabaseConnectionName { get; set; }
	}

	// @interface A0FacebookAuthenticator : NSObject <A0AuthenticationProvider>
	[BaseType (typeof (NSObject))]
	interface A0FacebookAuthenticator : A0AuthenticationProvider {

		// +(A0FacebookAuthenticator *)newAuthenticatorWithPermissions:(NSArray *)permissions;
		[Static, Export ("newAuthenticatorWithPermissions:")]
		A0FacebookAuthenticator NewAuthenticatorWithPermissions (NSObject [] permissions);

		// +(A0FacebookAuthenticator *)newAuthenticatorWithDefaultPermissions;
		[Static, Export ("newAuthenticatorWithDefaultPermissions")]
		A0FacebookAuthenticator NewAuthenticatorWithDefaultPermissions ();
	}

	// @interface A0TwitterAuthenticator : NSObject <A0AuthenticationProvider>
	[BaseType (typeof (NSObject))]
	interface A0TwitterAuthenticator : A0AuthenticationProvider {

		// +(A0TwitterAuthenticator *)newAuthenticatorWithKey:(NSString *)key andSecret:(NSString *)secret;
		[Static, Export ("newAuthenticatorWithKey:andSecret:")]
		A0TwitterAuthenticator NewAuthenticatorWithKey (string key, string secret);
	}
}
