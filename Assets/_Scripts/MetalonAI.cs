using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MetalonAI : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform player;
    public Transform ogPosition;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.position, this.transform.position) < 25)
        {
            navMeshAgent.SetDestination(player.position);
            anim.SetBool("Run Forward", true);
            if (Vector3.Distance(player.position, this.transform.position) < 5)
            {
                anim.SetBool("Run Forward", false);
                anim.SetBool("Smash Attack", true);
            }
        }
        else
        {
            navMeshAgent.SetDestination(ogPosition.position);
            if (Vector3.Distance(this.transform.position, ogPosition.position) < 1)
            {
                anim.SetBool("Run Forward", false);
            }
            
        }
        
    }
}
