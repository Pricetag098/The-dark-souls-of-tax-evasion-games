using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health, maxHealth;

    public bool isPlayer;

    public GameObject destroyOnDeath;


    // Start is called before the first frame update
    private void Start()
    {
        health = maxHealth;
    }


    public void DoDamage(float dmg)
    {
        health -= dmg;
        OnTakeDmg(dmg);
    }
    void OnTakeDmg(float dmg)
    {
        if (isPlayer)
        {
            return;
        }
        if(health <= 0)
        {
            OnDeath();
        }
    }
    void OnDeath()
    {
        if (destroyOnDeath)
        {
            Destroy(destroyOnDeath);
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
