using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[,] stones;
    private int count;
    private bool isPut;

    public enum TurnState { Black, White} //�ǂ����̃^�[����
    public TurnState turnState;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        isPut = false;
        stones = new GameObject[8,8];//8�~8�̃I�u�W�F�N�g�z��쐬
        turnState = TurnState.Black; //�ŏ��͍��̃^�[��

        //�z��Ɋe�΂����Ă���
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

        //�ŏ��̔Ֆʂ���������
        //��
        stones[3, 3].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
        stones[3, 3].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
        stones[4, 4].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
        stones[4, 4].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
        //��
        stones[3, 4].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 255);
        stones[3, 4].GetComponent<StoneController>().colorState = StoneController.ColorState.Black;
        stones[4, 3].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 255);
        stones[4, 3].GetComponent<StoneController>().colorState = StoneController.ColorState.Black;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PutCheck(int X, int Y) //�u�����Ƃ��ł��邩�m�F
    {
        Debug.Log("X = " + X + "Y = " + Y);
        if (turnState == TurnState.Black) //���̃^�[��
        {
            //���Ɍ������Ċm�F
            for (int x = X - 1; x >= 0; x--)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //�������Ȃ�
                }
                else if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (x == X - 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂���E�Ɍ������ĐF��ς��Ă���
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
            //�E�Ɍ������Ċm�F
            for (int x = X + 1; x <= 8; x++)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //�������Ȃ�
                }
                else if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (x == X + 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂��獶�Ɍ������ĐF��ς��Ă���
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
            //��Ɍ������Ċm�F
            for (int y = Y - 1; y >= 0; y--)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //�������Ȃ�
                }
                else if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (y == Y - 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂��牺�Ɍ������ĐF��ς��Ă���
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
            //���Ɍ������Ċm�F
            for (int y = Y + 1; y <= 8; y++)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //�������Ȃ�
                }
                else if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (y == Y + 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂����Ɍ������ĐF��ς��Ă���
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
            //�E��Ɍ������Ċm�F
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X + Count > 8 ||  Y - Count < 0)
                {
                    break;
                }
                else if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //�������Ȃ�
                }
                else if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂���E��Ɍ������ĐF��ς��Ă���
                        stones[X + Count, Y - Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //�E���Ɍ������Ċm�F
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X + Count > 8 || Y + Count > 8)
                {
                    break;
                }
                else if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //�������Ȃ�
                }
                else if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂���E��Ɍ������ĐF��ς��Ă���
                        stones[X + Count, Y + Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //����Ɍ������Ċm�F
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X - Count < 0 || Y - Count < 0)
                {
                    break;
                }
                else if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //�������Ȃ�
                }
                else if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂���E��Ɍ������ĐF��ς��Ă���
                        stones[X - Count, Y - Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //�����Ɍ������Ċm�F
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X - Count < 0 || Y + Count > 8)
                {
                    break;
                }
                else if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //�������Ȃ�
                }
                else if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂���E��Ɍ������ĐF��ς��Ă���
                        stones[X - Count, Y + Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
        }
        else //���̃^�[��
        {
            //���Ɍ������Ċm�F
            for (int x = X - 1; x >= 0; x--)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //�������Ȃ�
                }
                else if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (x == X - 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂���E�Ɍ������ĐF��ς��Ă���
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
            //�E�Ɍ������Ċm�F
            for (int x = X + 1; x <= 8; x++)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //�������Ȃ�
                }
                else if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (x == X + 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂��獶�Ɍ������ĐF��ς��Ă���
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
            //��Ɍ������Ċm�F
            for (int y = Y - 1; y >= 0; y--)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //�������Ȃ�
                }
                else if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (y == Y - 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂��牺�Ɍ������ĐF��ς��Ă���
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
            //���Ɍ������Ċm�F
            for (int y = Y + 1; y <= 8; y++)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //�������Ȃ�
                }
                else if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (y == Y + 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂����Ɍ������ĐF��ς��Ă���
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
            //�E��Ɍ������Ċm�F
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X + Count > 8 || Y - Count < 0)
                {
                    break;
                }
                else if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //�������Ȃ�
                }
                else if (stones[X + Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂���E��Ɍ������ĐF��ς��Ă���
                        stones[X + Count, Y - Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //�E���Ɍ������Ċm�F
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X + Count > 8 || Y + Count > 8)
                {
                    break;
                }
                else if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //�������Ȃ�
                }
                else if (stones[X + Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂���E��Ɍ������ĐF��ς��Ă���
                        stones[X + Count, Y + Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //����Ɍ������Ċm�F
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X - Count < 0 || Y - Count < 0)
                {
                    break;
                }
                else if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //�������Ȃ�
                }
                else if (stones[X - Count, Y - Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂���E��Ɍ������ĐF��ς��Ă���
                        stones[X - Count, Y - Count].GetComponent<StoneController>().isRotation = true;
                    }
                }
                else
                {
                    break;
                }
            }
            //�����Ɍ������Ċm�F
            for (int Count = 1; Count <= 8; Count++)
            {
                if (X - Count < 0 || Y + Count > 8)
                {
                    break;
                }
                else if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //�������Ȃ�
                }
                else if (stones[X - Count, Y + Count].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    if (Count == 1)
                    {
                        break;
                    }
                    else
                    {
                        //���̐΂���E��Ɍ������ĐF��ς��Ă���
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
                //��
                stones[X, Y].GetComponent<Renderer>().material.color = new Color(0, 0, 0, 255);
                stones[X, Y].GetComponent<StoneController>().colorState = StoneController.ColorState.Black;
                turnState = TurnState.White;
                isPut = false;
                Debug.Log("���̃^�[���ɕς��");
            }
            else
            {
                //��
                stones[X, Y].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
                stones[X, Y].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
                turnState = TurnState.Black;
                isPut = false;
                Debug.Log("���̃^�[���ɕς��");
            }
        }
    }
}
