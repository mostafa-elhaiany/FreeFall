using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterup : MonoBehaviour
{
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, 10);
    }
    void Update()
    {
        if (transform.position.y > 30)
            Destroy(gameObject);
    }
}
