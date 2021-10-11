using System.Collections;
using System.Collections.Generic;
using System.Net;
using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public Server server;
    public Client client;
    [SerializeField] private TMP_InputField addressInput;
    // Start is called before the first frame update
    public void OnOnlineHostButton(){
        /*string hostname = Dns.GetHostName();
        IPAddress[] ipaddress = Dns.GetHostEntry(hostname).AddressList;
        foreach (IPAddress ip in ipaddress) {
            if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork) {
                Debug.Log(ip.ToString());
            }
        }*/

        server.Init(8005);
        client.Init("58.145.9.40", 8005);
    }

    public void OnOnlineClinetButton(){
        client.Init(addressInput.text, 8005);
    }
}
