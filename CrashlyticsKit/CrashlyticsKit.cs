//
// CrashlyticsKit.cs
// Fabric Crashlytics NuGet Package
//
// Created by David N. Junod on 8/1/2017
// Copyright 2017 Reality Check, Inc. All Rights Reserved Worldwide.
//

using System;
using System.Diagnostics;

using FabricSdk;

namespace CrashlyticsKit
{
    public interface ICrashlytics : IKit
    {
		void Crash();

		string UserIdentifier { set; }
		string UserName { set; }
		string UserEmail { set; }

		void SetStringValue(string key, string value);

		void SetIntValue(string key, int value);

		void SetBoolValue(string key, bool value);

		void LogEvent(string msg);
	}

	public static partial class Crashlytics
	{
		static Lazy<ICrashlytics> Implementation = new Lazy<ICrashlytics>(() => CreateInstance(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		public static ICrashlytics Current
		{
			get
			{
				var ret = Implementation.Value;
				Debug.WriteLine("Current = " + ret);
				if (ret == null)
				{
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
            Console.WriteLine("portable is not defined.");
            return new CrashlyticsImplementation();
#endif
		}

		internal static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
	}
}
