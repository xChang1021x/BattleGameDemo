using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EntityView))]
[RequireComponent(typeof(NavMeshAgent))]
public class EnemyController : MonoBehaviour
{
  [Header("AI Settings")]
  [SerializeField] private float detectRange = 8f;
  [SerializeField] private float attackRange = 1.5f;

  private NavMeshAgent agent;

  private EntityView entityView;
  private BattleEntity entity;

  private Transform targetTransform;
  private BattleEntity targetEntity;

  void Awake()
  {
    agent = GetComponent<NavMeshAgent>();

    entityView = GetComponent<EntityView>();

  }

  void Start()
  {
    entity = entityView.Entity;

    PlayerView playerView =
        FindObjectOfType<PlayerView>();

    targetTransform = playerView.transform;
    targetEntity = playerView.Entity;
  }

  void Update()
  {
    if (targetTransform == null || targetEntity == null)
      return;

    float distance =
        Vector3.Distance(
            transform.position,
            targetTransform.position
        );

    if (distance > detectRange)
    {
      Idle();
    }
    else if (distance > attackRange)
    {
      Chase();
    }
    else
    {
      Attack();
    }
  }

  void Idle()
  {
    agent.isStopped = true;
  }

  void Chase()
  {
    agent.isStopped = false;
    agent.SetDestination(targetTransform.position);
  }

  void Attack()
  {
    agent.isStopped = true;

    Vector3 dir =
        (targetTransform.position - transform.position);
    dir.y = 0;
    transform.forward = dir.normalized;

    TryUseSkill();
  }

  void TryUseSkill()
  {
    if (entity.Skills.Count == 0) return;

    SkillInstance skill = entity.Skills[0];
    skill.TryCast(entity, targetEntity);
  }

  void OnEntityDeath(BattleEntity entity)
  {
    enabled = false; // 停止 AI
    agent.enabled = false;
  }
}
