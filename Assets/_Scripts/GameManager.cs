using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Unity.Mathematics;

public enum controlMode
{
    Mouse,
    OSC
}

public class GameManager : MonoBehaviour
{
    public controlMode currentControlMode = controlMode.Mouse;
    public List<ControlBase> controllers = new List<ControlBase>();

    public GameObject controlPosObj;
    public GameObject dancer;

    private Vector2 floorPosRange = new Vector2(-5.5f, 5.5f);
    private controlMode lastControlMode;

    private void Start()
    {
        SetController();
    }

    private void Update()
    {
        UpdateDancerPos();

        if (currentControlMode != lastControlMode)
        {
            SetController();
        }
        lastControlMode = currentControlMode;
    }

    private void UpdateDancerPos()
    {
        Vector3 dancerPos = new Vector3();
        dancerPos.x = math.remap(0, 1, floorPosRange.x, floorPosRange.y, controlPosObj.transform.position.x);
        dancerPos.z = math.remap(0, 1, floorPosRange.x, floorPosRange.y, controlPosObj.transform.position.y);

        UpdateDancerPosToCloth(dancerPos);
    }

    private void UpdateDancerPosToCloth(Vector3 dancerPos)
    {
        float rate = Mathf.Min(1, Time.deltaTime / 0.05f);

        Vector3 obiPos = dancer.transform.parent.transform.position;
        dancerPos += obiPos;

        dancer.transform.position = Vector3.Lerp(dancer.transform.position, dancerPos, rate);
    }

    private void SetController()
    {
        foreach(var controller in controllers)
        {
            controller.SetTargetVector(null);
        }
        controllers[(int)currentControlMode].SetTargetVector(controlPosObj);
    }

}
