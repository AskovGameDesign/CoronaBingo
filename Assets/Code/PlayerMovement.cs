using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{

    public float speed = 5f;

    Vector3 movement;
    Rigidbody rb;
    int groundMask;

	// Use this for initialization
	void Start () 
    {
        rb = GetComponent<Rigidbody>();
        groundMask = LayerMask.GetMask("Walkable");	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        Move(h, v);
        Turning();
	}

    void Move(float h, float v)
    {
        movement.Set(h, 0f, v);

        movement = movement.normalized * speed * Time.deltaTime;

        rb.MovePosition(transform.position + movement);
    }

    void Turning()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit groundHit;

        if(Physics.Raycast(ray, out groundHit, 100f, groundMask))
        {
            Vector3 lookDirection = groundHit.point - transform.position;
            lookDirection.y = 0f;

            Quaternion lookRotation = Quaternion.LookRotation(lookDirection);
            rb.MoveRotation(lookRotation);
        }
    }
}
