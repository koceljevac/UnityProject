using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    public GameObject donut;
    public GameObject knife;

    Rigidbody rb;

    bool hasLanded;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float moveForce;

    [SerializeField]
    private Vector3 _rotation;

    [SerializeField]
    private float rotationSpeed;

    Transform pivotPoint;

    float z;

    int remainingJump = 5;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Jump
            if (remainingJump > 0)
            {
                moveAndRotate();
                TurnX();
                remainingJump--;
            }
            
        }
        if (!hasLanded)
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, -50)* Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ISlice clickableObject))
        {
            clickableObject.getSlice();
        }


        if (collision.gameObject.tag == "Ground")
        {
            remainingJump = 5;
            Debug.Log("NASSSSAO JE!!!!");
            hasLanded = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            remainingJump = 5;
            hasLanded = false;
        }
    }

    private void moveAndRotate()
    {
        //Move and Rotate
        hasLanded = false;
        rb.AddForce(Vector3.forward * moveForce+ Vector3.up * jumpForce, ForceMode.Impulse);
    }
    public void TurnX()
    {
        z = -1;
    }

}
