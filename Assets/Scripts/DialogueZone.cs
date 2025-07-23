using UnityEngine;

public class DialogueZone : MonoBehaviour
{
    [Header("Put this on the box collider of the zone you want to enter to trigger dialogue")]
    [Header("--------------------")]
    [Header("Whether this triggers automatically or needs to be interacted with")]
    public bool needsInteraction;
    public string textToDisplay;
    public Sprite speakerIcon;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
