using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodGatherer : MonoBehaviour
{
    private Context context;
    
    Node<Context> root;


    List<Node<Context>> layer1 = new List<Node<Context>>();

    Node<Context> gather = new Gather();
    Node<Context> deposit = new Deposit();
    //Node<Context> attackTarget = new AttackTarget();
    //Node<Context> findTargetInRange = new FindTargetInRange();



    void Awake()
    {
    // layer 1
        layer1.Add(gather);
        layer1.Add(deposit);
        //layer1.Add(attackTarget);

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
