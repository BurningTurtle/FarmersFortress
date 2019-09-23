using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class petMachine : MonoBehaviour
{

    public GameObject player;
    public GameObject coin;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        { 
            if(Vector2.Distance(this.transform.position, player.transform.position) < 2f)
            {
                StartCoroutine(spin());
            }
        }
    }

    IEnumerator spin()
    {
        anim.SetBool("isSpinning", true);
        yield return new WaitForSeconds(0.75f);
        Instantiate(coin, new Vector2(this.transform.position.x, this.transform.position.y - 1.5f), Quaternion.identity);
        anim.SetBool("isSpinning", false);
    }
}
