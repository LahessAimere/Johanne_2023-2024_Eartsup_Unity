using UnityEngine;

public class ConeVision : MonoBehaviour
{
   [SerializeField] private GameObject _otherCollision;
   [SerializeField] private float _coneAngle = 0.8f;
    private void OnDrawGizmos()
    {
        Vector3 circleDistanceOtherCollision = _otherCollision.transform.position - transform.position;
        Vector3 viewRight = transform.TransformDirection(Vector3.right);
        
        if (Vector3.Dot(viewRight, circleDistanceOtherCollision) > _coneAngle)
        {
            Debug.Log("The OtherCollision is front me!");
            Gizmos.color = Color.green;
        }
        
        Gizmos.DrawLine(transform.position, _otherCollision.transform.position);
    }
}
