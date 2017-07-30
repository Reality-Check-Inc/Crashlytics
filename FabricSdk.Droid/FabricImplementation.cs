//
// FabricImplementation.cs
// Crashlytics
//
// Created by David N. Junod on 7/30/2017
// Copyright (c) 2017 Reality Check, Inc.  All Rights Reserved Worldwide.
//

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace FabricSdk
{
	public sealed class FabricImplementation : IFabric
	{
		bool _debug = false;
		ICollection<IKit> _kits = new List<IKit>();

		public FabricImplementation()
		{
			Console.WriteLine("Fabric initialization (Android)");
		}

		public string AppIdentifier {
			get {
				throw new NotImplementedException();
			}
		}

		public string AppInstallIdentifier {
			get {
				throw new NotImplementedException();
			}
		}

		public bool Debug {
			get {
				return _debug;
			}

			set {
				_debug = value;
			}
		}

		public string Identifier {
			get {
				throw new NotImplementedException();
			}
		}

		public ICollection<IKit> Kits {
			get {
				throw new NotImplementedException();
			}
		}

		public string Version {
			get {
				throw new NotImplementedException();
			}
		}
	}
}
