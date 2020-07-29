﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

using UnityEngine;
using UnityEngine.SceneManagement;

namespace Microsoft.MixedReality.Toolkit.Examples.Demos.EyeTracking
{
    private enum LoadOptions
    {
        LoadOnDeviceAndInEditor,
        LoadOnlyOnDevice,
    }

    /// <summary>
    /// When the button is selected, it triggers starting the specified scene.
    /// </summary>
    [AddComponentMenu("Scripts/MRTK/Examples/OnLoadStartScene")]
    public class OnLoadStartScene : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("Name of the scene to be loaded when the button is selected.")]
        private string SceneToBeLoaded = "";

        [SerializeField]
        [Tooltip("Option to only load the scene if running on the HoloLens device.")]
        private LoadOptions LoadOption = LoadOptions.LoadOnlyOnDevice;

        public void Start()
        {
            if (LoadOption == LoadOptions.LoadOnlyOnDevice)
            {
                LoadOnDevice();
            }
            else
            {
                LoadNewScene();
            }
        }

        private void LoadOnDevice()
        {
#if WINDOWS_UWP
            LoadNewScene();
#endif // (UNITY_WSA && DOTNETWINRT_PRESENT) || WINDOWS_UWP
        }

        private void LoadNewScene()
        {
            if (SceneToBeLoaded != "")
            {
                SceneManager.LoadSceneAsync(SceneToBeLoaded, LoadSceneMode.Additive);
            }
        }
    }
}
