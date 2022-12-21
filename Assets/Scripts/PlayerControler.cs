using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerControler : MonoBehaviour
{
    public GameObject donut;
    public GameObject knife;


    Rigidbody rb;

    bool hasLanded;

    [SerializeField]
    GameObject butn1, butn2;

    [SerializeField]
    AudioSource audio, victory;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float moveForce;

    [SerializeField]
    private Vector3 _rotation;

    [SerializeField]
    private float rotationSpeed;

    Transform pivotPoint;


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
        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.Space))
        {
          
                moveAndRotate();
               
            
        }
        if (!hasLanded)
        {
            Quaternion deltaRotation = Quaternion.Euler(new Vector3(0, 0, -rotationSpeed) * Time.fixedDeltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out ISlice clickableObject))
        {
            audio.Play();
            clickableObject.getSlice(this);
        }


        if (collision.gameObject.tag == "Ground")
        {
           
            Debug.Log("NASSSSAO JE!!!!");
            hasLanded = true;
            rb.Sleep();
            GameManager.instance.menu.SetActive(true);
            butn1.SetActive(false);
            butn2.SetActive(true);

            //GameManager.instance.startGameFromBegin();

        }

        if(collision.gameObject.tag == "Fin")
        {
           
            victory.Play();
            rb.Sleep();
            rb.isKinematic = true;
            butn1.SetActive(true);
            butn2.SetActive(false);

            GameManager.instance.menu.SetActive(true);
           
           
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="Ground")
        {
            
            hasLanded = false;
            //Application.Quit();

        }
    }

    private void moveAndRotate()
    {
        //Move and Rotate
        hasLanded = false;
        rb.AddForce(Vector3.forward * moveForce+ Vector3.up * jumpForce, ForceMode.Impulse);
    }









}
