using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public int attack;
    public int health;
    
    void Start()
    {
        health = 25;
    }//end start

    public void Hurt(int damage)
    {
        health -= damage;
    }

}
