using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update


    // Update is called once per frame
    Rigidbody2D rb;
    bool ground=false;
    [SerializeField] GameObject live1,live2,live3,uicon,bonusEffect,platform;
    int live = 3;
    private UiControler uiconScript;
    bool bonus = false;
    float timer;
    [SerializeField] Sprite LiveOn, LiveOff;
    private UnityEngine.Vector3 velocity = UnityEngine.Vector3.zero;
    bool respawnLive=true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        uiconScript = uicon.GetComponent<UiControler>();
    }
    void Update()
    {
        Debug.Log(respawnLive);
        if (PlayerPrefs.GetInt("reLive") == 1)
        {
            PlayerPrefs.SetInt("reLive", 0);
            respawnLive = true;
        }
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && ground)
            {

                rb.AddForce(new UnityEngine.Vector2(0, 10), ForceMode2D.Impulse);
                ground = false;
            }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) && bonus)
        {

            rb.AddForce(new UnityEngine.Vector2(0, 2), ForceMode2D.Impulse);
      
        }


        //действия от бонуса
        if (bonus)
        {
            
            bonusEffect.SetActive(true);
            timer += Time.deltaTime;
            if (timer >= 10)
            {
                bonus = false;
                timer = 0;
                bonusEffect.SetActive(false);
                rb.gravityScale = 1;

            }
          
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "panel")
        {
            ground = true;
        }
       
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "panel")
        {
            ground = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "coin")
        {
            PlayerPrefs.SetInt("coin", PlayerPrefs.GetInt("coin") + 1);
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "DopLive")
        {
            if (live<=2)
            {
                live++;
                LifeCheak();
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "bonus")
        {
            if (bonus)
            {
                timer -= 5;
            }
            bonus = true;
            Destroy(collision.gameObject);
            rb.gravityScale = 0; ;
            StartCoroutine(MoveToTarget());
        }
        if (collision.gameObject.tag == "ground")
        {
            Dead();
        }
    }

    public void Dead()
    {
      
        if (respawnLive)
        {
            if (PlayerPrefs.GetInt("vibr") == 1)
            {
              //  Handheld.Vibrate();
            }

            
            if (!bonus && respawnLive)
            {
                live -= 1;

                LifeCheak();
                respawnLive = false;
            }
           
        }
        if (GameObject.FindWithTag("spawn") != null && !respawnLive)
        {
            transform.position = GameObject.FindWithTag("spawn").transform.position;
            if (transform.position.y > -5)
            {
                respawnLive = true;
            }
        }

    }
    public void LifeCheak()
    {
        switch (live)
        {
            case 3:
                live1.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
                live2.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
                live3.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
                break;
            case 2:
                live3.GetComponent<UnityEngine.UI.Image>().sprite = LiveOff;
                live2.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
                live1.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
                break;
            case 1:
                live3.GetComponent<UnityEngine.UI.Image>().sprite = LiveOff;
                live2.GetComponent<UnityEngine.UI.Image>().sprite = LiveOff;
                live1.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
                break;
            case 0:
                live3.GetComponent<UnityEngine.UI.Image>().sprite = LiveOff;
                live2.GetComponent<UnityEngine.UI.Image>().sprite = LiveOff;
                live1.GetComponent<UnityEngine.UI.Image>().sprite = LiveOff;
                respawnLive = true;
                GameOver();
                break;
            default:
                break;
        }
    }
    public void GameOver()
    {
        respawnLive = true;
        uiconScript.GameOverMenu();
        transform.position = new UnityEngine.Vector2(-0.74f, 0.42f);
        live1.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
        live2.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
        live3.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
        live = 3;
        
    }
    public void ExitGame()
    {respawnLive = true;
        transform.position = new UnityEngine.Vector2(-0.74f, 0.42f);
        live1.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
        live2.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
        live3.GetComponent<UnityEngine.UI.Image>().sprite = LiveOn;
        live = 3;

            uiconScript.ExitToMenu();
        

    }
    private IEnumerator MoveToTarget()
    {
        while ((UnityEngine.Vector2)transform.position != new UnityEngine.Vector2(0, 2))
        {
            // Интерполируем текущую позицию к целевой позиции с использованием Lerp
            transform.position = UnityEngine.Vector2.Lerp(transform.position,new UnityEngine.Vector2(0,2), 2 * Time.deltaTime);
            if (transform.position.y>1.5)
            {
                rb.gravityScale = 0.1f;
                yield break;
                
            }
            yield return null;
        }
    }
    private IEnumerator Respawn()
    {
        
            yield return null;
        
    }
}
