# Crashlytics
Xamarin component for Crashlytics

| Module                        | Framework     | Version | Date |
|-------------------------------|---------------|---------|------|
| FabricSdk                     | Profile111    | 1.3.16  | 2017/07/29 |
| FabricSdk.Droid               | monoandroid60 | 1.3.17  | 2017/07/29 |
| FabricSdk.iOS                 | xamarinios10  | 1.6.12  | 2017/07/29 |
| Fabric.CrashlyticsKit         | Profile111    | 2.6.7   | 2017/07/29 |
| Fabric.CrashlyticsKit.Droid   | monoandroid60 | 2.6.8   | 2017/07/29 |
| Fabric.CrashlyticsKit.iOS     | xamarinios10  | 3.8.5   | 2017/07/29 |
| Fabric.AnswersKit.Droid       | monoandroid60 | 1.3.13  | 2017/07/29 |
| Fabric.BetaKit.Droid          | monoandroid60 | 1.2.5   | 2017/07/29 |
| Fabric.Crashlytics.Core.Droid | monoandroid60 | 2.3.17  | 2017/07/29 |

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

- Fabric: 1.3.17
- Crashlytics: 2.6.8
- Crashlytics-Core: 2.3.17
- AnswerKit: 1.3.13
- Beta: 1.2.5

## iOS

- Crashlytics: 3.8.5
- Fabric: 1.6.12

## Binding

This section details how to provide bindings for each supported platform.

### Pattern

following this pattern, except putting Abstraction into the shared file.

    https://blog.xamarin.com/creating-reusable-plugins-for-xamarin-forms/
    
 * Multiplatform / Library / Portable Library
 	Main Settings / Default Namespace: FabricSdk
 	Output / Assembly Name: FabricSdk
 * iOS / Library / Bindings Library
 	Main Settings / Default Namespace: FabricSdk
 	Output / Assembly Name: FabricSdk
 * Android / Library / Bindings Library
 	Main Settings / Default Namespace: FabricSdk
 	Output / Assembly Name: FabricSdk

 * this file is SHARED between implementations  
		Fabric.cs - add a link to the file
 * implementation  
		FabricImplementation.cs
 * all implementation assemblies have the same Properties/AssemblyInfo.

On the iOS app, have to do:
	Build / iOS Build / Additional mtouch arguments: -cxx -gcc_flags "-lc++"

### iOS

On iOS we will use Objective Sharpie to create the bindings.

Open a terminal.  

    cd workspace/iOS/Fabric/  
    sharpie pod init ios Crashlytics  
    
add the following to the generated Podfile

	pod 'Crashlytics'
	pod 'Fabric'

After modifying the Podfile:

	pod install
	
Once your CocoaPod has been set up, you can now create the binding:

    sharpie pod bind

This will result in the CocoaPod Xcode project being built, evaluated and parsed by Objective Sharpie. A lot of console output will be generated, but should result in the binding definition at the end.  Bottom line, look at the summary, if there are **Errors**, then the bind is incomplete.

Also, be sure to look for **Warnings** and fix them!

To regenerate the bindings with the latest Pods:

    pod update
    sharpie pod bind

In the Binding directory are the files for binding to the Frameworks.

Be sure to update ApiDefinitions.cs and Structs.cs from the new bindings. Unfortunately, you can't just copy them over.

Further details:

[iOS Bindings](https://developer.xamarin.com/guides/cross-platform/macios/binding/)

### Android

On Android, get the latest Answers, Beta, Crashlytics, and Crashlytics-Core aar files from

    $HOME/.gradle/caches/modules-2/files-2.1/com.crashlytics.sdk.android
    
Get the latest Fabric aar file from

    $HOME/.gradle/caches/modules-2/files-2.1/io.fabric.sdk.android

Ensure that the .aar is set to Build Action -> LibraryProjectZip.

After building the binding library, look for api.xml in the obj/Debug directory.

To sort of pretty print the xml:

    cat FabricSdk.Droid/obj/Debug/api.xml | xmllint --format - > api.pretty.xml
    
Further details:

[Android .AAR Bindings](https://developer.xamarin.com/guides/android/advanced_topics/binding-a-java-library/binding-an-aar/)

### Visual/Xamarin Studio

Open multiple from the terminal

    open -n /Applications/Visual\ Studio.app/  
    open -n /Applications/Xamarin\ Studio.app/  

### NuGet
The NuGet is privately hosted on TestMinds.com.

	NuGet SetApiKey 484B9674-F583-39E5-A9EB-940B066D5D7A -Source http://testminds.com/nuget/upload

    NuGet Push FabricSdk/bin/release/FabricSdk.1.3.17.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push CrashlyticsKit/bin/release/Fabric.CrashlyticsKit.2.6.8.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push AnswersKit/bin/release/Fabric.AnswersKit.1.3.13.nupkg -Source http://testminds.com/nuget/upload

    NuGet Push FabricSdk.Droid/bin/release/FabricSdk.Droid.1.3.17.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push CrashlyticsKit.Droid/bin/release/Fabric.CrashlyticsKit.Droid.2.6.8.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push CrashlyticsCore.Droid/bin/release/Fabric.Crashlytics.Core.Droid.2.3.17.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push CrashlyticsBeta.Droid/bin/release/Fabric.Crashlytics.Beta.Droid.1.2.5.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push AnswersKit.Droid/bin/release/Fabric.AnswersKit.Droid.1.3.13.nupkg -Source http://testminds.com/nuget/upload

    NuGet Push FabricSdk.iOS/bin/release/FabricSdk.iOS.1.6.12.nupkg -Source http://testminds.com/nuget/upload
    NuGet Push CrashlyticsKit.iOS/bin/release/Fabric.CrashlyticsKit.iOS.3.8.5.nupkg -Source http://testminds.com/nuget/upload
