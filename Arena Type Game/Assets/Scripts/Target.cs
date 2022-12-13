
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 50f;
    public Transform target;
    public float speed = 4f;
    Rigidbody rig;


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

    public void takeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        Destroy(gameObject);
    }
}
