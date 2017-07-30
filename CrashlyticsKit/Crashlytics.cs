//
// ICrashlytics.cs
// Crashlytics
//
// Created by David N. Junod on 3/18/2017
// Copyright (c) 2017 Reality Check, Inc.  All Rights Reserved Worldwide.
//
using System;
using System.Diagnostics;

using FabricSdk;

// following this pattern, except putting Abstraction into the shared file.
// https://blog.xamarin.com/creating-reusable-plugins-for-xamarin-forms/
//
// * this file is SHARED between implementations
//		Crashlytics.cs - add a link to the file
// * implementation
//		CrashlyticsImplementation.cs
// * all implementation assemblies have the same Properties/AssemblyInfo.
// * General/Main Settings/Name same with .Droid & .iOS
// * General/Main Settings/Default Namespace exact same

namespace CrashlyticsKit
{
	public interface ICrashlytics : IKit
	{
		string Version { get; }

		void Crash();

		ICrashlytics SetUserIdentifier(string identifier);

		ICrashlytics SetUserName(string name);

		ICrashlytics SetUserEmail(string email);

		ICrashlytics SetObjectValue(string key, object value);

		ICrashlytics SetStringValue(string key, string value);

		ICrashlytics SetIntValue(string key, int value);

		ICrashlytics SetBoolValue(string key, bool value);

		ICrashlytics SetFloatValue(string key, float value);

		ICrashlytics SetDoubleValue(string key, double value);

		ICrashlytics SetLongValue(string key, long value);

		ICrashlytics Log(string msg);

		void RecordException(Exception exception);
	}

	public static class Crashlytics
	{
		static Lazy<ICrashlytics> Implementation = new Lazy<ICrashlytics>(() => CreateInstance(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		public static ICrashlytics Current {
			get {
				var ret = Implementation.Value;
				if (ret == null) {
					throw NotImplementedInReferenceAssembly();
				}
				return ret;
			}
		}

		static ICrashlytics CreateInstance()
		{
#if PORTABLE
		    Debug.WriteLine("portable *is* defined.");
		    return null;
#else
			Debug.WriteLine("portable is not defined.");
			return new CrashlyticsImplementation();
#endif
		}

		internal static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
	}
}
