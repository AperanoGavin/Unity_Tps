using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Pour utiliser les fonctionnalités du système UI
using UnityEngine.SceneManagement; // Pour charger des scènes, relancer le niveau (par ex)

public class PlayerV3Collision : MonoBehaviour
{
    public Text healthTxt;
    public int health = 100;
    bool hasKey = false;
    public GameObject porte;
    public Text passageTxt;
    public GameObject cameraAnimation;
    public Text textObjectif;
    public Text textVictoire;



    // Détecter les collisions avec le tir 
    void OnCollisionEnter(Collision col)
    {
        // Si l'objet qui touche le joueur a le Tag Tourelle
        if (col.gameObject.tag == "Tourelle")
        {
            LooseHealth(20); // Perte de 20 points de vie
            Destroy(col.gameObject); // Destruction du projectile
        }
    }

    // Si le joueur touche un Trigger
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Pic") // Si le joueur touche un piège 
        {
            LooseHealth(100); // Perte de 100 pts de vie
        }

        if (collider.gameObject.tag == "Vie") // Si le joueur touche un Kit de soin 
        {
            LooseHealth(-50); // gain de 50pts de vie
            Destroy(collider.gameObject); // Destruction du projectile
        }

        if (collider.gameObject.tag == "Key") // Si le joueur touche la clé
        {
            hasKey = true;
            Destroy(collider.gameObject); // destruction de la clé
        }

        if (collider.gameObject.tag == "Porte" && hasKey && passageTxt != null) // Si le joueur a la clé et touche la porte
        {
            porte.GetComponent<Animator>().enabled = true;

            passageTxt.enabled = true;
            Destroy(passageTxt, 2);
        }

        if (collider.gameObject.tag == "Portal" ) // Déclencher la fin du jeu
        {
            SceneManager.LoadScene(5);
        }

        if (collider.gameObject.tag == "Robot" && textObjectif != null) // Si le joueur parle au robot Ami
        {

            // Déclencher le dialogue/cinématique
            cameraAnimation.SetActive(true);
            textObjectif.enabled = true;
            Destroy(textObjectif, 10);

            StartCoroutine("FinCinematique");

        }

    }


    // Perte de vie
    void LooseHealth(int val) // val: valeur de perte
    {
        health = health - val; // Perte de val% de vie
        healthTxt.text = health + "%"; // Mise à jour du texte
        if (health < 0)
        {
            health = 0; // on bloque la vie à 0
            // Le perso n'a plus de vie, on lancera le Game Over ici
            SceneManager.LoadScene(4); // On relance la scene d'index 4 (gérer les scènes dans FILE/build Settings)
        }
    }

    IEnumerator FinCinematique()
    {
        yield return new WaitForSeconds(14);
        cameraAnimation.SetActive(false);
    }
    
}
