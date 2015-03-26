using System;
using ObjCRuntime;

[assembly: LinkWith ("libLock.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator | LinkTarget.Arm64, SmartLink = true, ForceLoad = true, Frameworks="Security Accounts Social Twitter MobileCoreServices SystemConfiguration")]
