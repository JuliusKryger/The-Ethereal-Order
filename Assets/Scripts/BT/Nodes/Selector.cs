using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector<Context> : Node<Context>
{
    private List<Node<Context>> children = null;

    private int running = 0; 

    public Selector(List<Node<Context>> children) => this.children = children;

    public Result Run(Context context) 
    {
        for (int i = running; i < children.Count; i++) 
        {
            Node<Context> child = children[i];
            Result result = child.Run(context);
            Debug.Log(child + ": " + result);

            if (result == Result.RUNNING) 
            {
                running = i;
                return result;
            }

            if (result == Result.SUCCESS) 
            {
                running = 0;
                return result;
            }
        }

        running = 0; 
        return Result.FAILURE;
    }

    public List<Node<Context>> GetChildren() => children;
}
