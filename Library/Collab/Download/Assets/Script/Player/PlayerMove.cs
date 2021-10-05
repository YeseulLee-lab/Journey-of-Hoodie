using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    int i;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        i = 0;
        _animation = GetComponent<Animation>();
    }
    void Awake()
    {
        _animation = GetComponent<Animation>();
        if (!_animation)
            Debug.Log("The character you would like to control doesn't have animations. " +
                "Moving her might look weird.");

        //Idle = GetComponent<AnimationClip>();
    }

    void Start_Action()
    {
        manager.StartAction();
        Destroy(manager.Questimage, 3);
        Destroy(manager.Quest, 3);
        Destroy(manager.Question, 3);
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
        print(i);
    }

    // Update is called once per frame
    void Update()
    {
        if (i == 0)
        {          
            _animation.Play("Start");
            Invoke("plus", 3);
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
            //controller.Move(moveDirection * Time.deltaTime);

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

            Debug.DrawRay(transform.position, transform.forward * MaxDistance, Color.blue, 0.3f);
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (Physics.Raycast(transform.position + transform.up * 0.75f, transform.forward, out hit, MaxDistance))
                {
                    scanObject = hit.transform.gameObject;
                    manager.Action(scanObject);
                }
            }
        }
    }
}
