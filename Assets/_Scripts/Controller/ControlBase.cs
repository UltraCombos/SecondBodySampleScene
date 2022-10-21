using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBase : MonoBehaviour
{
    protected GameObject dancer;

    public void SetTargetVector(GameObject obj)
    {
        dancer = obj;
    }

}
