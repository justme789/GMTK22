using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed = 7;
    public float jump = 14;
    private SpriteRenderer spriteRenderer;
    public Sprite[] spriteArray;
    private Rigidbody2D body;
    private Animator anim;
    private bool grounded;
    private int weight = 0;
    

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, body.velocity.y);
        anim.SetBool("jump", !grounded);
        if(transform.position.y < -12){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (Input.GetKey(KeyCode.Space) && grounded)
        {
            weight = Random.Range(0, 6);
            spriteRenderer.sprite = spriteArray[weight];
            body.velocity = new Vector2(Input.GetAxis("Horizontal") * speed, jump);
            grounded = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        string c = tag.Substring(0, 1);
        int w = int.Parse(tag.Substring(1));
        if((w < weight+1&& c.Equals("b"))||(w > weight+1&& c.Equals("r"))){
            Destroy(collision.gameObject);
            grounded = false;
        }
        else if(collision.gameObject.tag != "Enemy")
        {
            grounded = true;
        }
    }
}
