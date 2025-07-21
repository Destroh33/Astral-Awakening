using System.Collections;
using UnityEngine;

public class SoulMovement : MonoBehaviour
{
    [SerializeField] private int speed = 2;
    private Vector2 vel;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            vel = new Vector2(-1.0f, 0.0f) * Time.fixedDeltaTime * speed;
            rb.MovePosition(rb.position + vel);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            vel = new Vector2(1.0f, 0.0f) * Time.fixedDeltaTime * speed;
            rb.MovePosition(rb.position + vel);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            vel = new Vector2(0.0f, 1.0f) * Time.fixedDeltaTime * speed;
            rb.MovePosition(rb.position + vel);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            vel = new Vector2(0.0f, -1.0f) * Time.fixedDeltaTime * speed;
            rb.MovePosition(rb.position + vel);
        }
    }
}
