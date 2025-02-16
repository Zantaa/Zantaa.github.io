using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField]
    private GameObject playerAmmoPrefab;

    private GameObject bullet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, .75f, out hit))
            {

                GameObject hitObject = hit.transform.gameObject;

                if (hitObject.GetComponent<ReactiveTarget>())
                {
                    //if bullet doesnt exist, make one!
                    if (bullet == null)
                    {
                        bullet = Instantiate(playerAmmoPrefab) as GameObject;

                        bullet.transform.position =
                            transform.TransformPoint(Vector3.forward * 5f);
                        bullet.transform.rotation = transform.rotation;
                    }
                }
            }

        }
    }//end update

}
