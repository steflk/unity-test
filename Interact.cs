using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour {

    public GUIText interactMessage;

    private bool isClose;

	// Use this for initialization
	void Start ()
    {
        interactMessage.text = "";
        isClose = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (isClose == true)
        {
            interactMessage.text = "E to Interact";
        }
        else
        {
            interactMessage.text = "";
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isClose = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isClose = false;
        }
    }
}
