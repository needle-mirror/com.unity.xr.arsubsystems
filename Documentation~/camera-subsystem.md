# XR Camera Subsystem

The camera subsystem is responsible for managing a hardware camera on the AR device. It provides the following data concerning the camera:
- Camera image (as an "external" texture on the GPU).
- Camera image (as a buffer of bytes available on the CPU).
- Projection matrix, used to set the field of view and other properties of the virtual camera according to the physical one.
- Display matrix, used to orient the camera image correctly.
- Camera intrinsics describing a mathematical model of the camera. Useful for computer vision algorithms.
- Camera conversion utilities, for converting the CPU image to RGB and grayscale.
- Light estimation information (color and brightness of the environment).
- Camera focus mode (i.e., autofocus vs fixed)

See the [Script API Reference](../api/UnityEngine.XR.ARSubsystems.XRCameraSubsystem.html) for API details.

> [!NOTE]
> Starting November 2022, the camera image will not be available on Android platforms due to API deprecation 
> in ARCore SDK. Update to package version 4.x or higher to use supported version of the API. 
> See https://developers.google.com/ar/develop/unity-arf/ndk-camera-deprecation.
> 
> The camera image APIs will not be affected on iOS platforms and will continue to work same as before.