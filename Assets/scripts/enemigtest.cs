using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigtest : MonoBehaviour
{
    public Transform heroi; // Referência ao transform do herói
    public float velocidade = 5f; // Velocidade do inimigo
    public float distanciaDeteccao = 2f; // Distância para detectar obstáculos
    public float forcaPulo = 10f; // Força do pulo do inimigo
    private Rigidbody2D rb; // Componente Rigidbody2D do inimigo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtém o Rigidbody2D
    }

    void Update()
    {
        if (heroi != null) // Verifica se o herói existe
        {
            // Movimento horizontal em direção ao herói
            Vector2 direcao = (heroi.position - transform.position).normalized;
            transform.position += (Vector3)direcao * velocidade * Time.deltaTime;

            // Detecção de obstáculos à frente
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direcao, distanciaDeteccao);
            if (hit.collider != null && hit.collider.CompareTag("Obstaculo")) // Se encontrou um obstáculo
            {
                // Pulo para desviar do obstáculo
                rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            }
        }
    }
}
