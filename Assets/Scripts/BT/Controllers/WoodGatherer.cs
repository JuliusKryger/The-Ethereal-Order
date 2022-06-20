using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGatherer : MonoBehaviour
{
    private Context context;
    
    Node<Context> root;


    List<Node<Context>> layer1 = new List<Node<Context>>();

    Node<Context> gather = new Gather();
    //Node<Context> deposit = new Deposit();
    Node<Context> moveToTarget = new MoveToTarget();
    //Node<Context> findTargetInRange = new FindTargetInRange();



    void Awake()
    {
    // layer 1 This is actually the order which the tree will be executed aswell.
        
        //layer1.Add(deposit);
        layer1.Add(moveToTarget);
        layer1.Add(gather);

    // root
        root = new Sequence<Context>(layer1);

        context = GetComponent<Context>();
        
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            root.Run(context);
        }
    }
}
