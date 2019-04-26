using System;

namespace UnityEngine.Advertisements
{
    static class Creator
    {
#if ASSET_STORE
        static internal IPlatform CreatePlatform()
        {
            try
            {
#if UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS
                return new Platform();
#else
                return new UnsupportedPlatform();
#endif
            }
            catch (Exception exception)
            {
                try
                {
                    Debug.LogError("Initializing Unity Ads.");
                    Debug.LogException(exception);
                }
                catch (MissingMethodException)
                {
                }
                return new UnsupportedPlatform();
            }
        }

#else
        static bool initializeOnStartup
        {
            get
            {
                return UnityAdsSettings.initializeOnStartup;
            }
        }

        internal static bool enabled
        {
            get
            {
                return UnityAdsSettings.enabled;
            }
        }

        static bool testMode
        {
            get
            {
                return UnityAdsSettings.testMode;
            }
        }

        static string gameId
        {
            get
            {
                return UnityAdsSettings.GetGameId(Advertisement.application.platform);
            }
        }

        static internal IPlatform CreatePlatform()
        {
            try
            {                
                #if UNITY_EDITOR || UNITY_ANDROID || UNITY_IOS
                    return new Platform();
                #else
                    return new UnsupportedPlatform();
                #endif
            }
            catch (Exception exception)
            {
                try
                {
                    Debug.LogError("Initializing Unity Ads.");
                    Debug.LogException(exception);
                }
                catch (MissingMethodException)
                {
                }
                return new UnsupportedPlatform();
            }
        }

        #if UNITY_ADS
            [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
            static void LoadRuntime()
            {
                if (!Advertisement.isSupported)
                {
                    return;
                }
    
                if (initializeOnStartup)
                {
                    Advertisement.Initialize(gameId, testMode);
                }
            }
        #endif

#endif
    }
}
