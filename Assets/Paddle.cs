using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed; //Geschwindkeit als units pro Sekunde
    public Transform floor; //Verlinkung Paddle auf Floor)

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dir = Input.GetAxis("Horizontal"); //x-Achsen-Position
        //Grenzen Paddlebewegung festlegen
        float maxX = floor.localScale.x * 10f * 0.5f - transform.localScale.x * 0.5f;
        float posX = transform.position.x + dir * speed * Time.deltaTime;
        float clampedX = Mathf.Clamp(posX, -maxX, maxX);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        //Position Paddle
        Debug.Log(dir); //gibt in der Konsole die aktuelle X-Achsen-Position aus
        transform.position += new Vector3(dir * speed * Time.deltaTime, 0, 0);
    }
}
