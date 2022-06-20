using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gather : Leaf<Context>
{
    MoveToClosestTarget moveToClosestTarget;

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
            Debug.LogError(context.AgentCollider.attachedRigidbody);
            if (context.Food < 5)
            { 
                context.Food++;
                return Result.RUNNING;
            }
            else if (context.Food == 5)
            {
                return Result.SUCCESS;
            }
        }   
        return Result.SUCCESS;
    }
}
