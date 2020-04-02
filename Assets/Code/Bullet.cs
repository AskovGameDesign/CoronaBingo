using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour {

    public float shotSpeed = 10f;

    private Rigidbody mMyRigidbody;

    private Vector3 shootDirection = Vector3.forward;



    // Use this for initialization
    void Start () 
    {
        mMyRigidbody = GetComponent<Rigidbody>();
        ShootDirection = transform.forward;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
    {
        mMyRigidbody.AddForce(ShootDirection * shotSpeed, ForceMode.VelocityChange);
	}


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            /*
            Player playerScript = collision.collider.GetComponent<Player>();

            if(playerScript)
            {
                playerScript.PlayerGotHit();
            }

            Destroy(this.gameObject);
            */
        }
        else
        {
            Destroy(this.gameObject);
        }
    }


    public Vector3 ShootDirection
    {
        get
        {
            return shootDirection;
        }

        set
        {
            shootDirection = value;
        }
    }
}
