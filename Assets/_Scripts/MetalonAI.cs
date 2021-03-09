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

    public PlayerBehaviour playerBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        playerBehaviour = FindObjectOfType<PlayerBehaviour>();
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

                if (Time.frameCount % 240  == 0)
                {
                    DoDamage();
                }
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

    private void DoDamage()
    {
        playerBehaviour.TakeDamage(20);
    }
}
