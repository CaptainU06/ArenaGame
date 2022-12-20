
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public WeaponController wc;


    //Death
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee" && wc.isAttacking)
        {
            health -= 10;
            if (health <= 0)
            {
                Die();
            }
        }
    }


    void Die()
    {

        Destroy(gameObject);
    }
}
