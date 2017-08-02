//
// Structs.cs
// Fabric Crashlytics NuGet Package
//
// Created by David N. Junod on 7/31/2017
// Copyright 2017 Reality Check, Inc. All Rights Reserved Worldwide.
//

using System;
using System.Runtime.InteropServices;
using Foundation;

namespace FabricSdk
{
	static class CFunctions
	{
	    // extern void CLSLog (NSString * _Nonnull format, ...) __attribute__((format(NSString, 1, 2)));
	    [DllImport ("__Internal")]
	    static extern void CLSLog (NSString format, IntPtr varArgs);

	    // extern void CLSLogv (NSString * _Nonnull format, va_list _Nonnull ap) __attribute__((format(NSString, 1, 0)));
	    [DllImport ("__Internal")]
	    static extern unsafe void CLSLogv (NSString format, sbyte* ap);

	    // extern void CLSNSLog (NSString * _Nonnull format, ...) __attribute__((format(NSString, 1, 2)));
	    [DllImport ("__Internal")]
	    static extern void CLSNSLog (NSString format, IntPtr varArgs);

	    // extern void CLSNSLogv (NSString * _Nonnull format, va_list _Nonnull ap) __attribute__((format(NSString, 1, 0)));
	    [DllImport ("__Internal")]
	    static extern unsafe void CLSNSLogv (NSString format, sbyte* ap);
	}

}
