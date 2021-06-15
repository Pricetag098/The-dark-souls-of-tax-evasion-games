using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletTypes { bullet,rocket};
    public BulletTypes bulletType;

    public float armingDist;
    public GameObject explosionVfx;
    public float minBounceAngle;

    public float damage;

    public LayerMask whatIsEnemy;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void GO(Vector3 velocity,float dmg)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = velocity;
        transform.forward = rb.velocity.normalized;
        transform.up = -velocity.normalized;
        damage = dmg;
    }

    private void LateUpdate()
    {
        transform.forward = rb.velocity.normalized;
    }

    private void OnCollisionEnter(Collision collision)
    {

        
        switch (bulletType)
        {
            case BulletTypes.bullet:
                {
                    print(collision.gameObject.name);
                    print(whatIsEnemy.value);
                    print(whatIsEnemy);
                    if (Mathf.Pow(2, collision.gameObject.layer) == whatIsEnemy.value)
                    {

                        if (collision.gameObject.GetComponent<Health>())
                        {
                            collision.gameObject.GetComponent<Health>().DoDamage(damage);
                        }
                    }
                    else if(Vector3.Angle(transform.forward, collision.GetContact(0).normal) > minBounceAngle)
                    {
                        
                        //Destroy(gameObject);
                    }
                    break;
                }
            case BulletTypes.rocket:
                {
                    Explode(collision.GetContact(0).point);
                    Destroy(gameObject);
                    break;
                }
        }
    }
    void Explode(Vector3 pos)
    {
        if(Vector3.Distance(transform.position,GameObject.FindGameObjectWithTag("Player").transform.position) < armingDist)
        {
            Destroy(gameObject);
            return;
        }
        Destroy(Instantiate(explosionVfx, pos,Quaternion.Euler(Vector3.zero)),5);
    }

}
