QABuild.tools Documentation
================

# Available Actions
## Builtin Actions
This section shows the builtin actions
bump
----------------
Bump the build number
```
qabuild bump
```
#### --write (-w)
Write new value
#### --build (-b)
Set build to value
info
----------------
Show information about the current directory
```
qabuild info
```
init
----------------
Prepare a Xamarin solution for QABuild.Tools
```
qabuild init
```
#### --force (-f)
Init even if already exists
#### --package (-p)
Package name
#### --version (-v)
Version string
#### --build (-b)
Build number
install
----------------
Install QABuild.Tools and Add-Ins
```
qabuild install
```
#### --home (-p)
Path to create QABUILD_HOME off of
#### --addin (-a)
Install Action Addin <name>
props
----------------
Show the key/values in a properties file
```
qabuild props
```
#### --file (-f)
Properties file name
#### --eval (-e)
Evaluate properties
## Addin Actions
This section shows the addin actions currently installed
## fabric
Support for Fabric Crashlytics
init
----------------
Prepare a Xamarin project for Crashlytics
```
qabuild init
```
#### --force (-f)
Init even if already exists
#### --token (-t)
Company token
#### --secret (-s)
Company secret
#### --package (-p)
Package name
update
----------------
Update app info on Crashlytics
```
qabuild update
```
