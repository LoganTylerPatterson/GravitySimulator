using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{

    GameObject gameManager;
    GravityCalculator calc;
    Rigidbody rb;
    GameObject sun;
    [SerializeField] float velocity;
    [SerializeField] ParticleSystem p;

    [SerializeField] bool shouldOrbit = true;
    [SerializeField] float necSpeed;
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        calc = gameManager.GetComponent<GravityCalculator>();
        rb = gameObject.GetComponent<Rigidbody>();
        sun = GameObject.Find("Sun");
        //Have to kick start the orbit 
        necSpeed = calc.CalculateVelocity(gameObject, sun);

        if(shouldOrbit)
        {
            rb.velocity = new Vector3(necSpeed, 0, 0);
        }
        necSpeed = calc.CalculateVelocity(gameObject, sun);
        Instantiate(p, gameObject.transform);
        p.Play();
    }

    void Update()
    {
        if(shouldOrbit){
            Vector3 force = calc.calculateGravForce(gameObject, sun);
            rb.AddForce(force);
        }
        velocity = rb.velocity.magnitude;
    }
}
