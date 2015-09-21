using UnityEngine;
using System.Collections;

public class TimeController : MonoBehaviour {

#if UNITY_EDITOR
	void Update(){
		if(Input.GetKeyDown(KeyCode.Space))
		{
			StartCoroutine("StopTimeForSeconds",1);
		}	
	}
#endif

	public void Freeze(float t)
	{
		StartCoroutine("StopTimeForSeconds",t);
	}

	public IEnumerator StopTimeForSeconds(float seconds)
	{
		Time.timeScale =0f;
		float pauseTime = Time.realtimeSinceStartup+seconds;
		while(Time.realtimeSinceStartup<pauseTime)
		{
			yield return 0;
		}
		Time.timeScale =1f;
	}
}
