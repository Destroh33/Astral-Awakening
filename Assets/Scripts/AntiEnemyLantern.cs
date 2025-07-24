using UnityEngine;

public class AntiEnemyLantern : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && other.GetComponent<EnemyAI>().GetAlpha() > 0.1f)
        {
            Debug.Log("Lantern destroyed an enemy!");

            // can add death effect or something here

            Destroy(other.gameObject);
        }
    }
}