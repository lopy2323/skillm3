using UnityEngine;

public class FromAToB : MonoBehaviour
{
    [SerializeField] GameObject A;
    [SerializeField] GameObject B;
    [SerializeField] GameObject Player;

    Vector3 DifferenceVector;
    float distance;
    Vector3 Direction;

    float t = 0;
    float duration;

    bool AToB = true;

    void Start()
    {
        DifferenceVector = B.transform.position - A.transform.position;
        distance = DifferenceVector.magnitude;
        Direction = DifferenceVector.normalized;
        Player.transform.position = A.transform.position;
        duration = distance / 1;
    }

    void Update()
    {
        if( AToB )
        {
            DifferenceVector = B.transform.position - A.transform .position; 
        } else
        {
            DifferenceVector = A.transform .position - B.transform .position;
        }

        Direction =DifferenceVector.normalized;
        Player.transform.position += Direction * Time.deltaTime;

        if (t > duration)
        {
            AToB = !AToB;
            t = 0;
        }
        t += Time.deltaTime;
    }
}
