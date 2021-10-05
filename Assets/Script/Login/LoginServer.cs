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
    public IMongoCollection<BsonDocument> collection;

    void Start() {
        collection = GameObject.Find("Data").GetComponent<FindData>().collection;
    }

    public async void OnClickConfirmButton()
    {       
        string password = passwordIF.text;
        string username = usernameIF.text;

        var usernamefilter = Builders<BsonDocument>.Filter.Eq("username", username);
        var passwordfilter = Builders<BsonDocument>.Filter.Eq("username", username) & Builders<BsonDocument>.Filter.Eq("password", password);
        var nicknamefilter = Builders<BsonDocument>.Projection.Include("nickname").Include("icenickname").Exclude("_id");

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
            var userlist = collection.Find(usernamefilter);
            var passwordlist = collection.Find(passwordfilter);

            if(null == await userlist.FirstOrDefaultAsync()){
                print("아이디가 없어");
                usernameIF.text = "ID가 존재하지 않습니다.";
            }
            else{
                if(null == await passwordlist.FirstOrDefaultAsync()){
                    print("비번이 틀려");
                    usernameIF.text = "비밀번호가 틀렸습니다.";
                }
                else{
                    var list = await passwordlist.Project(nicknamefilter).ToListAsync();
                    foreach(var doc in list){
                        GameObject.Find("DataObject").GetComponent<TransData>().nickname = 
                        doc.ToString().Substring(doc.ToString().IndexOf(":") + 3, doc.ToString().IndexOf(",") - 2 - doc.ToString().IndexOf(":") - 2);
                        GameObject.Find("DataObject").GetComponent<TransData>().icenickname = 
                        doc.ToString().Substring(doc.ToString().IndexOf(",") + 19, doc.ToString().IndexOf("}") - doc.ToString().LastIndexOf(":") - 5);
                    }
                   // print(nicknamelist.FirstOrDefaultAsync());
                   // GameObject.Find("DataObject").GetComponent<TransData>().nickname = nicknamelist.FirstOrDefaultAsync().ToString();
                   GameObject.Find("DataObject").GetComponent<TransData>().call();
                   GameObject.Find("CustomFormMenu").SetActive(false);
                   GameObject.Find("LoginButton").SetActive(false);
                }
            }

            /*for(int i = 0; i < Data.Count; i++)
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
            return;      */      
        }
    }
}
