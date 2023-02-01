using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 velocity;
    public float maxX;  //max Geschwindigkeit x- und z-Richtung
    public float maxZ;

    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector3(0, 0, maxZ);
    }

    //wenn Ball an Schl�ger prallt
    private void OnTriggerEnter(Collider other)
    {
        //Wand + Paddle unterscheiden
        if(other.transform.CompareTag("Paddle"))
        {
            //Maximaldistanz (halber Schl�ger * halbe Kugel)
            float maxDist = 0.5f * other.transform.localScale.x + 0.5f * transform.localScale.x;
            //tats�chliche Distanz
            float dist = transform.position.x - other.transform.position.x;
            //normalisierte Distanz zur Berechnung bei Aufprall Ball
            float nDist = dist / maxDist;
            velocity = new Vector3(nDist * maxX, velocity.y, -velocity.z); //umso weiter au�en Ball getroffen, desto gr��er Ausfallwinkel

            //velocity *= -1; //Richtung wird umgekehrt (das hier ohne normalisierte Distanz)
        }
        else if(other.transform.CompareTag("Wall"))
        {
            velocity = new Vector3(-velocity.x, velocity.y, velocity.z);
        }

        gameObject.GetComponent<AudioSource>().Play(); //spielt Sound wenn Ball Schl�ger / Wand ber�hrt
    }
        

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime;
    }
}
