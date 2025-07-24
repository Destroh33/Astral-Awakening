using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] Transform[] movePositions;
    [SerializeField] float moveSpeed = 2f;
    [SerializeField] bool moveAutomatically;
    [SerializeField] float detectRad;
    int nextPos = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (moveAutomatically)
        {
            Vector2.Lerp(transform.position, movePositions[nextPos].position, moveSpeed * Time.deltaTime);
        }
        if (Vector2.Distance(transform.position, movePositions[nextPos].position) < detectRad)
        {
            nextPos++;
            if (nextPos > movePositions.Length) nextPos = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>())
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.transform.SetParent(null);
    }

    IEnumerator MoveToNextPosition()
    {
        while (Vector2.Distance(transform.position, movePositions[nextPos].position) > detectRad)
        {
            Vector2.Lerp(transform.position, movePositions[nextPos].position, moveSpeed * Time.deltaTime);
            yield return null;
        }
        nextPos++;
        if (nextPos >= movePositions.Length) nextPos = 0;
    }

}
