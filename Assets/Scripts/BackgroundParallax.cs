using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundParallax : MonoBehaviour
{

    private float lenght, startPos;
    public GameObject cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        lenght = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void FixedUpdate()
    {
        //float temp = (cam.transform.position.x * (1-parallaxEffect));
        float dist = (cam.transform.position.x-2.7f * parallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y,transform.position.z);

      //  if (temp > startPos + lenght) startPos += lenght;
       // else if (temp < startPos - lenght) startPos -= lenght;
    }
}
