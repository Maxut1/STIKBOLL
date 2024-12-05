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
        // Находим все объекты с тегом "Score"
        GameObject[] scoreObjects = GameObject.FindGameObjectsWithTag("Score");

        int totalScore = 0;

        // Проходим по всем объектам с тегом "Score"
        foreach (GameObject obj in scoreObjects)
        {
            Text scoreText = obj.GetComponent<Text>(); // Получаем компонент Text
            if (scoreText != null)
            {
                // Парсим текст в целое число и добавляем к общему счёту
                totalScore += int.Parse(scoreText.text);
            }
        }
        return totalScore;

    }

    // Update is called once per frame
    void Update()
    {
        // Проверяем, что это второй раунд и сумма очков больше 1
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
