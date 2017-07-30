//
// FabricImplementation.cs
// Crashlytics
//
// Created by David N. Junod on 7/30/2017
// Copyright (c) 2017 Reality Check, Inc.  All Rights Reserved Worldwide.
//

using System;
using System.Collections.Generic;

namespace FabricSdk
{
	public sealed class FabricImplementation : IFabric
	{
		public FabricImplementation()
		{
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
				throw new NotImplementedException();
			}

			set {
				throw new NotImplementedException();
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

		public event EventHandler AfterInitialize;
		public event EventHandler BeforeInitialize;
	}
}
