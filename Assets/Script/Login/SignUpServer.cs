using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MongoDB.Bson;

public class SignUpServer : MonoBehaviour
{
    public InputField usernameIF;
    public InputField passwordIF;
    public InputField nicknameIF;
    List<users> usernames;
    public GameObject SignUp;
    public GameObject beforeData;
    public GameObject afterData;
    public string path;

    void Start() 
    {
        usernames = GameObject.Find("SignupbeforeData").GetComponent<FindData>().allinfo;
    }

    public void OnClickConfirmButton(){
        string password = passwordIF.text;
        string username = usernameIF.text;
        string nickname = nicknameIF.text;
        string path = Application.persistentDataPath;
        string icenickname = "";

        var document = new BsonDocument { { "username", username },
        { "password", password }, { "nickname", nickname }, { "path", path }, { "icenickname", icenickname } };

        if (username == "")
        {
            print("아이디 입력해");
            usernameIF.text = "ID를 입력해주세요";
        }
        else if (password == "")
        {
            print("비번 입력해");
            usernameIF.text = "비밀번호를 입력해주세요.";
            
        }
        else if (nickname == "")
        {
            print("닉네임 입력해");
            usernameIF.text = "닉네임을 입력해주세요.";
        }
        else
        {
            for(int i = 0; i < usernames.Count; i++)
            {
                if (username == usernames[i].username)
                {
                    print("아이디가 중복");
                    usernameIF.text = "ID가 이미 존재합니다.";
                    return;
                }
            }
            GameObject.Find("SignupbeforeData").GetComponent<FindData>().collection.InsertOne(document);
            SignUp.SetActive(false);
            beforeData.SetActive(false);
            afterData.SetActive(true);
        }
    }
}