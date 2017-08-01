//
// Implementation.cs (iOS)
// Fabric Crashlytics NuGet Package
//
// Created by David N. Junod on 7/31/2017
// Copyright 2017 Reality Check, Inc. All Rights Reserved Worldwide.
//

using System;
using System.Collections.Generic;

using Foundation;
using ObjCRuntime;

namespace FabricSdk
{
	public abstract class Kit : IKit
	{
		internal NSObject NativeObject;

		protected Kit(NSObject nativeObject)
		{
			NativeObject = nativeObject;
		}

		public string Version
		{
			get
			{
				throw new NotImplementedException();
			}
		}
    }

	public static class KitMixins
	{
		public static NSObject ToNative(this IKit kit)
		{
			return (kit as Kit)?.NativeObject;
		}
	}

    public sealed class FabricImplementation : IFabric
	{
		ICollection<IKit> _kits = new List<IKit>();

		public FabricImplementation()
		{
			Console.WriteLine("Fabric initialization (iOS)");
		}

		public string AppIdentifier
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string AppInstallIdentifier
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public bool Debug
		{
			get
			{
				return Bindings.FabricSdk.Fabric.SharedSDK().Debug; ;
			}

			set
			{
				Bindings.FabricSdk.Fabric.SharedSDK().Debug = value;
			}
		}

		public string Identifier
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public ICollection<IKit> Kits
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public string Version
		{
			get
			{
				throw new NotImplementedException();
			}
		}

        public void With(ICollection<IKit> Kits)
        {
			var nativeKits = new List<NSObject>();
			foreach (var kit in Kits)
				nativeKits.Add(kit.ToNative());
			Bindings.FabricSdk.Fabric.With(nativeKits.ToArray());
		}
    }
}
