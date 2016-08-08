using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]

//simplifies Unity Standard Assets ThirdPersonCharacter & AICharacterControl
public class ThdPersonController : MonoBehaviour {

	private NavMeshAgent agent;
	private Transform currentDest;

	void Start () {
		agent = GetComponent<NavMeshAgent>();
	}

	public void SetTarget(Transform point) {
		currentDest = point;
		agent.SetDestination(point.position);
	}

	void Update () {
		if (currentDest != null) {
			agent.SetDestination(currentDest.position); }
		/*
		if (agent.remainingDistance > agent.stoppingDistance)
			obj.Move(agent.desiredVelocity, false, false);
		else
			obj.Move(Vector3.zero, false, false);	
		*/
	}
}
