# Crashlytics
Xamarin component for Crashlytics

| Module                        | Framework     | Version | Date |
|-------------------------------|---------------|---------|------|
| Fabric.AnswersKit             | Profile111    | 1.3.12  | 2017/07/29 |
| Fabric.AnswersKit.Droid       | monoandroid60 | 1.3.12  | 2017/07/29 |
| Fabric.Crashlytics.Beta.Droid | monoandroid60 | 1.2.4   | 2017/07/29 |
| Fabric.Crashlytics.Core.Droid | monoandroid60 | 2.3.16  | 2017/07/29 |
| Fabric.Crashlytics.Kit        | Profile111    | 2.6.7   | 2017/07/29 |
| Fabric.Crashlytics.Kit.Droid  | monoandroid60 | 2.6.7   | 2017/07/29 |
| Fabric.Crashlytics.Kit.iOS    | xamarinios10  | 3.8.4   | 2017/07/29 |
| FabricSdk                     | Profile111    | 1.3.16  | 2017/07/29 |
| FabricSdk.Droid               | monoandroid60 | 1.3.16  | 2017/07/29 |
| FabricSdk.iOS                 | xamarinios10  | 1.6.11  | 2017/07/29 |

Install
-------

## Android

- Edit AndroidManifest.xml per https://fabric.io/kits/android/crashlytics/install
- Add & edit

## iOS

- Edit info.plist per https://fabric.io/kits/ios/crashlytics/install

Versions
--------

Unfortunately the Unity version doesn't always track the most recent release, plus does things that are specific to Unity.  Use the 'qabuild latest' action to see the current versions used by the Unity plugin.

This Xamarin component binds the following versions:

## Android

- AnswerKit: 1.3.12
- Beta: 1.2.4
- Crashlytics-Core: 2.3.16
- Crashlytics: 2.6.7
- Fabric: 1.3.16

## iOS

- Crashlytics: 3.8.4
- Fabric: 1.6.11

### Xamarin Studio


open -n /Applications/Xamarin\ Studio.app/

### NuGet
The NuGet is privately hosted on TestMinds.com.

	NuGet SetApiKey 484B9674-F583-39E5-A9EB-940B066D5D7A -Source http://testminds.com/nuget/upload
    NuGet Push AnswersKit/bin/release/Fabric.AnswersKit.1.3.12.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push AnswersKit.Droid/bin/release/Fabric.AnswersKit.Droid.1.3.12.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push CrashlyticsBeta.Droid/bin/release/Fabric.Crashlytics.Beta.Droid.1.2.4.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push CrashlyticsCore.Droid/bin/release/Fabric.Crashlytics.Core.Droid.1.2.4.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push CrashlyticsKit/bin/release/Fabric.CrashlyticsKit.2.6.7.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push CrashlyticsKit.Droid/bin/release/Fabric.CrashlyticsKit.Droid.2.6.7.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push CrashlyticsKit.iOS/bin/release/Fabric.CrashlyticsKit.iOS.3.8.4.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push FabricSdk/bin/release/FabricSdk.1.3.16.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push FabricSdk.Droid/bin/release/FabricSdk.Droid.1.3.16.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push FabricSdk.iOS/bin/release/FabricSdk.iOS.1.6.11.nupkg -Source http://testminds.com/nuget/upload
