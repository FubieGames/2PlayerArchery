using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelLoaded : MonoBehaviour {

    public GameObject onLevelLoadedObject;

    public GameObject loadNewLevelObject;
    //public Animator onLevelLoadedAnimator;

    //public CanvasRenderer loadingTextRenderer;

    public int thisSceneInt;
    public MenuController menuController;

    public void OnLevelLoadedAnimation()
    {
        onLevelLoadedObject.SetActive(true);
    }

    public bool loadScene;
    public int nextScene;

    public void GoToOtherScene(int sceneName)
    {
        loadNewLevelObject.SetActive(true);
        nextScene = sceneName;
        if (nextScene != thisSceneInt)
        {
            menuController.musicOn = false;
        }
    }
    public void LoadScene()
    {
        Application.LoadLevel(nextScene);
    }

}
