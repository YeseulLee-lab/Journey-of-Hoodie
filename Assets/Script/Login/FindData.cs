using MongoDB.Driver;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MongoDB.Bson;
using System.Threading.Tasks;
using System.IO;

public class users
{
    public string _id;
    public string username;
    public string password;
    public string nickname;
    public string path;
    public string icecreamnickname;
}
public class FindData : MonoBehaviour
{
    MongoClient client = new MongoClient("mongodb+srv://younguser:young@cluster0.lext6.mongodb.net/testdb?retryWrites=true&w=majority");
    IMongoDatabase database;
    public IMongoCollection<BsonDocument> collection;
    public List<users> allinfo;
    public List<string> usernameinfo;

    void Start()
    {
        database = client.GetDatabase("testdb");
        collection = database.GetCollection<BsonDocument>("users");
     //   usernameData();
    }

   /* void Update(){
        usernameData();
    }

    public async Task<List<users>> usernameData(){
        var allInfoTask = collection.FindAsync(new BsonDocument());
        var allInfoAwaited = await allInfoTask;

        //var filter = await collection.Find(new BsonDocument()).Project(BsonDocument.Parse("{username:1, _id:0}")).ToListAsync();
      //  var filter = Builders<BsonDocument>.Filter.Eq("username", "young1");

        allinfo = new List<users>();
        usernameinfo = new List<string>();

        foreach (var username in allInfoAwaited.ToList())
        {
            allinfo.Add(Deserialize(username.ToString()));
        }

        return allinfo;
    }
    
    private users Deserialize(string rawJson)
    {
        var testdb = new users();
        var stringWithoutID = rawJson.Substring(rawJson.IndexOf("),") + 4);

        var username = stringWithoutID.Substring(stringWithoutID.IndexOf(":") + 3,
        stringWithoutID.IndexOf(",") - stringWithoutID.IndexOf(":") - 4);
        stringWithoutID = stringWithoutID.Substring(stringWithoutID.IndexOf(",") + 3);

        var password = stringWithoutID.Substring(stringWithoutID.IndexOf(":") + 3,
        stringWithoutID.IndexOf(",") - stringWithoutID.IndexOf(":") - 4);
        stringWithoutID = stringWithoutID.Substring(stringWithoutID.IndexOf(",") + 3);

        var nickname = stringWithoutID.Substring(stringWithoutID.IndexOf(":") + 3, 
        stringWithoutID.IndexOf(",") - stringWithoutID.IndexOf(":") - 4);
        stringWithoutID = stringWithoutID.Substring(stringWithoutID.IndexOf(",") + 3);

        var path = stringWithoutID.Substring(stringWithoutID.IndexOf(":") + 3,
        stringWithoutID.IndexOf("}") - stringWithoutID.IndexOf(":") - 5);

        testdb.username = username;
        testdb.password = password;
        testdb.nickname = nickname;
        testdb.path = path;
        return testdb;
    }*/
}