using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Photon.Pun;

public class IcePlayer : MonoBehaviour
{
    public float moveSpeed;
    float hAxis;
    float vAxis;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float gravityScale;
    public Vector3 moveDirection;
    Vector3 moveVec;
    Animator anim;
    public CharacterController controller;
    public GameObject ButtonAlert;
    public RaycastHit hit;
    public RaycastHit Enterhit;
    float MaxDistance = 2f;
    public GameObject EnterPanel;
    public GameObject textpudding;
    public GameObject textbread;
    public GameObject textcheese;
    public GameObject Darker;
    public Text townName;
    public Vector3 position;
    PlayerData data;
    public PhotonView PV;
    public GameObject Pause;
    [SerializeField] GameObject Player;
    //SavePlayerPos playerPosData;
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        PV = GetComponent<PhotonView>();
        //animator = GetComponent<Animator>();
        // playerPosData = FindObjectOfType<SavePlayerPos>();

        // playerPosData.PlayerPosLoad();
        // Debug.Log("이건 왜안되니?");
        //SavePlayerPos.LoadPlayer();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        PlayerData data = SavePlayerPos.LoadPlayer();
        //ector3 position;

        position.x = data.position[0];
        position.y = data.position[1];
        position.z = data.position[2];
        Debug.Log(position);
        transform.position = position;
        
        Player = GameObject.Find("Player");
        // else{
        //     ButtonAlert = GameObject.Find("Canvas").transform.Find("BubbleWhiteSmall2").gameObject;            
        // }
        Darker = GameObject.Find("Darker");
        EnterPanel = Darker.transform.Find("EnterPanel").gameObject;
        textpudding = Darker.transform.Find("Textpudding").gameObject;
        textbread = Darker.transform.Find("Textbread").gameObject;
        textcheese = Darker.transform.Find("Textcheese").gameObject;
        townName = Darker.transform.Find("TownName").gameObject.GetComponent<Text>();
        Pause = GameObject.Find("Canvas").transform.Find("Pause").gameObject;

        controller = GetComponent<CharacterController>();

        if(gameObject.name == "Player"){
            return;
        }
        else
        {
            if(PV.IsMine){
                ButtonAlert = GameObject.Find("Canvas").transform.Find("BubbleWhiteSmall").gameObject;
            }
        }
    }

    public void Move(){
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);

        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        moveVec = new Vector3(hAxis, 0, vAxis).normalized;

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);

        if (moveVec.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(moveVec.x, moveVec.z) * Mathf.Rad2Deg;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Cancel"))
        {
            Pause.SetActive(!Pause.activeSelf);
        }

        data = SavePlayerPos.LoadPlayer();
        /*if(null != GameObject.Find("MultiPlayer(Clone")){
            print("dpd");
            GameObject.Find("Player").SetActive(false);
        }*/

        if(gameObject.name == "MultiPlayer(Clone)"){
            if(null != Player){
                Player.SetActive(false);                
            }
            if (!PV.IsMine){
                return;
            }
            Move();         
        }
        else{
            Move();
        }

        if(EnterPanel.activeSelf == true){
            Pause.SetActive(false);
        }
        
//        Debug.Log(gameObject.name);

        controller.Move(moveDirection * Time.deltaTime);

        anim.SetBool("isWalk", moveVec != Vector3.zero);

        Debug. DrawLine (transform.position, hit.point, Color.red);
        if(Physics.Raycast(transform.position + transform.up * 3.0f, transform.forward, out hit, MaxDistance)){
            if(hit.transform.gameObject.tag == "Building" || hit.transform.gameObject.tag == "Building2" || hit.transform.gameObject.tag == "Building3"){
                //Debug.Log("빌딩맞는데");
                ButtonAlert.SetActive(true);
                if(Input.GetButtonDown("Enter")){
                    if(Physics.Raycast(transform.position + transform.up * 3.0f, transform.forward, out Enterhit, MaxDistance)){
                        if(hit.transform.gameObject.tag == "Building"){
                            Darker.GetComponent<Image>().enabled = true;
                            Darker.SetActive(true);
                            EnterPanel.SetActive(true);                            townName.transform.gameObject.SetActive(true);
                            textpudding.SetActive(true);
                            textbread.SetActive(false);
                            textcheese.SetActive(false);
                            ButtonAlert.SetActive(false);
                            townName.text = "푸딩마을";
                            position.x = data.position[0];
                            position.y = data.position[1];
                            position.z = data.position[2];
                        }
                        else if(hit.transform.gameObject.tag == "Building2"){
                            Darker.GetComponent<Image>().enabled = true;
                            Darker.SetActive(true);
                            EnterPanel.SetActive(true);
                            townName.transform.gameObject.SetActive(true);
                            textpudding.SetActive(false);
                            textbread.SetActive(true);
                            textcheese.SetActive(false);
                            ButtonAlert.SetActive(false);
                            townName.text = "빵마을";
                            position.x = data.position[0];
                            position.y = data.position[1];
                            position.z = data.position[2];
                        }
                        else if(hit.transform.gameObject.tag == "Building3"){
                            Darker.GetComponent<Image>().enabled = true;
                            Darker.SetActive(true);
                            EnterPanel.SetActive(true);
                            townName.transform.gameObject.SetActive(true);
                            textpudding.SetActive(false);
                            textbread.SetActive(false);
                            textcheese.SetActive(true);
                            ButtonAlert.SetActive(false);
                            townName.text = "치즈마을";
                            position.x = data.position[0];
                            position.y = data.position[1];
                            position.z = data.position[2];
                        }
                    }
                }
                
            }
        }else{
            ButtonAlert.SetActive(false);
        }
    }

    [PunRPC]
    void Sceneunify(string townname, GameObject SaveManager){
        SceneManager.LoadScene(townname);
        DontDestroyOnLoad(SaveManager);        
    }

    [PunRPC]
    void getColor(string icekind)
    {
        //Debug.Log("불려지니");
        GameObject.Find("SaveManager").GetComponent<ColorChange>().othericekind = icekind;
    }

}