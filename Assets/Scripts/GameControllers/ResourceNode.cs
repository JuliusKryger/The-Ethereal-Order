using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceNode
{

    private static int resourceAmount = 4;

    public static void GetResource () 
    {
        Debug.Log("ResourceNode -> " + resourceAmount);
        resourceAmount--;
    }

    public static bool HasResource () 
    {
        return resourceAmount > 0;
    }


}
