using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float TimerStart = 3;
    public Text TimerText;
    private bool gameStarted = false;

    // Массив с разными тегами для поиска объектов
    private string[] tagsToActivate = { "ball", "RedPlayer", "BluePlayer" }; //сюда потом добавить теги каждой конечности и голов игроков, если понадобиться!!!

    private List<GameObject> objectsToActivate = new List<GameObject>();

    void Start()
    {
        TimerText.text = TimerStart.ToString();

        // Находим и сохраняем ссылки на все объекты с нужными тегами
        foreach (string tag in tagsToActivate)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag(tag);
            foreach (GameObject obj in objects)
            {
                // Отключаем физику и визуальный рендеринг
                Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                    rb.isKinematic = true; // Отключаем физику
                }

                Renderer renderer = obj.GetComponent<Renderer>();
                if (renderer != null)
                {
                    renderer.enabled = false; // Отключаем рендеринг (делаем невидимым)
                }

                // Добавляем объект в список для дальнейшей активации
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
                TimerText.text = "Вперед!";
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
        TimerText.gameObject.SetActive(false); // Скрываем текст таймера

        // Включаем физику и рендеринг для всех объектов в списке
        foreach (GameObject obj in objectsToActivate)
        {
            Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = false; // Включаем физику
            }

            Renderer renderer = obj.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = true; // Включаем рендеринг (делаем видимым)
            }
        }

        Debug.Log("Игра началась!");
    }
}
