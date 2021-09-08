using System.Collections;
using System.Collections.Generic;
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
    public GameObject ButtonAlert;
    public GameObject BuildingParticle;
    public GameObject small;
    public GameObject medium;
    public GameObject fork;
    public int percent;
    public float Allpercent;
    public Text percentTxt;
    public Text AllpercentTxt;
    public GameObject RythmGame;
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Pudding"){
            percent = GameObject.Find("percentManager").GetComponent<Bpercent>().percent1;
           // percent = 40;
        }
        else if (SceneManager.GetActiveScene().name == "Bread"){
            percent = GameObject.Find("percentManager").GetComponent<Bpercent>().percent2;
            percent = 15;
        }
        else if (SceneManager.GetActiveScene().name == "Cheese"){
            percent = GameObject.Find("percentManager").GetComponent<Bpercent>().percent3;
            percent = 47;
        }

        Allpercent = GameObject.Find("percentManager").GetComponent<Bpercent>().Allpercentmid;
        controller = GetComponent<CharacterController>();
        //percent = 34;
        //percentTxt.text = percent.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        if(inventoryUI.activeSelf == true && weaponCreator.activeSelf == true){
            if(Input.GetButtonDown("Cancel")){
                weaponCreator.SetActive(false);
                inventoryUI.SetActive(false);
            }
        }
        if(inventoryUI.activeSelf == true || GameManager.MyGameManager.SelectPanel.activeSelf == true){
            
        }
        else{
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

            Debug.DrawRay(transform.position + transform.up * 3.0f, transform.forward * MaxDistance, Color.blue, 0.3f);
            if(Physics.Raycast(transform.position + transform.up * 3.0f, transform.forward, out hit, MaxDistance)){
                if(Input.GetButtonDown("GetItems")){
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if(interactable != null){
                        SetFocus(interactable);
                    }
                }
                else if(fork.activeSelf == true)
                {
                    if(hit.transform.gameObject.tag == "WeaponCreator"){
                        EnterWeaponCreator();
                    }
                    else if(hit.transform.gameObject.tag == "Building")
                    {
                        anim.SetBool("isFix", moveVec != Vector3.zero);
                       //Debug.Log("왜안돼");
                        ButtonAlert.SetActive(true);
                        ButtonAlert.GetComponentInChildren<Text>().text = "B";
                        if(Input.GetButtonDown("Break"))
                            RythmGame.SetActive(true);
                            //Debug.Log("건물 부수기");
                            Interactable interactable = hit.collider.GetComponent<Interactable>();
                           
                                if(hit.collider.GetComponent<BreakBuilding>().count == 0)
                                {
                                    hit.transform.gameObject.SetActive(false);
                                    Instantiate(BuildingParticle, hit.transform.position, hit.transform.rotation);
                                    ButtonAlert.SetActive(false);
                                    percent += 14;
                                    RythmGame.SetActive(false);
                                    Allpercent = Mathf.Round((Allpercent + percent)/3);
                                }                         
                    }
                    else{
                        ButtonAlert.SetActive(false);
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
                       //Debug.Log("왜안돼");
                        ButtonAlert.SetActive(true);
                        ButtonAlert.GetComponentInChildren<Text>().text = "B";
                        if(Input.GetButtonDown("Break"))
                            RythmGame.SetActive(true);
                            //Debug.Log("건물 부수기");
                            Interactable interactable = hit.collider.GetComponent<Interactable>();
                            
                                if(hit.collider.GetComponent<BreakBuilding>().count == 0)
                                {
                                    hit.transform.gameObject.SetActive(false);
                                    Instantiate(BuildingParticle, hit.transform.position, hit.transform.rotation);
                                    ButtonAlert.SetActive(false);
                                    percent += 14;
                                    RythmGame.SetActive(false);
                                    Allpercent = Mathf.Round((Allpercent + percent)/3);
                                }
                            
                        
                    }
                    else{
                        ButtonAlert.SetActive(false);
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
                        ButtonAlert.SetActive(true);
                        ButtonAlert.GetComponentInChildren<Text>().text = "B";
                        if(Input.GetButtonDown("Break"))
                            RythmGame.SetActive(true);
                            //Debug.Log("건물 부수기");
                            Interactable interactable = hit.collider.GetComponent<Interactable>();
                            
                                if(hit.collider.GetComponent<BreakBuilding>().count == 0)
                                {
                                    hit.transform.gameObject.SetActive(false);
                                    Instantiate(BuildingParticle, hit.transform.position, hit.transform.rotation);
                                    ButtonAlert.SetActive(false);
                                    percent += 14;
                                    RythmGame.SetActive(false);
                                    Allpercent = Mathf.Round((Allpercent + percent)/3);
                                }
                            
                        
                    }
                    else{
                        ButtonAlert.SetActive(false); 
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
                    ButtonAlert.SetActive(false);
                }
            }
        }
        percentTxt.text = percent.ToString() + "%";
        AllpercentTxt.text = Allpercent.ToString() + "%";
        if(Allpercent >= 50){
            print("세뇌푸나요?");
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

}
