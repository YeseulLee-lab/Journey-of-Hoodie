using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MongoDB.Bson;

public class LoginServer : MonoBehaviour
{
    public InputField usernameIF;
    public InputField passwordIF;
    List<users> Data;
    public GameObject beforeData;

    public void OnClickConfirmButton()
    {
        if (beforeData.activeSelf == true){
            Data = GameObject.Find("SignupbeforeData").GetComponent<FindData>().allinfo;
        }
        else{
            Data = GameObject.Find("SignupafterData").GetComponent<FindData>().allinfo;
        }
        string password = passwordIF.text;
        string username = usernameIF.text;

        if (username == "")
        {
            print("아이디 입력");
            usernameIF.text = "ID를 입력해주세요.";
        }
        else if (password == "")
        {
            print("비번 입력");
            usernameIF.text = "비밀번호를 입력해주세요.";
        }
        else
        {
            for(int i = 0; i < Data.Count; i++)
            {
                if (username == Data[i].username)
                {
                    if (password != Data[i].password)
                    {
                        print("비번이 틀려");
                        usernameIF.text = "비밀번호가 틀렸습니다.";
                        return;
                    }
                    else
                    {
                        GameObject.Find("DataObject").GetComponent<TransData>().nickname = Data[i].nickname;
                        GameObject.Find("DataObject").GetComponent<TransData>().call();
                        return;
                    }
                }
            }
            print("아이디가 없어");
            usernameIF.text = "ID가 존재하지 않습니다.";
            return;            
        }
    }
}
