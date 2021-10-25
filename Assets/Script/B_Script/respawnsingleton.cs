using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class respawnsingleton : MonoBehaviour
{
    public static respawnsingleton Instance;

    void Awake()
    {
        if (Instance)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Instance = this;
    }

    void Update()
    {
        if("B" != SceneManager.GetActiveScene().name)
            gameObject.name = SceneManager.GetActiveScene().name;
    }
}
