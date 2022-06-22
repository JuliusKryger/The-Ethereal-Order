using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FindStorageTarget : Leaf<Context>
{
    public override Result Run(Context context) 
    {
        float closestStorageNodeDistance = float.MaxValue;
        NavMeshPath Path = null;
        NavMeshPath ShortestPath = null;

        if (context == null)
        {
            Debug.LogError("Context is null");
            return Result.FAILURE;
        }
        if (context.navMeshAgent == null) 
        {
            Debug.LogError("No navMeshAgent set on Context");
            return Result.FAILURE;
        }

        // if (context.Target == null)
        // {
        //     context.Target = context.StorageNodes[0];
        //     return Result.RUNNING;
        // }

        for (int i = 0; i < context.StorageNodes.Length; i++)
        {
            bool hasReachedDestination()
            {
                context.navMeshAgent.stoppingDistance = 2f; //<---Offset
                if (context.navMeshAgent.remainingDistance <= 2f)
                    return true;
                else
                    return false;        
            }

            if (context.StorageNodes[i] == null)
            {
                continue;
                //Debug.LogError("The Target was not managed to be set correctly");
                //return Result.FAILURE;
            }
            Path = new NavMeshPath();

            if (NavMesh.CalculatePath(context.transform.position, context.StorageNodes[i].position, context.navMeshAgent.areaMask, Path))
            {
                float distance = Vector3.Distance(context.transform.position, Path.corners[0]);

                for (int j = 1; j < Path.corners.Length; j++)
                {
                    distance += Vector3.Distance(Path.corners[j - 1], Path.corners[j]);
                }

                if (distance < closestStorageNodeDistance)
                {
                    closestStorageNodeDistance = distance;
                    ShortestPath = Path;           
                }
            }
            if (ShortestPath != null)
            {
                context.animator.SetBool("IsMoving",true);
                context.navMeshAgent.SetPath(ShortestPath);
                //Debug.LogError(context.navMeshAgent.hasPath);
                if (hasReachedDestination() == true)
                {
                    return Result.SUCCESS;
                }
                return Result.RUNNING;
            }
            return Result.SUCCESS;
        }
        return Result.SUCCESS;
    }
}