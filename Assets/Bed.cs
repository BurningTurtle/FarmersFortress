using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    public GameObject player;
    public GameObject gameController;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (Vector2.Distance(this.transform.position, player.transform.position) < 1.5f)
            {
                Debug.Log("Farmer goes to sleep...");
                gameController.GetComponent<GameController>().startNextDay();
            }
        }
    }
}
