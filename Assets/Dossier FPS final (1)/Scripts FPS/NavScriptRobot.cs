using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavScriptRobot : MonoBehaviour
{
    public GameObject[] points; // Points de patrouille
    public Transform player; // Joueur à attaquer

    NavMeshAgent agent; // Nav Mesh Agent du robot

    // Start is called before the first frame update
    void Start()
    {
        // On récupère le composant agent
        agent = GetComponent<NavMeshAgent>();
        GotoNextPoint(); // On va au point aléatoire suivant
    }

    void GotoNextPoint() // récupère une destination au hasard
    {
        // On donne une destination à l'agent
        // On tire un nombre aléatoire entre 0 et nbr de points-1
        agent.destination = points[Random.Range(0, points.Length - 1)].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, player.position) > 12) // Si la distance entre le robot et le joueur est > 12
        {
            agent.isStopped = false;
            // On patrouille
            // Si on n'a pas de chemin en attente et si on a atteint le point
            if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                GotoNextPoint();  // On va au point suivant
            }
        }
        else
        {
            agent.isStopped = true;
        }
    }
}
