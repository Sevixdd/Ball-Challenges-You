using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement: MonoBehaviour {

    [SerializeField] private Ball minge;
	
	// Update is called once per frame
	private void Update () {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("button down");
        }
        if (Input.GetMouseButtonUp(0))
        {
            minge.Launch(100f);
        }
		
	}
}
