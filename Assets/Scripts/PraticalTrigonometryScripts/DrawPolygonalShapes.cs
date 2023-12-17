using UnityEditor;
using UnityEngine;

public class DrawPolygonalShapes : MonoBehaviour
{
    [SerializeField] private int _numPoint = 3;
    [Range(0,1)] [SerializeField] private float _size = 1f;
    private int _density = 1;
    private void OnDrawGizmos()
    {
        float tauMultiplier = 2 * Mathf.PI / (_numPoint * _density);
        
        for (int i = 0; i < _numPoint * _density; i += _density)
        {
            float tau = tauMultiplier * i;
            float x = Mathf.Cos(tau) * _size;
            float y = Mathf.Sin(tau) * _size;
            
            Vector3 currentPoint = transform.position + new Vector3(x, y, 0);
            
            float nextX = Mathf.Cos(2 * Mathf.PI * (i + _density) / (_numPoint * _density)) * _size;
            float nextY = Mathf.Sin(2 * Mathf.PI * (i + _density) / (_numPoint * _density)) * _size;
            
            Vector3 nextPoint = transform.position + new Vector3(nextX, nextY, 0);
            
            Handles.color = Color.magenta;
            Handles.DrawLine(currentPoint, nextPoint);
        }
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, _size);
    }
}