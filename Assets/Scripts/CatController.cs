using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    private SpriteRenderer sr;
    private Animator animator;
    private Rigidbody2D rb;

    private const int Idle = 0;
    private const int Run = 1;
    private const int Jump = 2;
    private const int Slide = 3;
    
    private bool estaSaltando = false;
    
    public float velocityX = 7;  
    public float jumpForce = 30;
    
    private const int PISO_SALTAR = 8;
    
    private const int MONEDA_BRONCE = 10;
    private const int MONEDA_PLATA = 11;
    private const int MONEDA_ORO = 12;
   
    
    public GameObject rightBullet;
    public GameObject leftBullet;
    
    private GameController _game;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
        _game = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        CambiarAnimacion(Idle);

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.velocity = new Vector2(velocityX, rb.velocity.y);
            sr.flipX = false;
            CambiarAnimacion(Run);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.velocity = new Vector2(- velocityX, rb.velocity.y);
            sr.flipX = true;
            CambiarAnimacion(Run);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
        
        
        if (Input.GetKeyUp(KeyCode.Space)  && !estaSaltando )
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            CambiarAnimacion(Jump);
            estaSaltando = true;
        }

        if (Input.GetKey(KeyCode.X))
        {
            CambiarAnimacion(Slide);
        }
        
        
        if (Input.GetKeyUp(KeyCode.C))
        {
            var bullet = sr.flipX ? leftBullet : rightBullet;
            var position = new Vector2(transform.position.x, transform.position.y);
            var rotation = rightBullet.transform.rotation;
            Instantiate(bullet, position, rotation);
        }
        
        
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.layer == PISO_SALTAR)
            estaSaltando = false;


        if (other.gameObject.layer == MONEDA_ORO)
        {
            Destroy(other.gameObject);
            _game.PlusOro(5);
        }
        
        if (other.gameObject.layer == MONEDA_PLATA)
        {
            Destroy(other.gameObject);
            _game.PlusPlata(2);
        }
        
        if (other.gameObject.layer == MONEDA_BRONCE)
        {
            Destroy(other.gameObject);
            _game.PlusBronce(1);
        }
        
        
       
        
    }
    
    
    private void CambiarAnimacion(int animacion)
    {
        animator.SetInteger("Estado", animacion);
    }
}
