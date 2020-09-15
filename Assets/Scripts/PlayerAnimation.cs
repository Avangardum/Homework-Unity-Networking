using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class PlayerAnimation : NetworkBehaviour
{
    private Animator _animator;
    private NavMeshAgent _navMeshAgent;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        _animator.SetBool("Moving", _navMeshAgent.velocity != Vector3.zero);
    }
}
