using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractCollider : MonoBehaviour {

    public GUIText interactMessage;
    public Transform target;

    private bool isClose;
    private bool interacted;
    private Interaction interactionScript;

    // Use this for initialization
    private void Start ()
    {
        interactMessage.text = "";
        isClose = false;
        interactionScript = GameObject.Find("Player").GetComponent<Interaction>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
		if (isClose == true && interacted == false)
        {
            interactMessage.text = "E to Interact";
        }
        if (isClose == true && Input.GetKeyDown(KeyCode.E) && interacted == false)
        {
            interacted = true;
            transform.LookAt(target);
            StartCoroutine(interactionScript.DrinkInteract(interactMessage));
        }
        else if (isClose == false)
        {
            interactMessage.text = "";
        }
	}

    private void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            isClose = true;
        }
    }

    private void OnTriggerExit (Collider other)
    {
        if (other.tag == "Player")
        {
            isClose = false;
            interacted = false;
        }
    }
}
