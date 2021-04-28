using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
   public int scoreGive = 30;

   void OnTriggerEnter2D(Collider2D collision){

       if (collision.gameObject.CompareTag("Player"))
       {
           Game.obj.addScore(scoreGive);
           PlayerDestiniy.obj.gemWin();
           UIManager.obj.updateGem();
           UIManager.obj.updateScore();
           AudioManager.obj.playGem();
           FXManager.obj.showPop(transform.position);
           gameObject.SetActive(false);
           
       }
        
    }
}


//Game.obj.addScore(scoreGive);
 //gameObject.SetActive(false);