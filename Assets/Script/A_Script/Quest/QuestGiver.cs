using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    [SerializeField]
    public Quest[] quests;

    //Debugging
    [SerializeField]
    private QuestLog tmpLog;

    private void Awake()
    {
        //Here we need to accept a quest //DEBBUGING ONLY
        tmpLog.AcceptQuest(quests[0]);
    }

    void Update(){
        tmpLog.UpdateSelected(quests[0]);
        if(GameManager.MyGameManager.SavedNPC == 1){
            quests[0].MyDescription = "뷔앙카를 찾아야 한다. 뷔앙카는 석상의 남서쪽의 부서진 다리 건너에 있다.";
        }else if(GameManager.MyGameManager.SavedNPC == 2){
            quests[0].MyDescription = "제쉬카를 찾아야 한다. 제쉬카는 석상의 북서쪽의 숲 속에 있다.";
        }else if(GameManager.MyGameManager.SavedNPC == 3){
            quests[0].MyDescription = "쉬드를 찾아야 한다. 쉬드는 석상의 남동쪽 쯤에 있다.";
        }else if(GameManager.MyGameManager.SavedNPC == 4){
            quests[0].MyDescription = "올뤼뷔아를 찾아야 한다. 올뤼뷔아는 석상의 북동쪽의 도미닉을 구한 집 근처 큰 바위 뒤에 있다.";
        }
        
        if(GameManager.MyGameManager.SavedNPC == 5 && GameManager.MyGameManager.allSaved == true){
            tmpLog.AcceptQuest(quests[1]);
            //GameManager.MyGameManager.SavedNPC = 6;
            
        }
    }
}
