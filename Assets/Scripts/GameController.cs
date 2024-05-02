using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[,] stones;
    private int count;

    public enum TurnState { Black, White} //どっちのターンか
    public TurnState turnState;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
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
            }
        }

        //最初の盤面を準備する
        //白
        stones[3, 3].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
        stones[3, 3].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
        stones[4, 4].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
        stones[3, 4].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
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

    private void PutCheck(int X, int Y) //置くことができるか確認
    {
        if (turnState == TurnState.Black) //黒のターン
        {
            //黒の石を探す
            //横
            for (int x = 0; x < 8; x++)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //間がすべて白なら
                    if (x < X)
                    {
                        for (int i = x+1; i < X; i++)
                        {
                            if (stones[i, Y].GetComponent<StoneController>().colorState != StoneController.ColorState.White)
                            {
                                break;
                            }
                            if (i == X - 1)
                            {
                                //色を変える
                            }
                        }
                    }
                    else
                    {
                        for (int i = X + 1; i < x; i++)
                        {
                            if (stones[i, Y].GetComponent<StoneController>().colorState != StoneController.ColorState.White)
                            {
                                break;
                            }
                            if (i == x - 1)
                            {
                                //色を変える
                            }
                        }
                    }
                }
            }
            //縦
            for (int y = 0; y < 8; y++)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //間がすべて白なら
                    if (y < Y)
                    {
                        for (int i = y + 1; i < Y; i++)
                        {
                            if (stones[X, i].GetComponent<StoneController>().colorState != StoneController.ColorState.White)
                            {
                                break;
                            }
                            if (i == Y - 1)
                            {
                                //色を変える
                            }
                        }
                    }
                    else
                    {
                        for (int i = Y + 1; i < y; i++)
                        {
                            if (stones[X, i].GetComponent<StoneController>().colorState != StoneController.ColorState.White)
                            {
                                break;
                            }
                            if (i == y - 1)
                            {
                                //色を変える
                            }
                        }
                    }
                }
            }
            //左下から右上
        }
        else //白のターン
        {
            //白の石を探す
            //横
            for (int x = 0; x < 8; x++)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //間がすべて黒なら
                    if (x < X)
                    {
                        for (int i = x + 1; i < X; i++)
                        {
                            if (stones[i, Y].GetComponent<StoneController>().colorState != StoneController.ColorState.Black)
                            {
                                break;
                            }
                            if (i == X - 1)
                            {
                                //色を変える
                            }
                        }
                    }
                    else
                    {
                        for (int i = X + 1; i < x; i++)
                        {
                            if (stones[i, Y].GetComponent<StoneController>().colorState != StoneController.ColorState.Black)
                            {
                                break;
                            }
                            if (i == x - 1)
                            {
                                //色を変える
                            }
                        }
                    }
                }
            }
            //縦
            for (int y = 0; y < 8; y++)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //間がすべて黒なら
                    if (y < Y)
                    {
                        for (int i = y + 1; i < Y; i++)
                        {
                            if (stones[X, i].GetComponent<StoneController>().colorState != StoneController.ColorState.Black)
                            {
                                break;
                            }
                            if (i == Y - 1)
                            {
                                //色を変える
                            }
                        }
                    }
                    else
                    {
                        for (int i = Y + 1; i < y; i++)
                        {
                            if (stones[X, i].GetComponent<StoneController>().colorState != StoneController.ColorState.Black)
                            {
                                break;
                            }
                            if (i == y - 1)
                            {
                                //色を変える
                            }
                        }
                    }
                }
            }
            //左下から右上
        }
    }
}
