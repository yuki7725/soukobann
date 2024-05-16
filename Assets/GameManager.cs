using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameManager : MonoBehaviour
{
    //配列の表示
    int[] map;
    // Start is called before the first frame update

    //クラスの中、メゾットの外に置く
    //返り値の値に注意
    void PrintArray()
    {
        string debugText = "";
        for(int i=0;i<map.Length;i++)
        {
            debugText += map[i].ToString()+",";
        }
        Debug.Log(debugText);
    }

    //クラスの中、メゾットの外に置く
    //返り値の値に注意
    bool MoveNumber(int number,int moveFrom,int moveTo)
    {
        if (moveTo < 0 || moveTo >= map.Length)
        {
            //動けない条件を先に置き、リターンする、早期リターン
            return false;
        }
        if (map[moveTo] == 2)
        { 
        //どの方向へ移動するか
        int velocity = moveTo - moveFrom;
        //プレイヤーの移動先から2個分移動させる
        bool success = MoveNumber(2, moveTo, moveTo + velocity);
        //移動が失敗したらプレイヤーも移動しない
            if (!success ) 
            {
                return false;
            } 
        }
        map[moveTo] = number;
        map[moveFrom] = 0;
        return true;
    }
    int GetPlayerIndex()
    {
        for(int i=0; i<map.Length ; i++)
        {
            if (map[i] == 1)
            {
                return i;
            }
         }
        return -1;
    }

    void Start()
    {   
        map = new int[] { 0, 0, 0, 1, 0, 2, 0, 0, 0 };
        PrintArray();
       
    }

    // Update is called once per frame
    void Update()
    {
        //右移動
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //メソッド化した処理を使用
            int playerIndex= GetPlayerIndex();

            if (playerIndex < map.Length - 1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
            }

            //移動処理を関数化
            MoveNumber(1, playerIndex, playerIndex + 1);
            PrintArray();

        }

        //左移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //メソッド化した処理を使用
            int playerIndex = GetPlayerIndex();

            if (playerIndex < map.Length - 1)
            {
                map[playerIndex - 1] = 1;
                map[playerIndex] = 0;
            }

            //移動処理を関数化
            MoveNumber(1, playerIndex, playerIndex - 1);
            PrintArray();

        }
    }
}
