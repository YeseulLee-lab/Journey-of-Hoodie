using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public CharacterController controller;

    private Animation _animation;
    public AnimationClip Idle;
    public AnimationClip Walk;
    public AnimationClip Start1;
    public AnimationClip Stand;

    private Vector3 moveDirection;
    public float gravityScale;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    float hAxis;
    float vAxis;
    Vector3 moveVec;

    RaycastHit hit;
    float MaxDistance = 15f;
    public GameObject scanObject;
    public GameManager manager;
    public TalkManager talkManager;
    public TriggerManager triggerManager;
    public Sprite playerSprite;
    public GameObject QuestButton;
    public Image Portrait;
    public bool isAlive;
    public GameObject talkpanel;
    public GameObject[] timeline;
    public GameObject[] trigger;
    int i;
    public int a;

    public GameObject Diary;
    // Start is called before the first frame update
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        i = 0;
        _animation = GetComponent<Animation>();

        if (i == 0)
        {
            Invoke("plus", 3);      //invoke는 스타트에 넣어야 잘됨
        }

        isAlive = true;

        //a = 1;

        moveSpeed = 0;
    }
    void Awake()
    {
        _animation = GetComponent<Animation>();
        if (!_animation)
            Debug.Log("The character you would like to control doesn't have animations. " +
                "Moving her might look weird.");

        //Idle = GetComponent<AnimationClip>();
    }

    void Quest_Action()
    {
        manager.QuestionAction();
    }

    void plus()
    {
        for (; i < 4; i++)
        {
            _animation.Play("Stand");
        }

        Invoke("Quest_Action", 1);
    }

    // Update is called once per frame
    void Update()
    {
        if(QuestButton.activeSelf == true || talkpanel.activeSelf == true){
            isAlive = false;
        }
        else{
            isAlive = true;
        }

        if(Diary.activeSelf == true)
        {

        }else if(isAlive){
            moveSpeed = 12;
            Move();
        }

        switch(a){
            case 1:
                timeline[a-1].SetActive(true);
                break;
            case 2:
                timeline[a-2].SetActive(false);
                timeline[a-1].SetActive(true);
                break;
            case 3:
                timeline[a-2].SetActive(false);
                timeline[a-1].SetActive(true);
                break;
            case 4:
                timeline[a-2].SetActive(false);
                timeline[a-1].SetActive(true);
                break;
            case 5:
                timeline[a-2].SetActive(false);
                timeline[a-1].SetActive(true);
                break;
        }

        if(Portrait.sprite == playerSprite)         //독백시 스페이스 누르면 스프라이트 none으로 바꿔서 대화창 다시 못나오게
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                manager.Action(gameObject);     //대화 다 끝났을 경우의 코드 추가하기 if문 대화 인덱스가 끝인지
                Portrait.sprite = null;
                manager.isSavable = false;
            }               
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if((null != trigger[a-1]) && (null != timeline[a-1])){
                return;
            }
            else{
                if (Physics.Raycast(transform.position + transform.up * 0.75f, transform.forward, out hit, MaxDistance))
                {
                    scanObject = hit.transform.gameObject;
                    manager.Action(scanObject);
                }
            }
        }
    }

    void Move(){
        if (i == 0)
        {
            _animation.Play("Start");
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);

            hAxis = Input.GetAxisRaw("Horizontal");
            vAxis = Input.GetAxisRaw("Vertical");

            moveVec = new Vector3(hAxis, 0, vAxis).normalized;

            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }

            moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);

            if (moveVec.magnitude >= 0.1f)
            {
                float targetAngle = Mathf.Atan2(moveVec.x, moveVec.z) * Mathf.Rad2Deg;
                float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                transform.rotation = Quaternion.Euler(0f, angle, 0f);
            }

            controller.Move(moveDirection * Time.deltaTime);

            if (hAxis >= 0.1f)
            {
                _animation.CrossFade(Walk.name);
            }
            else if (hAxis <= -0.1f)
            {
                _animation.CrossFade(Walk.name);
            }
            else if (vAxis >= 0.1f)
            {
                _animation.CrossFade(Walk.name);
            }
            else if (vAxis <= -0.1f)
            {
                _animation.CrossFade(Walk.name);
            }
            else
            {
                _animation.CrossFade(Idle.name);
            }   

            Debug.DrawRay(transform.position + transform.up * 0.75f, transform.forward * MaxDistance, Color.blue, 0.3f);
        }                           
    }
}