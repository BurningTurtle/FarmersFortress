using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    public Text dayText;
    public Text foodText;
    public Text moneyText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeFoodText(string text)
    {
        foodText.text = text;
    }

    public void changeDayText(string text)
    {
        dayText.text = text;
    }

    public void changeMoneyText(string text)
    {
        moneyText.text = text;
    }
}
