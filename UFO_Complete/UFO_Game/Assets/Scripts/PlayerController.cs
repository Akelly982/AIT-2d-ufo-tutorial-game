using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float speed;
    private int count;
    public Text countText, winText;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        count = 0;
        setCountText();
        winText.text = "";
    }

    void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce (movement * speed);
    }

    
    private void OnTriggerEnter2D(Collider2D other)   // Collider2d of gameObject collided with
    {
        
        if (other.gameObject.CompareTag("PickUp")){  // if tag == PickUp
            other.gameObject.SetActive(false); // other game object do thing.
            count++;
            setCountText();


        }
    }


    void setCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 8)
        {
            winText.text = "YOU WIN!!";
        }
    }

}
