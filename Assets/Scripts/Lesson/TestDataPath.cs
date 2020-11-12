using GameAnalyticsSDK;
using UnityEngine;

public class TestDataPath : MonoBehaviour
{
    private void Start()
    {
        GameAnalytics.Initialize();
        Debug.Log(Application.dataPath);
    }
}
