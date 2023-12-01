using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour
{
    [SerializeField] Transform heartParent;
    [SerializeField] float health = 3;
    [SerializeField] TextMeshProUGUI printer;
    [SerializeField] GameObject gameOverMeny;
    [SerializeField] GameObject blood;

    private void Start()
    {
        printer.text = "Health: " + health;
    }

    // Update is called once per frame
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
        if (blood)
        {
            blood.SetActive(true);
        }
        Destroy(gameObject, 1);
        if (gameOverMeny)
        {
            gameOverMeny.SetActive(true);
        }
    }
}
