using UnityEngine;

public class CircleCollisionDetection : MonoBehaviour
{
    [Range(0, 10)] [SerializeField] private float _radius;
    [SerializeField] private GameObject _point;
    [SerializeField] private GameObject _otherCircle;
    [Range(0, 10)] [SerializeField] private float _radiusOtherCircle;

    private void OnDrawGizmos()
    {
        Vector3 circleDistancePoint = _point.transform.position - transform.position;
        
        if (circleDistancePoint.sqrMagnitude <= _radius * _radius)
        {
            Gizmos.color = Color.green;
        }

        Vector3 circleDistanceOtherCircle = _otherCircle.transform.position - transform.position;
        
        if (circleDistanceOtherCircle.sqrMagnitude <= (_radius * _radius) + (_radiusOtherCircle * _radiusOtherCircle))
        {
            Gizmos.color = Color.green;
        }
        
        Gizmos.DrawSphere(transform.position, _radius);
        Gizmos.DrawSphere(_otherCircle.transform.position, _radiusOtherCircle);
        Gizmos.DrawLine(transform.position, _otherCircle.transform.position);
    }
}