using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MongoDB.Bson;
using UnityEngine.SceneManagement;

public class nicknameAdd : MonoBehaviour
{
    MongoClient client = new MongoClient("mongodb+srv://younguser:young@cluster0.lext6.mongodb.net/testdb?retryWrites=true&w=majority");
    IMongoDatabase database;
    public IMongoCollection<BsonDocument> collection;
    public InputField icenicknameIF;
    public GameObject DataObject;
    public GameObject icenicknameObject;
    public string nickname;
    public string icenickname;
    // Start is called before the first frame update
    void Start()
    {
      database = client.GetDatabase("testdb");
      collection = database.GetCollection<BsonDocument>("users");

      DataObject = GameObject.Find("DataObject");

        //if (DataObject != null){
      nickname = DataObject.GetComponent<TransData>().nickname;
        //}

      //  icenicknameObject = GameObject.Find("ice").transform.Find("icenicknameObject").gameObject;
      icenicknameObject = GameObject.Find("DataObject");
    }

    public void ButtonClick(){
      icenickname = icenicknameIF.text;
      var filter = Builders<BsonDocument>.Filter.Eq("nickname", nickname);
      var update = Builders<BsonDocument>.Update.Set("icenickname", icenickname);
      collection.UpdateOne(filter, update);
      icenicknameObject.GetComponent<TransData>().icenickname = icenickname;
      DontDestroyOnLoad(icenicknameObject);
      SceneManager.LoadScene("MultiChoice");
    }

    // Update is called once per frame
 
        //var document = collection.Find(filter).FirstOrDefault();
       // print(studentDocument.ToString());
     //   print(document);
        //if (usernames[1].username == "1"){
          //  var document = collection.Find<BsonDocument>();
        //}
        //var collection = MyExtensions. 
        /*var filter = new BsonDocument("_id", findUserName);
        
        var document = await collection.Find("icenickname").SingleAsync;
        string icenickname = icenicknameIF.text;

        collection.ReplaceOneAsync("icenickname", document);*/

    
}
