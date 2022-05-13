using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolScript : MonoBehaviour
{
    public GameObject projectile; // on stockera le prefab Balle
    public Transform posTir; // Position de la Balle
    public float force; // puissance de tir
    public int chargeur = 10;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && chargeur != 0)// qd on clique 
        {
            // Instanciation (cr�ation) du projectile
            GameObject go = Instantiate(projectile, posTir.position, Quaternion.identity);
            // Instantiate prend comme param�tre l'objet � instancier, la position et la rotation (ici elle est nulle)
            // on a acc�s aux composants de go qui est un game object

            // on propulse le projectile
            go.GetComponent<Rigidbody>().AddForce(posTir.forward * force); // on applique une force au rigidbody en face

            // on d�truit le prjectile apr�s 10s
            Destroy(go, 10);

            chargeur--;
        }

        if (Input.GetKey("r"))
        {
            chargeur = 10;
        }
        
    }
}
