using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

/// <summary>
/// 
/// </summary>
//public class GameManager : MonoBehaviour
//{
    ////�z��̕\��
    //int[,] map;
    // Start is called before the first frame update

    //�N���X�̒��A���]�b�g�̊O�ɒu��
    //�Ԃ�l�̒l�ɒ���
    //void PrintArray()
    //{
    //    string debugText = "";
    //    for(int i=0;i<map.Length;i++)
    //    {
    //        debugText += map[i].ToString() + ",";
    //    }
    //    Debug.Log(debugText);
    //}

    //�N���X�̒��A���]�b�g�̊O�ɒu��
    //�Ԃ�l�̒l�ɒ���
    //bool MoveNumber(int number,int moveFrom,int moveTo)
    //{
    //    if (moveTo < 0 || moveTo >= map.Length)
    //    {
    //        //�����Ȃ��������ɒu���A���^�[������A�������^�[��
    //        return false;
    //    }
    //    //�ǂ̕����ֈړ����邩
    //        int velocity = moveTo - moveFrom;
    //        //�v���C���[�̈ړ��悩��2���ړ�������
    //       // new Vector3(moveTo, -1 * moveTo, 0);

    //    bool success = MoveNumber(2, moveTo, moveTo + velocity);
    //    //�ړ������s������v���C���[���ړ����Ȃ�
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
    //    //�ύX�A��dfor���œ񎟌��z��̏����o��
    //    for(int y=0; y < map.GetLength(0); y++)
    //    {
    //        for(int x=0; x < map.GetLength(1); x++)
    //        {
    //            debugText += map[y, x].ToString() + ",";
    //        }
    //        debugText += "\n";//���s
    //    }
    //   Debug.Log(debugText);
    //}

    // Update is called once per frame
    //void Update()
    //{
    //    //�E�ړ�
    //    if (Input.GetKeyDown(KeyCode.RightArrow))
    //    {
    //        //���\�b�h�������������g�p
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

    //        //�ړ��������֐���
    //        MoveNumber(1, playerIndex, playerIndex + 1);
    //        PrintArray();

    //    }

    //    //���ړ�
    //    if (Input.GetKeyDown(KeyCode.LeftArrow))
    //    {
    //        //���\�b�h�������������g�p
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

    //        //�ړ��������֐���
    //        MoveNumber(1, playerIndex, playerIndex - 1);
    //        PrintArray();

    //    }
    //}
//}

public class GameManagerScript : MonoBehaviour
{
    //�ǉ�
    public GameObject playerPrefab;
    public GameObject boxPrefab;
    int[,] map;//���x���f�U�C���p�̔z��
    GameObject[,] field;//�Q�[���Ǘ��p�̔z��

    bool MoveNumber(Vector2Int moveFrom,Vector2Int moveTo)
    {
        //�񎟌��z��ɑΉ�
        if (moveTo.y < 0 || moveTo.y >= field.GetLength(0)) { return false; };
        if (moveTo.x < 0 || moveTo.x >= field.GetLength(1)) { return false; };

        //���̃v���n�u���܂�����Ă��Ȃ��̂œ����������̓R�����g�A�E�g
        if (field[moveTo.y, moveTo.x] != null && field[moveTo.y, moveTo.x].tag == "Box")
        {
            Vector2Int velocity = moveTo + moveFrom;
            bool success = MoveNumber(moveTo, moveTo + velocity);
            if (!success) { return false; };
        }

        field[moveFrom.y, moveFrom.x].transform.position = new Vector3(moveTo.x, map.GetLength(0) - moveTo.y, 0);
        //GameObject player0rBox = field[moveTo.y,moveTo.x];

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
                //null��������^�O�𒲂ׂ����̗v�f�ֈڂ�
                if (field[y, x] == null) {
                    continue;
                }
                //null�������� continue���Ă���̂Ń^�O�̊m�F
                if (field[y,x].tag=="Player")
                {
                    //�v���C���[�̈ʒu��[x,y]�ɑ��
                    return new Vector2Int(y, x);
                }
            }
        }
        return new Vector2Int(-1, -1);
    }

    void Start()
    {
        //�m�F�o������폜
       // GameObject instance = Instantiate( playerPrefab,new Vector3(0, 0, 0), Quaternion.identity);

        map = new int[,] {
            { 1, 0, 0, 0, 0 },
            { 0, 0, 0, 2, 0 },
            { 0, 0, 0, 0, 0 },
        };
        //string debugText = "";

        field = new GameObject
            [
            map.GetLength(0),
            map.GetLength(1)
            ];

        //�ύX�A��dfor���œ񎟌��z��̏����o��
        for (int y = 0; y < map.GetLength(0); y++)
        {
            for (int x = 0; x < map.GetLength(1); x++)
            {
                //[y,x]=1�Ȃ� player�����̉�
                if (map[y, x] == 1)
                {
                    //GameObject instance=Instantiate(playerPrefab,new Vector3(x,map.GetLength(0)-y,0),Quaternion.identity);
                    field[y, x] = Instantiate(playerPrefab, new Vector3(x, map.GetLength(0) - y, 0), Quaternion.identity);
                }
                //debugText += map[y, x].ToString() + ",";

                //[y.x]=2�Ȃ�@box�����̉�
                if (map[y,x] == 2)
                {
                    field[y, x] = Instantiate(boxPrefab, new Vector3(x, map.GetLength(0) - y, 0), Quaternion.identity);
                }
            }
            //debugText += "\n";//���s
        }
       // Debug.Log(debugText);
    }
    void Update()
    {
        //�E�ړ�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //���݂̈ʒu�� playerIndex�ɓn��
            Vector2Int playerIndex = GetPlayerIndex();
            //�ʒu���ړ�������
            MoveNumber(
                playerIndex,//moveFrom
                playerIndex + new Vector2Int(1, 0));//moveTo
        }

        //���ړ�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //���݂̈ʒu�� playerIndex�ɓn��
            Vector2Int playerIndex = GetPlayerIndex();
            //�ʒu���ړ�������
            MoveNumber(
                playerIndex,//moveFrom
                playerIndex + new Vector2Int(-1, 0));//moveTo
        }

        //��ړ�
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            //���݂̈ʒu�� playerIndex�ɓn��
            Vector2Int playerIndex = GetPlayerIndex();
            //�ʒu���ړ�������
            MoveNumber(
                playerIndex,//moveFrom
                playerIndex + new Vector2Int(0, -1));//moveTo
        }

        //���ړ�
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            //���݂̈ʒu�� playerIndex�ɓn��
            Vector2Int playerIndex = GetPlayerIndex();
            //�ʒu���ړ�������
            MoveNumber(
                playerIndex,//moveFrom
                playerIndex + new Vector2Int(0, 1));//moveTo
        }

    }

    //void PrintArray()
    //{
    //    string debugText = "";
    //    for (int i = 0; i < map.Length; i++)
    //        for (int j = 0; j < map.Length; j++)
    //        {
    //            {
    //                debugText += map[j,i].ToString() + ",";
    //            }
    //        } debugText += "\n";
    //    Debug.Log(debugText);
    //}
}

