using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public enum BulletTypes { bullet,rocket};
    public BulletTypes bulletType;

    public float damage;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    public void GO(Vector3 velocity,float dmg)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = velocity;
        damage = dmg;
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (bulletType)
        {
            case BulletTypes.bullet:
                {
                    break;
                }
            case BulletTypes.rocket:
                {
                    break;
                }
        }
    }


}
