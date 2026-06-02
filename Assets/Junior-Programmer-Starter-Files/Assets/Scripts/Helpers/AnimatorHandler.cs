using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimatorHandler : MonoBehaviour
{
    private Animator m_Animator;
    private NavMeshAgent m_Agent;
    
    void Start()
    {
        m_Agent = GetComponentInParent<NavMeshAgent>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (m_Agent != null && m_Animator != null)
        {
            m_Animator.SetFloat("Speed", m_Agent.velocity.magnitude / m_Agent.speed);
        }
    }
}
