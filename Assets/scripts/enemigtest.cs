using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigtest : MonoBehaviour
{
    public Transform heroi; // Refer�ncia ao transform do her�i
    public float velocidade = 5f; // Velocidade do inimigo
    public float distanciaDeteccao = 2f; // Dist�ncia para detectar obst�culos
    public float forcaPulo = 10f; // For�a do pulo do inimigo
    private Rigidbody2D rb; // Componente Rigidbody2D do inimigo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obt�m o Rigidbody2D
    }

    void Update()
    {
        if (heroi != null) // Verifica se o her�i existe
        {
            // Movimento horizontal em dire��o ao her�i
            Vector2 direcao = (heroi.position - transform.position).normalized;
            transform.position += (Vector3)direcao * velocidade * Time.deltaTime;

            // Detec��o de obst�culos � frente
            RaycastHit2D hit = Physics2D.Raycast(transform.position, direcao, distanciaDeteccao);
            if (hit.collider != null && hit.collider.CompareTag("Obstaculo")) // Se encontrou um obst�culo
            {
                // Pulo para desviar do obst�culo
                rb.AddForce(Vector2.up * forcaPulo, ForceMode2D.Impulse);
            }
        }
    }
}
