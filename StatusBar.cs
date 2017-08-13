using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class StatusBar : MonoBehaviour {

    public float fillAmount;
    public Image content;
    public float maxThirst;

    private PlayerController playerController;

	// Use this for initialization
	private void Start ()
    {
        maxThirst = 100;
        playerController = GameObject.Find("Player").GetComponent <PlayerController>();
	}
	
	// Update is called once per frame
	private void Update ()
    {
        fillAmount = Mathf.Clamp(fillAmount, 0.0f, 1.0f);
        ThirstLevel();
        UpdateBar();
	}

    private void UpdateBar ()
    {
        content.fillAmount = fillAmount;
    }

    private void ThirstLevel ()
    {
        fillAmount = playerController.currentThirst / maxThirst;
    }
}
