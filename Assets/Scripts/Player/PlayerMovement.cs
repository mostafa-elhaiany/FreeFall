using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public enum State
    {
        freefall,
        umbrella
    };

    Rigidbody2D rb;
    [SerializeField] GameObject umbrella_gfx;
    [SerializeField] GameObject freefall_gfx;

    [SerializeField] FloatingJoystick movment_joystick;
    [SerializeField] public State state { get; private set; } = State.freefall;
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
            umbrella_gfx.SetActive(true);
            freefall_gfx.SetActive(false);
        }
        else
        {
            state = State.freefall;
            GameManager.lost_umbrella();
            umbrella_gfx.SetActive(false);
            freefall_gfx.SetActive(true);

        }
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = (Input.GetAxis("Horizontal") + movment_joystick.Horizontal) * speed;
    }

    private void FixedUpdate()
    {
        rb.velocity += movement * Time.fixedDeltaTime;

        Vector2 new_velocity = rb.velocity;
        new_velocity.x = Mathf.Clamp(new_velocity.x, -velocity_limits.x, velocity_limits.x);

        
    }
}
