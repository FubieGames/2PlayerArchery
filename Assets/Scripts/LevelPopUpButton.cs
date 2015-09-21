using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelPopUpButton : MonoBehaviour {

    public Image imageObj;
    Button imageBtn;

    [Header("Sprites")]
    public Sprite openedSpr;
    public Sprite openedPressedSpr;
    public Sprite closedSpr;
    public Sprite closedPressedSpr;

    MenuController menuController;
    bool open;
	
	void Start () {
        imageBtn = imageObj.GetComponent<Button>();
        menuController = GameObject.FindGameObjectWithTag("GameController").GetComponent<MenuController>();
	}
	
	
	void Update () {
        open = menuController.pauseMenuOpen;

        if (open)
        {
            imageObj.sprite = openedSpr;

            SpriteState state = new SpriteState();
            state.pressedSprite = openedPressedSpr;
            imageBtn.spriteState = state;
        }
        else
        {
            imageObj.sprite = closedSpr;

            SpriteState state = new SpriteState();
            state.pressedSprite = closedPressedSpr;
            imageBtn.spriteState = state;
        }
	}
}
