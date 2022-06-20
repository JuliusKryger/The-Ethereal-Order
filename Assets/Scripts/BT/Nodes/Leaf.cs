using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Leaf<Context> : Node<Context>
{
    public virtual Result Run(Context context) => Result.RUNNING;
    public virtual List<Node<Context>> GetChildren() => null;
}
