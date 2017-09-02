using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class ThirstBar : MonoBehaviour {

    public float thirstAmount;
    public Image thirstContent;
    public float maxThirst;

    private PlayerController playerController;

	// Use this for initialization
	private void Start ()
    {
        maxThirst = 100;
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        thirstAmount = Mathf.Clamp(thirstAmount, 0.0f, 1.0f);
        ThirstLevel();
	}

    private void ThirstLevel ()
    {
        thirstAmount = playerController.currentThirst / maxThirst;
        thirstContent.fillAmount = thirstAmount;
    }
}
