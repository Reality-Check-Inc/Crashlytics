//
// App.xaml.cs
// Fabric Crashlytics NuGet Package
//
// Created by David N. Junod on 7/31/2017
// Copyright 2017  All Rights Reserved Worldwide.
//

using CrashlyticsKit;
using FabricSdk;

using Xamarin.Forms;

namespace sample
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            Fabric.Current.Debug = true;
            Fabric.Current.With(new IKit[] { Crashlytics.Current});

            MainPage = new samplePage();
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
