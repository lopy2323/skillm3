using UnityEngine;

public class BouncingBall : MonoBehaviour
{
    Vector3 velocity = new Vector3(2, 3, 0);
    Vector3 direction;
    [SerializeField] float speed = 3f;

    Vector2 min, max;

    void Start()
    {
        direction = velocity.normalized;

        min = Camera.main.ScreenToWorldPoint(Vector2.zero);
        max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        if(transform.position.y > max.y - transform.localScale.y/2){ direction.y = -Mathf.Abs(direction.y);}
        if(transform.position.x > max.x - transform.localScale.y / 2) { direction.x = -Mathf.Abs(direction.x); }
        if (transform.position.y < min.y + transform.localScale.y / 2) { direction.y =Mathf.Abs(direction.y); }
        if (transform.position.x < min.x + transform.localScale.y / 2) { direction.x = Mathf.Abs(direction.x); }

        transform.position += direction * speed * Time.deltaTime; ;
    }
}
