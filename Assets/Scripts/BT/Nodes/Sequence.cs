using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence<Context> : Node<Context>
{
    private List<Node<Context>> children = null; 
    private int running = 0; 

    public Sequence(List<Node<Context>> children) => this.children = children;

    public Result Run(Context context) 
    {
        if (children.Count == 0) Debug.LogWarning("Sequence has no children");
        
        for (int i = running; i < children.Count; i++)
        {
            Node<Context> child = children[i];
            Result result = child.Run(context);
            Debug.Log(child + ": " + result);
            
            if (result == Result.FAILURE)
            {
                running = 0;
                return result;
            }
            else if (result == Result.RUNNING)
            {
                running = i;
                return result;
            }
        }

        running = 0;
        return Result.SUCCESS;
    }

    public List<Node<Context>> GetChildren() => children;
}
