using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private GameObject[,] stones;
    // Start is called before the first frame update
    void Start()
    {
        stones = new GameObject[8,8];//8×8のオブジェクト配列作成
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PutStone()
    {

    }
}
