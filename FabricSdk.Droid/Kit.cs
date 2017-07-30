//
// Kit.cs
// Recap
//
// Created by David N. Junod on 3/18/2017
// Copyright (c) 2017 Wimobia.com, Inc.  All Rights Reserved Worldwide.
//

using System;

namespace FabricSdk
{
	public class Kit : IKit
	{
		internal Bindings.FabricSdk.Kit NativeKit;

		public Kit(Bindings.FabricSdk.Kit nativeKit)
		{
			NativeKit = nativeKit;
		}
	}

	public static class KitMixins
	{
		public static Bindings.FabricSdk.Kit ToNative(this IKit kit)
		{
			return (kit as Kit)?.NativeKit;
		}
	}
}
