using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoAttack : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;
    
    public float velocityX = 1; 
    
    private const int CHOCA_IZQUIERDA = 18;
    private const int CHOCA_DERECHA = 19;
    
    public GameObject enemigo;
    
    private bool collided;

   
    public bool puedeSaltar = true;
   
    
    public float velocityx = 5;
    
       GameObject colision;
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        
       

    }
    
    public void OnCollisionEnter2D(Collision2D other){
         
        if ( other.gameObject.layer== CHOCA_DERECHA)
        {
            rb.velocity = new Vector2(- velocityX, rb.velocity.y);
            sr.flipX = true;
        }

        else if (other.gameObject.layer== CHOCA_IZQUIERDA )
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
        }
    }
    
  
  
  
       
        
    
}
