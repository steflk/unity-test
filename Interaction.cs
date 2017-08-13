using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Interaction : MonoBehaviour {

    private PlayerController playerController;
    private StatusBar drinkScript;

    private void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        drinkScript = GameObject.Find("Thirst Bar").GetComponent<StatusBar>();
    }

    public IEnumerator DrinkInteract(GUIText interactMessage)
    {
        if (playerController.currentThirst < drinkScript.maxThirst)
        {
            interactMessage.text = "Drinking...";
            yield return new WaitForSeconds(2);
            for (float x = 0.0f; (x <= 10 && playerController.currentThirst < drinkScript.maxThirst); x += 1)
            {
                playerController.currentThirst = playerController.currentThirst + 1;
                yield return new WaitForSeconds(0.3f);
            }
            interactMessage.text = "";
        }  
    }
}
