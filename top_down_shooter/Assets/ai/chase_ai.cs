using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chase_ai : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public float Sight_range, Attack_range;
    public bool playerin_sight, playerin_attacksight;
    public LayerMask Groundlayer, playerlayer ;
    //waypoint
    public Transform[] waypoint;
    int waypointindex=0;
    Vector3 traget;

    //animation
    public Animator animator ;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();        
    }

    void Update()
    {
        playerin_sight = Physics.CheckSphere(transform.position, Sight_range,playerlayer);
        playerin_attacksight = Physics.CheckSphere(transform.position, Attack_range,playerlayer);

       
        
        if (!playerin_sight && !playerin_attacksight) petrol();
        
        
        if (playerin_sight && !playerin_attacksight) chase();
        


        if (playerin_sight && playerin_attacksight) attack();
      
    }

    void petrol()
    {
        if(Vector3.Distance(transform.position,traget)<1)
        {
            updatepoint();
            updatedestion();

        }
    }

    void updatepoint()
    {
        waypointindex++;
        if(waypointindex>=waypoint.Length)
        {
            waypointindex = 0;
        }
    }
    void updatedestion()
    {
            traget = waypoint[waypointindex].position;
            agent.SetDestination(traget);
        
    }



    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Attack_range);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, Sight_range);
    }
    void chase()
    {
        agent.SetDestination(player.position);
        animator.SetBool("iswalking", true);
    }
    void attack()
    {
        transform.LookAt(player);
        animator.SetBool("iswalking", false);
        animator.SetBool("attacking", true);

    }
     

}
