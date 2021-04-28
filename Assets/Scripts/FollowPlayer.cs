using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject Jugador;
    public bool Direccion;
    // Start is called before the first frame update
    void Start()
    {
        if(Jugador == null){
            Debug.LogWarning("Voy a comenzar a buscar");
        }
    }

    void OnTiggerStay2D(Collider2D collision){
        if(collision.gameObject.tag =="Player"){
            if(collision.gameObject.transform.position.x<transform.position.x){
                Direccion = true;
            }else{
                Direccion = false;
                Invoke("follow",0.1f);
                Jugador = collision.gameObject;
            }
        }
    }
    public void follow(){
        transform.position = Vector2.MoveTowards(transform.position,Jugador.transform.position,EnemyDestiny.obj.speed*Time.deltaTime);
        if(Direccion == true){
            transform.rotation = Quaternion.Euler(Vector2.left *180f);
        }else{
            transform.rotation = Quaternion.Euler(Vector2.right * 0f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
