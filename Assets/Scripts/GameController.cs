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

    // Start is called before the first frame update
    void Start()
    {
        updateFoods();
        updateKnights();

        StartCoroutine(wave1());
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Score:" + score);
        updateFoods();
        updateKnights();
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

    IEnumerator wave1()
    {
        for (int i=0; i<5; i++){
            spawnKnight(new Vector2(7.5f, 1.6f), i);
            yield return new WaitForSeconds(0);
        }
    }
}
