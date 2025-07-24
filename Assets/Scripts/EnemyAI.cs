using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    [Header("Chase Settings")]
    public Transform target;
    public float speed = 2f;

    [Header("Fade Settings")]
    public float fadeDuration = 1.5f;

    private SpriteRenderer sr;
    private bool isActive = false;     

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        if (sr != null)
        {
            Color c = sr.color;
            c.a = 0f;
            sr.color = c;
        }
        isActive = false;
    }

    private void Update()
    {
        if (!isActive || target == null) return;
        Vector2 direction = (target.position - transform.position).normalized;
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    public void Activate()
    {
        if (sr.color.a < 1f)
        {
            StartCoroutine(FadeIn());
        }
    }

    private IEnumerator FadeIn()
    {
        float t = 0f;
        Color startColor = sr.color;
        Color endColor = sr.color;
        endColor.a = 1f;

        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            sr.color = Color.Lerp(startColor, endColor, t / fadeDuration);
            yield return null;
        }
        sr.color = endColor;
        isActive = true;
    }
    public float GetAlpha()
    {
        return sr.color.a;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Soull"))
        {
            Destroy(other.gameObject);
        }
    }
}