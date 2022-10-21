using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Unity.Mathematics;

public class MouseController : ControlBase
{
    public RawImage cameraView;

    private float textureWidth;

    private void Start()
    {
        textureWidth = cameraView.texture.width;
        //Debug.Log($"Texture Width : {textureWidth}");
    }

    private void FixedUpdate()
    {
        if (dancer == null)
            return;


        if (Input.GetMouseButton(0))
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            Vector2 screenRes = new Vector2(Screen.width, Screen.height);

            mousePos = RemapMousePos(mousePos);

            dancer.transform.position = mousePos;

            //mousePos *= (textureWidth / cameraView.rectTransform.sizeDelta.x);
        }
    }

    private Vector2 RemapMousePos(Vector2 mousPos)
    {
        float center = Screen.width / 2;

        float xMin = center - (Screen.height / 2);
        float xMax = center + (Screen.height / 2);

        float newPosX;
        float newPosY;

        newPosX = math.remap(xMin, xMax, 0, 1, mousPos.x);
        newPosX = Mathf.Clamp(newPosX, 0, 1);

        newPosY = math.remap(0, Screen.height, 0, 1, mousPos.y);
        newPosY = Mathf.Clamp(newPosY, 0, 1);

        return new Vector2(newPosX, newPosY);
    }
}
