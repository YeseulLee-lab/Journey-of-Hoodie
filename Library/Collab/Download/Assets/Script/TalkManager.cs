using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    // Start is called before the first frame update
    void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1000, new string[] { "저기요!:1", "누구세요?:0", "저 좀 구해주세요!:1" });
        talkData.Add(2000, new string[] { "저기요!:1", "누구세요?:0", "저 좀 구해주세요!:1" });
        talkData.Add(3000, new string[] { "저기요!:1", "누구세요?:0", "저 좀 구해주세요!:1" });
        talkData.Add(4000, new string[] { "저기요!:1", "누구세요?:0", "저 좀 구해주세요!:1" });
        talkData.Add(5000, new string[] { "저기요!:1", "누구세요?:0", "저 좀 구해주세요!:1" });
        talkData.Add(100, new string[] { "바닥" });

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);
        portraitData.Add(2000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 1, portraitArr[2]);
        portraitData.Add(3000 + 0, portraitArr[0]);
        portraitData.Add(3000 + 1, portraitArr[3]);
        portraitData.Add(4000 + 0, portraitArr[0]);
        portraitData.Add(4000 + 1, portraitArr[4]);
        portraitData.Add(5000 + 0, portraitArr[0]);
        portraitData.Add(5000 + 1, portraitArr[5]);
    }

    public string GetTalk(int id, int talkIndex)
    {
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }

    public Sprite GetPortrait(int id, int portraitIndex)
    {
        return portraitData[id + portraitIndex];
    }
}
