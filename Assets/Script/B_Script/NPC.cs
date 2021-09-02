using UnityEngine;
using System.Collections;

public class NPC: FSM 
{
	public enum FSMState
	{
		None,
		Normal,
		Chase,
		Attack
	}
	
	//Current state that the NPC is reaching
	public FSMState curState;
	private float curSpeed;
	
	public float speed = 20.0f;
	public float mass = 5.0f;
	public float force = 50.0f;
	public float minimumDistToAvoid = 20.0f;
	private float curRotSpeed;
	Animator anim;
    Vector3 moveVec;
	private Vector3 destPos;
    public string tag;
	//public GUISkin skin;
	
    void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

	protected override void Initialize () 
	{
		mass = 5.0f; 
		curState = FSMState.Normal;
		curSpeed = 30.0f;
		elapsedTime = 0.0f;
		curRotSpeed = 2.0f;
		destPos = Vector3.zero;
		
		
		//Get the list of points
		pointList = GameObject.FindGameObjectsWithTag(tag);
		
		//Set Random destination point first
		FindNextPoint();
		
		//Get the target enemy(Player)
		GameObject objPlayer = GameObject.FindGameObjectWithTag(tag);
		playerTransform = objPlayer.transform;
		
		if(!playerTransform)
			print("Player doesn't exist.. Please add one with Tag named 'Player'");
	}
	
	//Update each frame
	protected override void FSMUpdate()
	{
		switch (curState)
		{
		case FSMState.Normal: UpdateNormalState(); break;
		case FSMState.Attack: UpdateAttackState(); break;
		}
		elapsedTime += Time.deltaTime;
	}
	
	protected void UpdateNormalState()
	{
		//Find another random patrol point if the current point is reached
		if (Vector3.Distance(transform.position, destPos) <= 5.0f)
		{
            
			curState = FSMState.Attack;
            Debug.Log("랄라!");
		}
		
		// if (Vector3.Distance(transform.position, playerTransform.position) <= 10.0f)
		// {
		// 	curState = FSMState.Chase;
		// }
		
		walk ();

	}
	
	
	protected void FindNextPoint()
	{
		Debug.Log("진짜루 다음 목적지");
		int rndIndex = Random.Range(0, pointList.Length);
		float rndRadius = 10.0f;
		
		Vector3 rndPosition = Vector3.zero;
		destPos = pointList[rndIndex].transform.position + rndPosition;
		
		//Check Range
		//Prevent to decide the random point as the same as before
		if (IsInCurrentRange(destPos))
		{
			rndPosition = new Vector3(Random.Range(-rndRadius, rndRadius), 0.0f, Random.Range(-rndRadius, rndRadius));
			destPos = pointList[rndIndex].transform.position + rndPosition;
		}
	}
	
	
	protected void UpdateAttackState(){
		int i = 0;
		if(pointList[i].activeSelf == true)
		{
			if (pointList[i].activeSelf == false)
			{
				i += 1;
				Debug.Log("다음 목적지" + i);
				
				FindNextPoint();
				curState = FSMState.Normal;
				
			}
		}
		
		//i++;
		anim.SetBool("isFix", true);
	}
	
	
	protected bool IsInCurrentRange(Vector3 pos)
	{
		float xPos = Mathf.Abs(pos.x - transform.position.x);
		float zPos = Mathf.Abs(pos.z - transform.position.z);
		
		if (xPos <= 50 && zPos <= 50)
			return true;
		
		return false;
	}
	
	public void AvoidObstacles(ref Vector3 dir)
	{
		RaycastHit hit;
		
		int layerMask = 1 << 9;
		
		//Check that the vehicle hit with the obstacles within it's minimum distance to avoid
		if (Physics.Raycast(transform.position, transform.forward, out hit, minimumDistToAvoid, layerMask))
		{
			//Get the normal of the hit point to calculate the new direction
			Vector3 hitNormal = hit.normal;
			hitNormal.y = 0.0f; //Don't want to move in Y-Space
			
			//Get the new directional vector by adding force to vehicle's current forward vector
			dir = transform.forward + hitNormal * force;
		}
	}
	
	public void walk(){
		curSpeed = speed * Time.deltaTime;
		Vector3 dir = (destPos - transform.position);
		dir.Normalize();
		AvoidObstacles(ref dir);
		//Rotate the vehicle to its target directional vector
		var rot = Quaternion.LookRotation(dir);
		transform.rotation = Quaternion.Slerp(transform.rotation, rot, 5.0f *  Time.deltaTime);
		anim.SetBool("isWalk", true);
		//Move the vehicle towards
		transform.position += transform.forward * curSpeed;
	}
	
}