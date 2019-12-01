using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Text time;
    public Text life;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (time != null && life != null)
        { 
        time.text = "Time: " + Mathf.FloorToInt(GM.instance.tempo);
        life.text = " " + Mathf.FloorToInt(Player.instance.life);
        }
    }

    public void ButtonStart()
    {
        SceneManager.LoadScene("Game");
        SoundsEffects.Instance.MakeButton();
    }

    public void ButtonMenu()
    {
        SceneManager.LoadScene("Controls");
        SoundsEffects.Instance.MakeButton();
    }

    public void ButtonBack()
    {
        SceneManager.LoadScene("Menu");
        SoundsEffects.Instance.MakeButton();
    }

    public void ButtonExit()
    {
        Application.Quit();
        SoundsEffects.Instance.MakeButton();
    }
}
