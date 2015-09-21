using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {

    public int id;

	void Start () {
        Application.LoadLevel(id);
	}

}
