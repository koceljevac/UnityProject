using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour,ISlice
{

    public float cubeSize = 0.2f;
    public int cubesInRow = 5;
    float cubesPivotDistance;
    Vector3 cubesPivot;

    int explosionRadius=2;
    float explosionUpward= 0.6f;
    int explosionForce= 100;

    // Start is called before the first frame update
    void Start()
    {
        cubesPivotDistance = cubeSize * cubesInRow / 2;
        cubesPivot = new Vector3(cubesPivotDistance, cubesPivotDistance, cubesPivotDistance);
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void explode()
    {
        gameObject.SetActive(false);
        

        //loop 3 times to create 5x5x5 pieces in x,y,z coordinates
        for(int x = 0; x < cubesInRow; x++)
        {
            for(int y = 0; y<cubesInRow; y++)
            {
                for(int z = 0; z<cubesInRow; z++)
                {
                    createPiece(x, y, z);
                }
            }
        }

        //get explosion position
        Vector3 explosionPos = transform.position;
        //get colliders in that position and radius
        Collider[] colliders = Physics.OverlapSphere(explosionPos, explosionRadius);
        foreach(Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius, explosionUpward);
            }
        }
    }

    void createPiece(int x,int y,int z)
    {
        GameObject piece;
        piece = GameObject.CreatePrimitive(PrimitiveType.Cube);
        piece.GetComponent<Renderer>().material.color = Color.magenta;


        piece.layer = LayerMask.NameToLayer("Presecen Predmet");

        //set piece position and scale

        piece.transform.position = transform.position + new Vector3(cubeSize*x,cubeSize*y,cubeSize*z)-cubesPivot;
        piece.transform.localScale = new Vector3(cubeSize, cubeSize, cubeSize);

        //add rigibody and set mass
        piece.AddComponent<Rigidbody>();
        piece.GetComponent<Rigidbody>().mass = cubeSize;



    }

    public void getSlice(PlayerControler player)
    {
        GameManager.instance.incraseCoins(250);
        explode();
    }
}
