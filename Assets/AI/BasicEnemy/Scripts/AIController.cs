using UnityEngine;
using System;
using Common;

namespace BasicEnemy.Enemy
{
    public class AIController : MonoBehaviour
    {
        [Header("Movement and fighter")]
        [SerializeField] float chaseDistance = 5f;
        [SerializeField] float suspicionTime = 3f;
        [SerializeField] float agroCoolTime = 3f;
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float waypointTolerance = 1f;
        [SerializeField] float waypointDwellTime = 3f;
        [Range(0,1)] [SerializeField] float patrolSpeedFraction = 0.2f;
        [SerializeField] float shoutDistance = 5;

        [Header("Health")]
        [SerializeField] private float _timeBetweenReceivedDamage = 0.5f;


        [SerializeField] GameObject player;
        EnemyMovement mover;

        private IHealth health;
        private IFighter fighter;

        Vector3 guardLocation;
        float timeSinceLastSawPlayer = Mathf.Infinity;
        float timeSinceArriveAtWaypoint = Mathf.Infinity;
        float timeSinceAggrevated = Mathf.Infinity;
        float timeSinceReceivedDamage = Mathf.Infinity;
        int currentWaypointIndex = 0;
        
        private void Awake()
        {
            mover = GetComponent<EnemyMovement>();
            health = GetComponent<IHealth>();
            fighter = GetComponent<IFighter>();
        }

        private void Start()
        {
            health.OnDie += CancelMovement;
            health.OnSubstractHealth += ReceiveDamageCancelMove;

            player = GameObject.FindWithTag("Player");
        }

        private void ReceiveDamageCancelMove(int damage)
        {
            timeSinceReceivedDamage = 0;
        }

        private void Update()
        {
            timeSinceReceivedDamage += Time.deltaTime;

            if (health.IsDead() || timeSinceReceivedDamage < _timeBetweenReceivedDamage)
                return;

            if(player is null)
                player = GameObject.FindWithTag("Player");

            if (IsAggrevated(player) && fighter.CanAttack(player))
            {
                timeSinceLastSawPlayer = 0;
                AttackBehaviour();
            }
            else if (timeSinceLastSawPlayer < suspicionTime)
            {
                SuspicionBehaviour();
            }
            else
            {
                PatrolBehaviour();
            }

            UpdateTimers();
        }

        private bool IsAggrevated(GameObject player)
        {
            if(player == null)
                return false;

            float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);

            return distanceToPlayer < chaseDistance || timeSinceAggrevated < agroCoolTime;
        }

        private void AttackBehaviour()
        {
            timeSinceArriveAtWaypoint = 0;
            fighter.Attack(player);

            AggrevateNearByEnemies();
        }

        private void UpdateTimers()
        {
            timeSinceLastSawPlayer += Time.deltaTime;
            timeSinceArriveAtWaypoint += Time.deltaTime;
            timeSinceAggrevated += Time.deltaTime;
        }

        private void PatrolBehaviour()
        {
            Vector3 nextPosition = guardLocation;

            if (patrolPath == null)
                return;

            if (IsFinishMoveToWaypoint())
            {
                timeSinceArriveAtWaypoint = 0;
                CycleWaypoint();
            }
            nextPosition = GetCurrentWaypoint();

            if (timeSinceArriveAtWaypoint > waypointDwellTime)
            {
                mover.StartMoveAction(nextPosition , patrolSpeedFraction);
            }
        }

        private bool IsFinishMoveToWaypoint()
        {
            float distanceToWaypoint = Vector3.Distance(transform.position, GetCurrentWaypoint());

            return distanceToWaypoint < waypointTolerance;
        }

        private Vector3 GetCurrentWaypoint()
        {
            return patrolPath.GetWaypoint(currentWaypointIndex);
        }

        private void CycleWaypoint()
        {
            currentWaypointIndex = patrolPath.GetNextIndex(currentWaypointIndex);
        }

        private void SuspicionBehaviour()
        {

        }

        private void AggrevateNearByEnemies()
        {
            RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, shoutDistance, Vector3.up, 0);

            foreach (RaycastHit2D hit in hits) {
                AIController ai = hit.collider.GetComponent<AIController>();

                if (ai == null)
                    continue;

                ai.SetAggrevateState();
            }
        }

        public void SetAggrevateState()
        {
            timeSinceAggrevated = 0;
        }

        private void CancelMovement()
        {
            mover.Cancel();
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
