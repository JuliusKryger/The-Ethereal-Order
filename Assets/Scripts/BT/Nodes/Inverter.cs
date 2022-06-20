using System.Collections;
using System.Collections.Generic;

public class Inverter<Context> : Node<Context>
{
    private List<Node<Context>> children = null;

    private int running = 0;

    public Inverter(List<Node<Context>> children) => this.children = children;

    public Result Run(Context context) {

        for (int i = running; i < children.Count; i++) 
        {
            Node<Context> child = children[i];
            Result result = child.Run(context);
        
            if (result == Result.RUNNING) 
            {
                running = i;
                return result;
            }
        
            if (result == Result.SUCCESS) 
            {
                running = 0;
                return Result.FAILURE;
            }
        }

        running = 0;
        return Result.SUCCESS;
    }

    public List<Node<Context>> GetChildren() => children;
}
