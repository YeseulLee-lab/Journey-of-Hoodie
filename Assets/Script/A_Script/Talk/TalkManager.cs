using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    public string nickname;
    GameObject StageManager;
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portraitData;
    public Sprite[] portraitArr;
    // Start is called before the first frame update
    void Awake()
    {
        StageManager = GameObject.Find("DataObject");
      // nickname = StageManager.GetComponent<TransData>().nickname;
        talkData = new Dictionary<int, string[]>();
        portraitData = new Dictionary<int, Sprite>();
        if (null != StageManager){
            nickname = StageManager.GetComponent<TransData>().nickname;
        }
        else{
            nickname = "플레이어";
        }
        GenerateData();
    }

    // Update is called once per frame
    void GenerateData()
    {
        talkData.Add(1, new string[] {"여기에 왜 쓰러져 있던거지? \n 내 몸은 왜 이래:0"});
        talkData.Add(2, new string[] {"E를 눌러서 대화를 할 수 있어:0"});
        talkData.Add(3, new string[] {"Space를 눌러서 고치거나 장애물을 파괴할 수 있어.:0"});
        talkData.Add(1000, new string[] { "저기요!:1", "저 좀 구해주세요!:1" });
        talkData.Add(2000, new string[] { "다리 고쳐줘서 정말 고맙다:2", "뷔앙카잖아! 살아있었구나!:1", "이 탑에 볼 일이 있어서 잠깐 왔는데 이렇게 갑자기 테러를 당하다니..:2", "이게 무슨 일이야 진짜.. 우리 행성이 모두 픽셀화가 되다니..:1"});
        talkData.Add(3000, new string[] { "야!:3", "아오 저 싸가지 제쉬카:2", "보고만 있지 말고 좀 구해봐! 멍청아!:3" });
        talkData.Add(4000, new string[] { "쉬드야..!:1", "어이 ㅋ:4", "나 좀 구해바라:4" });
        talkData.Add(5000, new string[] { nickname + "님!:5", "뭔 님이냐 착한 척 오지네:3", "....:5", "구해주셔서 감사합니다!:5" });
        talkData.Add(10000, new string[] { nickname + "야! 정신 차려! 우리 행성이 파괴당하고 있다고!:6", "뭐야 이 자식 세뇌풀렸네?:0", "어? 뭐야 눈 앞이 이상해:0", 
        "으아악! 내 몸을 돌려내!!:7", "누구야! 정신 차려야 돼! 우리 행성을 구해야지!:6", "구하긴 뭘 구해! 이미 너희 행성은 끝났다고! 정신을 차린다고 구할 수 있을 거 같아?:0"});


        portraitData.Add(1 + 0, portraitArr[0]);
        portraitData.Add(2 + 0, portraitArr[0]);
        portraitData.Add(3 + 0, portraitArr[0]);

        portraitData.Add(1000 + 0, portraitArr[0]);
        portraitData.Add(1000 + 1, portraitArr[1]);

        portraitData.Add(2000 + 0, portraitArr[0]);
        portraitData.Add(2000 + 1, portraitArr[1]);
        portraitData.Add(2000 + 2, portraitArr[2]);

        portraitData.Add(3000 + 1, portraitArr[1]);
        portraitData.Add(3000 + 2, portraitArr[2]);
        portraitData.Add(3000 + 3, portraitArr[3]);

        portraitData.Add(4000 + 1, portraitArr[1]);
        portraitData.Add(4000 + 4, portraitArr[4]);

        portraitData.Add(5000 + 3, portraitArr[3]);
        portraitData.Add(5000 + 5, portraitArr[5]);

        portraitData.Add(10000 + 6, portraitArr[6]);
        portraitData.Add(10000 + 0, portraitArr[0]);
        portraitData.Add(10000 + 7, portraitArr[7]);
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