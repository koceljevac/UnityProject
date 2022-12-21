using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slice : MonoBehaviour,ISlice
{

    public GameObject gameObjOrg;
    public GameObject gameObjLeft;
    public GameObject gameObjRight;
    public Transform _transform;

    public PlayerControler player;


    public void getSlice(PlayerControler player)
    {
        GameManager.instance.incraseCoins(300);
        _transform = gameObjOrg.transform;
        Instantiate(gameObjLeft, _transform.position, _transform.rotation);
        Instantiate(gameObjRight, _transform.position, _transform.rotation);
        Destroy(gameObjOrg);
       
    }

}
