using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ai_1 : MonoBehaviour
{

    NavMeshAgent agent;
    public float speed;
    public Transform[] petrolpoint;
    public float waittime;
    public int currentpoint=0;
    public Vector3 traget;

    bool onetime;
    void Start()
    {
       
        agent = GetComponent<NavMeshAgent>();
        UpdateDestation();
    }


    void Update()
    {  
        traget = petrolpoint[currentpoint].transform.position;

        if(Vector3.Distance(petrolpoint[currentpoint].transform.position,traget) <=3 )
        {
            updatepoint();
            UpdateDestation();
        }

    }

   void UpdateDestation()
    {
        Debug.Log("traget is set"); 
        agent.SetDestination(traget);   
    }

    void updatepoint()
    {
        Debug.Log("update point");
       currentpoint = Mathf.Clamp(currentpoint, 0, petrolpoint.Length);
        currentpoint = currentpoint + 1;

        if (currentpoint == petrolpoint.Length)
        {
            currentpoint = 0;
        }

    }


}
