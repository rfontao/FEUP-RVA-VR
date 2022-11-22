using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private static readonly int Speed = Animator.StringToHash("Speed");

    public static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
               
        randomDirection += origin;
               
        NavMeshHit navHit;
               
        NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
               
        return navHit.position;
    }

    // Start is called before the first frame update
    void Start()
    {
        Vector3 v3 = RandomNavSphere(this.transform.position, 10, LayerMask.NameToLayer("Terrain"));

        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        navMeshAgent.SetDestination(v3);
        animator.SetFloat(Speed, 2.0f);
        
        
        Debug.Log(v3);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
