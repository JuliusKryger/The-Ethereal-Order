using UnityEngine;
using UnityEngine.AI;

public class MoveToClosestTarget : MonoBehaviour
{
public Transform[] ResourceNodes;
public NavMeshAgent Agent;

public void ChoseResourceNode () 
{
    float closestResourceNodeDistance = float.MaxValue;
    NavMeshPath Path = null;
    NavMeshPath ShortestPath = null;

    for (int i = 0; i < ResourceNodes.Length; i++)
    {
        if (ResourceNodes[i] == null)
        {
            continue;
        }
        Path = new NavMeshPath();

        if (NavMesh.CalculatePath(transform.position, ResourceNodes[i].position, Agent.areaMask, Path))
        {
            float distance = Vector3.Distance(transform.position, Path.corners[0]);

            for (int j = 1; j < Path.corners.Length; j++)
            {
                distance += Vector3.Distance(Path.corners[j - 1], Path.corners[j]);
            }

            if (distance < closestResourceNodeDistance)
            {
                closestResourceNodeDistance = distance;
                ShortestPath = Path;           
            }
        }
    }
    if (ShortestPath != null)
    {
        Agent.SetPath(ShortestPath);
    }
}

private void OnGUI () 
{
    if (GUI.Button(new Rect(20, 20, 300, 50), "Move To Target"))
    {
        ChoseResourceNode();
    }
}
}