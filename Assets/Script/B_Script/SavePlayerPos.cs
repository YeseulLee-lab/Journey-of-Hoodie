using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public static class SavePlayerPos
{
    public static void SavePlayer (IcePlayer player)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.fun";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(player);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.fun";
        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
//            Debug.Log(stream);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;
        }else{
            Debug.LogError("Save File not found in " + path);
            return null;
        }
    }


    //public GameObject player;

    // private void Start()
    // {
    //     if(PlayerPrefs.GetInt("Saved") == 1 && PlayerPrefs.GetInt("TimeToLoad") ==1)
    //     {
    //         float pX = player.transform.position.x;
    //         float pY = player.transform.position.y;
    //         float pZ = player.transform.position.z;

    //         pX = PlayerPrefs.GetFloat("p_x");
    //         pY = PlayerPrefs.GetFloat("p_y");
    //         pZ = PlayerPrefs.GetFloat("p_Z");

    //         player.transform.position = new Vector3(pX, pY, pZ);
    //         Debug.Log(pX + "," + pY + "," + pZ);

    //         PlayerPrefs.SetInt("TimeToLoad", 0);
    //         PlayerPrefs.Save();
    //     }
        
    // }

    // public void PlayerPosSave(){
    //     PlayerPrefs.SetFloat("p_x", player.transform.position.x);
    //     PlayerPrefs.SetFloat("p_y", player.transform.position.y);
    //     PlayerPrefs.SetFloat("p_z", player.transform.position.z);
    //     PlayerPrefs.SetInt("Saved", 1);
    //     PlayerPrefs.Save();
    //     Debug.Log("저장됨");
    // }

    // public void PlayerPosLoad()
    // {
    //     PlayerPrefs.SetInt("TimeToLoad", 1);
    //     PlayerPrefs.Save();
    // }
}
