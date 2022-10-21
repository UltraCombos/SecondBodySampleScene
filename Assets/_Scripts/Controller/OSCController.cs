using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class OSCController : ControlBase
{

    public void SetDancerPos(Vector2 v2)
    {
        dancer.transform.position = v2;
    }

}
