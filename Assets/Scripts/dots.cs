using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class dots : MonoBehaviour {

    Text text;

    void Start()
    {
        text = gameObject.GetComponent<Text>();
    }

    public void ChangeText(string _text)
    {
        text.text = _text;
    }
}
