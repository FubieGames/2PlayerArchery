using UnityEngine;
using System.Collections;

public class loadLevel : MonoBehaviour {

    public LevelLoaded lvlloaded;


    public void LvlLoad()
    {
        lvlloaded.LoadScene();
    }
}
