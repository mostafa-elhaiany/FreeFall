using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    enum State
    {
        freefall,
        umbrella
    };

    Rigidbody2D rb;

    [SerializeField] State state = State.freefall;
    [SerializeField] Vector2 velocity_limits;


    [SerializeField] float speed = 5;
    Vector2 movement = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    public void toggle_state()
    {
        if(state == State.freefall)
        {
            state = State.umbrella;
            GameManager.got_umbrella();
        }
        else
        {
            state = State.freefall;
            GameManager.lost_umbrella();
        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxis("Horizontal") * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity += movement * Time.fixedDeltaTime;

        Vector2 new_velocity = rb.velocity;
        new_velocity.x = Mathf.Clamp(new_velocity.x, -velocity_limits.x, velocity_limits.x);

        
    }
}
