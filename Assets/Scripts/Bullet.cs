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

    public float armingDist,expRadius,expForce;
    public GameObject explosionVfx;

    //public AudioClip hitSound;
    //AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        
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
        //if (hitSound)
        //{
            //audioSource.PlayOneShot(hitSound);
        //}
        
        
        switch (bulletType)
        {
            case BulletTypes.bullet:
                {
                    print(collision.gameObject.name);
                    print(whatIsEnemy.value);
                    print(whatIsEnemy);
                    if ((whatIsEnemy.value & (1 << collision.gameObject.layer))>0)
                    {

                        if (collision.gameObject.GetComponent<Health>())
                        {
                            collision.gameObject.GetComponent<Health>().DoDamage(damage);
                        }
                        else if (collision.gameObject.GetComponentInParent<Health>())
                        {
                            collision.gameObject.GetComponentInParent<Health>().DoDamage(damage);
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
        //Time.timeScale = 0;
        if(Vector3.Distance(transform.position,GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).position) < armingDist)
        {
            Destroy(gameObject);
            return;
        }
        Collider[] hits = Physics.OverlapSphere(pos, expRadius, whatIsEnemy);
        //print(hits.Length);
        if(hits.Length > 0)
        {
            for(int i = 0; i < hits.Length; i++)
            {
                //print(hits[i].name);
                if (hits[i].gameObject.GetComponent<Health>())
                {
                    //print("OOOOOOOOEEEEE");
                    hits[i].gameObject.GetComponent<Health>().DoDamage(damage);
                }
                else if (hits[i].gameObject.GetComponentInParent<Health>())
                {
                    hits[i].gameObject.GetComponentInParent<Health>().DoDamage(damage);
                }
                if (hits[i].gameObject.GetComponent<Rigidbody>())
                {
                    hits[i].gameObject.GetComponent<Rigidbody>().AddExplosionForce(expForce, pos, expRadius, 0.1f);
                }
            }
            
        }

        Destroy(Instantiate(explosionVfx, pos,Quaternion.Euler(Vector3.zero)),5);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, expRadius);
    }

}
