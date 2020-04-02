using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieControl : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        SetDestination(new Vector3(12, 0, 3));
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.isStopped)
            return;

        animator.SetFloat("Speed", agent.speed/ agent.velocity.magnitude);

        Debug.Log(agent.speed / agent.velocity.magnitude);
    }

    void SetDestination(Vector3 _destination)
    {
        agent.SetDestination(_destination);
    }
}
