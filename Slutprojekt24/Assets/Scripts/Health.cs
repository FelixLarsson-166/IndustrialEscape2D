using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] float health = 3;
    [SerializeField] TextMeshProUGUI printer;
    [SerializeField] GameObject gameOverMenu;
    [SerializeField] float deathTime = 0.5f;
    [SerializeField] GameObject bloodEmitter;

    void Start()
    {
        printer.text = "Health " + health; 
    }

    void Update()
    {
        
    }

    public void AddHealth(float healthToAdd)
    {
        health += healthToAdd;
        printer.text = "Health: " + health;
        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        if(bloodEmitter)
        {
            bloodEmitter.SetActive(true);
        }
        Destroy(gameObject, deathTime);
        if (gameOverMenu)
        {
            gameOverMenu.SetActive(true);
        }
    }
}
