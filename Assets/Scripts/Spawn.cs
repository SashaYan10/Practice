using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Sprite heroGun, heroRPG;

    private SpriteRenderer mainSprite;

    private readonly string charSelected = "charSelected";

    public void Awake()
    {
        mainSprite = this.GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        int getChar;

        getChar = PlayerPrefs.GetInt(charSelected);

        switch (getChar)
        {
            case 1:
                mainSprite.sprite = heroGun;
                break;
            case 2:
                mainSprite.sprite = heroRPG;
                break;
            default:
                mainSprite.sprite = heroRPG;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
