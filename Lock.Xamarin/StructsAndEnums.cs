using System;

namespace Auth0 {

	public enum A0StrategyType : ulong /* nuint */ {
		Social = 0,
		Database,
		Enterprise
	}

	public enum A0ErrorCode : long /* nint */ {
		AuthenticationFailed = 0,
		InvalidCredentials,
		InvalidUsername,
		InvalidPassword,
		InvalidRepeatPassword,
		InvalidPasswordAndRepeatPassword,
		FacebookCancelled,
		TwitterAppNotAuthorized,
		TwitterCancelled,
		TwitterNotConfigured,
		TwitterInvalidAccount,
		UknownProviderForStrategy,
		Auth0Cancelled,
		Auth0NotAuthorized,
		Auth0InvalidConfiguration,
		Auth0NoURLSchemeFound,
		NoConnectionNameFound,
		NotConnectedToInternet,
		GooglePlusFailed,
		GooglePlusCancelled
	}

	public enum A0ContainerLayoutVertical : long /* nint */ {
		Center = 0,
		Fill
	}
}
