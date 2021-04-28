using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFinal : MonoBehaviour
{
    public static UIFinal obj;
    public Transform UIPanel;


    public void finalPanel(){
        AudioManager.obj.playGui();
        Game.obj.gamePaused = true;
        UIPanel.gameObject.SetActive(true);
    }

    public void Exit(){
        Application.Quit();
    }

    public void hidenFinal(){
        AudioManager.obj.playGui();
        Game.obj.gamePaused = false;
        UIPanel.gameObject.SetActive(false);
    }

     public void nextLevel(){
        hidenFinal();
        SceneManager.LoadScene("LevelTwo");
    }

    void Awake(){
        obj = this;
    }

    void OnDestroy(){
        obj = null;
    }
}
