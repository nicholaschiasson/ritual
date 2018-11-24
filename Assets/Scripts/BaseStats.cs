using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour {

    protected int health, str, mana;

    void Start () {
        health = 100;
        str = 5;
        mana = 100;
	}
	
    public int getHealth()
    {
        return health;
    }

    public int takeDamage(int damage)
    {
        health = (health-damage>0)?health - damage:0;
        return health;
    }
}
