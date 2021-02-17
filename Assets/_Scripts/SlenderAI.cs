using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SlenderAI : MonoBehaviour
{
    public Transform player;

    private float appearRadius = 30;
    private bool isCoroutineExecuting = false;
    private NavMeshAgent navMeshAgent;
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
        StartCoroutine(Teleport());

        if (Vector3.Distance(player.position, this.transform.position) < 25)
        {
            navMeshAgent.SetDestination(player.position);
            anim.SetBool("isRunning", true);
            if (Vector3.Distance(player.position, this.transform.position) < 5)
            {
                anim.SetBool("isRunning", false);
                anim.SetBool("isAttacking", true);
            }
        }
    }

    IEnumerator Teleport()
    {
        if (isCoroutineExecuting)
        {
            yield break;
        }

        isCoroutineExecuting = true;

        yield return new WaitForSeconds(10);

        float angle = Random.Range(0f, 360f);
        float x = Mathf.Cos(angle) * appearRadius;
        float z = Mathf.Sin(angle) * appearRadius;
        this.transform.position = player.position + new Vector3(x, 0, z);

        isCoroutineExecuting = false;
        

        /*Debug.Log("Started Coroutine at timestamp : " + Time.time);
        yield return new WaitForSeconds(5);
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);*/
    }
}
