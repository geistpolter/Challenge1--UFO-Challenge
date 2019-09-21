using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Public makes things show up in inspector as editable property
    public float speed;
    public Text countText;
    public Text winText;
    public Text livesText;

    private Rigidbody2D rb2d;
    private int count;
    private int lives;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        SetCountText();
        lives = 3;
        SetLivesText();
        winText.text = "";

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count += 1;
            SetCountText();
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);
            lives -= 1;
            SetLivesText();
        }
        if (count == 12)
        {
            transform.position = new Vector2(154.35f, 0f);
        }
    }
    private void SetLivesText()
    {
        livesText.text = "Lives: " + lives.ToString();
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 20)
        {
            winText.text = "You Win! Game designed by Cheyenne Fiedler";
        }
    }


}
