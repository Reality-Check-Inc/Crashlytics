//
// Kit.cs
// Recap
//
// Created by David N. Junod on 3/18/2017
// Copyright (c) 2017 Wimobia.com, Inc.  All Rights Reserved Worldwide.
//

using Foundation;

namespace FabricSdk
{
	public abstract class Kit : IKit
	{
		internal NSObject NativeObject;

		protected Kit(NSObject nativeObject)
		{
			NativeObject = nativeObject;
		}
	}

	public static class KitMixins
	{
		public static NSObject ToNative(this IKit kit)
		{
			return (kit as Kit)?.NativeObject;
		}
	}
}
