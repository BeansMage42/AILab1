using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;

public class navController : MonoBehaviour
{

    NavMeshAgent agent;
    public Vector3 target;
    private Animator anime;

    bool iswalking = true;
    bool isAttacking = false;

    [SerializeField] private Transform dragonPos;
    // Start is called before the first frame update
    void Start()
    {
        anime = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        anime.SetBool("isWalking", iswalking);
    }

    // Update is called once per frame
    void Update()
    {
        if (iswalking) 
        {
            agent.destination = target;
        }
        else
        {
            agent.destination = transform.position;
            transform.LookAt(dragonPos.position);
        }
    }

    public void SetTarget(Vector3 newTarget)
    {
        target = newTarget;
    }
    private void OnTriggerEnter(Collider other)
    {
        iswalking = false;
        isAttacking = true;
        anime.SetBool("isWalking", false);
        anime.SetBool("isAttacking", isAttacking);
    }
}
