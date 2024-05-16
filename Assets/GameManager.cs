using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class GameManager : MonoBehaviour
{
    //�z��̕\��
    int[] map;
    // Start is called before the first frame update

    //�N���X�̒��A���]�b�g�̊O�ɒu��
    //�Ԃ�l�̒l�ɒ���
    void PrintArray()
    {
        string debugText = "";
        for(int i=0;i<map.Length;i++)
        {
            debugText += map[i].ToString()+",";
        }
        Debug.Log(debugText);
    }

    //�N���X�̒��A���]�b�g�̊O�ɒu��
    //�Ԃ�l�̒l�ɒ���
    bool MoveNumber(int number,int moveFrom,int moveTo)
    {
        if (moveTo < 0 || moveTo >= map.Length)
        {
            //�����Ȃ��������ɒu���A���^�[������A�������^�[��
            return false;
        }
        if (map[moveTo] == 2)
        { 
        //�ǂ̕����ֈړ����邩
        int velocity = moveTo - moveFrom;
        //�v���C���[�̈ړ��悩��2���ړ�������
        bool success = MoveNumber(2, moveTo, moveTo + velocity);
        //�ړ������s������v���C���[���ړ����Ȃ�
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
        //�E�ړ�
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //���\�b�h�������������g�p
            int playerIndex= GetPlayerIndex();

            if (playerIndex < map.Length - 1)
            {
                map[playerIndex + 1] = 1;
                map[playerIndex] = 0;
            }

            //�ړ��������֐���
            MoveNumber(1, playerIndex, playerIndex + 1);
            PrintArray();

        }

        //���ړ�
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //���\�b�h�������������g�p
            int playerIndex = GetPlayerIndex();

            if (playerIndex < map.Length - 1)
            {
                map[playerIndex - 1] = 1;
                map[playerIndex] = 0;
            }

            //�ړ��������֐���
            MoveNumber(1, playerIndex, playerIndex - 1);
            PrintArray();

        }
    }
}
