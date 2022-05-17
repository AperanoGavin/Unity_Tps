using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controller : MonoBehaviour
{
    public bool IsGrounded = false;
    public GameObject RotorMain;
    public GameObject RotorRear;
    int RotorSpeed = 800;
    AudioSource Audio;

    // Start is called before the first frame update
    void Start()
    {
        Audio = GetComponent<AudioSource>();        
    }

    // Update is called once per frame
    void Update()
    {
        //Rotation des rotors
        RotorMain.transform.Rotate(Vector3.up * RotorSpeed * Time.deltaTime);
        RotorRear.transform.Rotate(Vector3.up * RotorSpeed * Time.deltaTime);

        //// augmentation de la vitesse et de la hauteur faire monter

        if (Input.GetKey(KeyCode.LeftShift))

        {
            RotorSpeed += 10;
            RotorSpeed = Mathf.Clamp(RotorSpeed,800,1200);
            transform.Translate(Vector3.up * 2 * Time.deltaTime);

        }

        //// Faire descendre

        if (Input.GetKey(KeyCode.LeftControl))

        {
            RotorSpeed -= 10;
            RotorSpeed = Mathf.Clamp(RotorSpeed, 800, 1200);
            transform.Translate(-Vector3.up * 2 * Time.deltaTime);

        }

        Audio.pitch = ((float)RotorSpeed / 1000)+0.5f;

        //Rotation de l'helico
        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * Time.deltaTime * RotorSpeed / 10);

        //Déplacement Avant/arrière
        transform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * RotorSpeed / 100);



    }
}
