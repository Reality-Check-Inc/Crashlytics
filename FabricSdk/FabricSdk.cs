//
// FabricSdk.cs
// Fabric Crashlytics NuGet Package
//
// Created by David N. Junod on 3/18/2017
// Copyright (c) 2017 Reality Check, Inc.  All Rights Reserved Worldwide.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;

// following this pattern, except putting Abstraction into the shared file.
// https://blog.xamarin.com/creating-reusable-plugins-for-xamarin-forms/
//
// * this file is SHARED between implementations
//      Fabric.cs - add a link to the file
// * implementation
//      FabricImplementation.cs
// * all implementation assemblies have the same Properties/AssemblyInfo.
// * General/Main Settings/Name same with .Droid & .iOS
// * General/Main Settings/Default Namespace exact same

namespace FabricSdk
{
	public interface IKit
	{
		string Version { get; }
	}

	public interface IFabric
	{
		string Version { get; }

		string AppIdentifier { get; }
		string AppInstallIdentifier { get; }
		string Identifier { get; }

		bool Debug { get; set; }
		ICollection<IKit> Kits { get; }

        void With(ICollection<IKit> Kits);
	}

	public static partial class Fabric
	{
		static Lazy<IFabric> Implementation = new Lazy<IFabric>(() => CreateInstance(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		public static IFabric Current
		{
			get
			{
				var ret = Implementation.Value;
				if (ret == null)
				{
					throw NotImplementedInReferenceAssembly();
				}
				return ret;
			}
		}

		static IFabric CreateInstance()
		{
#if PORTABLE
            Debug.WriteLine("portable *is* defined.");
            return null;
#else
			Debug.WriteLine("portable is not defined.");
			return new FabricImplementation();
#endif
		}

		internal static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
	}
}
