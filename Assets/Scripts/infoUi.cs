using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class infoUi : MonoBehaviour
{
    public Image healthBar;
    public TextMeshProUGUI ammoUi, maxAmmoUi,livesUi,waveNumUi;

    public GameManager gm;
    public Holster holster;
    public Health health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ammoUi.text = holster.ammo.ToString();
        maxAmmoUi.text = holster.maxAmmo.ToString();
        healthBar.fillAmount = health.health / health.maxHealth;
        if (gm)
        {
            livesUi.text = ((int)gm.lives).ToString();
            waveNumUi.text = gm.wave.ToString();
        }
        

    }
}
