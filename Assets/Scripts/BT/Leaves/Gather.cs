using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : Leaf<Context>
{
    private static int food;
    private int maxVal = 5;

    public static int GetFood () {
        return food;
    }

    public static void SetFood (int amount) {
        food = amount;
    }

    public override Result Run(Context context) 
    {   
        if (context == null)
        {
            Debug.LogError("Context is null");
            return Result.FAILURE;
        }
        if (context.navMeshAgent == null) 
        {
            Debug.LogError("No NavMeshAgent set on Context");
            return Result.FAILURE;
        }

        if (context.AgentCollider == null)
        {
            Debug.LogError("Seems to be a problem with the Agents Collider");
            return Result.FAILURE;
        }

        if (context.AgentCollider.attachedRigidbody)
        {
            if (food < maxVal)
            { 
                context.animator.SetBool("IsMoving",false);
                //ResourceNode.GetResource();
                food = food+1;
                Debug.Log("This is the AI's Food amount carried: " + food);
                return Result.RUNNING;
            }
            else if (food == maxVal)
            {
                return Result.SUCCESS;
            }
        }   
        return Result.SUCCESS;
    }
}
