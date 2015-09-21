using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AcrivateLoadingText : MonoBehaviour {

    public CanvasGroup text;

    public void ActivateText()
    {
        text.gameObject.SetActive(true);
    }
}
