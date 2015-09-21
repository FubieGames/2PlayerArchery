using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityStandardAssets.ImageEffects;

public class MenuLevelChooser : MonoBehaviour {

    public bool levelChoosen;
    public Animator anim;
    [Header("UI")]
    public Text levelNameText;
    public Image thumb;
    public GameObject levelPanel;
    public Button backButton;
    public GameObject shadow1;
    [Header("-Play with AI")]
    public Button playVsAIButton;
    public Button aiVsAIButton;
    [Header("-Play with human being")]
    public Button playVsPlayerButton;
    [Header("-Play some different mode")]
    public Button playOtherModeButton;

    LaunchSettings launchSettings;

    LevelDataBase levelDB;
    LevelLoaded levelLoad;

    Level nextLevel = new Level();

	void Start () {
        levelDB = GetComponent<LevelDataBase>();
        levelLoad = GetComponent<LevelLoaded>();

        launchSettings = GameObject.Find("LaunchSettings").GetComponent<LaunchSettings>();

        launchSettings.SetAllToFalse();
    }

    void Update()
    {
        anim.SetBool("open", levelChoosen);
        backButton.gameObject.SetActive(levelChoosen);

        if (levelChoosen)
            shadow1.transform.localScale = Vector3.Lerp(shadow1.transform.localScale, new Vector3(1.1f, 1, 1), Time.deltaTime * 3f);
        else
            shadow1.transform.localScale = Vector3.Lerp(shadow1.transform.localScale, new Vector3(0, 1, 1), Time.deltaTime * 6f);
    }

    public void ChoseLevel(int sceneId)
    {
        for (int i = 0; i < levelDB.levels.Count - 1; i++)
        {
            if (levelDB.levels[i].id == sceneId)
            {
                nextLevel = levelDB.levels[i];
                break;
            }
        }

        SetVars();//Settng buttons and texts appropriatly

        //TODO: close panel;
    }

    void SetVars()
    {
        levelNameText.text = nextLevel.name;
        thumb.sprite = nextLevel.img;

        playVsAIButton.gameObject.SetActive(nextLevel.enabledAI);
        aiVsAIButton.gameObject.SetActive(nextLevel.enabledAI);

        playVsPlayerButton.gameObject.SetActive(nextLevel.enabled2players);

        playOtherModeButton.gameObject.SetActive(nextLevel.otherMode);

        levelChoosen = true;
    }

    public void ClosePanel()
    {
        levelChoosen = false;
    }

    public void LoadChoosenLevel()
    {
        levelLoad.GoToOtherScene(nextLevel.id);
    }

    //LaunchSettings
    public void PlayerVsPlayer()
    {
        launchSettings.twoPlayers = true;
    }

    public void PlayerVsAI()
    {
        launchSettings.playerVsAi = true;
    }

    public void AIvsAI()
    {
        launchSettings.aiVsAi = true;
    }
}
