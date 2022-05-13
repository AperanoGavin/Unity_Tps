using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwitchWeapon : MonoBehaviour
{
    int activeWeapon = 0; // arme active (0=pistolet, 1=fusil)
    public GameObject[] weapons; // tableau d'armes
    public Image[] weaponIcons; // images des armes
    public Color activeColor; // couleur blanc alpha 200
    public Color inactiveColor; // couleur blanc alpha 100

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Alpha1)) // Si on appuie sur 1
        {
            DesactivateWeapons(); // On desactive tout
            ActivateWeaponById(0); // On active l'arme 0
        }

        if (Input.GetKey(KeyCode.Alpha2)) // Si on appuie sur 2
        {
            DesactivateWeapons(); // On desactive tout
            ActivateWeaponById(1); // On active l'arme 1
        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0f) // Si molette
        {
            DesactivateWeapons(); // On desactive tout

            if (activeWeapon == 1) // Si l'arme active est 1
            {
                ActivateWeaponById(0); // On active l'arme 0
            }
            else
            {
                ActivateWeaponById(1); // On active l'arme 1
            }
        }
    }

    public void DesactivateWeapons() // Tout désactiver
    {
        foreach(GameObject go in weapons) // Pour chaque arme
        {
            go.SetActive(false); // On désactive
        }

        foreach (Image img in weaponIcons) // Pour chaque icone d'arme
        {
            img.color = inactiveColor; // On met la couleur inactive
        }
    }

    public void ActivateWeaponById(int id) // Activer l'arme spécifiée
    {
        activeWeapon = id; // On active l'arme
        weapons[id].SetActive(true); // On montre le modèle de l'arme
        weaponIcons[id].color = activeColor; // On active l'icone de l'arme
    }
}
