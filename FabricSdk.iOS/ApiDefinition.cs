//
// ApiDefinition.cs
// Fabric Crashlytics NuGet Package
//
// Created by David N. Junod on 7/31/2017
// Copyright 2017 Reality Check, Inc. All Rights Reserved Worldwide.
//

using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;

namespace Bindings.FabricSdk
{
	// @interface Fabric : NSObject
	[BaseType(typeof(NSObject))]
	[DisableDefaultCtor]
	interface Fabric
	{
		// +(instancetype _Nonnull)with:(NSArray * _Nonnull)kitClasses;
		[Static]
		[Export("with:")]
		Fabric With(NSObject[] kitClasses);

		// +(instancetype _Nonnull)sharedSDK;
		[Static]
		[Export("sharedSDK")]
		Fabric SharedSDK();

		// @property (assign, nonatomic) BOOL debug;
		[Export("debug")]
		bool Debug { get; set; }
	}
}
