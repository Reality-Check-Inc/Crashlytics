//
// MainApplication.cs
// Fabric Crashlytics NuGet Package
//
// Created by David N. Junod on 8/1/2017
// Copyright 2017 Reality Check, Inc. All Rights Reserved Worldwide.
//
using System;
using System.IO;

using CrashlyticsKit;
using FabricSdk;

using Android.App;
using Android.Runtime;
using Android.Content.PM;
using Android.Content.Res;
using Android.Runtime;
using Android.OS;

namespace sample.Droid
{
	[Application]
	public class MainApplication : Android.App.Application
	{
		public static string APP_TAG = "CrashlyticsSample";

		/// <summary>
		/// Base constructor which must be implemented if it is to successfully inherit from the Application
		/// class.
		/// </summary>
		/// <param name="handle"></param>
		/// <param name="transfer"></param>
		public MainApplication(IntPtr handle, JniHandleOwnership transfer)
					: base(handle, transfer)
		{
			Console.WriteLine("MainApplication Create");
		}

		public override void OnCreate()
		{
			base.OnCreate();
			Console.WriteLine("OnCreate");

			// this is just here to show us the current info
			PackageManager pm = this.PackageManager;
			string name = this.PackageName;
			PackageInfo pi = pm.GetPackageInfo(name, 0);
			string label = pm.GetApplicationLabel(pi.ApplicationInfo);
			string version = string.Format("{0} ({1})", pi.VersionName, pi.VersionCode);
			string apiKey = "";
			ApplicationInfo info = pm.GetApplicationInfo(name, PackageInfoFlags.MetaData);
			Bundle metaData = info.MetaData;
			if (metaData != null)
			{
				apiKey = metaData.GetString("io.fabric.ApiKey");
			}

			// make sure we have the build id
			int id = this.Resources.GetIdentifier("com.crashlytics.android.build_id", "string", PackageName);
			string buildId = null;
			if (id != 0)
				buildId = Resources.GetString(id);

			// make sure we have the properties
			string content = null;
			AssetManager assets = this.Assets;
            try
            {
                using (StreamReader sr = new StreamReader(assets.Open("crashlytics-build.properties")))
                    content = sr.ReadToEnd();
            } catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
			Console.WriteLine(content);
			Console.WriteLine("[{0}] [{1}] [{2}] [{3}]", name, label, version, pm.GetInstallerPackageName(name));
			Console.WriteLine("Fabric Build ID is: {0}", buildId);
			Console.WriteLine("Fabric ApiKey is: {0}", apiKey);

			if (string.IsNullOrEmpty(apiKey))
				throw new Exception("Missing io.fabric.ApiKey from AndroidManifest.xml");
			if (string.IsNullOrEmpty(content))
				throw new Exception("Missing crashlytics-build.properties from Assets");
			if (string.IsNullOrEmpty(buildId))
				throw new Exception("R.string.com.crashlytics.android.build_id");

			// we can initialize Crashlytics
			Console.WriteLine("Initialize Fabric");
			var crashlyticsKit = Crashlytics.Current;
			Fabric.Current.Debug = true;

            ((FabricImplementation)Fabric.Current).Context = this;
			/*
            Crashlytics.Current.Initialize();
            Fabric.Current.Debug = true;
            Fabric.Current.Initialize(this);
            Console.WriteLine("Fabric initialized");

            Crashlytics.Current.SetUserIdentifier("12345");
            Crashlytics.Current.SetUserName("Sample User");
             */
		}

    }
}
