using System;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Tank : MonoBehaviour
{

    [SerializeField] Bullet bullet;
    Vector3 velocity;
    Vector3 direction;
    float speed;
    float horizontal = 0;
    float vertical = 0;
    Vector2 maxScreen, minScreen;


    void Start()
    {
        direction = transform.right;
        speed = 1.0f;

        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        horizontal = -Input.GetAxis("Horizontal");
        transform.Rotate(0, 0, horizontal);

        vertical = Input.GetAxis("Vertical");
        speed += vertical * 0.3f;
        speed = Mathf.Clamp(speed, 0f, 10.0f);

        direction = transform.right;
        velocity = direction *speed * Time.deltaTime;
        transform.position += velocity;
        BoxingTank();
        Shoot();
    }

    private void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet CopyOfBullet = Instantiate(bullet,transform.position,Quaternion.identity);
            CopyOfBullet.Direction = direction;
        }
        
    }

    void BoxingTank()
    {
        Vector3 pos = transform.position;
        if (pos.x > maxScreen.x) { pos.x = minScreen.x; }
        if(pos.x < minScreen.x) {pos.x = maxScreen.x; }
        if (pos.y > maxScreen.y) { pos.y = minScreen.y; }
        if (pos.y < minScreen.y) { pos.y = maxScreen.y; }
        transform.position = pos;
    }
}
