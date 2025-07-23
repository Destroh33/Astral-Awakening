using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Interaction : MonoBehaviour
{
    public bool interactingPressed = false;
    [SerializeField] float interactionPressTime;
    bool isInteracting;

    [SerializeField] GameObject dialogueUIBox;
    [SerializeField] Image speakerImg;
    [SerializeField] TextMeshProUGUI dialogueText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) 
        {
            StartCoroutine(InteractingPressed());
        }
        if (isInteracting & Input.anyKey) 
        {
            isInteracting = false;
        }
    }

    IEnumerator InteractingPressed() 
    {
        interactingPressed = true;
        yield return new WaitForSeconds(interactionPressTime);
        interactingPressed = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.GetComponent<DialogueZone>() != null)
        {
            DialogueZone zone = collision.GetComponent<DialogueZone>();
            //TODO
            dialogueUIBox.SetActive(true);
            dialogueText.text = zone.textToDisplay;
            speakerImg.sprite = zone.speakerIcon;
        }
    }
}
