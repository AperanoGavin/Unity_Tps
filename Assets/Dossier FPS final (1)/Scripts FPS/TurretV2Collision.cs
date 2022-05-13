using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretV2Collision : MonoBehaviour
{
    public int health = 3;
    public GameObject explodeParticules; // on stocke l'explosion
    public Transform healthBar; // Barre de vie
    float startHealth; // Vie max


    void Start()
    {
        startHealth = health;
    }


    // Détecter les collisions avec un tir 
    void OnCollisionEnter(Collision col)
    {
        // Si la tourelle est touchée par une balle du joueur
        if (col.gameObject.tag == "Balle")
        {
            health -= 1; // Perte de 1pt de vie

            if (healthBar != null)  // Si le robot a une barre de vie
            {
                // On réduit la taille en x en fonction du nombre de points de vie
                healthBar.localScale = new Vector3(healthBar.localScale.x - (1f / startHealth), 0.2f, 1);
            }



            if (health <= 0)
            {
                Instantiate(explodeParticules, transform.position, Quaternion.identity); // on créée l'explosion
                Destroy(this.gameObject); // Destruction de la tourelle
                print("WELL DONE");
            }
        }
    }

}
