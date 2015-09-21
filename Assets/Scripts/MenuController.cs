using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections;

public class MenuController : MonoBehaviour {

    public bool pauseMenuOpen;
    public Animator pausePanelAnim;
    public CanvasGroup block1;
    public CanvasGroup block2;

    [Header("Audio")]
    public AudioMixerSnapshot paused;
    public AudioMixerSnapshot unpaused;
    public AudioMixerSnapshot musicOff;
    public bool musicOn = true;

    public Image musicImg;

    public Sprite musicOnSpr;
    public Sprite musicOffSpr;
	
	void Update () {
        pausePanelAnim.SetBool("open", pauseMenuOpen);

        if (pauseMenuOpen)
        {
            block1.alpha = Mathf.Lerp(block1.alpha, 1f, Time.deltaTime * 7.5f);
            block2.alpha = Mathf.Lerp(block2.alpha, 1f, Time.deltaTime * 7.5f);

            if (musicOn)
                paused.TransitionTo(1f);
            else
                musicOff.TransitionTo(1f);
        }
        else
        {
            block1.alpha = Mathf.Lerp(block1.alpha, 0f, Time.deltaTime * 7.5f);
            block2.alpha = Mathf.Lerp(block2.alpha, 0f, Time.deltaTime * 7.5f);

            if(musicOn)
                unpaused.TransitionTo(1f);
            else
                musicOff.TransitionTo(1f);
        }

        block1.blocksRaycasts = pauseMenuOpen;
        block2.blocksRaycasts = pauseMenuOpen;

        if (musicOn)
            musicImg.sprite = musicOnSpr;
        else
            musicImg.sprite = musicOffSpr;
        
	}

    public void PauseMenuOpenOrClose()
    {
        pauseMenuOpen = !pauseMenuOpen;
    }
    public void PauseMenuClose()
    {
        pauseMenuOpen = false;
    }

    public void OnOffMusic()
    {
        musicOn = !musicOn;
    }
}
