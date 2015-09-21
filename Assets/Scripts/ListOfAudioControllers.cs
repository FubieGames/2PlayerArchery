using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListOfAudioControllers : MonoBehaviour {

    public List<GameObject> audioControllerList = new List<GameObject>();
    public bool transition = true;

    void Awake()
    {
        if (!audioControllerList[0])
            Destroy(this.gameObject);
    }

    public void FindAllControllers()
    {

        if (transition)
        {
            DontDestroyOnLoad(this.gameObject);
            DontDestroyOnLoad(audioControllerList[1]);
        }
        audioControllerList.AddRange(GameObject.FindGameObjectsWithTag("AudioController"));
        RemoveOthers();
    }

    void RemoveOthers()
    {
        if (audioControllerList.Count > 1)
        {
            Destroy(audioControllerList[1]);
            audioControllerList.Remove(audioControllerList[1]);
        }
    }
}
