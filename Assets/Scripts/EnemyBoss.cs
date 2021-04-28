using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : MonoBehaviour
{
    public static EnemyBoss obj;
    public int livesEnemyBoss = 3;
    
    void Awake(){
        obj = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        PlayerDestiniy.obj.flip(EnemyDestiny.obj.movHor);
    }


    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            AudioManager.obj.playEnemyHit();
            EnemyDestiny.obj.getDamageBoss();
        }
    }

    void OnDestroy(){
        obj = null;
    }
}
