using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class HungerBar : MonoBehaviour {

    public float hungerAmount;
    public Image hungerContent;
    public float maxHunger;

    private PlayerController playerController;

    // Use this for initialization
    private void Start ()
    {
        maxHunger = 100;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }
	
	// Update is called once per frame
	private void Update ()
    {
        hungerAmount = Mathf.Clamp(hungerAmount, 0.0f, 1.0f);
        HungerLevel();
    }

    private void HungerLevel()
    {
        hungerAmount = playerController.currentHunger / maxHunger;
        hungerContent.fillAmount = hungerAmount;
    }
}
