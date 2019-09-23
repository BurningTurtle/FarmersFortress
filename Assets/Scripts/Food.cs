using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{

    public bool willBeRobbed = false;
    public bool hasBeenRobbed = false;
    public GameObject robber;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (hasBeenRobbed && robber.activeSelf)
        {
            this.transform.position = robber.transform.position;
        }
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("Food collided with " + col.name);
        if(col.gameObject.tag == "knight" && !hasBeenRobbed && col.gameObject.GetComponent<Knight>().currentFood == this.gameObject)
        {
            robber = col.gameObject;
            hasBeenRobbed = true;
        }
    }
}
