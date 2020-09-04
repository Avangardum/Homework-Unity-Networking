using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
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
