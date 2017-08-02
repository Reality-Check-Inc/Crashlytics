//
// Implementation.cs (iOS)
// Fabric Crashlytics NuGet Package
//
// Created by David N. Junod on 8/1/2017
// Copyright 2017 Reality Check, Inc. All Rights Reserved Worldwide.
//

using System;

using FabricSdk;

using Foundation;
using ObjCRuntime;

namespace CrashlyticsKit
{
    public sealed class CrashlyticsImplementation : Kit, ICrashlytics
    {
		public CrashlyticsImplementation() : base(Bindings.CrashlyticsKit.Crashlytics.SharedInstance)
		{
			Console.WriteLine("Crashlytics initialization (iOS)");
		}

		public void Crash()
		{
			Bindings.CrashlyticsKit.Crashlytics.SharedInstance.Crash();
		}

		public string UserIdentifier
		{
			set
			{
				Bindings.CrashlyticsKit.Crashlytics.SetUserIdentifier(value);
			}
		}
		public string UserName
		{
			set
			{
				Bindings.CrashlyticsKit.Crashlytics.SetUserName(value);
			}
		}
		public string UserEmail
		{
			set
			{
				Bindings.CrashlyticsKit.Crashlytics.SetUserEmail(value);
			}
		}

		public void SetStringValue(string key, string value)
		{
			//Bindings.CrashlyticsKit.Crashlytics.SetStringValue(value, key);
		}

		public void SetIntValue(string key, int value)
		{
			Bindings.CrashlyticsKit.Crashlytics.SetIntValue(value, key);
		}

		public void SetBoolValue(string key, bool value)
        {
            Bindings.CrashlyticsKit.Crashlytics.SetBoolValue(value, key);
        }

		public void LogEvent(string msg)
		{
			Bindings.CrashlyticsKit.Crashlytics.LogEvent(msg, null);
		}
	}
}
