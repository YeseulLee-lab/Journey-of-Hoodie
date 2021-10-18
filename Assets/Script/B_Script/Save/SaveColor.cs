using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveColor : MonoBehaviour
{
    [SerializeField] public ColorChange colorChange;
    public List<string> icekind = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        colorChange = GameObject.Find("SaveManager").GetComponent<ColorChange>();

        icekind.Add(colorChange.icekind);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S)){
            Save();
        }else if(Input.GetKeyDown(KeyCode.L)){
            Load();
        }
    }

    void Save()
    {
        List<ColorLoad> ColortoLoad = new List<ColorLoad>();

        for(int i = 0; i< icekind.Count; i++)
        {
            ColorLoad C = new ColorLoad(icekind[i]);
            ColortoLoad.Add(C);
        }
        Debug.Log(ColortoLoad.Count);
        //PercenttoLoad.ToString();
        string jsonP = customJSON.ToJson(ColortoLoad);

        File.WriteAllText(Application.persistentDataPath + transform.name + "color", jsonP);

        Debug.Log("Color Saving");
    }

    void Load()
    {
        Debug.Log("Color Loading");

        List<ColorLoad> ColorToLoad = customJSON.FromJson<ColorLoad>(File.ReadAllText(Application.persistentDataPath + transform.name + "color"));

        for(int i = 0; i < ColorToLoad.Count; i++)
        {
            icekind[i] = ColorToLoad[i].icekind;
        }

        colorChange.icekind = ((string)ColorToLoad[0].icekind);
    }
}

[System.Serializable]
public class ColorLoad
{
    public string icekind;

    public ColorLoad(string C)
    {
        icekind = C;
    }
}
