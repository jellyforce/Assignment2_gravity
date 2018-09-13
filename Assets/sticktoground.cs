using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sticktoground : MonoBehaviour {
    public int rotationSpeed = 100;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		if(Physics.Raycast(transform.position, -transform.up, out hit,  1.5f)){
			Debug.Log("player cast ray to floor");


			//ransform.position = hit.transform.position;
			//.Rotate(hit.transform.eulerAngles, Space.World);

			// Quaternion newRotation = Quaternion.FromToRotation(transform.position, hit.transform.position);

			// transform.Rotate(newRotation.eulerAngles);

			//             //store the roation
            // Quaternion objectRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            // transform.rotation = Quaternion.Lerp(transform.rotation, objectRotation, rotationSpeed * Time.deltaTime);

		}
		
	}
}
