using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretScript : MonoBehaviour
{
    public Transform target; // cible
    public GameObject bullet; // prefab balle
    public float force; // puissance tir
    public float reloadTime; // temps entre 2 tirs
    public Transform posTir; // pour intacncier la balle
    public GameObject canon; // canon Tourelle
    public int champ = 10; // champ de tir
    bool canShot = true; // peut tirer?


    // Update is called once per frame
    void Update()
    {

        // calcul de la position de la cible (sauf l'axe Y qui reste fixe)
        Vector3 targetPosition = new Vector3(target.position.x, canon.transform.position.y, target.position.z);

        // Orientation de la tourelle vers la cible (sauf l'axe Y qui reste fixe)
        canon.transform.LookAt(targetPosition);

        // Calcul de la distance entre le joueur et la tourelle
        float distance = Vector3.Distance(transform.position, target.position);

        // Si on peut tirer, on tire, sinon on attend
        if (canShot && distance < champ)
        {
            canShot = false;
            // On tire
            if (posTir != null)
            { 
                GameObject go = Instantiate(bullet, posTir.position, Quaternion.identity);
                go.GetComponent<Rigidbody>().AddForce(posTir.forward * force);
                Destroy(go, 5);
            }

            // On recharge
            StartCoroutine("Reload");
        }

        

    }

    IEnumerator Reload()
    {
        // On attend un instant et on peut tirer à nouveau
        yield return new WaitForSeconds(reloadTime);
        canShot = true;
    }
}
