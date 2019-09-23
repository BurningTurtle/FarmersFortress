using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        if(this.gameObject.name == "pitchfork")
        {
            damage = 10;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
