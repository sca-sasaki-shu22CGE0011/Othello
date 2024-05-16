using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] private Text turnText;
    [SerializeField] private Text blackStoneText;
    [SerializeField] private Text whiteStoneText;
    private GameObject[,] stones;
    private int count;
    private int blackStones;
    private int whiteStones;
    private int passCount;
    private bool isPut;

    public enum TurnState { Black, White} //どっちのターンか
    public TurnState turnState;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        blackStones = 2;
        whiteStones = 2;
        passCount = 0;
        isPut = false;
        stones = new GameObject[8,8];//8×8のオブジェクト配列作成
        turnState = TurnState.Black; //最初は黒のターン
        TurnText();

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
                if (x > 7)
                {
                    break;
                }
                if (X == 0)
                {
                    break;
                }
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                    if (x == 0)
                    {
                        break;
                    }
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
                            blackStones++;
                            whiteStones--;
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
                if (x < 0)
                {
                    break;
                }
                if (X == 7)
                {
                    break;
                }
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                    if (x == 7)
                    {
                        break;
                    }
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
                            blackStones++;
                            whiteStones--;
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
                if (y < 0)
                {
                    break;
                }
                if (Y == 0)
                {
                    break;
                }
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                    if (y == 0)
                    {
                        break;
                    }
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
                        for (int turn = y + 1; turn < Y; turn++)
                        {
                            stones[X, turn].GetComponent<StoneController>().isRotation = true;
                            blackStones++;
                            whiteStones--;
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
                if (y > 7)
                {
                    break;
                }
                if (Y == 7)
                {
                    break;
                }
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                    if (y == 7)
                    {
                        break;
                    }
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
                            blackStones++;
                            whiteStones--;
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
                if (X == 7 || Y == 0)
                {
                    break;
                }
                if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                    if (X + Count == 7 || Y - Count == 0)
                    {
                        break;
                    }
                }
                else if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //置いた石から右上に向かって色を変えていく
                        for (int turn = 1; turn < Count; turn++)
                        {
                            stones[X+turn,Y-turn].GetComponent<StoneController>().isRotation = true;
                            blackStones++;
                            whiteStones--;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }

                //盤面外に出そうになったら抜ける
                if (X + Count > 7 || Y - Count < 1)
                {
                    break;
                }
            }
            //右下に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X == 7 || Y == 7)
                {
                    break;
                }
                if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                    if (X + Count == 7 || Y + Count == 7)
                    {
                        break;
                    }
                }
                else if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //置いた石から右上に向かって色を変えていく
                        for (int turn = 1; turn < Count; turn++)
                        {
                            stones[X + turn, Y + turn].GetComponent<StoneController>().isRotation = true;
                            blackStones++;
                            whiteStones--;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }

                //盤面外に出そうになったら抜ける
                if (X + Count > 7 || Y + Count > 7)
                {
                    break;
                }
            }
            //左上に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X == 0 || Y == 0)
                {
                    break;
                }
                if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                    if (X - Count == 0 || Y - Count == 0)
                    {
                        break;
                    }
                }
                else if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //置いた石から左上に向かって色を変えていく
                        for (int turn = 1; turn < Count; turn++)
                        {
                            stones[X - turn, Y - turn].GetComponent<StoneController>().isRotation = true;
                            blackStones++;
                            whiteStones--;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }

                //盤面外に出そうになったら抜ける
                if (X - Count < 1 || Y - Count < 1)
                {
                    break;
                }
            }
            //左下に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X == 0 || Y == 7)
                {
                    Debug.Log("1");
                    break;
                }
                if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //何もしない
                    if (X - Count == 0 || Y + Count == 7)
                    {
                        Debug.Log("2");
                        break;
                    }
                }
                else if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        Debug.Log("3");
                        break;
                    }
                    else
                    {
                        //置いた石から左下に向かって色を変えていく
                        for (int turn = 1; turn < Count; turn++)
                        {
                            stones[X - turn, Y + turn].GetComponent<StoneController>().isRotation = true;
                            blackStones++;
                            whiteStones--;
                        }
                        Debug.Log("4");
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    Debug.Log("5");
                    break;
                }

                //盤面外に出そうになったら抜ける
                if (X - Count < 1 || Y + Count > 7)
                {
                    Debug.Log("6");
                    break;
                }
            }
        }
        else //白のターン
        {
            //左に向かって確認
            for (int x = X - 1; x >= 0; x--)
            {
                if (x < 0)
                {
                    break;
                }
                if (X == 0)
                {
                    break;
                }
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                    if (x == 0)
                    {
                        break;
                    }
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
                            whiteStones++;
                            blackStones--;
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
                if (x > 7)
                {
                    break;
                }
                if (X == 7)
                {
                    break;
                }
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                    if (x == 7)
                    {
                        break;
                    }
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
                            whiteStones++;
                            blackStones--;
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
                if (y < 0)
                {
                    break;
                }
                if (Y == 0)
                {
                    break;
                }
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                    if (y == 0)
                    {
                        break;
                    }
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
                            whiteStones++;
                            blackStones--;
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
                if (y > 7)
                {
                    break;
                }
                if (Y == 7)
                {
                    break;
                }
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                    if (y == 7)
                    {
                        break;
                    }
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
                            whiteStones++;
                            blackStones--;
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
                if (X == 7 || Y == 0)
                {
                    break;
                }
                if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                    if (X + Count == 7 || Y - Count == 0)
                    {
                        break;
                    }
                }
                else if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //置いた石から右上に向かって色を変えていく
                        for (int turn = 1; turn < Count; turn++)
                        {
                            stones[X + turn, Y - turn].GetComponent<StoneController>().isRotation = true;
                            whiteStones++;
                            blackStones--;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }

                //盤面外に出そうになったら抜ける
                if (X + Count > 7 || Y - Count < 1)
                {
                    break;
                }
            }
            //右下に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X == 7 || Y == 7)
                {
                    break;
                }
                if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                    if (X + Count == 7 || Y + Count == 7)
                    {
                        break;
                    }
                }
                else if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //置いた石から右上に向かって色を変えていく
                        for (int turn = 1; turn < Count; turn++)
                        {
                            stones[X + turn, Y + turn].GetComponent<StoneController>().isRotation = true;
                            whiteStones++;
                            blackStones--;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }

                //盤面外に出そうになったら抜ける
                if (X + Count > 7 || Y + Count > 7)
                {
                    break;
                }
            }
            //左上に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X == 0 || Y == 0)
                {
                    break;
                }
                if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                    if (X - Count == 0 || Y - Count == 0)
                    {
                        break;
                    }
                }
                else if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //置いた石から左上に向かって色を変えていく
                        for (int turn = 1; turn < Count; turn++)
                        {
                            stones[X - turn, Y - turn].GetComponent<StoneController>().isRotation = true;
                            whiteStones++;
                            blackStones--;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }

                //盤面外に出そうになったら抜ける
                if (X - Count < 1 || Y - Count < 1)
                {
                    break;
                }
            }
            //左下に向かって確認
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X == 0 || Y == 7)
                {
                    break;
                }
                if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //何もしない
                    if (X - Count == 0 || Y + Count == 7)
                    {
                        break;
                    }
                }
                else if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //置いた石から左下に向かって色を変えていく
                        for (int turn = 1; turn < Count; turn++)
                        {
                            stones[X - turn, Y + turn].GetComponent<StoneController>().isRotation = true;
                            whiteStones++;
                            blackStones--;
                        }
                        isPut = true;
                        break;
                    }
                }
                else
                {
                    break;
                }

                //盤面外に出そうになったら抜ける
                if (X - Count < 1 || Y + Count > 7)
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
                blackStones++;
                blackStoneText.text = "" + blackStones;
                whiteStoneText.text = "" + whiteStones;
                Debug.Log("白のターンに変わる");
                TurnText();
            }
            else
            {
                //黒
                stones[X, Y].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
                stones[X, Y].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
                turnState = TurnState.Black;
                isPut = false;
                whiteStones++;
                blackStoneText.text = "" + blackStones;
                whiteStoneText.text = "" + whiteStones;
                Debug.Log("黒のターンに変わる");
                TurnText();
            }
            passCount = 0;
            if (blackStones + whiteStones >= 64)
            {
                GameOver();
            }
        }
    }

    private void TurnText()
    {
        if (turnState == TurnState.Black)
        {
            turnText.text = "黒のターン";
        }
        else
        {
            turnText.text = "白のターン";
        }
    }

    public void PassButton()
    {
        if (turnState == TurnState.Black)
        {
            turnState = TurnState.White;
            TurnText();
        }
        else
        {
            turnState = TurnState.Black;
            TurnText();
        }
        passCount++;
        if (passCount >= 2)
        {
            GameOver();
        }
    }

    public void RetryButton()
    {
        blackStones = 2;
        whiteStones = 2;
        blackStoneText.text = "" + blackStones;
        whiteStoneText.text = "" + whiteStones;
        passCount = 0;
        isPut = false;
        turnState = TurnState.Black; //最初は黒のターン
        TurnText();

        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                stones[x, y].GetComponent<CircleCollider2D>().enabled = true;
                stones[x, y].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 0);
                stones[x, y].GetComponent<StoneController>().colorState = StoneController.ColorState.None;
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

    private void GameOver()
    {
        if (blackStones > whiteStones)
        {
            turnText.text = "黒の勝ち！";
        }
        else if (whiteStones > blackStones)
        {
            turnText.text = "白の勝ち！";
        }
        else
        {
            turnText.text = "引き分け";
        }


        //石を操作できなくする
        for (int x = 0; x < 8; x++)
        {
            for (int y = 0; y < 8; y++)
            {
                stones[x, y].GetComponent<CircleCollider2D>().enabled = false;
            }
        }
    }
}
