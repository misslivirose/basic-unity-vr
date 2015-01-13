# Getting Started with the Oculus Rift SDK
At this point, our game is playable and in theory is ready to go - by default, Unity allows you to export your game project in several formats for desktop and mobile, but we want to add an additional layer to it that allows us to build out our environment and make it fully immersive using the Oculus SDK.

## Installing the Oculus SDK
The first thing that we're going to want to do here is install the SDK that Oculus provides for developing. Since Oculus has teamed up with Samsung for their Gear VR headset on Android, we have a couple of options for how to build our final project depending on the final goals. In this section, we'll cover both the mobile and desktop Oculus experience.

The first thing that we're going to do is install the tools that we need in order to utilize the tools that Oculus has created for VR development.

{x: create Oculus dev account}
If you haven't already, create an Oculus developer account

{x: download vr tools}
Download and install the Oculus developer tools


### Oculus VR: Deploying for the Rift

There are several components that we'll need to install to begin working with the Oculus SDK: we'll need to install the SDK itself, as well as the Oculus Runtime and Integration components.

Head over to the <a href="https://developer.oculus.com/downloads/"> Oculus Developer portal </a> to download the tools. We'll be using the Oculus 0.4.3 beta tools and downloading the following packages:

* Oculus Runtime for Mac OS / Windows
* Oculus SDK for Mac OS / Windows
* Unity 4 Integration

### Mobile VR: Deploying for Samsung Gear VR
If you have a Samsung Galaxy Note 4 & Gear VR headset, you can deploy your game to run on mobile with the Oculus Mobile SDK for Gear VR.

From the <a href="https://developer.oculus.com/downloads/"> Oculus Developer portal </a>, select 'Mobile' and download the Oculus Mobile SDK for Samsung Note 4. In addition to the Oculus mobile SDK, you'll also need to download the Android SDK and associated runtimes.

{x: install Android SDK}
Install the Android SDK and Java runtime for Android development. If you aren't familiar with developing Android apps, we recommend grabbing the Android Studio download for Google, which contains the Android Studio Eclipse-based editor for Android apps and SDK.

### Replace the main camera with the Oculus Controller & Camera Rig
