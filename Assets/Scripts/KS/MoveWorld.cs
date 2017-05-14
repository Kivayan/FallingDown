using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorld : MonoBehaviour {

    public float worldSpeed;
    public Transform target;


	// Use this for initialization
	void Start () {


		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * worldSpeed);
	}
}
