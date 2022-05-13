using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolV2Script : MonoBehaviour
{
    public GameObject projectile; // on stockera le prefab Balle
    public Transform posTir; // Position de la Balle
    public float force; // puissance de tir
    public int chargeur = 10;
    public AudioClip sonDeTir; // Son de tir
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && chargeur != 0)// qd on clique 
        {
            // Instanciation (création) du projectile
            GameObject go = Instantiate(projectile, posTir.position, Quaternion.identity);
            // Instantiate prend comme paramètre l'objet à instancier, la position et la rotation (ici elle est nulle)
            // on a accès aux composants de go qui est un game object

            // on propulse le projectile
            go.GetComponent<Rigidbody>().AddForce(posTir.forward * force); // on applique une force au rigidbody en face

            // on détruit le prjectile après 10s
            Destroy(go, 10);

            // On lance le son de tir
            GetComponent<AudioSource>().PlayOneShot(sonDeTir);

            chargeur--;
        }

        if (Input.GetKey("r"))
        {
            chargeur = 10;
        }
        
    }
}
