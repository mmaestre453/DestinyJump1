using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{

    public static Game obj;

    public int maxLives = 1;
    public int maxGem = 3;

    public bool gamePaused = false;
    public int score = 0;
    public int gem = 0;

    void Awake(){
        obj = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        gamePaused = false;
        UIManager.obj.startGame();
    }

    // Update is called once per frame
    public void addScore (int scoreGive){
        score += scoreGive;
    }

    

    public void gameOver(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void OnDestroy(){
        obj = null;
    }
}
