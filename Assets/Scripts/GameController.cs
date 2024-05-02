using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[,] stones;
    private int count;

    public enum TurnState { Black, White} //�ǂ����̃^�[����
    public TurnState turnState;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
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
            }
        }

        //�ŏ��̔Ֆʂ���������
        //��
        stones[3, 3].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
        stones[3, 3].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
        stones[4, 4].GetComponent<Renderer>().material.color = new Color(255, 255, 255, 255);
        stones[3, 4].GetComponent<StoneController>().colorState = StoneController.ColorState.White;
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

    private void PutCheck(int X, int Y) //�u�����Ƃ��ł��邩�m�F
    {
        if (turnState == TurnState.Black) //���̃^�[��
        {
            //���̐΂�T��
            //��
            for (int x = 0; x < 8; x++)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //�Ԃ����ׂĔ��Ȃ�
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
                                //�F��ς���
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
                                //�F��ς���
                            }
                        }
                    }
                }
            }
            //�c
            for (int y = 0; y < 8; y++)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.Black)
                {
                    //�Ԃ����ׂĔ��Ȃ�
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
                                //�F��ς���
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
                                //�F��ς���
                            }
                        }
                    }
                }
            }
            //��������E��
        }
        else //���̃^�[��
        {
            //���̐΂�T��
            //��
            for (int x = 0; x < 8; x++)
            {
                if (stones[x, Y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //�Ԃ����ׂč��Ȃ�
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
                                //�F��ς���
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
                                //�F��ς���
                            }
                        }
                    }
                }
            }
            //�c
            for (int y = 0; y < 8; y++)
            {
                if (stones[X, y].GetComponent<StoneController>().colorState == StoneController.ColorState.White)
                {
                    //�Ԃ����ׂč��Ȃ�
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
                                //�F��ς���
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
                                //�F��ς���
                            }
                        }
                    }
                }
            }
            //��������E��
        }
    }
}
