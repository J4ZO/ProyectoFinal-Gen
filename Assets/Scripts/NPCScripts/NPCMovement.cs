using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NPCMovement : MonoBehaviour
{
    private NavMeshAgent agentNPC;

    [SerializeField] private float patrolWait = 2f; // Tiempo de espera en cada waypoint
    [SerializeField] private Transform[] wayPoints; // Lista de waypoints
    [SerializeField] private float arrivalRadius = 3f; // Radio de llegada al waypoint

    private int wayPointIndex = 0; // Índice del waypoint actual
    private bool isWaiting = false; // Estado para controlar la espera

    void Start()
    {
        agentNPC = GetComponent<NavMeshAgent>();
        agentNPC.stoppingDistance = arrivalRadius;
        if (wayPoints.Length > 0)
        {
            agentNPC.SetDestination(wayPoints[wayPointIndex].position); // Inicia movimiento hacia el primer waypoint
        }
    }

    void Update()
    {
        // Revisar si el NPC está dentro del radio de llegada
        if (!isWaiting && !agentNPC.pathPending && agentNPC.remainingDistance <= arrivalRadius)
        {
            StartCoroutine(WaitAtWaypoint());
        }
    }

    private IEnumerator WaitAtWaypoint()
    {
        isWaiting = true;
        yield return new WaitForSeconds(patrolWait); // Espera en el waypoint
        wayPointIndex = (wayPointIndex + 1) % wayPoints.Length; // Cambia al siguiente waypoint (vuelve al inicio si es el último)
        agentNPC.SetDestination(wayPoints[wayPointIndex].position); // Establece el siguiente destino
        isWaiting = false;
    }

    private bool IsWithinArrivalRadius()
    {
        // Calcula la distancia entre el NPC y el waypoint actual
        float distance = Vector3.Distance(transform.position, wayPoints[wayPointIndex].position);
        return distance <= arrivalRadius;
    }
}
