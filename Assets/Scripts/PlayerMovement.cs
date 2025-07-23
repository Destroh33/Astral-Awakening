using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2;
    private Vector2 vel;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        vel = new Vector2(0.0f, 0.0f);
        if (Input.GetKey(KeyCode.A))
        {
            vel += new Vector2(-1.0f, 0.0f) * Time.fixedDeltaTime * speed;
            rb.MovePosition(rb.position + vel);
        }
        if (Input.GetKey(KeyCode.D))
        {
            vel += new Vector2(1.0f, 0.0f) * Time.fixedDeltaTime * speed;
            rb.MovePosition(rb.position + vel);
        }
        if (Input.GetKey(KeyCode.W))
        {
            vel += new Vector2(0.0f, 1.0f) * Time.fixedDeltaTime * speed;
            rb.MovePosition(rb.position + vel);
        }
        if (Input.GetKey(KeyCode.S))
        {
            vel += new Vector2(0.0f, -1.0f) * Time.fixedDeltaTime * speed;
            rb.MovePosition(rb.position + vel);
        }
    }
}
