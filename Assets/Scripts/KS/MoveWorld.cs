using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorld : MonoBehaviour {

    public float worldSpeed;
    public Transform target;

	void FixedUpdate () {

        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * worldSpeed);
	}
}
