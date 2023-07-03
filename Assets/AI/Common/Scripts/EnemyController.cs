using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum EnemyType
    {
        PatrolAttack,
        RangeAttack
    }

    public EnemyType enemyType;
    [Header("Ranges")]
    public float patrolRange = 5f;
    public float chaseRange = 10f;
    public float attackRange = 2f;
    [Header("CD Attack")]
    public float attackCooldown = 2f;
    [Header("Speed")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 4f;
    public float projectileSpeed = 5f;
    [Header("Target Variation")]
    public float projectileVariation = 0.5f;
    public int maxAttackCount = 3;
    public GameObject projectilePrefab;
    [Header("Player")]
    public Transform player;
    private float lastAttackTime = 0f;
    private bool isAttacking = false;
    private int attackCount = 0;
    private bool isPatrollingRight = true;
    private Vector2 originalPosition;
    private EnemyState currentState;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        originalPosition = transform.position;

        switch (enemyType)
        {
            case EnemyType.PatrolAttack:
                currentState = new PatrolAttackState(this);
                break;
            case EnemyType.RangeAttack:
                currentState = new RangeAttackState(this);
                break;
            default:
                currentState = new PatrolAttackState(this);
                break;
        }
    }

    private void Update()
    {
        currentState.UpdateState();
    }

    public void SetState(EnemyState newState)
    {
        currentState = newState;
    }

    public bool IsPlayerInRange(float range)
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);
        return distanceToPlayer <= range;
    }

    public void Attack()
    {
        if (isAttacking || Time.time < lastAttackTime + attackCooldown)
            return;

        Vector2 targetPosition = player.position + new Vector3(Random.Range(-projectileVariation, projectileVariation), Random.Range(-projectileVariation, projectileVariation), 0f);
        Vector2 direction = (targetPosition - (Vector2)transform.position).normalized;

        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        rb.velocity = direction * projectileSpeed;

        lastAttackTime = Time.time;
        isAttacking = true;
        Invoke(nameof(ResetAttack), attackCooldown);
    }

    private void ResetAttack()
    {
        isAttacking = false;
        attackCount++;

        if (attackCount >= maxAttackCount)
        {
            attackCount = 0;
            SetState(new ChaseState(this));
        }
    }

    public void FlipDirection()
    {
        isPatrollingRight = !isPatrollingRight;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    public void Patrol()
    {
        float patrolDistance = patrolRange * 2f;
        float movement = isPatrollingRight ? 1f : -1f;
        transform.Translate(Vector2.right * movement * patrolSpeed * Time.deltaTime);

        if ((isPatrollingRight && transform.position.x >= originalPosition.x + patrolDistance) ||
            (!isPatrollingRight && transform.position.x <= originalPosition.x - patrolDistance))
        {
            FlipDirection();
        }
    }
}

public abstract class EnemyState
{
    protected EnemyController enemy;

    public EnemyState(EnemyController enemy)
    {
        this.enemy = enemy;
    }

    public abstract void UpdateState();
}

public class PatrolAttackState : EnemyState
{
    public PatrolAttackState(EnemyController enemy) : base(enemy) { }

    public override void UpdateState()
    {
        Patrol();

        if (enemy.IsPlayerInRange(enemy.chaseRange))
        {
            enemy.SetState(new ChaseState(enemy));
        }
    }

    private void Patrol()
    {
        enemy.Patrol();

        if (enemy.IsPlayerInRange(enemy.attackRange))
        {
            enemy.SetState(new AttackState(enemy));
        }
    }
}

public class ChaseState : EnemyState
{
    public ChaseState(EnemyController enemy) : base(enemy) { }

    public override void UpdateState()
    {
        Chase();

        if (!enemy.IsPlayerInRange(enemy.chaseRange))
        {
            enemy.SetState(new PatrolAttackState(enemy));
        }
        else if (enemy.IsPlayerInRange(enemy.attackRange))
        {
            enemy.SetState(new AttackState(enemy));
        }
    }

    private void Chase()
    {
        float moveSpeed = enemy.chaseSpeed;
        Vector2 direction = (enemy.player.position - enemy.transform.position).normalized;
        enemy.transform.Translate(direction * moveSpeed * Time.deltaTime);
    }
}

public class AttackState : EnemyState
{
    public AttackState(EnemyController enemy) : base(enemy) { }

    public override void UpdateState()
    {
        Attack();

        if (!enemy.IsPlayerInRange(enemy.attackRange))
        {
            enemy.SetState(new ChaseState(enemy));
        }
    }

    private void Attack()
    {
        enemy.Attack();
    }
}

public class RangeAttackState : EnemyState
{
    private bool isPlayerInRange;

    public RangeAttackState(EnemyController enemy) : base(enemy)
    {
        isPlayerInRange = false;
    }

    public override void UpdateState()
    {
        if (!isPlayerInRange && enemy.IsPlayerInRange(enemy.attackRange))
        {
            isPlayerInRange = true;
            enemy.Attack();
        }
        else if (isPlayerInRange && !enemy.IsPlayerInRange(enemy.attackRange))
        {
            isPlayerInRange = false;
        }
    }
}
