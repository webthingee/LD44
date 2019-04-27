using UnityEngine;
using MyEvents;
using Prime31;

public class PlayerMovement : MonoBehaviour
{
	// movement config
	public float gravity = -25f;
	public float runSpeed = 8f;
	public float groundDamping = 20f; // how fast do we change direction? higher means faster
	public float inAirDamping = 5f;
	
	private Vector2 floorPoint;
	private Vector2 gotoFloorPoint;

	[HideInInspector]
	private float normalizedHorizontalSpeed = 0;

	private CharacterController2D _controller;
	private RaycastHit2D _lastControllerColliderHit;
	private Vector3 _velocity;


	void Awake()
	{
		_controller = GetComponent<CharacterController2D>();

		// listen to some events for illustration purposes
		_controller.onControllerCollidedEvent += onControllerCollider;
		_controller.onTriggerEnterEvent += onTriggerEnterEvent;
		_controller.onTriggerExitEvent += onTriggerExitEvent;
	}
	
	private void OnEnable()
	{
		FloorPointEvent.RegisterListener(OnFloorPointEvent);
	}

	#region Event Listeners

	void onControllerCollider( RaycastHit2D hit )
	{
		// bail out on plain old ground hits cause they arent very interesting
		if( hit.normal.y == 1f )
			return;

		// logs any collider hits if uncommented. it gets noisy so it is commented out for the demo
		//Debug.Log( "flags: " + _controller.collisionState + ", hit.normal: " + hit.normal );
	}


	void onTriggerEnterEvent( Collider2D col )
	{
		Debug.Log( "onTriggerEnterEvent: " + col.gameObject.name );
	}


	void onTriggerExitEvent( Collider2D col )
	{
		Debug.Log( "onTriggerExitEvent: " + col.gameObject.name );
	}

	#endregion

	// the Update loop contains a very simple example of moving the character around and controlling the animation
	void Update()
	{		
		if (Input.GetMouseButtonUp(0))
		{
			if (floorPoint != null) gotoFloorPoint = floorPoint;
		}

		if (_controller.isGrounded)
		{
			_velocity.y = 0;
		}
			
		if (Mathf.Abs(transform.position.x - gotoFloorPoint.x) > 0.3f)
		{
			if (transform.position.x - gotoFloorPoint.x > 0.2f)
			{
				normalizedHorizontalSpeed = -1;
				if (transform.localScale.x > 0f)
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
				}
			}
			else if (transform.position.x - gotoFloorPoint.x < 0.2f)
			{
				normalizedHorizontalSpeed = 1;
				if (transform.localScale.x < 0f)
				{
					transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, 0);
				}
			}
		}
		else
		{
			normalizedHorizontalSpeed = 0;
		}

		// apply horizontal speed smoothing it. dont really do this with Lerp. Use SmoothDamp or something that provides more control
		var smoothedMovementFactor = _controller.isGrounded ? groundDamping : inAirDamping; // how fast do we change direction?
		_velocity.x = Mathf.Lerp( _velocity.x, normalizedHorizontalSpeed * runSpeed, Time.deltaTime * smoothedMovementFactor );

		// apply gravity before moving
		_velocity.y += gravity * Time.deltaTime;

		// over write vertical velocity
		if (normalizedHorizontalSpeed == 0) _velocity.y = 0;
		
		_controller.move( _velocity * Time.deltaTime );

		// grab our current _velocity to use as a base for all calculations
		_velocity = _controller.velocity;
	}
	
	private void OnFloorPointEvent(FloorPointEvent e)
	{
		//Debug.Log("PlayerMovement sees floor point at: " + e.floorPoint);
		floorPoint = e.floorPoint;
	}
}