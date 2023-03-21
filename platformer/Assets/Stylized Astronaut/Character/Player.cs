using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {


	[SerializeField] private float forceMagnitude;

		private Animator anim;
		private CharacterController controller;

		

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		private Vector3 moveDirection = Vector3.zero;
		public float gravity = 20.0f;

		void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

		void Update (){
			if (Input.GetKey ("w") || Input.GetKey ("s")) {
				anim.SetInteger ("AnimationPar", 1);
			}  else {
				anim.SetInteger ("AnimationPar", 0);
			}

			if(controller.isGrounded){
				moveDirection = transform.forward * Input.GetAxis("Vertical") * speed;
			}

			float turn = Input.GetAxis("Horizontal");
			transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
			controller.Move(moveDirection * Time.deltaTime);
			moveDirection.y -= gravity * Time.deltaTime;
		}

		private void OnControllerColliderHit(ControllerColliderHit hit) {
			Rigidbody rigidbody = hit.collider.attachedRigidbody;

			if(rigidbody != null) {
				Vector3 forceDirection = hit.gameObject.transform.position - transform.position;
				forceDirection.y = 0;
				forceDirection.Normalize();

				rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
			}
		}
}
