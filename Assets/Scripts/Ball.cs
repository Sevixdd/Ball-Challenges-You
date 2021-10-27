using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]

public class Ball: MonoBehaviour {
    // Vector2 Direction =
    [SerializeField] private Transform forceTransform;
    [SerializeField] private Transform Arrow;
    public Transform shotPoint;
    Vector2 dir;


    private SpriteMask forceSpriteMask;

    void Start()
    {
        forceSpriteMask = forceTransform.Find("mask").GetComponent<SpriteMask>();
       // forceSpriteMask = Arrow.Find("mask").GetComponent<SpriteMask>();
        HideForce();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

         Arrow.position = transform.position;
        forceTransform.position = new Vector3(3, -4+1/10, 0);
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized;
        // forceTransform.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
           Arrow.eulerAngles = new Vector3(0, 0, GetAngleFromVectorFloat(dir));
       // Vector2 Arrow = transform.position;
       // Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
       // dir = mousePosition - Arrow;
       // transform.right = dir;
       

    }

    public const float MAX_FORCE = 20f;

    private void HideForce()
    {
        forceSpriteMask.alphaCutoff = 1;
    }

    public void Launch(float force)
    {
        Vector2 dir = (Camera.main.ScreenToWorldPoint(Input.mousePosition) ).normalized * -1f;
        transform.GetComponent<Rigidbody2D>().velocity = dir * force;
        HideForce();
    }

   
    public void ShowForce(float force)
    {
        forceSpriteMask.alphaCutoff = 1 - force / MAX_FORCE;
    }

    public static float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if (n < 0) n += 360;
        return n;
    }
    
    private Rigidbody2D rb;

    // Use this for initialization
  

    private void OnMouseDown()
    {
       // rb.AddForce(new Vector2(transform.up * JumpForce, ForceMode2D.Impulse);
    }

}
