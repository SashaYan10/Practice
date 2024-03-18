using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.U2D.Aseprite;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Char_Select : MonoBehaviour
{
    public GameObject heroGun;
    public GameObject heroRPG;

    private Vector3 charPosition;
    private Vector3 charOutside;

    private int charInt = 1;

    private SpriteRenderer GunRen, RPGRen;

    private readonly string charSelected = "charSelected";

    private void Awake()
    {
        charPosition = heroGun.transform.position;
        charOutside = heroRPG.transform.position;

        GunRen = heroGun.GetComponent<SpriteRenderer>();
        RPGRen = heroRPG.GetComponent<SpriteRenderer>();
    }

    public void Next()
    {
        switch (charInt)
        {
            case 1:
                PlayerPrefs.SetInt(charSelected, 1);
                GunRen.enabled = false;
                heroGun.transform.position = charOutside;
                heroRPG.transform.position = charPosition;
                RPGRen.enabled = true;
                charInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(charSelected, 2);
                RPGRen.enabled = false;
                heroRPG.transform.position = charOutside;
                heroGun.transform.position = charPosition;
                GunRen.enabled = true;
                charInt++;
                Loop();
                break;
                default: Loop(); break;
        }
    }

    public void Previous()
    {
        switch (charInt)
        {
            case 1:
                PlayerPrefs.SetInt(charSelected, 1);
                GunRen.enabled = false;
                heroGun.transform.position = charOutside;
                heroRPG.transform.position = charPosition;
                RPGRen.enabled = true;
                charInt--;
                Loop();
                break;
            case 2:
                PlayerPrefs.SetInt(charSelected, 2);
                RPGRen.enabled = false;
                heroRPG.transform.position = charOutside;
                heroGun.transform.position = charPosition;
                GunRen.enabled = true;
                charInt--;
                break;
            default: Loop(); break;
        }
    }

    private void Loop()
    {
        if (charInt >= 2)
        {
            charInt = 1;
        }
        else
        {
            charInt = 2;
        }
    }

    public void Manager()
    {
        SceneManager.LoadScene(1);
    }
} 
