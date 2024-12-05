using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoostBox : MonoBehaviour
{
    public bool isBoosted;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isBoosted = Random.value > 0.5f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BluePlayer") || collision.CompareTag("RedPlayer"))
        {
            Destroy(gameObject); // �������� �������

            // �������� ������ � �������� ������
            player playerComponent = collision.GetComponent<player>(); // �������� ��������� player � ������� ������������
            if (playerComponent != null)
            {
                if (isBoosted) 
                {
                    playerComponent.speed *= 1.5f; // ����������� ��������
                    collision.transform.localScale /= 1.5f; // ��������� ������ �� 50%
                }
                else 
                {
                    playerComponent.speed /= 1.5f; // ��������� ��������
                    collision.transform.localScale *= 1.5f; // ����������� ������ �� 50%
                }
                
            }
        } 
    }
}
