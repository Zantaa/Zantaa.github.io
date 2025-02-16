using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int health;
    public int maxHealth = 25;
    
    void Start()
    {
        health = maxHealth;
        
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void AddHealth(int healthAmount)
    {
        health += healthAmount;
    }

    private void OnTriggerEnter(Collider sphereCollider)
    {
        if (sphereCollider.gameObject.tag == "Flame")
        {
            health -= 1;
            Debug.Log("You were hit by a Flame: -1 Health!");

            if (health <= 0)
            {
                
                Debug.Log("You have died!");
                health = 0;
                Time.timeScale = 0f;

            }
        }
        if(sphereCollider.gameObject.tag == "HealthPack" && health <= 23)
        {
            health += 2;
            Debug.Log("You have gained 2 health!");
        }

        if (sphereCollider.gameObject.tag == "HealthPack" && health == 24)
        {
            health += 1;
            Debug.Log("You have gained 1 health!");

        }

        else if(sphereCollider.gameObject.tag == "HealthPack" && health == 25)
        {
            Debug.Log("Health is full: " + health);
        }


    }//end sphereCollider

    // Update is called once per frame
    void Update()
    {
        
    }

}
