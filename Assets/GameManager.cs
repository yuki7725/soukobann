using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //配列の表示
    int[] map;
    // Start is called before the first frame update
    void Start()
    {   
        map = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0 };

        //追加、文字列の宣言と初期化
        string debugText = "";

        for (int i = 0; i < map.Length; i++)
        {
            //文字列に結合していく
            debugText+= map[i].ToString()+",";
        }
        //結合した文字列を出力
        Debug.Log(debugText);
    }

    // Update is called once per frame
    void Update()
    {
        //→キーで右に一つ移動
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //見つからなかった時のために-1で初期化
            int playerIndex = -1;
            //要素数は map.Lengthで取得
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            } 
            if (playerIndex < map.Length - 1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
            }

            string debugText = "";
            for(int i = 0; i < map.Length; i++)
            {
                 debugText += map[i].ToString() + ",";
            }
            Debug.Log(debugText);

        }
        //←キーで左に一つ移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //見つからなかった時のために-1で初期化
            int playerIndex = -1;
            //要素数は map.Lengthで取得
            for (int i = 0; i < map.Length; i++)
            {
                if (map[i] == 1)
                {
                    playerIndex = i;
                    break;
                }
            }
            if (playerIndex < map.Length - 1)
            {
                map[playerIndex - 1] = 1;
                map[playerIndex] = 0;
            }

            string debugText = "";
            for (int i = 0; i < map.Length; i++)
            {
                debugText += map[i].ToString() + ",";
            }
            Debug.Log(debugText);

        }
    }
}
