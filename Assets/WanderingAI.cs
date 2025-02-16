using System.Collections;
using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField]
    private float speed = 3.0f;

    [SerializeField]
    private float obstacleRange = 1.0f;

    [SerializeField]
    private GameObject fireballPrefab;

    private GameObject fireball;

    private bool isAlive;


    private void Start()
    {
        isAlive = true;
    }

    public void SetAlive(bool isAlive)
    {
        this.isAlive = isAlive;
    }

    void Update()
    {
        if (isAlive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
        }

        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.SphereCast(ray, .75f, out hit))
        {

            GameObject hitObject = hit.transform.gameObject;

            if(hitObject.GetComponent<PlayerCharacter>())
            {
                //if fireball doesnt exist, make one!
                if(fireball == null)
                {
                    fireball = Instantiate(fireballPrefab) as GameObject;

                    fireball.transform.position =
                        transform.TransformPoint(Vector3.forward * 5f);
                    fireball.transform.rotation = transform.rotation;
                }
            }

             else if (hit.distance < obstacleRange)
            {
                float angle = Random.Range(-110, 110);
                transform.Rotate(0, angle, 0);
            }
        }//end if physics spherecast
    }//end update

}
