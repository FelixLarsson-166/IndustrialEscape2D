using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float damage = -1;
    [SerializeField] string damageTag = "Player";
    [SerializeField] bool givesHealth = false;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(damageTag))
        {
            collision.gameObject.GetComponent<Health>().AddHealth(damage);
            if(givesHealth == true)
            {
                Destroy(gameObject);
            }
        }
    }
}
