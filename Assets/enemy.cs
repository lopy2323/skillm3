using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{

    private int speed;
    Vector3 direction;
    private Vector3 velocity;

    Vector3 differenceVector;

    Vector2 minScreen, maxScreen;

    Vector3 Target;

    float distance;

    enum State
    {
        begin,
        move,
        end
    }

    State myState = State.begin;

    float time;
    float duration = 5;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        direction = Vector3.right;
        speed = 1;

        minScreen = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxScreen = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

        //Target = choosePoint();
        //moveToTarget();

    }

    // Update is called once per frame
    void Update()
    {
        if (myState == State.begin)
        {
            time = 0;
            Target = choosePoint();
            moveToTarget();
            myState = State.move;
        }

        if (myState == State.move)
        {
            time += Time.deltaTime;
            if (time >= duration)
            {
                myState = State.end;
            }
        }

        if (myState == State.end)
        {
            myState = State.begin;
        }

        velocity = direction * speed * Time.deltaTime;
        transform.position += velocity;
    }

    Vector3 choosePoint()
    {
        // Choose a random point within the screen bounds
        float x_pos = Random.Range(minScreen.x, maxScreen.x);
        float y_pos = Random.Range(minScreen.y, maxScreen.y);
        return new Vector3(x_pos, y_pos, 0);
    }

    void moveToTarget()
    {
        differenceVector = Target - transform.position;
        distance = differenceVector.magnitude;
        direction = differenceVector.normalized;
        transform.right = direction;

        duration = distance / speed;


    }


    private void OnDrawGizmos()
    {
        // Draw a red sphere at the chosen point
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(Target, 0.1f);
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, Target);
    }

}