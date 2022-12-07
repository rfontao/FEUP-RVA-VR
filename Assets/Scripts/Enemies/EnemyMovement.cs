using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    public class EnemyMovement : MonoBehaviour
    {
        private NavMeshAgent navMeshAgent;
        private Animator animator;
        private Vector3 targetPosition;
        private float timeStopped = 5;
        private bool wasRunning;
        private GameObject shell;

        [SerializeField] private int fov = 60;
        [SerializeField] private int viewRange = 15;
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Walk = Animator.StringToHash("Walk");
        private static readonly int Run = Animator.StringToHash("Run");

        private static Vector3 RandomNavSphere (Vector3 origin, float distance, int layermask) {
            Vector3 randomDirection = Random.insideUnitSphere * distance;
               
            randomDirection += origin;
            NavMeshHit navHit;
               
            NavMesh.SamplePosition(randomDirection, out navHit, distance, layermask);
               
            return navHit.position;
        }

        public void Stop()
        {
            navMeshAgent.SetDestination(this.transform.position);
        }
        
        // Start is called before the first frame update
        void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            shell = GameObject.Find("TurtleShellPBR");
        }

        private bool CanSeeTarget(Transform target)
        {
            Vector3 toTarget = target.position - (transform.position + new Vector3(0,1,0));
            if (Vector3.Angle(transform.forward, toTarget) <= fov && toTarget.magnitude < viewRange)
            {
                return true;
            } 
            return false;
        }
    
        private void NextPosition()
        {
            if (wasRunning) animator.SetTrigger(Idle);
            if (timeStopped > 1.0f && timeStopped < 3.0f && navMeshAgent.velocity == new Vector3(0, 0, 0) && InWalkingState())
            {
                animator.SetTrigger(Idle);
            }

            if (timeStopped > 3.0f)
            {
                Vector3 v3 = RandomNavSphere(this.transform.position, viewRange, LayerMask.NameToLayer("Terrain"));
                navMeshAgent.SetDestination(v3);
                animator.SetTrigger(Walk);
                transform.LookAt(v3);
                timeStopped = 0;
            }
        }
    
        // Update is called once per frame
        void Update()
        {
            if (animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "Die") return;
            timeStopped += Time.deltaTime;
            Transform player = GameObject.FindGameObjectWithTag("Player").transform;
            if(!CanSeeTarget(player))
                NextPosition();
            else
                RunToPlayer(player);
        }
        
        private void RunToPlayer(Transform player)
        {
            Vector3 v3 = player.position;
            navMeshAgent.SetDestination(v3);
            animator.SetTrigger(Run);
            wasRunning = true;
        }

        private bool InWalkingState()
        {
            return animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == "WalkFWD";
        }
    }
}
