using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deposit : Leaf<Context>
{

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
            //Debug.LogError(context.AgentCollider.attachedRigidbody);
            if (Gather.GetFood() == 5)
            { 
                ResourceHandler.AddFoodAmount(Gather.GetFood());
                Gather.SetFood(0);
                Debug.Log("The food has now been put in storage the AI is now holding: " + Gather.GetFood() + "Food");
                return Result.RUNNING;
            }
            else if (Gather.GetFood() == 0)
            {
                return Result.SUCCESS;
            }
        }   
        return Result.SUCCESS;
    }
}
