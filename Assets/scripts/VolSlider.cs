using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolSlider : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] AudioSource audioS;
    [SerializeField] Slider slider;
    [SerializeField] Sprite VolOnSprite,VolOffSprite;
    [SerializeField] GameObject VolButton;
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("vol");
    }

    // Update is called once per frame
    void Update()
    {
        audioS.volume=slider.value;
        
    }
    private void FixedUpdate()
    {
        PlayerPrefs.SetFloat("vol",slider.value);
    }
    public void VolOff()
    {
       
        if (slider.value == 0)
        {
            slider.value = PlayerPrefs.GetFloat("VolFiks");
            VolButton.GetComponent<Image>().sprite = VolOnSprite;
        }
        else
        {
            PlayerPrefs.SetFloat("VolFiks", slider.value);
            slider.value = 0;
            VolButton.GetComponent<Image>().sprite = VolOffSprite;
        }
        
    }
}
