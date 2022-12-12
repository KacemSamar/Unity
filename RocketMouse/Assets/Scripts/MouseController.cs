using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseController : MonoBehaviour {
	public float jetpackForce = 75.0f; 
	public float forwardMovementSpeed = 3.0f; 
	public Transform groundCheckTransform;
	private bool grounded; 
	public LayerMask groundCheckLayerMask;
	public ParticleSystem jetpack; 
	public Text sc;
	Animator animator; 
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>(); 

	}
	
	// Update is called once per frame
	void FixedUpdate ()
	{
		sc.text = coin.score.ToString();
		bool jetpackActive = Input.GetButton("Fire1");
		if (jetpackActive)
		{
			GetComponent<Rigidbody2D>().AddForce(new Vector2(0,
				jetpackForce));
		}
		Vector2 newVelocity = GetComponent<Rigidbody2D> ().velocity;
		newVelocity.x = forwardMovementSpeed;
		GetComponent<Rigidbody2D> ().velocity = newVelocity;
		UpdateGroundedStatus(); 
		AdjustJetpack(jetpackActive); 

	}
	void UpdateGroundedStatus()
		{
		//1
		grounded = Physics2D.OverlapCircle(groundCheckTransform.position, 0.1f,
		groundCheckLayerMask);
		//2
		animator.SetBool("grounded", grounded);
		} 
		void AdjustJetpack (bool jetpackActive)
{
 jetpack.enableEmission = !grounded;
 jetpack.emissionRate = jetpackActive ? 300.0f : 75.0f;
} 
}
