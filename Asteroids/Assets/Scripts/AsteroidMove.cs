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
    // Start is called before the first frame update
    void Start()
    {
        float xSpeed = Random.Range(minSpeed, maxSpeed);
        float ySpeed = Random.Range(minSpeed, maxSpeed);
        if(transform.position.x > 0)
        {
            xSpeed = xSpeed * -1;
        }
        if(transform.position.y > 0)
        {
            ySpeed = ySpeed * -1;
        }
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xSpeed, ySpeed);
        MainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
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
}
