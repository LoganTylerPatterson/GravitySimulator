using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityCalculator : MonoBehaviour
{ 
	//Newton Formula for Gravity given by Force(gravity) = G * mass1 * mass2 / r^2
	private float G = (float) 6.67;
	private Vector3 orbiterPosition;
	private Vector3 orbiteePosition;
	
	public Vector3 calculateGravForce(GameObject orbitee, GameObject orbiter)
	{
		//Get the position and mass of the objects
		orbiterPosition = orbiter.transform.position;
		float orbiterMass = orbiter.GetComponent<Rigidbody>().mass;
		orbiteePosition = orbitee.transform.position;
		float orbiteeMass = orbitee.GetComponent<Rigidbody>().mass;

		//Calculate distance between the objects (r)
		float distance = Vector3.Distance(orbiterPosition, orbiteePosition);
		float distanceSquared = distance * distance;
		//Calculate force with equation above
		float force = G * orbiterMass * orbiteeMass / distanceSquared;
		Debug.Log(force);
		//Calculate heading
		Vector3 heading = (orbiterPosition - orbiteePosition);
		//Calculate force and a direction vector
		Vector3 forceAndDirection = (force * (heading/ heading.magnitude));
		
		return forceAndDirection;
	}

	public float CalculateVelocity(GameObject satellite, GameObject central)
	{
		float distance = Vector3.Distance(satellite.transform.position, central.transform.position);
		float velocity = Mathf.Sqrt((central.GetComponent<Rigidbody>().mass * G) / distance);
		return velocity;
	}
}
