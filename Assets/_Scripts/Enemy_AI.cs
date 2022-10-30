using UnityEngine;
using UnityEngine.AI;

public class Enemy_AI : MonoBehaviour
{
    [SerializeField] private Transform attackTarget;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    private bool _startAttack;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }
    public void TriggerAnimation()
    {
        _startAttack = true;
        _animator.SetBool("__attackClones",true);
    }
    private void LateUpdate()
    {
        if (!_startAttack) return;
        _navMeshAgent.SetDestination(attackTarget.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Clone"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void OnDisable() => GameManager.Instance.ActiveEnemyAmount--;
}
