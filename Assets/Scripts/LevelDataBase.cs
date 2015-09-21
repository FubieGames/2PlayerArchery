using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Level
{
    public string name;
    public int id;
    public Sprite img;
    [Header("Competitives")]
    public bool enabledAI;
    public bool enabled2players;
    [Header("Misc")]
    public bool otherMode;
}

public class LevelDataBase : MonoBehaviour {

    public List<Level> levels = new List<Level>();
}
