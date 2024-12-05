using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimerStart = 3;
    public Text TimerText;
    private bool gameStarted = false;

    // ������ � ������� ������ ��� ������ ��������
    private string[] tagsToActivate = { "ball", "RedPlayer", "BluePlayer" }; //���� ����� �������� ���� ������ ���������� � ����� �������, ���� ������������!!!

    private List<GameObject> objectsToActivate = new List<GameObject>();

    void Start()
    {
        TimerText.text = TimerStart.ToString();

        // ������� � ��������� ������ �� ��� ������� � ������� ������
        foreach (string tag in tagsToActivate)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objects)
            {
                // ��������� ������ � ���������� ���������
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.isKinematic = true; // ��������� ������
                }

                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.enabled = false; // ��������� ��������� (������ ���������)
                }

                // ��������� ������ � ������ ��� ���������� ���������
                objectsToActivate.Add(obj);
            }
        }
    }

    void Update()
    {
        if (!gameStarted)
        {
            TimerStart -= Time.deltaTime;

            if (TimerStart > 0)
            {
                TimerText.text = Mathf.Ceil(TimerStart).ToString();
            }
            else if (TimerStart <= 0 && TimerStart > -1)
            {
                TimerText.text = "������!";
            }
            else if (TimerStart <= -1)
            {
                StartGame();
            }
        }
    }

    void StartGame()
    {
        gameStarted = true;
        TimerText.gameObject.SetActive(false); // �������� ����� �������

        // �������� ������ � ��������� ��� ���� �������� � ������
        foreach (GameObject obj in objectsToActivate)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = false; // �������� ������
            }

            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = true; // �������� ��������� (������ �������)
            }
        }

        Debug.Log("���� ��������!");
    }
}
