﻿//
// MainApplication.cs
//
// Created by David N. Junod on 4/7/2017
// Copyright (c) 2017 Reality Check, Inc.  All Rights Reserved Worldwide.
//
using System;
using System.IO;
using Android.App;
using Android.Content.PM;
using Android.Content.Res;
using Android.Runtime;
using CrashlyticsKit;
using FabricSdk;
using Android.OS;
using Xamarin.Forms;

namespace CrashlyticsSample.Droid
{
	[Application]
	public class MainApplication : Android.App.Application
	{

		/// <summary>
		/// Base constructor which must be implemented if it is to successfully inherit from the Application
		/// class.
		/// </summary>
		/// <param name="handle"></param>
		/// <param name="transfer"></param>
		public MainApplication(IntPtr handle, JniHandleOwnership transfer)
		            : base(handle,transfer)
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
			using (StreamReader sr = new StreamReader(assets.Open("crashlytics-build.properties")))
				content = sr.ReadToEnd();
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
			Crashlytics.Instance.Initialize();
			Fabric.Instance.Debug = true;
			Fabric.Instance.Initialize(this);
			Console.WriteLine("Fabric initialized");

			Crashlytics.Instance.SetUserIdentifier("12345");
			Crashlytics.Instance.SetUserName("Sample User");
		}
	}
}