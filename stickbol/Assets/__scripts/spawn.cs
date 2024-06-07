using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
  public Sprite grigory, valera, morgen;

  private SpriteRenderer mainSprite;
  
  private readonly string charSelected = "charSelected";

  public void Awake()
  {
    mainSprite = this.GetComponent<SpriteRenderer>();
  }

  public void Start()
  {
    int getChar;

    getChar = PlayerPrefs.GetInt(charSelected);

    switch (getChar)
    {
      case 1:
        mainSprite.sprite = valera;
        break;
      case 2:
        mainSprite.sprite = morgen;
        break;
      case 3:
        mainSprite.sprite = grigory;
        break;
      default:
        mainSprite.sprite = grigory;
        break;
    }
  }
}
