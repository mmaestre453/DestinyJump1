using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestiniy : MonoBehaviour
{

    public static PlayerDestiniy obj;

    public int lives = 1;
    public int gem = 0;
    public bool isGrounded = false;
    public bool isMoving = false;
    public bool isInmune = false;

    public float speed = 5f;
    public float jumpForce =3f;
    public float movHor;

    public float inmuneTimeCnt= 0f;
    public float inmuneTime = 0.5f;

    public LayerMask groundLayer;
    public float radius= 0.3f;
    public float groundRayDist = 0.5f;

    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer spr;

    void Awake(){
        obj = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //movimiento al presionar una tecla horizontal
        movHor = Input.GetAxisRaw("Horizontal");
        //detectando si el personaje se esta moviendo
        isMoving = (movHor != 0f);
        //detectabdo si el personaje toca el seulo
        isGrounded = Physics2D.CircleCast(transform.position, radius,Vector3.down,groundRayDist,groundLayer);
        if(Input.GetKeyDown(KeyCode.Space))
            jump();

        //posicion del personaje al girar    
        flip(movHor);
        //,andanod paramatros al animator para las animaciones
        anim.SetBool("isMoving", isMoving);
        anim.SetBool("isGrounded", isGrounded);
    }

    void FixedUpdate(){
        //dando movimiento horizontal al player
        rb.velocity = new Vector2(movHor * speed, rb.velocity.y);
    }
    public void jump(){
        if(!isGrounded) return;

        rb.velocity = Vector2.up * jumpForce;
    }
    private void flip(float _xValue){
        Vector3 theScale = transform.localScale;

        if(_xValue < 0)
            theScale.x = Mathf.Abs(theScale.x)*-1;
        else
        if(_xValue > 0){
            theScale.x = Mathf.Abs(theScale.x);
        }
        transform.localScale = theScale;
    }

    public void getDamage(){
        lives--;
        if(lives <=  0){
            this.gameObject.SetActive(false);
        }
    }

    public void addLive(){
        lives++;

        if(lives > Game.obj.maxLives){
            lives= Game.obj.maxLives;
        }
    }

    public void gemWin(){

        gem++;
        if(gem == Game.obj.maxGem){
            Debug.Log("Ganaste!!");
        }


    }

    void OnDestroy(){
        obj = null;
    }
}
