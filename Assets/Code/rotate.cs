using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{

    private Vector3 randomRotationVector;
    private float randomRotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        randomRotationVector = new Vector3(Random.value, Random.value, Random.value);
        randomRotationSpeed = Random.Range(15f, 18f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(randomRotationVector, randomRotationSpeed * Time.deltaTime);
    }
}
