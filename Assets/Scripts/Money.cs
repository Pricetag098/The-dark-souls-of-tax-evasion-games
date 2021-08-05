using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{

	public static int money = 0;
    public int testVar;
    public float incomeRate = 10;
    public int   incomeAmount = 10;
    float timer = 0;



    public static int lvl = 1;
    public void Update()
    {
        if(timer > incomeRate)
        {
            money += incomeAmount * lvl;
        }
        timer += Time.deltaTime;
        testVar = money;
    }

}
