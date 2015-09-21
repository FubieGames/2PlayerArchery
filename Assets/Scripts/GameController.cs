using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

    [Header("Archers")]
    public Archer blueArcher;
    public Archer greenArcher;

    [Header("UI")]
    public Text blueScoreText;
    public Text greenScoreText;

    public int blueScore;
    public int greenScore;

    LaunchSettings launchSettings;

    void Start()
    {
        launchSettings = GameObject.Find("LaunchSettings").GetComponent<LaunchSettings>();
    }

    void Update()
    {
        if (launchSettings != null)
        {
            if (launchSettings.twoPlayers)
            {
                blueArcher.AI = false;
                greenArcher.AI = false;
            }

            if (launchSettings.playerVsAi)
            {
                blueArcher.AI = true;
                greenArcher.AI = false;
            }

            if (launchSettings.aiVsAi)
            {
                blueArcher.AI = true;
                greenArcher.AI = true;
            }
        }


        blueScore  = (5 - greenArcher.health);
        greenScore = (5 - blueArcher.health);

        blueScoreText.text  = blueScore.ToString();
        greenScoreText.text = greenScore.ToString();


        if (blueScore == 5 && greenScore != 5)
        {
            blueArcher.winner = true;
        }

        if (blueScore != 5 && greenScore == 5)
        {
            greenArcher.winner = true;
        }

        if (blueScore == 5 && greenScore == 5)
        {
            print("Nobody Wins!");
        }
    }
}
