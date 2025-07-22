using UnityEngine;

public class AntiEnemyLantern : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Lantern destroyed an enemy!");

            // can add death effect or something here

            Destroy(other.gameObject);
        }
    }
}