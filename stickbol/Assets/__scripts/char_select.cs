using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class char_select : MonoBehaviour
{
    public GameObject Grigory;
    public GameObject valera;
    public GameObject morgen;
    public GameObject niga;

    private Vector3 charPosition;
    private Vector3 charOutside;

    private int charInt = 1;

    private SpriteRenderer grigoryRen, valeraRen, morgenRen, nigaRen;
    private readonly string charSelected = "charSelected";

    private void Awake()
    {
        charPosition = Grigory.transform.position;
        charOutside = morgen.transform.position;

        grigoryRen = Grigory.GetComponent<SpriteRenderer>();
        valeraRen = valera.GetComponent<SpriteRenderer>();
        morgenRen = morgen.GetComponent<SpriteRenderer>();
        nigaRen = niga.GetComponent<SpriteRenderer>();
    }

    public void Next()
    {
        switch (charInt)
        {
            case 1:
                PlayerPrefs.SetInt(charSelected, 1);
                grigoryRen.enabled = false;
                Grigory.transform.position = charOutside;
                valera.transform.position = charPosition;
                valeraRen.enabled = true;
                charInt++;
                break;
            case 2:
                PlayerPrefs.SetInt(charSelected, 2);
                valeraRen.enabled = false;
                valera.transform.position = charOutside;
                morgen.transform.position = charPosition;
                morgenRen.enabled = true;
                charInt++;
                break;
            case 3:
                PlayerPrefs.SetInt(charSelected, 3);
                morgenRen.enabled = false;
                morgen.transform.position = charOutside;
                Grigory.transform.position = charPosition;
                grigoryRen.enabled = true;
                charInt++;
                break;
            case 4:
                PlayerPrefs.SetInt(charSelected, 4);
                grigoryRen.enabled = false;
                Grigory.transform.position = charOutside;
                niga.transform.position = charPosition;
                nigaRen.enabled = true;
                charInt++;
                Loop();
                break;
            default:
                Loop();
                break;
            
        }
    }

    public void Previous()
    {
        switch (charInt)
        {
            case 1:
                PlayerPrefs.SetInt(charSelected, 2);
                grigoryRen.enabled = false;
                Grigory.transform.position = charOutside;
                niga.transform.position = charPosition;
                nigaRen.enabled = true;
                charInt--;
                Loop();
                break;
            case 2:
                PlayerPrefs.SetInt(charSelected, 3);
                valeraRen.enabled = false;
                valera.transform.position = charOutside;
                Grigory.transform.position = charPosition;
                grigoryRen.enabled = true;
                charInt--;
                break;
            case 3:
                PlayerPrefs.SetInt(charSelected, 1);
                nigaRen.enabled = false;
                niga.transform.position = charOutside;
                valera.transform.position = charPosition;
                valeraRen.enabled = true;
                charInt--;
                break;
            case 4:
                PlayerPrefs.SetInt(charSelected, 4);
                grigoryRen.enabled = false;
                Grigory.transform.position = charOutside;
                valera.transform.position = charPosition;
                valeraRen.enabled = true;
                charInt--;
                break;
            default:
                Loop();
                break;
        }
    }

    private void Loop()
    {
        if (charInt >= 4)
        {
            charInt = 1;
        }
        else
        {
            charInt = 4;
        }
    }

    public void Manager()
    {
        SceneManager.LoadScene(2);
    }
}
