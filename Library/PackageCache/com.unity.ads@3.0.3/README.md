# com.unity.ads Packman Package

## Getting Started

To get started with this repo, you need the following tools:

- Unity 2018.3 or newer. 

Use the Unity command line to generate a project file (replace with your correct Unity path):

```sh
/Applications/Unity/Hub/Editor/2018.3.3f1/Unity.app/Contents/MacOS/Unity -quit -createProject UnityAdsTest
```

This assumes `com.unity.ads` is cloned in the same root level as the test project.

Next, edit the `UnityAdsTest/Packages/manifest.json` file. Inside `dependencies` there is a `com.unity.ads` property, change the version
to `file:../../com.unity.ads`.

Next, add `"testables": [ "com.unity.ads" ]` as a sibling property to `dependencies`.

## Compiling

Open up the UnityAdsTest project in Unity created from the steps above, then, open the C# project to see the Advertisement sources.

## Testing

Inside Unity, navigate to `Window => General => Test Runner` to open the test runner dialog. Inside, you can then click `Run All` to run tests.

