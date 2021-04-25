using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
   public int scoreGive = 150;

   void OnTriggerEnter2D(Collider2D collision){

       if (collision.gameObject.CompareTag("Player"))
       {
           Game.obj.addScore(scoreGive);
           FXManager.obj.showPop(transform.position);
           gameObject.SetActive(false);
           PlayerDestiniy.obj.gemWin();
       }
        
    }
}


//Game.obj.addScore(scoreGive);
 //gameObject.SetActive(false);