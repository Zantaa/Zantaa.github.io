using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField]
    private float speed = 10.0f;

    [SerializeField]
    private int damage = 1;


    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }//end update

    //collision detected
    private void OnTriggerEnter(Collider other)
    {
        PlayerCharacter player = GetComponent<PlayerCharacter>();

        if (player != null)
        {
            player.Hurt(damage);
        }

        Destroy(this.gameObject);
    }
}
