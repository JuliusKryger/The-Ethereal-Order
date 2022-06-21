using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Window_GameResources : MonoBehaviour
{
    private void Awake () 
    {
        ResourceHandler.OnFoodAmountChanged += delegate (object sender, EventArgs e) 
        {
            UpdateResourceTextObjects();
        };
        UpdateResourceTextObjects();
    }
    private void UpdateResourceTextObjects () 
    {
        transform.Find("FoodAmount").GetComponent<Text>().text = "FOOD: " + ResourceHandler.GetFoodAmount();
    }
}
