using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Context : MonoBehaviour
{
    public Transform transform;
    public NavMeshAgent navMeshAgent;
    public Animator animator;
    public Transform Target;
    public Transform[] ResourceNodes;
    public Transform[] StorageNodes;
    public int Wood;
    public int Food; // Måske skaber dette problemer hvis vi har mere en 1 AI
    public Collider AgentCollider;
}
