using UnityEngine;
using UnityEngine.AI;

public class Clone_AI : MonoBehaviour
{
    [Header("Target for clone to follow")]
    [SerializeField] private Transform target;
    [Header("Spawn and Dead Sounds")]
    [SerializeField] private AudioSource _spawnAudio;
    [SerializeField] private AudioSource _deadAudio;
    private NavMeshAgent _navMeshAgent;
    private Animator _animator;
    

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    private void LateUpdate() => _navMeshAgent.SetDestination(target.position);

    private void SetAnimation(bool setAnim) => _animator.SetBool("__isCloneActive", setAnim);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Environment"))
        {
            this.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        _spawnAudio.Play();
        SetAnimation(true);
        GameManager.Instance.ActiveCloneAmount++;
        CloneSpawner.ParticleSystemHandler(true, this.transform);
    }

    private void OnDisable()
    {
        _deadAudio.Play();
        SetAnimation(false);
        GameManager.Instance.ActiveCloneAmount--;
        CloneSpawner.ParticleSystemHandler(false, this.transform);
    }
}