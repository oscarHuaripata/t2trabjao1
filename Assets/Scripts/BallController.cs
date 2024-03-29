using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    
    public float velocityX = 10f;

    private const string ENEMY_TAG = "Enemy"; 

    private Rigidbody2D rb;
    private GameController _game;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        _game = FindObjectOfType<GameController>();
        Destroy(this.gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(velocityX, rb.velocity.y);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
      
         

        if (other.gameObject.CompareTag(ENEMY_TAG))
        {  
            Destroy(this.gameObject);
            Destroy(other.gameObject);
            _game.PlusScore(10);
           Debug.Log(_game.GetScore());//aa
            // que le pasara al enemigo//aa
        }
    }
}
