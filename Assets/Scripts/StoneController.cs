using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    RectTransform rectTransform;
    Renderer renderer;

    private bool isRotation;
    private bool isColorChange;
    private float rotationSpeed;
    private float rotationTime;
    private float rotationCount;

    public enum ColorState { None, CanPut, Black, White}
    public ColorState colorState;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        renderer = GetComponent<Renderer>();
        isRotation = false;
        isColorChange = false;
        rotationSpeed = 180.0f;
        rotationCount = 0;
        rotationTime = 180.0f / rotationSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //isRotation = true;//‰¼

        if (isRotation)
        {
            rectTransform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            rotationCount += Time.deltaTime;
            if (rotationTime/2 < rotationCount) //‚Ð‚Á‚­‚è•Ô‚é‚Æ‚«‚Ìˆ—
            {
                if (!isColorChange)
                {
                    isColorChange = true;
                    if (colorState == ColorState.Black)
                    {
                        renderer.material.color = new Color(255, 255, 255);//”’F‚É‚·‚é
                        colorState = ColorState.White;
                    }
                    else
                    {
                        renderer.material.color = new Color(0, 0, 0);//•F‚É‚·‚é
                        colorState = ColorState.Black;
                    }
                }
            }

            if (rotationTime <= rotationCount) //180“x‰ñ‚Á‚½‚ç
            {
                isRotation = false;//rotation‚ðŽ~‚ß‚é
                isColorChange = false;
                rotationCount = 0.0f;
            }
        }
    }
}
