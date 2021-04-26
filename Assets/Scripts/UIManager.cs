using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager obj;
    
    public Text gemLbl;
    public Text scoreLbl;

    public Transform UIPanel;

    public void updateGem(){
        gemLbl.text = "" + PlayerDestiniy.obj.gem;
    } 

    public void updateScore(){
        scoreLbl.text = "" + Game.obj.score;
    }

    public void startGame(){
        AudioManager.obj.playGui();
        Game.obj.gamePaused = true;
        UIPanel.gameObject.SetActive(true);
    }

    public void hideInitPanel(){
        AudioManager.obj.playGui();
        Game.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);
    }
    void Awake(){
        obj = this;
    }

    void OnDestroy(){
        obj = null;
    }
}
