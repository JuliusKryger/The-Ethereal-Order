using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : Leaf<Context>
{
    MoveToClosestTarget moveToClosestTarget;
    public int food;

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

        if (context.AgentCollider.attachedRigidbody) // Det virker ikke da det ikke er i et for loop indtil den rammer 5
        {
            //Debug.LogError(context.AgentCollider.attachedRigidbody);
            if (food < 5)
            { 
                food++;
                Debug.Log("This is the AI's Food amount carried: " + food);
                return Result.RUNNING;
            }
            else if (food == 5)
            {
                return Result.SUCCESS;
            }
        }   
        return Result.SUCCESS;
    }
}
