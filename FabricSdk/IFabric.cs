//
// IFabric.cs
// Recap
//
// Created by David N. Junod on 3/18/2017
// Copyright (c) 2017 Wimobia.com, Inc.  All Rights Reserved Worldwide.
//

using System;
using System.Collections.Generic;

namespace FabricSdk
{
    public interface IFabric
    {
		bool Debug { get; set; }
        ICollection<IKit> Kits { get; }

        event EventHandler BeforeInitialize;
        event EventHandler AfterInitialize;
    }
}