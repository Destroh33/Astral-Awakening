using UnityEngine;

public class SoulPickupBox : MonoBehaviour
{
    public float followSpeed = 10f;
    public Transform holdPoint;

    private Rigidbody2D heldBox;
    private Rigidbody2D nearbyBox;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            if (heldBox == null)
            {
                if (nearbyBox != null)
                    PickupBox(nearbyBox);
            }
            else
            {
                DropBox();
            }
        }
    }

    void FixedUpdate()
    {
        if (heldBox != null)
        {
            FollowSoul();
        }
    }

    void PickupBox(Rigidbody2D box)
    {
        heldBox = box;
        heldBox.bodyType = RigidbodyType2D.Dynamic;
        heldBox.mass = 0.001f;
        heldBox.gravityScale = 0f;
        heldBox.linearDamping = 0f;
        heldBox.angularDamping = 0f;
    }

    void DropBox()
    {
        if (heldBox != null)
        {
            heldBox.bodyType = RigidbodyType2D.Kinematic;
            heldBox.gravityScale = 0f;
            Physics2D.SyncTransforms();
            heldBox = null;
        }
    }

    void FollowSoul()
    {
        Vector2 targetPos = holdPoint.position;
        Vector2 currentPos = heldBox.position;
        Vector2 newPos = Vector2.Lerp(currentPos, targetPos, followSpeed * Time.fixedDeltaTime);
        heldBox.MovePosition(newPos);
        heldBox.MoveRotation(0f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("SoulBox"))
        {
            nearbyBox = collision.rigidbody;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("SoulBox") && collision.rigidbody == nearbyBox)
        {
            nearbyBox = null;
        }
    }
}
