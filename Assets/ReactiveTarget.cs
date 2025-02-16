using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{

    public Waves waves;

    public int health;

    private int number;

    [Header("Loot")]
    public List<HealthPack> lootTable = new List<HealthPack>();

    public void ReactToHit()
    {
        WanderingAI behavior = GetComponent<WanderingAI>();

        if (behavior != null)
        {
            behavior.SetAlive(false); //dont move anymore
        }

        StartCoroutine(Die());

    }//end ReactToHit
    
    private IEnumerator Die()
    {
        this.transform.Rotate(-75, 0, 0);

        yield return new WaitForSeconds(.5f);

        foreach(HealthPack healthPack in lootTable)
        {
            if(Random.Range(0f, 100f) <= healthPack.dropChance)
            {
                InstantiateLoot(healthPack.healthPackPrefab);
            }
            break;
        }

        Destroy(this.gameObject);

        Debug.Log("You have killed an enemy!");


    } 

    void InstantiateLoot(GameObject loot)
    {
        if (loot)
        {
            GameObject droppedLoot = Instantiate(loot, transform.position, Quaternion.identity);

            droppedLoot.GetComponent<SpriteRenderer>().color = Color.blue;

            Destroy(droppedLoot, 5f);

        }
    }

    private void OnTriggerEnter(Collider bullet)
    {
        if (bullet.gameObject.tag == "Bullet")
        {
            health -= 1;
            Debug.Log("You hit an enemy: -1 Health!");

            if (health <= 0)
            {

                Debug.Log("You have killed an enemy!");
                health = 0;
                StartCoroutine(Die());

            }
        }
    }

}
