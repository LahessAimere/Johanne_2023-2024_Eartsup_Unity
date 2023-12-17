using UnityEngine;

public class ConeVision : MonoBehaviour
{
   [SerializeField] private GameObject _otherCollision;
   [Range(0,180)][SerializeField] private float _coneAngle;
   private void OnDrawGizmos()
   { 
       Vector3 circleDistanceOtherCollision = _otherCollision.transform.position - transform.position;
       Vector3 viewRight = transform.TransformDirection(Vector3.right);

       Vector3 circleDistanceOtherCollisionNormalized = circleDistanceOtherCollision.normalized;
       Vector3 viewRightNormalized = viewRight.normalized;
       
       if (-Vector3.Dot(viewRightNormalized, circleDistanceOtherCollisionNormalized) <= (_coneAngle - 180) / 180)
       { 
           Debug.Log("The OtherCollision is front me!"); 
           Gizmos.color = Color.green;
       } 
       Gizmos.DrawLine(transform.position, _otherCollision.transform.position);
   }
}