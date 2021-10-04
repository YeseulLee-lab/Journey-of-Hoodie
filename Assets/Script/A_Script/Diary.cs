using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Diary : MonoBehaviour
{
    public int num;
    public List<string> content = new List<string>();
    public GameObject updatee;
    public bool state;

    // Start is called before the first frame update
    void Start()
    {

        //content[0] = "잠에서 깨어나보니 온 마을이 파괴되어 있고 픽셀화가 되어 있었다. \n내 몸마저.. 앙숙이었던 B행성의 짓일까?";

        gameObject.GetComponentsInChildren<Text>()[1].text = "잠에서 깨어나보니 온 마을이 파괴되어 있고 픽셀화가 되어 있었다. \n내 몸마저.. 앙숙이었던 B행성의 짓일까?";
    }

    // Update is called once per frame
    public void DiaryStory()
    {
        if (state == true){
            updatee.SetActive(true);
        }
        else{
            updatee.SetActive(false);
        }
            
        if(GameManager.MyGameManager.SavedNPC == 0)
        {
            content.Add("일단 마을 후디들을 찾아야겠다. \n먼저 도뮈뉙을 찾자. \n도뮈뉙은 연두색이고 석상의 북동쪽에 있다.");
        }
        else if(GameManager.MyGameManager.SavedNPC == 1)
        {
            state = false;
            content[0] = "일단 마을 후디들을 찾아야겠다. \n먼저 도뮈뉙을 찾자. \n도뮈뉙은 연두색이고 석상의 북동쪽에 있다. \n\n\n\n도뮈뉙을 찾았다! \n도뮈뉙의 말을 들어보니 B행성이 우리 행성에 테러를 한 것이 맞았다.";
            if(num == content.Count){
                state = true;
                gameObject.GetComponentsInChildren<Text>()[1].text = content[0];
            }
            content.Add("뷔앙카를 찾아야 한다. 뷔앙카는 석상의 남서쪽의 부서진 다리 건너에 있다.");
        }else if(GameManager.MyGameManager.SavedNPC == 2)
        {
            state = false;
            content[1] = "뷔앙카를 찾아야 한다. 뷔앙카는 석상의 남서쪽의 부서진 다리 건너에 있다. \n\n\n뷔앙카를 찾았다! \n뷔앙카는 탑에 볼 일이 있어서 왔다가 다리가 무너져서 고립되었다고 한다. 우리 행성은 예로부터 B행성에게 아무 이유없이 테러를 당해왔다.";
            if(num == content.Count){
                state = true;
                gameObject.GetComponentsInChildren<Text>()[1].text = content[1];
            }
            content.Add("제쉬카를 찾아야 한다. 제쉬카는 석상의 북서쪽의 숲 속에 있다.");
        }else if(GameManager.MyGameManager.SavedNPC == 3)
        {
            state = false;
            content[2] = "제쉬카를 찾아야 한다. 제쉬카는 석상의 북서쪽의 숲 속에 있다. \n\n\n제쉬카를 찾았다! \n제쉬카는 여러모로 참 맘에 들지 않는 친구지만 행동대장이라 아무도 나서지 않는 일을 잘 한다. 이번에도 제쉬카가 결정적인 일을 해주지 않을까?";
            if(num == content.Count){
                state = true;
                gameObject.GetComponentsInChildren<Text>()[1].text = content[2];
            }
            content.Add("쉬드를 찾아야 한다. 쉬드 석상의 남동쪽 쯤에 있다.");
        }else if(GameManager.MyGameManager.SavedNPC == 4)
        {
            state = false;
            content[3] = "쉬드를 찾아야 한다. 쉬드는 석상의 남동쪽 쯤에 있다. \n\n\n쉬드를 찾았다! \n쉬드는 물을 길으러 왔다가 우물에 깔려 있었다고 한다. 무뚝뚝하지만 참 다정한 친구다.";
            if(num == content.Count){
                state = true;
                gameObject.GetComponentsInChildren<Text>()[1].text = content[3];
            }
            content.Add("올뤼뷔아를 찾아야 한다. 올뤼뷔아는 석상의 북동쪽의 도미닉을 구한 집 근처 큰 바위 뒤에 있다.");
        }else if(GameManager.MyGameManager.SavedNPC == 5)
        {
            state = false;
            content[4] = "올뤼뷔아를 찾아야 한다. 올뤼뷔아는 석상의 북동쪽의 도미닉을 구한 집 근처 큰 바위 뒤에 있다. \n\n\n올뤼뷔아를 찾았다! 올뤼뷔아는 평소처럼 돌을 주우러 왔다가 떨어진 바위에 의해 오도가도 못하게 되었다고 한다. 제쉬카가 맨날 시비를 걸지만 웃으며 받아주는 착한 친구다.";
            if(num == content.Count){
                state = true;
                gameObject.GetComponentsInChildren<Text>()[1].text = content[4];
            }
            content.Add("동료를 모두 구했다. 마을 중앙의 계단을 지나 다리를 고쳐 본부로 가자");
        }
        
        content = content.Distinct().ToList();
        
        if(gameObject.activeSelf == true){
            if(Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.JoystickButton9))
            {
                //Debug.Log(content);
                if(num > content.Count)
                {
                    num = content.Count + 1;                
                }
                else
                    num++;

                //gameObject.GetComponentInChildren<Text>().text = "#" + num.ToString();
                gameObject.GetComponentsInChildren<Text>()[0].text = "#" + num.ToString();

                gameObject.GetComponentsInChildren<Text>()[1].text = content[num-2];

            }
            if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.JoystickButton10))
            {
                if(num <= 0)
                    num = 1;
                else
                    num --;

                if(num == 1)
                    gameObject.GetComponentsInChildren<Text>()[1].text = "잠에서 깨어나보니 온 마을이 파괴되어 있고 픽셀화가 되어 있었다. \n내 몸마저.. 앙숙이었던 B행성의 짓일까?";
                else{
                    gameObject.GetComponentsInChildren<Text>()[1].text = content[num-2];
                }

                gameObject.GetComponentsInChildren<Text>()[0].text = "#" + num.ToString();
                //Debug.Log(num);
            }
        }
    }
}