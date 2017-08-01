// Main.cs
// Fabric Crashlytics NuGet Package
//
// Created by David N. Junod on 7/31/2017
// Copyright 2017  All Rights Reserved Worldwide.
using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace sample.iOS
{
    public class Application
    {
        // This is the main entry point of the application.
        static void Main(string[] args)
        {
            // if you want to use a different Application Delegate class from "AppDelegate"
            // you can specify it here.
            UIApplication.Main(args, null, "AppDelegate");
        }
    }
}
