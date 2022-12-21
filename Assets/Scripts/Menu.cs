using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    private GameObject menu;

    [SerializeField]
    private GameObject endGame;


    public void onClickNewGame()
    {
        GameManager.instance.onClickNewGame();
    }

    public void startGameFromBegin()
    {
        GameManager.instance.startGameFromBegin();
    }

}
