using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour {

    [SerializeField] private Ball minge;

    private float holdDownStartTime;
	// Update is called once per frame
	private void Update () {
        if (Input.GetMouseButtonDown(0)){
            holdDownStartTime = Time.time;
        }
        if(Input.GetMouseButton(0))
        {
            float holdDownTimes = Time.time - holdDownStartTime;
            minge.ShowForce(CalculateHoldDownForce(holdDownTimes));
        }
        if (Input.GetMouseButtonUp(0))
        {
            float holdDownTime = Time.time - holdDownStartTime;
            minge.Launch(CalculateHoldDownForce(holdDownTime));
        }
		
	}

    private float CalculateHoldDownForce(float holdTime)
    {
        float maxForceHoldDownTime = 1f;
        float holdTimeNormalized = Mathf.Clamp01(holdTime / maxForceHoldDownTime);
        float force = holdTimeNormalized * Ball.MAX_FORCE;
        return force;
    }
}
