using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject[] foods;
    public GameObject[] knights;
    public GameObject knightPrefab;
    public GameObject UIManager;

    public int score;

    public int days = 0;

    // Start is called before the first frame update
    void Start()
    {
        updateFoods();
        updateKnights();

        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score:" + score);
        updateFoods();
        updateKnights();
    }

    public void startNextDay()
    {
        if(knights.Length == 0)
        {
            foreach (GameObject food in foods){
                food.transform.position = food.GetComponent<Food>().originalPosition;
                food.GetComponent<Food>().robber = null;
                food.GetComponent<Food>().hasBeenRobbed = false;
                food.GetComponent<Food>().willBeRobbed= false;
            }
            StartCoroutine(startWave());
            days++;
            UIManager.GetComponent<UIManager>().changeDayText("Day " + days);
        }  
    }

    private void updateFoods()
    {
        foods = GameObject.FindGameObjectsWithTag("food");
        UIManager.GetComponent<UIManager>().changeFoodText("Remaining Food: \n" + foods.Length);
        Debug.Log("Foods: " + foods.Length);
    }

    private void updateKnights()
    {
        knights = GameObject.FindGameObjectsWithTag("knight");
        Debug.Log("Knights have been updated: ");
        foreach (GameObject knight in knights)
        {
            Debug.Log(knight);
        }
    }

    public void spawnKnight(Vector2 vector, int order)
    {
        GameObject knight = Instantiate(knightPrefab, vector, Quaternion.identity);
        knight.GetComponent<SpriteRenderer>().sortingOrder = order;
    }

    IEnumerator startWave()
    {
        yield return new WaitForSeconds(3);

        switch (days)
        {
            case 1:
                for (int i = 0; i < 1; i++)
                {
                    spawnKnight(new Vector2(7.5f, 1.6f), i);
                }
                break;

            case 2:
                for (int i = 0; i < 1; i++)
                {
                    spawnKnight(new Vector2(7.5f, 1.6f), i);
                }
                break;

            case 3:
                for (int i = 0; i < 2; i++)
                {
                    spawnKnight(new Vector2(7.5f, 1.6f), i);
                }
                break;

            case 4:
                for (int i = 0; i < 2; i++)
                {
                    spawnKnight(new Vector2(7.5f, 1.6f), i);
                }
                break;

            case 5:
                for (int i = 0; i < 3; i++)
                {
                    spawnKnight(new Vector2(7.5f, 1.6f), i);
                }
                break;

            case 6:
                for (int i = 0; i < 3; i++)
                {
                    spawnKnight(new Vector2(7.5f, 1.6f), i);
                }
                break;
        }
    }
}
