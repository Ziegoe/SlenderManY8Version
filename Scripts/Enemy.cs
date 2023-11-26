using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    public Transform target;
    public Animator animator;

    public float triggerDistance = 10;
    public float forgetDistance = 30;
    public float wanderingSpeed = 1;
    public float chasingSpeed = 3.1f;

    bool isFollowing;
    NavMeshAgent agent;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        InvokeRepeating(nameof(Wander), 0, 25);
    }

    void Update()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);

        var distance = Vector3.Distance(transform.position, target.position);

        if(distance <= triggerDistance) { isFollowing = true;
            agent.speed = chasingSpeed;
        }
        else if(distance >= forgetDistance) { isFollowing = false;
            agent.speed = wanderingSpeed;        
        }

        if(isFollowing )
        {
            agent.SetDestination(target.position);
        }


        if(target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    void Wander()
    {
        if(isFollowing) return;

        var pos = new Vector3();
        pos.x = Random.Range(10, 90);
        pos.z = Random.Range(10, 90);
        pos.y = 300;

        if(Physics.Raycast(pos, Vector3.down, out var hit))
        {
            agent.SetDestination(hit.point);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(0);
        }
        
            
        
    }
}
