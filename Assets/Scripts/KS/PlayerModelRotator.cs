using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelRotator : MonoBehaviour {

    
	void Update () {

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
	}
}
