using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update

    bool leftStarted = false;
    bool rightStarted = false;
    bool inAir = false;
    public TextMeshProUGUI score;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inAir==false)
        {
            inAir = true;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
        }if (Input.GetKeyDown(KeyCode.D))
        {
            leftStarted = false;
            rightStarted = true;
        }if (Input.GetKeyDown(KeyCode.A))
        {
            rightStarted = false;
            leftStarted = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            rightStarted = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            leftStarted = false;
        }
    }

    private void FixedUpdate()
    {
        if (inAir) return;
        if (leftStarted)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-5f,0);
        }
        if (rightStarted)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(5f,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick") inAir = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coin")
        {
            LevelOneManager.score++;
            Destroy(collision.gameObject);
            score.text = LevelOneManager.score.ToString();
        }
    }
}
