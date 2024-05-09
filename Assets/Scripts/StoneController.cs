using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneController : MonoBehaviour
{
    RectTransform rectTransform;
    Renderer renderer;

    public int number;
    public bool isRotation;
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
        //isRotation = true;//仮

        if (isRotation)
        {
            rectTransform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
            rotationCount += Time.deltaTime;
            if (rotationTime/2 < rotationCount) //ひっくり返るときの処理
            {
                if (!isColorChange)
                {
                    isColorChange = true;
                    if (colorState == ColorState.Black)
                    {
                        renderer.material.color = new Color(255, 255, 255);//白色にする
                        colorState = ColorState.White;
                    }
                    else
                    {
                        renderer.material.color = new Color(0, 0, 0);//黒色にする
                        colorState = ColorState.Black;
                    }
                }
            }

            if (rotationTime <= rotationCount) //180度回ったら
            {
                isRotation = false;//rotationを止める
                isColorChange = false;
                rotationCount = 0.0f;
            }
        }
    }

    public void OnTouch()
    {
        int Y = 0;
        int X = 0;
        number = number - 1;
        if (number <= 8)
        {
            Y = number;
        }
        else
        {
            X = number / 8;
            Y = (number - (8 * X)) % 8;
        }
        FindObjectOfType<GameController>().PutCheck(X,Y);
    }
}
