using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class spawnBoostBox : MonoBehaviour
{
    [SerializeField]
    private GameObject obj;
    float RandX;
    Vector2 whereToSpawn;
    public float spawnRate = 2f;
    float nextSpawn = 0.0f;
    void Start()
    {

    }

    public int CheckScore()
    {
        // ������� ��� ������� � ����� "Score"
        GameObject[] scoreObjects = GameObject.FindGameObjectsWithTag("Score");

        int totalScore = 0;

        // �������� �� ���� �������� � ����� "Score"
        foreach (GameObject obj in scoreObjects)
        {
            Text scoreText = obj.GetComponent<Text>(); // �������� ��������� Text
            if (scoreText != null)
            {
                // ������ ����� � ����� ����� � ��������� � ������ �����
                totalScore += int.Parse(scoreText.text);
            }
        }
        return totalScore;

    }

    // Update is called once per frame
    void Update()
    {
        // ���������, ��� ��� ������ ����� � ����� ����� ������ 1
        if (CheckScore() > 1)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                RandX = Random.Range(-12.88f, 13.05f);
                whereToSpawn = new Vector2(RandX, transform.position.y);
                Instantiate(obj, whereToSpawn, Quaternion.identity);
            }
        }
        
    }

}
