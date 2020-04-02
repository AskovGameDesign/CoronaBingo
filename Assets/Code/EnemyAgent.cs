using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAgent : MonoBehaviour
{
    [SerializeField] private GameObject deathParticles;
    [SerializeField] private Color normalColor;
    [SerializeField] private Color popColor;
    [SerializeField] private MeshRenderer bodyMesh;
    private NavMeshAgent agent;
    private Transform player;

    int numberOfHitsToDie = 7;
    int currentHitCount = 0;

    GameLogic gameLogic;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        gameLogic = FindObjectOfType<GameLogic>();

        agent = GetComponent<NavMeshAgent>();
        //agent.SetDestination(player.position);
        if (player != null)
            StartCoroutine(UpdateData());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Died()
    {
        Instantiate(deathParticles, transform.position, Quaternion.identity);
        gameLogic.SetPointInWorld(player.position);
        Destroy(this.gameObject);
    }

    IEnumerator UpdateData()
    {
        while(true)
        {
            agent.SetDestination(player.position);

            yield return new WaitForSeconds(1f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            currentHitCount++;
            currentHitCount = Mathf.Clamp(currentHitCount, 0, numberOfHitsToDie);

            transform.localScale = Vector3.Lerp(Vector3.one, Vector3.one * 2f, (1f / numberOfHitsToDie) * currentHitCount);
            bodyMesh.material.color = Color.Lerp(normalColor, popColor, (1f / numberOfHitsToDie) * currentHitCount);

            if(currentHitCount >= numberOfHitsToDie)
            {
                StopAllCoroutines();
                Died();
            }
        }
    }
}
