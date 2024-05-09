using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[,] stones;
    private int count;
    private bool isPut;

    public enum TurnState { Black, White} //どっちのターンか
    public TurnState turnState;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        isPut = false;
        stones = new GameObject[8,8];//8×8のオブジェクト配列作成
        turnState = TurnState.Black; //最初は黒のターン

        //配列に各石を入れていく
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                count++;
                stones[x, y] = GameObject.Find("Stone (" + count.ToString() + ")");
                stones[x, y].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);
                stones[x, y].GetComponent<StoneController>().colorState = StoneController.ColorState.None;
                stones[x, y].GetComponent<StoneController>().number = count;
            }
        }

        //最初の盤面を準備する
        //白
        stones[3, 3].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
        stones[3, 3].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
        stones[4, 4].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
        stones[4, 4].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
        //黒
        stones[3, 4].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 255);
        stones[3, 4].GetComponent<StoneController>().colorState = StoneController.ColorState.Black;
        stones[4, 3].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 255);
        stones[4, 3].GetComponent<StoneController>().colorState = StoneController.ColorState.Black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutCheck(int X, int Y) //置くことができるか確認
    {
        Debug.Log("X = " + X + "Y = " + Y);
        if (turnState == TurnState.Black) //黒のターン
        {
            //左に向かって確認
            for (int x = X - 1; x >= 0; x--)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                }
                else if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (x == X - 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から右に向かって色を変えていく
                        for (int turn = x + 1; turn < X; turn++)
                        {
                            stones[turn, Y].GetComponent<StoneController>().isRotation = true;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //右に向かって確認
            for (int x = X + 1; x <= 8; x++)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                }
                else if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (x == X + 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から左に向かって色を変えていく
                        for (int turn = x - 1; turn > X; turn--)
                        {
                            stones[turn, Y].GetComponent<StoneController>().isRotation = true;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //上に向かって確認
            for (int y = Y - 1; y >= 0; y--)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                }
                else if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (y == Y - 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から下に向かって色を変えていく
                        for (int turn = y +1; turn > Y; turn++)
                        {
                            stones[X, turn].GetComponent<StoneController>().isRotation = true;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //下に向かって確認
            for (int y = Y + 1; y <= 8; y++)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                }
                else if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (y == Y + 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から上に向かって色を変えていく
                        for (int turn = y - 1; turn > Y; turn--)
                        {
                            stones[X, turn].GetComponent<StoneController>().isRotation = true;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //右上に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X + Count > 8 ||  Y - Count < 0)
                {
                    break;
                }
                else if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                }
                else if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から右上に向かって色を変えていく
                        stones[X + Count, Y - Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //右下に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X + Count > 8 || Y + Count > 8)
                {
                    break;
                }
                else if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                }
                else if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から右上に向かって色を変えていく
                        stones[X + Count, Y + Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //左上に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X - Count < 0 || Y - Count < 0)
                {
                    break;
                }
                else if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                }
                else if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から右上に向かって色を変えていく
                        stones[X - Count, Y - Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //左下に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X - Count < 0 || Y + Count > 8)
                {
                    break;
                }
                else if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                }
                else if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から右上に向かって色を変えていく
                        stones[X - Count, Y + Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        else //白のターン
        {
            //左に向かって確認
            for (int x = X - 1; x >= 0; x--)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                }
                else if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (x == X - 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から右に向かって色を変えていく
                        for(int turn = x + 1; turn < X; turn++)
                        {
                            stones[turn, Y].GetComponent<StoneController>().isRotation = true;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //右に向かって確認
            for (int x = X + 1; x <= 8; x++)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                }
                else if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (x == X + 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から左に向かって色を変えていく
                        for (int turn = x - 1; turn > X; turn--)
                        {
                            stones[turn, Y].GetComponent<StoneController>().isRotation = true;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //上に向かって確認
            for (int y = Y - 1; y >= 0; y--)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                }
                else if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (y == Y - 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から下に向かって色を変えていく
                        for (int turn = y + 1; turn < Y; turn++)
                        {
                            stones[X, turn].GetComponent<StoneController>().isRotation = true;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //下に向かって確認
            for (int y = Y + 1; y <= 8; y++)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                }
                else if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (y == Y + 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から上に向かって色を変えていく
                        for (int turn = y - 1; turn > Y; turn--)
                        {
                            stones[X, turn].GetComponent<StoneController>().isRotation = true;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
            //右上に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X + Count > 8 || Y - Count < 0)
                {
                    break;
                }
                else if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                }
                else if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から右上に向かって色を変えていく
                        stones[X + Count, Y - Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //右下に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X + Count > 8 || Y + Count > 8)
                {
                    break;
                }
                else if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                }
                else if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から右上に向かって色を変えていく
                        stones[X + Count, Y + Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //左上に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X - Count < 0 || Y - Count < 0)
                {
                    break;
                }
                else if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                }
                else if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から右上に向かって色を変えていく
                        stones[X - Count, Y - Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //左下に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X - Count < 0 || Y + Count > 8)
                {
                    break;
                }
                else if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                }
                else if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //この石から右上に向かって色を変えていく
                        stones[X - Count, Y + Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        if (isPut)
        {
            if (turnState == TurnState.Black)
            {
                //黒
                stones[X, Y].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 255);
                stones[X, Y].GetComponent<StoneController>().colorState = StoneController.ColorState.Black;
                turnState = TurnState.White;
                isPut = false;
                Debug.Log("白のターンに変わる");
            }
            else
            {
                //黒
                stones[X, Y].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
                stones[X, Y].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
                turnState = TurnState.Black;
                isPut = false;
                Debug.Log("黒のターンに変わる");
            }
        }
    }
}
