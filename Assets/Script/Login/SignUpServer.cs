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
    public string path;
    public IMongoCollection<BsonDocument> collection;

    void Start() 
    {
      //  usernames = GameObject.Find("SignupbeforeData").GetComponent<FindData>().allinfo;
        collection = GameObject.Find("Data").GetComponent<FindData>().collection;
    }

    public async void OnClickConfirmButton(){
        string password = passwordIF.text;
        string username = usernameIF.text;
        string nickname = nicknameIF.text;
        string path = Application.persistentDataPath;
        string icenickname = "";

        var filter = Builders<BsonDocument>.Filter.Eq("username", username);

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
            var list = collection.Find(filter);

            if(null != await list.FirstOrDefaultAsync()){
                print("아이디가 중복");
                usernameIF.text = "ID가 이미 존재합니다.";
            }
            else{
                GameObject.Find("Data").GetComponent<FindData>().collection.InsertOne(document);
                SignUp.SetActive(false);
            }

           // if (filter.Equals(nickname)){
              //  print("아이디가 중복");
              //  usernameIF.text = "ID가 이미 존재합니다.";
               // return;
            }
            // new Bsonda
           /*for(int i = 0; i < usernames.Count; i++)
            {
                if (username == usernames[i].username)
                {
                    print("아이디가 중복");
                    usernameIF.text = "ID가 이미 존재합니다.";
                    return;
                }
            }*/
          //  GameObject.Find("SignupbeforeData").GetComponent<FindData>().collection.InsertOne(document);
         //   SignUp.SetActive(false);
          //  beforeData.SetActive(false);
          //  afterData.SetActive(true);*/
        }
    }

          //  var filter = collection.Find<users>(x => x.username).Project(Builders<users>.Projection.Include("username")).ToListAsync().Result;
      //var filter = await collection.Find(new BsonDocument()).Project(BsonDocument.Parse("{username:1}")).ToListAsync();
     // var doc = await collection.Find(filter).T;
     //  var filter = collection.Find(new BsonDocument()).Project(Builders<BsonDocument>.Projection.Include("username")).ToListAsync();
       //var doc = await filter.Result;
      /* var filter = Builders<BsonDocument>.Filter.Eq("username", "young");
       var doc = awiat collection.Find(filter).ToListAsync();

       var List = new List<string>();
       foreach (var documents in doc.ToList()){
           List.Add(documents.AsString);
       }

       print(List);*/

      // List.Dump();
       // foreach(var user in filter.ToString()){

      //  }
      ////  print(filter);

        //var filter = Builders<BsonDocument>.Filter.Eq("nickname", nickname);
      //  print(filter.ToString());
       // var update = Builders<BsonDocument>.Update.Set("icenickname", icenickname);

 //var filter = new BsonDocument().Project(BsonDocument.Parse("{username}"));
        //Builders<BsonDocument>.Filter.Eq("username", username);
     //   print(filter);

     //var documents = Builders<BsonDocument>.Projection.Include("username");
    // var projection = collection.Find(new BsonDocument()).Project(documents).ToListAsync();

        //var documents = collection.Find(new BsonDocument()).Project(BsonDocument.Parse("{ username:1 }")).ToListAsync();

      //  var studentDocument = collection.Find(filter).FirstOrDefault();
      //  print(projection.ToString());