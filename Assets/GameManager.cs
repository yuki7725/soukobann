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
    void Start()
    {   
        map = new int[] { 0, 0, 0, 1, 0, 0, 0, 0, 0 };

        //�ǉ��A������̐錾�Ə�����
        string debugText = "";

        for (int i = 0; i < map.Length; i++)
        {
            //������Ɍ������Ă���
            debugText+= map[i].ToString()+",";
        }
        //����������������o��
        Debug.Log(debugText);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //������Ȃ��������̂��߂�-1�ŏ�����
            int playerIndex = -1;
            //�v�f���� map.Length�Ŏ擾
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
    }
}
