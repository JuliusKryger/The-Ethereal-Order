using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Node<Context>
{
    Result Run(Context context);
    List<Node<Context>> GetChildren();
}
