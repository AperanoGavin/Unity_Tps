using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCollision : MonoBehaviour
{
    public int health = 3;
    public GameObject explodeParticules; // on stocke l'explosion

    // D�tecter les collisions avec un tir 
    void OnCollisionEnter(Collision col)
    {
        // Si la tourelle est touch�e par une balle du joueur
        if (col.gameObject.tag == "Balle")
        {
            health -= 1; // Perte de 1pt de vie
            if (health <= 0)
            {
                Instantiate(explodeParticules, transform.position, Quaternion.identity); // on cr��e l'explosion
                Destroy(this.gameObject); // Destruction de la tourelle
                print("WELL DONE");
            }
        }
    }

}
