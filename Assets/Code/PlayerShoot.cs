using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] Transform shootFromHere;
    [SerializeField] bool autoFire = true;

    float autoFireRate = 0.25f;
    float autoFireTimer = 0f;
    float timeSinceLastShoot;
    // Start is called before the first frame update
    void Start()
    {
        timeSinceLastShoot = autoFireRate;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //GameObject myBullet = Instantiate(bullet, shootFromHere.position, shootFromHere.rotation);

            
        }

        if(Input.GetMouseButton(0))
        {
            if(autoFireTimer - timeSinceLastShoot >= autoFireRate)
            {
                GameObject myBullet = Instantiate(bullet, shootFromHere.position, shootFromHere.rotation);

                autoFireTimer = timeSinceLastShoot;
            }
        }

        autoFireTimer += Time.deltaTime;
    }
}
