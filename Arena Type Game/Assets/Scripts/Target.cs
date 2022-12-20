
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;
    public WeaponController wc;

    //Move
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.fixedDeltaTime);
        rig.MovePosition(pos);
        transform.LookAt(target);

    }

    //Attack

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
