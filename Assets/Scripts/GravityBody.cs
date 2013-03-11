using UnityEngine;
using System.Collections;

public class GravityBody : MonoBehaviour {
	
	public GravityManager GM;
	
	public Vector3 Velocity = Vector3.zero;
	public Vector3 RotVelocity = Vector3.zero;
	
	public float Mass;
	
	public bool HasProjection;
	LineRenderer MyLR;
	Vector3 ProjectionRunner;
	
	
	// Use this for initialization
	void Start () {
		GM = GameObject.Find("GravityManager").GetComponent<GravityManager>();
		GM.GravityBodyList.Add(this);
		if(HasProjection)
		{
			MyLR = this.gameObject.GetComponent<LineRenderer>();	
		}
	}
	
	// Update is called once per frame
	void Update () {
		Move();
		if(HasProjection)
		{
			Project();	
		}
	}
	
	void Move()
	{
		Velocity.z = 0;
		if(Mass == 0){Debug.LogWarning(this.gameObject.name + "Gravity body Mass is equal to zero!");}
		this.transform.position += Velocity*Time.deltaTime;
		this.transform.Rotate(RotVelocity*Time.deltaTime,Space.Self);
	}
	
	void Project()
	{
		int ProjectionResolution = 1;
		float ProjectionLength = 300;
		MyLR.SetWidth(transform.localScale.x, transform.localScale.x);
		
		MyLR.SetVertexCount(ProjectionResolution);
		
		ProjectionRunner = this.transform.position; 
		float RunningProjectionLength = 0;
		
		Vector3 ProjectionRunnerVelocity = Velocity;
		
	
		MyLR.SetPosition(0, this.transform.position);
		
		Vector3 PreviousPoint = this.transform.position;
		
		while(RunningProjectionLength < ProjectionLength)
		{
			foreach(GravityAttractor GA in GM.GravityAttractorList)
			{
				ProjectionRunnerVelocity += GA.Pull(ProjectionRunner,Mass);
			}
			
			ProjectionRunner += ProjectionRunnerVelocity*GM.PM.AverageDeltaTime;
			
			ProjectionResolution+=1;
			MyLR.SetVertexCount(ProjectionResolution);
			
			MyLR.SetPosition(ProjectionResolution-1, ProjectionRunner);
			
			RunningProjectionLength += Vector3.Distance(PreviousPoint,ProjectionRunner);
				
			PreviousPoint = ProjectionRunner;
		}
		
		

	}
	
	void OnGUI()
	{
			
	}
}
