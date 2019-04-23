using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
//using UnityEngine.Monetization;

public class Advertising : MonoBehaviour {

    [SerializeField]
    private string GameId = "2989758";
    /*
    [SerializeField]
    private bool testMode;*/

    /// <summary>
    /// Shows add without reward
    /// </summary>
    public void ShowDefaultAd()
    {
//#if UNITY_ADS

        if (!Advertisement.IsReady())
        {
            Debug.Log("Ads not ready for default placement");
            return;
        }
        Advertisement.Show();
//#endif
    }

    /// <summary>
    /// Shows add thay may reward the user if it isn't skipped
    /// </summary>
    public void ShowRewardedAd()
    {
        const string RewardedPlacementId = "GainRubies_VIDEO";

//#if UNITY_ADS
        if (!Advertisement.IsReady(RewardedPlacementId))
        {
            Debug.Log(string.Format("Ads not ready for placement '{0}'", RewardedPlacementId));
            return;
        }

        var options = new ShowOptions { resultCallback = HandleShowResult };
        Advertisement.Show(RewardedPlacementId, options);
//#endif
    }

    //Callback for the previous function
//#if UNITY_ADS
    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                Debug.Log("The ad was successfully shown.");
                //
                // YOUR CODE TO REWARD THE GAMER
                // Give coins etc.
                GameManager.instance.AddRubies(200);
                break;
            case ShowResult.Skipped:
                Debug.Log("The ad was skipped before reaching the end.");
                break;
            case ShowResult.Failed:
                Debug.LogError("The ad failed to be shown.");
                break;
        }
    }

//#endif

    // Use this for initialization
    void Start () {
#if !UNITY_ADS // If the Ads service is not enabled...
        if (Advertisement.isSupported) { // If runtime platform is supported...
            Advertisement.Initialize(GameId, true); // ...initialize.
        }
        // Wait until Unity Ads is initialized,
        //  and the default ad placement is ready.
        while (!Advertisement.isInitialized || !Advertisement.IsReady())
        {}
        Debug.Log("Init ad");
#endif
    }


    // Update is called once per frame
    /*void Update () {
		
	}*/
}
