using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMove : MonoBehaviour
{
    public float minSpeed = 5f;
    public float maxSpeed = 15f;
    private Rigidbody2D rb;
    private Camera MainCamera;
    private Vector2 screenBounds;
    private float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        float xSpeed = Random.Range(minSpeed, maxSpeed);
        float ySpeed = Random.Range(minSpeed, maxSpeed);
        rotationSpeed = Random.Range(-3f, 3f);
        if (transform.position.x > screenBounds.x)
        {
            xSpeed = xSpeed * -1;
        }
        if(transform.position.y > screenBounds.y)
        {
            ySpeed = ySpeed * -1;
        }
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xSpeed, ySpeed);
        MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, rotationSpeed);
        remove();
        
    }

    private void remove()
    {
        if ((transform.position.x < screenBounds.x * -1 - 10) ||
            (transform.position.x > screenBounds.x + 10) || (transform.position.y < screenBounds.y * -1 - 10) ||
            (transform.position.y > screenBounds.y + 10))
        {
            Destroy(this.gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        float breakChance = Random.value;
        if (col.gameObject.name.Contains("Large Asteroid") &&
            this.gameObject.name.Contains("Large Asteroid") && breakChance > .75f)
        {
            ContactPoint2D contact = col.contacts[0];
            Vector2 pos = contact.point + ((Vector2)this.transform.position - contact.point) / 2;
            GameObject instance = Instantiate(Resources.Load("Medium Asteroid") as GameObject, pos, transform.rotation);
            Destroy(this.gameObject);
        } else if (col.gameObject.name.Contains("Large Asteroid") &&
            this.gameObject.name.Contains("Medium Asteroid") && breakChance > .5f)
        {
            ContactPoint2D contact = col.contacts[0];
            Vector2 pos = contact.point + ((Vector2)this.transform.position - contact.point) / 2;
            GameObject instance = Instantiate(Resources.Load("Small Asteroid") as GameObject, pos, transform.rotation);
            Destroy(this.gameObject);
        }
        else if (col.gameObject.name.Contains("Large Asteroid") &&
          this.gameObject.name.Contains("small Asteroid") && breakChance > .25f)
        {
            Destroy(this.gameObject);
        }
        else if (col.gameObject.name.Contains("Medium Asteroid") &&
           this.gameObject.name.Contains("Medium Asteroid") && breakChance > .75f)
        {
            ContactPoint2D contact = col.contacts[0];
            Vector2 pos = contact.point + ((Vector2)this.transform.position - contact.point) / 2;
            GameObject instance = Instantiate(Resources.Load("Small Asteroid") as GameObject, pos, transform.rotation);
            Destroy(this.gameObject);
        }
        else if (col.gameObject.name.Contains("Medium Asteroid") &&
          this.gameObject.name.Contains("small Asteroid") && breakChance > .5f)
        {
            Destroy(this.gameObject);
        } else if (col.gameObject.name.Contains("ship"))
        {
            Destroy(col.gameObject);
        }
    }
}
