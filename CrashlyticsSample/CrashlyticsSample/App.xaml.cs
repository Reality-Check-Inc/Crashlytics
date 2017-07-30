//
// App.xaml.cs
//
// Created by David N. Junod on 4/7/2017
// Copyright (c) 2017 Reality Check, Inc.  All Rights Reserved Worldwide.
//
using Xamarin.Forms;

namespace CrashlyticsSample
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			MainPage = new CrashlyticsSamplePage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
