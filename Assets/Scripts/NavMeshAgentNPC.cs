using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentNPC : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform target;

    private int currentTargetPosition;

    public float accuracy;

    public bool varyingPosition;

    public List<Transform> targetPositions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetWayPoint();
    }

    public void SetWayPoint()
    {
        Debug.Log(Vector3.Distance(targetPositions[currentTargetPosition].position, transform.position));
        if (Vector3.Distance(targetPositions[currentTargetPosition].position, transform.position) < accuracy)
        {
            if (varyingPosition)
            {
                currentTargetPosition = Random.Range(0, targetPositions.Count);
            }
            else
            {
                currentTargetPosition++;
            }

        }
        ResetPosition();

        agent.SetDestination(targetPositions[currentTargetPosition].position);
    }


    public void ResetPosition()
    {
        if (currentTargetPosition >= targetPositions.Count)
        {
            currentTargetPosition = 0;
        }
    }
}
