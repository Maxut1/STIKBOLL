using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class point : MonoBehaviour
{

    public int               score1;
    public GameObject        ball, _BluePlayer, _RedPlayer;
    public int               score2;
    private bool             endMath = false;
    public int               end = 5;
    [SerializeField] Text    scoreText2;
    [SerializeField] Text    scoreText1;
    [SerializeField] private Text NameText;
    [SerializeField] private string[] Names;


    private void SlowTime()
    {
      Time.timeScale = 0.1f;
      Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    
    public void  FastTime()
    {
      Time.timeScale = 1f;
      Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }

    void Start()
    {
        //_RedPlayer = GameObject.FindGameObjectWithTag("RedPlayer");
        //_BluePlayer = GameObject.FindGameObjectWithTag("BluePlayer");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        

        if (other.gameObject.tag == "geng")
        {
          score1++;
          //NameText.text = Names[Random.Range(0, Names.Length)];
           if (score1 == end)
           {
               endMath = true;
           }
            SlowTime();
            StartCoroutine(ExampleCoroutine());
            
        }


        else if(other.gameObject.tag == "boom")
        {
            score2++;
            //NameText.text = Names[Random.Range(0, Names.Length)];
           if(score2 == end)
           {
               endMath = true;
           }
            SlowTime();
            StartCoroutine(ExampleCoroutine());
        } 
    }

         
    void Update() 
    {
        scoreText1.text = score1.ToString();
        scoreText2.text = score2.ToString();
    }



    IEnumerator ExampleCoroutine()
    {
        for (int i = 0; i < 2; i++)
        {
            yield return new WaitForSeconds(0.1f);
        }

        if(endMath == false)
        {
          ball.transform.position = new Vector3(0.04f, 2.18f, 0);
          ball.GetComponent<Rigidbody2D>(). velocity = new Vector2(0, 0);
          _RedPlayer.transform.position = new Vector3(6, -2, 0);
          _BluePlayer.transform.position = new Vector3(-6, -2, 0);


         for (int i = 0; i < 2; i++)
         {
            yield return new WaitForSeconds(0.1f);
         }

          FastTime();
         
        }
       
    }


}
