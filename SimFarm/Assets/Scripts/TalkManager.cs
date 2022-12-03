using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "안녕하세요", "무엇을 사려고 왔습니다", "그거 좀 안좋은데?" });
        
    }
    public string GetTalk(int id, int talkIndex)
    {


        return talkData[id][talkIndex];
    }
}
