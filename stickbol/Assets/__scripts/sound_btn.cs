using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sound_btn : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;
    public GameObject buttonAudio; //������

    [Header("������")]
    public AudioClip clip; //��� ���� (������)

    [Header("")]
    public AudioSource audio; //��������, ������� ������������� ����

    public void OnOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
    }
}
