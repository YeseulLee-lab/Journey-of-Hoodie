using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuestLogin : MonoBehaviour
{
    public void OnClickConfirmButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}