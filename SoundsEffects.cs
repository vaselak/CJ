using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsEffects : MonoBehaviour
{
    public static SoundsEffects Instance;

    public AudioClip throow;
    public AudioClip takeDamage;
    public AudioClip buton;
    public AudioClip alertSound;
    public AudioClip recupItem;
    public AudioClip aiSound;
    public AudioClip PegaIssoSound;
    public AudioClip movimentada;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("BLALBLALBLALVBL");
        }
        Instance = this;
    }


    public void MakeThroow()
    {
        MakeSound(throow);
    }

    public void MakeTakeDamage()
    {
        MakeSound(takeDamage);
    }

    public void MakeButton()
    {
        MakeSound(buton);
    }

    public void MakeAlertSound()
    {
        MakeSound(alertSound);
    }

    public void MakeRecupItem()
    {
        MakeSound(recupItem);
    }

    public void MakeAiSound()
    {
        MakeSound(aiSound);
    }

    public void MakePegaSound()
    {
        MakeSound(PegaIssoSound);
    }

    public void MakeMovimentada()
    {
        MakeSound(movimentada);
    }


    private void MakeSound(AudioClip originalClip)
    {
        AudioSource.PlayClipAtPoint(originalClip, transform.position);
    }

}
