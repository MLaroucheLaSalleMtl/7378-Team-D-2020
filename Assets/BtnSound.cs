using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnSound : MonoBehaviour
{
    public AudioSource audio;
    public AudioClip Btn;

    public void Btnsound()
    {
        audio.PlayOneShot(Btn);
    }
}