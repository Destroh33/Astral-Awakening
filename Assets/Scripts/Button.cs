using UnityEngine;

public class Button : MonoBehaviour
{
    [Header("Set to either physical or astral plane tag")]
    [SerializeField] string tagToPress;
    public bool isPressed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isPressed = collision.CompareTag(tagToPress);
    }
}
