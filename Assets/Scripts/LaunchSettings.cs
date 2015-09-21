using UnityEngine;
using System.Collections;

public class LaunchSettings : MonoBehaviour{

    public bool twoPlayers;
    public bool playerVsAi;
    public bool aiVsAi;

    public bool musicOn;

    public void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public void SetAllToFalse()
    {
        twoPlayers = false;
        playerVsAi = false;
        aiVsAi = false;
    }
}
