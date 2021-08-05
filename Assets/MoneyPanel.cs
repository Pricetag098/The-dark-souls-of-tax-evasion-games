using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MoneyPanel : MonoBehaviour
{
    

    public TextMeshPro infoText, costText;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       //if(Money.lvl<)

    }
    private void OnMouseOver()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Money.lvl += 1;
        }
    }
}
