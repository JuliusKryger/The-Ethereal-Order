using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodGatherer : MonoBehaviour
{
    private Context context;
    Node<Context> root;

    List<Node<Context>> layer1 = new List<Node<Context>>();

    //List<Node<Context>> layer2 = new List<Node<Context>>();

    Node<Context> moveToTarget = new MoveToTarget();
    Node<Context> gather = new Gather();
    Node<Context> findStorageTarget = new FindStorageTarget();
    Node<Context> deposit = new Deposit();

    void Awake()
    {
    // layer 1 This is actually the order which the tree will be executed aswell.

        //layer1.Add(deposit);
        layer1.Add(moveToTarget);
        layer1.Add(gather);
        layer1.Add(findStorageTarget);
        layer1.Add(deposit);

        //layer2.Add(moveToTarget);
        //layer2.Add(gather);
        //layer2.Add(findStorageTarget);
        //layer2.Add(deposit);

    // root
        root = new Sequence<Context>(layer1);

        //root = new Sequence<Context>(layer2);

        context = GetComponent<Context>();
        
        StartCoroutine(Loop());
    }

    IEnumerator Loop()
    {
        while (true)
        {
            yield return new WaitForSeconds(2);
            root.Run(context);
        }
    }
}
