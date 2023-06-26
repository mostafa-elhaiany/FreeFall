using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectMovement : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, GameManager.current_difficulty);
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < GameManager.current_difficulty)
        {
            rb.velocity = new Vector2(rb.velocity.x, GameManager.current_difficulty);
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            rb.AddForce(new Vector2(1, 0), ForceMode2D.Impulse);
        }    
    }

}
