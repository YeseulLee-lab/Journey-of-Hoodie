using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MapIcePlayer : MonoBehaviour
{
    public float moveSpeed;
    float hAxis;
    float vAxis;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public float gravityScale;
    private Vector3 moveDirection;
    Vector3 moveVec;
    Animator anim;
    public CharacterController controller;
    public RaycastHit hit;
    float MaxDistance = 5f;
    public Interactable focus;
    public GameObject inventoryUI;
    public GameObject weaponCreator;
    public GameObject buildingCreator;
    public GameObject ButtonAlert;
    public GameObject ButtonAlert2;
    public GameObject BuildingParticle;
    //public GameObject BuildingWreck;
    public GameObject small;
    public GameObject medium;
    public GameObject fork;
    public int percent;
    public float Allpercent;
    public float Allpercentmid;
    public Text percentTxt;
    public Text AllpercentTxt;
    public GameObject RythmGame;
    public GameObject select;
    public GameObject Building1;
    public GameObject Building2;
    public GameObject Building3;
    public PhotonView PV;
    [SerializeField] GameObject Player;
    public StateSave stateSave;
    GameObject[] MultiPlayer;
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        PV = GetComponent<PhotonView>();
        stateSave = GameObject.Find("StateSave").GetComponent<StateSave>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");

        inventoryUI = GameObject.Find("Canvas").transform.Find("Inventory").gameObject;
        weaponCreator = GameObject.Find("Canvas").transform.Find("WeaponCreator").gameObject;
        buildingCreator = GameObject.Find("Canvas").transform.Find("BuildingCreator").gameObject;
        percentTxt = GameObject.Find("Canvas").transform.Find("percent").gameObject.GetComponent<Text>();
        AllpercentTxt = GameObject.Find("Canvas").transform.Find("Allpercent").gameObject.GetComponent<Text>();
        RythmGame = GameObject.Find("Canvas").transform.Find("rythmImage").gameObject;
        select = GameObject.Find("Canvas").transform.Find("Select").gameObject;

        if(gameObject.name != "Player"){
            if(PV.IsMine){
                ButtonAlert = GameObject.Find("Canvas").transform.Find("BubbleWhiteSmall").gameObject;
                ButtonAlert2 = GameObject.Find("Canvas").transform.Find("BubbleWhiteSmall (2)").gameObject;
            }
        }
        
        controller = GetComponent<CharacterController>();

        if (SceneManager.GetActiveScene().name == "Pudding"){
            percent = GameObject.Find("SaveManager").GetComponent<Bpercent>().percent1;
        }
        else if (SceneManager.GetActiveScene().name == "Bread"){
            percent = GameObject.Find("SaveManager").GetComponent<Bpercent>().percent2;
        }
        else if (SceneManager.GetActiveScene().name == "Cheese"){
            percent = GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3;
        }
        Allpercent = GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent;
        Allpercentmid = GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid;

        select.GetComponent<SelectMod>().destroying = GameObject.Find("SaveManager").GetComponent<Bpercent>().state;

        if(select.GetComponent<SelectMod>().destroying == false){
            select.GetComponent<SelectMod>().Jaeryo.SetActive(false);
            select.GetComponent<SelectMod>().BuildingCrack.SetActive(true);
        }
    }

    void Move(){
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
            RemoveFocus();
        }

        controller.Move(moveDirection * Time.deltaTime);

        anim.SetBool("isWalk", moveVec != Vector3.zero);
    }

    // Update is called once per frame
    void Update()
    {
        MultiPlayer = GameObject.FindGameObjectsWithTag("Player");
        if(inventoryUI.activeSelf == true && weaponCreator.activeSelf == true){
            if(Input.GetButtonDown("Cancel")){
                weaponCreator.SetActive(false);
                inventoryUI.SetActive(false);
                //buildingCreator.SetActive(false);
                //ButtonAlert.SetActive(false);
            }
        }
        if(inventoryUI.activeSelf ==true && buildingCreator.activeSelf ==true)
        {
            if(Input.GetButtonDown("Cancel")){
                //weaponCreator.SetActive(false);
                inventoryUI.SetActive(false);
                buildingCreator.SetActive(false);
                //ButtonAlert.SetActive(false);
            }
        }
        if(inventoryUI.activeSelf == true || GameManager.MyGameManager.SelectPanel.activeSelf == true){
            
        }
        else{
            if(gameObject.name == "TownMultiPlayer(Clone)"){
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

            Debug.DrawRay(transform.position + transform.up * 3.0f, transform.forward * MaxDistance, Color.blue, 0.3f);
            if(Physics.Raycast(transform.position + transform.up * 3.0f, transform.forward, out hit, MaxDistance)){
                if(Input.GetButtonDown("GetItems")){
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if(interactable != null){
                        SetFocus(interactable);
                    }
                }
                if(select.GetComponent<SelectMod>().destroying == true)
                {
                    if(fork.activeSelf == true)
                    {
                        if(hit.transform.gameObject.tag == "WeaponCreator"){
                            EnterWeaponCreator();
                        }
                        else if(hit.transform.gameObject.tag == "Building")
                        {
                            anim.SetBool("isFix", moveVec != Vector3.zero);
                            
                            ButtonAlert2.SetActive(true);
                            //Debug.Log("왜안돼");
                            ButtonAlert2.GetComponentInChildren<Text>().text = "B";
                            if(Input.GetButtonDown("Break"))
                                RythmGame.SetActive(true);
                                //Debug.Log("건물 부수기");
                                Interactable interactable = hit.collider.GetComponent<Interactable>();
                            
                                    if(hit.collider.GetComponent<BreakBuilding>().count == 0)
                                    {
                                        hit.transform.gameObject.SetActive(false);
                                        if (hit.transform.gameObject == GameObject.Find("StateSave").GetComponent<StateSave>().Building[0]){
                                            GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[0] = 1;
                                            if(null != PV){
                                                PV.RPC("State", RpcTarget.All, 0);
                                            }
                                        }
                                        else if(hit.transform.gameObject == GameObject.Find("StateSave").GetComponent<StateSave>().Building[1]){
                                            GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[1] = 1;
                                            if(null != PV){
                                                PV.RPC("State", RpcTarget.All, 1);
                                            }
                                        }
                                        Instantiate(BuildingParticle, hit.transform.position, hit.transform.rotation);
                                        //BuildingWreck.SetActive(true);
                                        //Instantiate(BuildingWreck, hit.transform.position, hit.transform.rotation);
                                        hit.transform.gameObject.GetComponent<BreakBuilding>().BuildingWreck.SetActive(true);
                                       // PV.RPC("WreckTrue", RpcTarget.All, true);
                                        hit.transform.gameObject.GetComponent<BreakBuilding>().count = 1;
                                        
                                        ButtonAlert.SetActive(false);
                                        RythmGame.SetActive(false);
                                        percent += 17;
                                        Allpercentmid = Allpercentmid + 17;
                                        Allpercent = Mathf.Round(Allpercentmid/3);
                                        if(null != PV){
                                            PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                            MultiPlayer[1].GetComponent<MapIcePlayer>().PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                        }
                                    }                         
                        }
                        else{
                            ButtonAlert2.SetActive(false);
                            ButtonAlert.SetActive(false);
                            //print("dd");
                        }
                    }
                    else if(small.activeSelf == true)
                    {
                        if(hit.transform.gameObject.tag == "WeaponCreator"){
                            EnterWeaponCreator();
                        }
                        else if(hit.transform.gameObject.tag == "Building2")
                        {
                            anim.SetBool("isFix", moveVec != Vector3.zero);
                            
                            ButtonAlert2.SetActive(true);
                            //Debug.Log("왜안돼");
                            ButtonAlert2.GetComponentInChildren<Text>().text = "B";
                            if(Input.GetButtonDown("Break"))
                                RythmGame.SetActive(true);
                                //Debug.Log("건물 부수기");
                                Interactable interactable = hit.collider.GetComponent<Interactable>();
                            
                                    if(hit.collider.GetComponent<BreakBuilding>().count == 0)
                                    {
                                        hit.transform.gameObject.SetActive(false);
                                        if (hit.transform.gameObject == GameObject.Find("StateSave").GetComponent<StateSave>().Building[2]){
                                            GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[2] = 1;
                                            if(null != PV){
                                                PV.RPC("State", RpcTarget.All, 2);
                                            }
                                        }
                                        else if(hit.transform.gameObject == GameObject.Find("StateSave").GetComponent<StateSave>().Building[3]){
                                            GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[3] = 1;
                                            if(null != PV){
                                                PV.RPC("State", RpcTarget.All, 3);
                                            }
                                        }
                                        Instantiate(BuildingParticle, hit.transform.position, hit.transform.rotation);
                                        //BuildingWreck.SetActive(true);
                                        //Instantiate(BuildingWreck, hit.transform.position, hit.transform.rotation);
                                        hit.transform.gameObject.GetComponent<BreakBuilding>().BuildingWreck.SetActive(true);
                                       // PV.RPC("WreckTrue", RpcTarget.All, true);
                                        hit.transform.gameObject.GetComponent<BreakBuilding>().count = 1;

                                        ButtonAlert.SetActive(false);
                                        RythmGame.SetActive(false);
                                        percent += 17;
                                        Allpercentmid = Allpercentmid + 17;
                                        Allpercent = Mathf.Round(Allpercentmid/3);
                                        if(null != PV){
                                            PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                            MultiPlayer[1].GetComponent<MapIcePlayer>().PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                        }
                                    }                         
                        }
                        else{
                            ButtonAlert2.SetActive(false);
                        }
                    }
                    else if(medium.activeSelf == true)
                    {   
                        if(hit.transform.gameObject.tag == "WeaponCreator"){
                            EnterWeaponCreator();
                        }
                        else if(hit.transform.gameObject.tag == "Building3")
                        {
                            anim.SetBool("isFix", moveVec != Vector3.zero);
                        //Debug.Log("왜안돼");
                            ButtonAlert2.SetActive(true);
                            ButtonAlert2.GetComponentInChildren<Text>().text = "B";
                            if(Input.GetButtonDown("Break"))
                                RythmGame.SetActive(true);
                                //Debug.Log("건물 부수기");
                                Interactable interactable = hit.collider.GetComponent<Interactable>();
                                
                                    if(hit.collider.GetComponent<BreakBuilding>().count == 0)
                                    {
                                        hit.transform.gameObject.SetActive(false);
                                        if (hit.transform.gameObject == GameObject.Find("StateSave").GetComponent<StateSave>().Building[4]){
                                            GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[4] = 1;
                                            if(null != PV){
                                                PV.RPC("State", RpcTarget.All, 4);
                                            }
                                        }
                                        else if(hit.transform.gameObject == GameObject.Find("StateSave").GetComponent<StateSave>().Building[5]){
                                            GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[5] = 1;
                                            if(null != PV){
                                                PV.RPC("State", RpcTarget.All, 5);
                                            }
                                        }
                                        Instantiate(BuildingParticle, hit.transform.position, hit.transform.rotation);
                                        //BuildingWreck.SetActive(true);
                                        //Instantiate(BuildingWreck, hit.transform.position, hit.transform.rotation);
                                        hit.transform.gameObject.GetComponent<BreakBuilding>().BuildingWreck.SetActive(true);
                                       // PV.RPC("WreckTrue", RpcTarget.All, true);
                                        hit.transform.gameObject.GetComponent<BreakBuilding>().count = 1;

                                        ButtonAlert.SetActive(false);
                                        RythmGame.SetActive(false);
                                        percent += 17;
                                        Allpercentmid = Allpercentmid + 17;
                                        Allpercent = Mathf.Round(Allpercentmid/3);
                                        if(null != PV){
                                            PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                            MultiPlayer[1].GetComponent<MapIcePlayer>().PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                        }
                                    }
                                
                            
                        }
                        else{
                            ButtonAlert2.SetActive(false); 
                        }
                    }
                    else if(hit.transform.gameObject.tag == "WeaponCreator"){
                    ButtonAlert.SetActive(true);
                    ButtonAlert.GetComponentInChildren<Text>().text = "C";
                    if(Input.GetButtonDown("Enter")){
                        weaponCreator.SetActive(true);
                        inventoryUI.SetActive(true);
                    }   
                    }else{
                        ButtonAlert2.SetActive(false);
                        ButtonAlert.SetActive(false);
                    }
                }
                if(select.GetComponent<SelectMod>().destroying == false)
                {
                    weaponCreator.SetActive(false);
                    if(hit.transform.gameObject.tag == "WeaponCreator"){
                            EnterBuildingCreator();
                    }
                    if(Building1.activeSelf == true)
                    {
                        if(hit.transform.gameObject.tag == "WeaponCreator"){
                            EnterBuildingCreator();
                        }
                        else if(hit.transform.gameObject.tag == "BuildingWreck1")
                        {
                            anim.SetBool("isFix", moveVec != Vector3.zero);
                            //Debug.Log("왜안돼");
                            ButtonAlert2.SetActive(true);
                            ButtonAlert2.GetComponentInChildren<Text>().text = "B";
                            if(Input.GetButtonDown("Break"))
                                RythmGame.SetActive(true);
                                //Debug.Log("건물 부수기");
                                Interactable interactable = hit.collider.GetComponent<Interactable>();
                                
                                    if(hit.collider.GetComponent<BreakBuilding>().count == 0)
                                    {
                                        hit.transform.gameObject.SetActive(false);
                                        
                                        //Instantiate(BuildingParticle, hit.transform.position, hit.transform.rotation);
                                        //Instantiate(Building1, hit.transform.position, hit.transform.rotation);
                                        if (hit.transform.gameObject.name == "BulidingWreckfork1"){
                                                print("엉??");
                                                GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[0] = 0;
                                                if(null != PV){
                                                    PV.RPC("Statezero", RpcTarget.All, 0);
                                                }
                                            }
                                            else if(hit.transform.gameObject.name == "BulidingWreckfork2"){
                                                GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[1] = 0;
                                                if(null != PV){
                                                    PV.RPC("Statezero", RpcTarget.All, 1);
                                                }
                                            }
                                        
                                        hit.transform.gameObject.GetComponent<BreakBuilding>().BuildingWreck.SetActive(true);
                                       // PV.RPC("WreckTrue", RpcTarget.All, true);

                                        ButtonAlert2.SetActive(false);
                                        RythmGame.SetActive(false);
                                        percent += 17;
                                        Allpercentmid = Allpercentmid + 17;
                                        Allpercent = Mathf.Round(Allpercentmid/3);
                                        if(null != PV){
                                            PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                            MultiPlayer[1].GetComponent<MapIcePlayer>().PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                        }
                                    }
                                
                            
                        }
                        else{
                            ButtonAlert2.SetActive(false); 
                        }
                    }
                    else if(Building2.activeSelf == true)
                    {
                        if(hit.transform.gameObject.tag == "WeaponCreator"){
                            EnterBuildingCreator();
                        }
                        else if(hit.transform.gameObject.tag == "BuildingWreck2")
                        {
                            anim.SetBool("isFix", moveVec != Vector3.zero);
                            //Debug.Log("왜안돼");
                            ButtonAlert2.SetActive(true);
                            ButtonAlert2.GetComponentInChildren<Text>().text = "B";
                            if(Input.GetButtonDown("Break"))
                                RythmGame.SetActive(true);
                                //Debug.Log("건물 부수기");
                                Interactable interactable = hit.collider.GetComponent<Interactable>();
                                
                                    if(hit.collider.GetComponent<BreakBuilding>().count == 0)
                                    {
                                        hit.transform.gameObject.SetActive(false);
                                        //Instantiate(BuildingParticle, hit.transform.position, hit.transform.rotation);
                                        //Instantiate(Building1, hit.transform.position, hit.transform.rotation);
                                        if (hit.transform.gameObject.name == "BulidingWreckspoon1"){
                                                GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[2] = 0;
                                                if(null != PV){
                                                    PV.RPC("Statezero", RpcTarget.All, 2);
                                                }
                                            }
                                            else if(hit.transform.gameObject.name == "BulidingWreckspoon2"){
                                                GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[3] = 0;
                                                if(null != PV){
                                                    PV.RPC("Statezero", RpcTarget.All, 3);
                                                }
                                            }
                                        hit.transform.gameObject.GetComponent<BreakBuilding>().BuildingWreck.SetActive(true);

                                        ButtonAlert2.SetActive(false);
                                        RythmGame.SetActive(false);
                                        percent += 17;
                                        Allpercentmid = Allpercentmid + 17;
                                        Allpercent = Mathf.Round(Allpercentmid/3);
                                        if(null != PV){
                                            PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                            MultiPlayer[1].GetComponent<MapIcePlayer>().PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                        }
                                    }
                                
                            
                        }
                        else{
                            ButtonAlert2.SetActive(false); 
                        }
                    }
                    else if(Building3.activeSelf == true)
                    {
                        if(hit.transform.gameObject.tag == "WeaponCreator"){
                            EnterBuildingCreator();
                        }
                        else if(hit.transform.gameObject.tag == "BuildingWreck3")
                        {
                            anim.SetBool("isFix", moveVec != Vector3.zero);
                            //Debug.Log("왜안돼");
                            ButtonAlert2.SetActive(true);
                            ButtonAlert2.GetComponentInChildren<Text>().text = "B";
                            if(Input.GetButtonDown("Break"))
                                RythmGame.SetActive(true);
                                //Debug.Log("건물 부수기");
                                Interactable interactable = hit.collider.GetComponent<Interactable>();
                                
                                    if(hit.collider.GetComponent<BreakBuilding>().count == 0)
                                    {
                                        hit.transform.gameObject.SetActive(false);
                                        //Instantiate(BuildingParticle, hit.transform.position, hit.transform.rotation);
                                        //Instantiate(Building1, hit.transform.position, hit.transform.rotation);
                                        if (hit.transform.gameObject.name == "BulidingWreckLS1"){
                                                GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[4] = 0;
                                                if(null != PV){
                                                    PV.RPC("Statezero", RpcTarget.All, 4);
                                                }
                                            }
                                            else if(hit.transform.gameObject.name == "BulidingWreckLS2"){
                                                GameObject.Find("StateSave").GetComponent<StateSave>().statenumber[5] = 0;
                                                if(null != PV){
                                                    PV.RPC("Statezero", RpcTarget.All, 5);
                                                }
                                            }
                                        hit.transform.gameObject.GetComponent<BreakBuilding>().BuildingWreck.SetActive(true);

                                        ButtonAlert2.SetActive(false);
                                        RythmGame.SetActive(false);
                                        percent += 17;
                                        Allpercentmid = Allpercentmid + 17;
                                        Allpercent = Mathf.Round(Allpercentmid/3);
                                        if(null != PV){
                                            PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                            MultiPlayer[1].GetComponent<MapIcePlayer>().PV.RPC("percentsync", RpcTarget.All, percent, Allpercent, Allpercentmid);
                                        }
                                    }
                                
                            
                        }
                        else{
                            ButtonAlert2.SetActive(false); 
                        }
                    }
                    else if(hit.transform.gameObject.tag == "WeaponCreator"){
                        ButtonAlert.SetActive(true);
                        ButtonAlert.GetComponentInChildren<Text>().text = "C";
                        if(Input.GetButtonDown("Enter")){
                            //weaponCreator.SetActive(true);
                            inventoryUI.SetActive(true);
                        }
                        
                    }else{
                        ButtonAlert.SetActive(false);
                        ButtonAlert2.SetActive(false);
                    }
                }
            }
        }
        percentTxt.text = percent.ToString() + "%";
        AllpercentTxt.text = Allpercent.ToString() + "%";
        if(percent > 100){
            percent = 100;
        }
        if(Allpercent > 100){
            Allpercent = 100;
        }
        if(Allpercentmid > 300){
            Allpercentmid = 300;
        }
    }

    void SetFocus (Interactable newFocus){
        if(newFocus != focus){
            if(focus != null)
                focus.OnDefocused();

            focus = newFocus;
        }
        
        newFocus.OnFocused(transform);
    }

    void RemoveFocus(){
        if(focus != null)
            focus.OnDefocused();
            
        focus = null;
        
    }

    void EnterWeaponCreator()
    {
        ButtonAlert.SetActive(true);
        ButtonAlert.GetComponentInChildren<Text>().text = "C";
        if(Input.GetButtonDown("Enter")){
            weaponCreator.SetActive(true);
            inventoryUI.SetActive(true);
        }
    }

    void EnterBuildingCreator()
    {
        ButtonAlert.SetActive(true);
        ButtonAlert.GetComponentInChildren<Text>().text = "C";
        if(Input.GetButtonDown("Enter")){
            buildingCreator.SetActive(true);
            inventoryUI.SetActive(true);
        }
    }

    [PunRPC]
    void State(int i)
    {
        Debug.Log(("1불려지는 중"));
        stateSave.statenumber[i] = 1;
    }

    [PunRPC]
    void Statezero(int i)
    {
        Debug.Log(("2불려지는 중"));
        stateSave.statenumber[i] = 0;
    }

    [PunRPC]
    void percentsync(int percent, float Allpercent, float Allpercentmid)
    {
        gameObject.GetComponent<MapIcePlayer>().percent = percent;
        gameObject.GetComponent<MapIcePlayer>().Allpercent = Allpercent;
        gameObject.GetComponent<MapIcePlayer>().Allpercentmid = Allpercentmid;
    }
    
    [PunRPC]
    void smallItemMulti(bool b){
        Debug.Log(("4불려지는 중"));
        if(!PV.IsMine){
            gameObject.transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("SmallSpoon3D").gameObject.SetActive(true);
            gameObject.transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("MediumSpoon3D").gameObject.SetActive(false);
            gameObject.transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("Fork (1)").gameObject.SetActive(false);
        }
    }

    [PunRPC]
    void mediumItemMulti(bool b){
        Debug.Log(("5불려지는 중"));
        if(!PV.IsMine){
            gameObject.transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("SmallSpoon3D").gameObject.SetActive(false);
            gameObject.transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("MediumSpoon3D").gameObject.SetActive(true);
            gameObject.transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("Fork (1)").gameObject.SetActive(false);
        }
    }

    [PunRPC]
    void forkItemMulti(bool b){
        Debug.Log(("6불려지는 중"));
        if(!PV.IsMine){
            gameObject.transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("SmallSpoon3D").gameObject.SetActive(false);
            gameObject.transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("MediumSpoon3D").gameObject.SetActive(false);
            gameObject.transform.Find("Bone002").transform.Find("Bone009").transform.Find("Bone030").transform.Find("Fork (1)").gameObject.SetActive(true);                     
        }
    }

    [PunRPC]
    void EnterB(string b)
    {
        Debug.Log("비 불려지는중");
        SceneManager.LoadScene(b);
        DontDestroyOnLoad(GameObject.Find("DeleteTimeline"));
        //PhotonNetwork.AutomaticallySyncScene = true;
    }

    [PunRPC]
    void BpercentSyncp(int percent, float Allpercent, float Allpercentmid)
    {
        GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent = Allpercent;
        GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid = Allpercentmid;
        GameObject.Find("SaveManager").GetComponent<Bpercent>().percent1 = percent;
        //PhotonNetwork.AutomaticallySyncScene = true;
    }

    [PunRPC]
    void BpercentSyncb(int percent, float Allpercent, float Allpercentmid)
    {
        GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent = Allpercent;
        GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid = Allpercentmid;
        GameObject.Find("SaveManager").GetComponent<Bpercent>().percent2 = percent;
        //PhotonNetwork.AutomaticallySyncScene = true;
    }

    [PunRPC]
    void BpercentSyncc(int percent, float Allpercent, float Allpercentmid)
    {
        GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercent = Allpercent;
        GameObject.Find("SaveManager").GetComponent<Bpercent>().Allpercentmid = Allpercentmid;
        GameObject.Find("SaveManager").GetComponent<Bpercent>().percent3 = percent;
        //PhotonNetwork.AutomaticallySyncScene = true;
    }
}