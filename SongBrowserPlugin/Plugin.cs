﻿using SongBrowser.UI;
using Logger = SongBrowser.Logging.Logger;
using System;
using IPA;
using BS_Utils.Utilities;

namespace SongBrowser
{
    [Plugin(RuntimeOptions.SingleStartInit)]
    public class Plugin
    {
        public const string VERSION_NUMBER = "6.1.0";
        public static Plugin Instance;
        public static IPA.Logging.Logger Log;

        [Init]
        public void Init(IPA.Logging.Logger logger)
        {
            Log = logger;
        }

        [OnStart]
        public void OnApplicationStart()
        {
            Instance = this;

            Base64Sprites.Init();

            BSEvents.OnLoad();
            BSEvents.lateMenuSceneLoadedFresh += OnMenuSceneLoadedFresh;
        }

        [OnExit]
        public void OnApplicationQuit()
        {            
        }

        private void OnMenuSceneLoadedFresh(ScenesTransitionSetupDataSO data)
        {
            try
            {
                SongBrowserApplication.OnLoad();
            }
            catch (Exception e)
            {
                Logger.Exception("Exception on fresh menu scene change: " + e);
            }
        }
    }
}
