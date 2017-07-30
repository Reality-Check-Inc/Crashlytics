//
// AppDelegate.cs
//
// Created by David N. Junod on 4/7/2017
// Copyright (c) 2017 Reality Check, Inc.  All Rights Reserved Worldwide.
//
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using CrashlyticsKit;
using FabricSdk;

namespace CrashlyticsSample.iOS
{
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init();

			// Crashlytics initialization
			Crashlytics.Instance.Initialize();
			Fabric.Instance.Debug = true;
			Fabric.Instance.Initialize();

			LoadApplication(new App());

			return base.FinishedLaunching(app, options);
		}
	}
}
