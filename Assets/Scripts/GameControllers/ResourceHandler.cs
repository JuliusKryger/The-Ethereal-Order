using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class ResourceHandler
{

    public static event EventHandler OnFoodAmountChanged;
    private static int foodAmount;

    public static void AddFoodAmount (int amount) //This method is called just before we reset our food amount from the deposit leaf.
    {
        foodAmount += amount;
        if (OnFoodAmountChanged != null)
        {
            OnFoodAmountChanged(null, EventArgs.Empty);
        }
    }

    public static int GetFoodAmount () 
    {
        return foodAmount;
    }
}
