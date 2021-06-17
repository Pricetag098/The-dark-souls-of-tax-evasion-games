using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletTypes { bullet,rocket};
    public BulletTypes bulletType;

    
    public float minBounceAngle;

    public float damage;

    public LayerMask whatIsEnemy;

    Rigidbody rb;

    public float armingDist,expRadius;
    public GameObject explosionVfx;


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
                        Destroy(gameObject);
                    }
                    else if(Vector3.Angle(transform.forward, collision.GetContact(0).normal) > minBounceAngle)
                    {
                        
                        Destroy(gameObject);
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
        if(Vector3.Distance(transform.position,GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).position) < armingDist)
        {
            Destroy(gameObject);
            return;
        }
        Collider[] hits = Physics.OverlapSphere(pos, expRadius, whatIsEnemy);
        print(hits.Length);
        if(hits.Length > 0)
        {
            for(int i = 0; i < hits.Length; i++)
            {
                if (hits[i].gameObject.GetComponent<Health>())
                {
                    hits[i].gameObject.GetComponent<Health>().DoDamage(damage);
                }
            }
            
        }

        Destroy(Instantiate(explosionVfx, pos,Quaternion.Euler(Vector3.zero)),5);
    }
    
}
