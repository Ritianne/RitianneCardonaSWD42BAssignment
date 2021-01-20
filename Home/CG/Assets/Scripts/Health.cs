using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    // Update Text in UI
    Text healthText;
    int health = 50;

    // Start is called before the first frame update
    void Start()
    {
        healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = health.ToString();
    }

    public void UpdateHealth(int healthValue)
    {
        health = healthValue;
    }

    public string GetScoreText()
    {
        return healthText.ToString();
    }
}
