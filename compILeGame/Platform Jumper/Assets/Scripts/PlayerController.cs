using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour {
    public int speed;
    public Rigidbody rb;
    public float jump;
    public TextMeshProUGUI TextBox;
    public TextMeshProUGUI TextBoxScore;
    public GameObject PlayAgain;
    public GameObject MainMenu;

    private Vector3 lastPosition;
    private bool isGrounded = true;
    private bool highJump = false;
    private int count;
    private bool doubleJump = false;
    private int score;
	// Use this for initialization
	void Start () {
        speed = 3;
        rb = GetComponent<Rigidbody>();
        count = 0;
        score = 0;
        
        MainMenu.gameObject.SetActive(false);
        PlayAgain.gameObject.SetActive(false);
        TextBox.gameObject.SetActive(false);

    }

    private void Update()
    {
        if (((this.transform.position.y) * 10) > score)
            
            score = (int)(this.transform.position.y*10);

        
    }
    private void OnGUI()
    {
        TextBoxScore.text = "Score: "+score;
    }

    private void FixedUpdate()
    {
        float movement = Input.GetAxis("Horizontal") * speed;
        movement += Time.deltaTime;
        rb.AddRelativeTorque(Vector3.back * movement);
        //jump code
        if (Input.GetButtonDown("Jump") && isGrounded == true && highJump == true)
        {
            rb.velocity += jump/2*3 * Vector3.up;
        }
        else if (Input.GetButtonDown("Jump") && isGrounded == true && doubleJump == true)
        {
            rb.velocity += jump * Vector3.up;
            count += 1;
        }
        else if (Input.GetButtonDown("Jump") && isGrounded == true)
        {
            rb.velocity += jump * Vector3.up;
        }
        

        if (count >= 2)
        {
            isGrounded = false;
            doubleJump = false;
            count = 0;
        }

    }

    // methods for jump. detect whether it is on gound or not.
    private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Floorx2"))
            {
                highJump = true;
                isGrounded = true;
            }
            if (collision.gameObject.CompareTag("Floor"))
            {

                isGrounded = true;
            }
            if (collision.gameObject.CompareTag("Double Jump"))
            {

                isGrounded = true;
                doubleJump = true;
            }



    }
    private void OnCollisionExit(Collision collision)
    {
       if (collision.gameObject.CompareTag("Floor"))
       {
            isGrounded = false;
            
       }
        if (collision.gameObject.CompareTag("Floorx2"))
        {
            isGrounded = false;
            highJump = false;
        }
        if (collision.gameObject.CompareTag("Double Jump") && count == 0)
        {
            isGrounded = true;
            doubleJump = true;
           
        }


    }
    // if the player enters the invisible plane under the level that indicates that the player has fallen and lost show text that asks to play again.
    // To Do: If player has a highscore prompt user for name and add their score to list of top ten scores.

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Game Over"))
        {
            MainMenu.gameObject.SetActive(true);
            PlayAgain.gameObject.SetActive(true);
            TextBox.gameObject.SetActive(true);
            TextBox.text = "Game Over";

        }

        if (other.gameObject.CompareTag("Final Level Complete"))
        {
            MainMenu.gameObject.SetActive(true);
            PlayAgain.gameObject.SetActive(true);
            TextBox.gameObject.SetActive(true);
            TextBox.text = "Game Over";
        }


    }





}
