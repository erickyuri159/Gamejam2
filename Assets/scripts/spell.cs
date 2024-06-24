using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spell : MonoBehaviour
{
    public GameObject player;

    private Animator anim;
    private Rigidbody2D rb;
    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        player = GameObject.Find("HeadPlayer");
    }
    private void FixedUpdate()
    {// direção e perseguir personagem
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //colisao e explode 
        anim.SetTrigger("Explosion");
        speed = 0;
        Destroy(gameObject.GetComponent<CircleCollider2D>());
        Destroy(gameObject.GetComponent<Rigidbody2D>());
        Destroy(gameObject, 0.4f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
