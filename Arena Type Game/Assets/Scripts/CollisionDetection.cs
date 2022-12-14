using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public WeaponController wc;
    public GameObject HitPartical;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy" && wc.isAttacking)
        {
            other.GetComponent<Animator>().SetTrigger("Hit");
            Instantiate(HitPartical, new Vector3(other.transform.position.x, transform.position.y, other.transform.position.z), other.transform.rotation);
        }
    }

   
}
