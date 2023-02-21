using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Hero : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer ren;
    public GameObject still, fight, move,roll;
    bool leftStarted = false;
    bool rightStarted = false;
    bool inAir = false;
    bool spaceClicked = false;
    public TextMeshProUGUI score;
    Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space) && inAir == false)
        {
          
            
            inAir = true;
            spaceClicked = true;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up, ForceMode2D.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            flipRight();
            movementStarted();
            leftStarted = false;
            rightStarted = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            flipLeft();
            movementStarted();
            rightStarted = false;
            leftStarted = true;
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            movementStopped();
            rightStarted = false;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            movementStopped();
            leftStarted = false;
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            fightStarted();
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            fightStopped();
            
        }
    }

    private void FixedUpdate()
    {
        if (inAir) return;
        if (leftStarted)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-3f, 0);
        }
        if (rightStarted)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(3f, 0);
        }
    }

    
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick")
        {
            inAir = true;
            
        }
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Brick" )
        {
            if (spaceClicked == false)
            {
                startRolling();
            }
            inAir = false;
            spaceClicked = false;
        }

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



//my functions

    private void movementStarted()
    {
        roll.SetActive(false);
        move.SetActive(true);
        still.SetActive(false);
        fight.SetActive(false);
    }

    private void movementStopped()
    {
        move.SetActive(false);
        still.SetActive(true);
    }

    private void fightStarted()
    {
        roll.SetActive(false);
        move.SetActive(false);
        still.SetActive(false);
        fight.SetActive(true);
    }

    private void fightStopped()
    {
        move.SetActive(false);
        still.SetActive(true);
        fight.SetActive(false);
    }

    private void startRolling()
    {
        roll.SetActive(true);
        move.SetActive(false);
        still.SetActive(false);
        Invoke("stopRoll", 0.5f);
    }
    private void stopRoll ()
    {
        roll.SetActive(false);
        move.SetActive(false);
        still.SetActive(true);
        
    }
    private void flipRight()
    {
        move.GetComponent<SpriteRenderer>().flipX = false;
        still.GetComponent<SpriteRenderer>().flipX = false;
        fight.GetComponent<SpriteRenderer>().flipX = false;
        roll.GetComponent<SpriteRenderer>().flipX = false;
    }

    private void flipLeft()
    {
        move.GetComponent<SpriteRenderer>().flipX = true;
        still.GetComponent<SpriteRenderer>().flipX = true;
        fight.GetComponent<SpriteRenderer>().flipX = true;
        roll.GetComponent<SpriteRenderer>().flipX = true;
    }

    
}
