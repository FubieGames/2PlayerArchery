using UnityEngine;
using System.Collections;

public class turnOffThisObj : MonoBehaviour {


    public void TurnOff()
    {
        this.gameObject.SetActive(false);
    }
}
