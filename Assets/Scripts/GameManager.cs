using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{

    public static GameManager instance;
    public TMP_Text coinText;
    int score = 0;
   




    [SerializeField]
    public GameObject menu;

    //[SerializeField]
    //private GameObject endGame;


    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0;
        //coinText.text = score.ToString();
    }

    // Update is called once per frame










    public void incraseCoins(int x)
    {
        score += x;
        //coinText.text = score.ToString();
    }

    public void showMenu()
    {
        menu.SetActive(true);
       
    }

    public void startGameFromBegin()
    {
        menu.SetActive(false);
       
        Time.timeScale=1;
    }

    
    public void onClickNewGame()
    {
        Debug.Log("A brate sto ne radis");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    

    }

}
