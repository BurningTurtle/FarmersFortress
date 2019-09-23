using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{

    GameObject gameController;
    Rigidbody2D body;

    public bool robbing = false;

    public GameObject currentFood;
    GameObject closest;

    public GameObject coinPrefab;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 30;

        Debug.Log("Knight is starting...");

        gameController = GameObject.Find("GameController");

        body = GetComponent<Rigidbody2D>();

        Debug.Log(gameController.GetComponent<GameController>().foods);

        walkToFood();

        StartCoroutine(noForce());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void walkToFood()
    {
        foreach (GameObject food in gameController.GetComponent<GameController>().foods)
        {
            Debug.Log("Knight searches through foods...");
            if (food.GetComponent<Food>().willBeRobbed == false && !robbing)
            {
                food.GetComponent<Food>().willBeRobbed = true;
                StartCoroutine(walkTo(food));
                currentFood = food;
                robbing = true;
            }
        }
    }

    IEnumerator noForce()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            body.velocity = Vector2.zero;
        }
        
    }

    IEnumerator walkTo(GameObject thing)
    {
        Debug.Log("Knight should walk to..." + thing.transform.position);

        while (!thing.gameObject.GetComponent<Food>().hasBeenRobbed)
        {
            transform.position = Vector2.MoveTowards(this.body.transform.position, thing.transform.position, 0.065f);
            yield return null;
        }

        StartCoroutine(flee());
    }

    IEnumerator flee()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(this.body.transform.position, new Vector2(7.5f, 1.6f), 0.09f);
            yield return null;
            if(body.transform.position.x > 7 && body.transform.position.y > 1.5f)
            {
                gameController.GetComponent<GameController>().score -= 10;
                Destroy(this.gameObject);
                Destroy(currentFood.gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "furniture")
        {
            Debug.Log("Knight bumped into furniture!");

            if(Vector2.Distance(currentFood.transform.position, this.transform.position) < 2.5f)
            {
                currentFood.transform.position = this.transform.position;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "weapon")
        {
            health -= collision.gameObject.GetComponent<WeaponDamage>().damage;
            Debug.Log("Health has been decreased to: " + health);
            if(health <= 0)
            {
                Instantiate(coinPrefab, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }
        }
    }
}
