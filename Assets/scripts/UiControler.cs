using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class UiControler : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject Menu, Settings, HTP, Shop, Game, StartPanel, player1, player2, player3, player4, gameOver, VibrIndif, NewRecordImage, ExBut1, ExBut2, ExBut3, ExBut4;
    [SerializeField] AudioClip GameSound, MenuSound;
    [SerializeField] AudioSource audioS;
    [SerializeField] Text scoreText,GameOverText,moneyText, moneyText1, moneyText2, moneyText3;
    [SerializeField] Sprite VibrOn, VibrOff;
    private float score;
    Animator anim;

    void Start()
    {        
        anim = GetComponent<Animator>();
        Time.timeScale = 0;
        if (PlayerPrefs.GetInt("vibr") != 1)
        {
            VibrIndif.GetComponent<UnityEngine.UI.Image>().sprite = VibrOff;
            PlayerPrefs.SetInt("vibr", 0);
        }
        else
        {
            VibrIndif.GetComponent<UnityEngine.UI.Image>().sprite = VibrOn;
            PlayerPrefs.SetInt("vibr", 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime * 2;

        scoreText.text = Mathf.Round(score).ToString();
        moneyText.text = PlayerPrefs.GetInt("coin").ToString();
        moneyText1.text = PlayerPrefs.GetInt("coin").ToString();
        moneyText2.text = PlayerPrefs.GetInt("coin").ToString();
        moneyText3.text = PlayerPrefs.GetInt("coin").ToString();
    }


    public void ToSettings()
    {
        Ochist();
        Settings.SetActive(true);
    }



    public void ToShop()
    {
        Ochist();
        Shop.SetActive(true);
    }


    public void ToInfo()
    {
        Ochist();
        HTP.SetActive(true);    
    }




    public void ToGame()
    {
        //anim.SetBool("start", true);
        Time.timeScale = 1;
        
        Ochist();
        Instantiate(StartPanel);
        Game.SetActive(true);

        audioS.clip = GameSound;
        audioS.Play();
        if (PlayerPrefs.GetInt("activePlayer")==0)
        {
            PlayerPrefs.SetInt("activePlayer",1);
            player1.SetActive(true);
            ExBut1.SetActive(true);
        }
        else
        {
            switch (PlayerPrefs.GetInt("activePlayer"))
            {
                case 1:
                    player1.SetActive(true);
                    ExBut1.SetActive(true);
                    break;
                case 2:
                    player2.SetActive(true);
                    ExBut2.SetActive(true);
                    break;
                case 3:
                    player3.SetActive(true);
                    ExBut3.SetActive(true);
                    break;
                case 4:
                    player4.SetActive(true);
                    ExBut4.SetActive(true);
                    break;
                default:
                    break;
            }
        }
       
        
    }


    public void ExitToMenu()
    {
        
        Time.timeScale = 0;
        if (Game.activeInHierarchy == true)
        {
            GameObject[] panel = GameObject.FindGameObjectsWithTag("panel");

            for (int i = 0; i < panel.Length; i++)
            {
                Destroy(panel[i].gameObject);
            }

            audioS.clip = MenuSound;
            audioS.Play();
        }
        Ochist();      
        Menu.SetActive(true);      
       
    }

    public void Restart()
    {
        Ochist();
        ToGame();
        PlayerPrefs.SetInt("reLive", 1);
    }

    public void GameOverMenu()
    {
       
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false);
        Time.timeScale = 0;
        gameOver.SetActive(true);
        if (PlayerPrefs.GetInt("BestScore")<score)
        {
            PlayerPrefs.SetInt("BestScore", (int)Mathf.Round(score));
            NewRecordImage.SetActive(true);
        }
        GameObject[] panel = GameObject.FindGameObjectsWithTag("panel");
        GameOverText.text = Mathf.Round(score).ToString();
        score = 0;
        for (int i = 0; i < panel.Length; i++)
        {
            Destroy(panel[i].gameObject);
        }
        PlayerPrefs.SetInt("reLive", 1);
    }

    public void SwitchVibration()
    {
        if (PlayerPrefs.GetInt("vibr") != 1)
        {
            VibrIndif.GetComponent<UnityEngine.UI.Image>().sprite = VibrOn;
            PlayerPrefs.SetInt("vibr", 1);
        }
        else
        {
            VibrIndif.GetComponent<UnityEngine.UI.Image>().sprite = VibrOff;
            PlayerPrefs.SetInt("vibr", 0);
        }
    }


    public void Ochist()
    {
        ExBut1.SetActive(false);
        ExBut2.SetActive(false);
        ExBut3.SetActive(false);
        ExBut4.SetActive(false);
        NewRecordImage.SetActive(false);
        Menu.SetActive(false);
        Settings.SetActive(false);
        HTP.SetActive(false);
        Shop.SetActive(false);
        Game.SetActive(false);
        player1.SetActive(false);
        player2.SetActive(false);
        player3.SetActive(false);
        player4.SetActive(false); 
        gameOver.SetActive(false);
    }
    public void AnimOff()

    {
        anim.SetBool("start", false);
    }
    public void ToGameanim()
    {
        Time.timeScale = 1;
        anim.SetBool("start", true);
    }

    public void ToGameanim1()
    {
        ToGame();
    }
}
