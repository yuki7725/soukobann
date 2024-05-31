using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

/// <summary>
/// 
/// </summary>
//public class GameManager : MonoBehaviour
//{
    ////配列の表示
    //int[,] map;
    // Start is called before the first frame update

    //クラスの中、メゾットの外に置く
    //返り値の値に注意
    //void PrintArray()
    //{
    //    string debugText = "";
    //    for(int i=0;i<map.Length;i++)
    //    {
    //        debugText += map[i].ToString() + ",";
    //    }
    //    Debug.Log(debugText);
    //}

    //クラスの中、メゾットの外に置く
    //返り値の値に注意
    //bool MoveNumber(int number,int moveFrom,int moveTo)
    //{
    //    if (moveTo < 0 || moveTo >= map.Length)
    //    {
    //        //動けない条件を先に置き、リターンする、早期リターン
    //        return false;
    //    }
    //    //どの方向へ移動するか
    //        int velocity = moveTo - moveFrom;
    //        //プレイヤーの移動先から2個分移動させる
    //       // new Vector3(moveTo, -1 * moveTo, 0);

    //    bool success = MoveNumber(2, moveTo, moveTo + velocity);
    //    //移動が失敗したらプレイヤーも移動しない
    //    if (!success ) 
    //    {
    //        return false;
    //    }

    //    if (map[moveTo] == 2)
    //    {
    //        int offset =moveTo - moveFrom;
    //    }

    //    map[moveTo] = number;
    //    map[moveFrom] = 0;
    //    return true;
    //}
    //int GetPlayerIndex()
    //{
    //    for(int i=0; i<map.Length ; i++)
    //    {
    //        if (map[i] == 1)
    //        {
    //            return i;
    //        }
    //     }
    //    return -1;
    //}

    //void Start()
    //{
    //    map = new int[,] { 
    //        { 0, 0, 0, 0, 0 },
    //        { 0, 0, 1, 0, 0 },
    //        { 0, 0, 0, 0, 0 },
    //    };

    //    string debugText = "";
    //    //変更、二重for文で二次元配列の情報を出力
    //    for(int y=0; y < map.GetLength(0); y++)
    //    {
    //        for(int x=0; x < map.GetLength(1); x++)
    //        {
    //            debugText += map[y, x].ToString() + ",";
    //        }
    //        debugText += "\n";//改行
    //    }
    //   Debug.Log(debugText);
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    //右移動
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        //メソッド化した処理を使用
    //        int playerIndex= GetPlayerIndex();

    //        if (playerIndex < map.Length - 1)
    //        {
    //            if (map[playerIndex + 1] == 2)
    //            {
    //                map[playerIndex + 2] = 2;
    //            }
    //            map[playerIndex + 1] = 1;
    //            map[playerIndex] = 0;
    //        }

    //        //移動処理を関数化
    //        MoveNumber(1, playerIndex, playerIndex + 1);
    //        PrintArray();

    //    }

    //    //左移動
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        //メソッド化した処理を使用
    //        int playerIndex = GetPlayerIndex();

    //        if (playerIndex < map.Length - 1)
    //        {
    //            if (map[playerIndex - 1] == 2)
    //            {
    //                map[playerIndex - 2] = 2;
    //            }
    //            map[playerIndex - 1] = 1;
    //            map[playerIndex] = 0;
    //        }

    //        //移動処理を関数化
    //        MoveNumber(1, playerIndex, playerIndex - 1);
    //        PrintArray();

    //    }
    //}
//}

public class GameManagerScript : MonoBehaviour
{
    //追加
    public GameObject playerPrefab;
    int[,] map;//レベルデザイン用の配列
    GameObject[,] field;//ゲーム管理用の配列

    bool MoveNumber(Vector2Int moveFrom,Vector2Int moveTo)
    {
        //二次元配列に対応
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; };
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(2)) { return false; };
        ////箱のプレハブをまだ作っていないので動かす処理はコメントアウト
        //if (map[moveTo] == 2) 
        //{
        //    int velocity = moveTo - moveFrom;
        //    bool success = MoveNumber(2, moveTo, moveTo + velocity);
        //    if (!success) {return false; }
        //}
        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);
        field[moveTo.y, moveTo.x] = field[moveFrom.y, moveFrom.x];
        field[moveFrom.y,moveFrom.x] = null;

        return true;
    }

    Vector2Int GetPlayerIndex()
    {
        for (int y = 0; y < field.GetLength(0); y++)
        {
            for (int x = 0; x < field.GetLength(1); x++)
            {
                //nullだったらタグを調べず次の要素へ移る
                if (field[y, x] == null) {
                    continue;
                }
                //nullだったら continueしているのでタグの確認
                if (field[y,x].tag=="Player")
                {
                    return new Vector2Int(x, y);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }

    void Start()
    {
        //確認出来たら削除
       // GameObject instance = Instantiate( playerPrefab,new Vector3(0, 0, 0), Quaternion.identity);

        map = new int[,] {
            { 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0 },
        };
        string debugText = "";

        field = new GameObject
            [
            map.GetLength(0),
            map.GetLength(1)
            ];

        //変更、二重for文で二次元配列の情報を出力
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                if (map[y, x] == 1)
                {
                    //GameObject instance=Instantiate(playerPrefab,new Vector3(x,map.GetLength(0)-y,0),Quaternion.identity);
                    field[y, x] = Instantiate(playerPrefab, new Vector3(x, map.GetLength(0) - y, 0), Quaternion.identity);
                }
                debugText += map[y, x].ToString() + ",";
            }
            debugText += "\n";//改行
        }
        Debug.Log(debugText);
    }
    void Update()
    {
        //右移動
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //メソッド化した処理を使用
            Vector2Int playerIndex = GetPlayerIndex();
            MoveNumber(
                playerIndex,
                playerIndex + new Vector2Int(1, 0));
        }

        //左移動
       
    }
}

