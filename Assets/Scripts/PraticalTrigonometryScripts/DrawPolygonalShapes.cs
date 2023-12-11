using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;
public class DrawPolygonalShapes : MonoBehaviour
{
    [Range(0,20)] [SerializeField] private int _numPoint = 3;
    [Range(0,1)] [SerializeField] private float _size = 1f;
    private int _density = 1;
    private void OnDrawGizmos()
    {
        for (int i = 0; i < _numPoint * _density; i += _density)
        {
            float tau = 2 * Mathf.PI * i / (_numPoint * _density);
            float x = Mathf.Cos(tau) * _size;
            float y = Mathf.Sin(tau) * _size;
            
            Vector3 currentPoint = transform.position + new Vector3(x, y, 0);
            Vector3 nextPoint = transform.position + 
                                new Vector3(Mathf.Cos(2 * Mathf.PI * (i + _density) / (_numPoint * _density)) * _size,
                                Mathf.Sin(2 * Mathf.PI * (i + _density) / (_numPoint * _density)) * _size);
            
            Handles.color = Color.magenta;
            Handles.DrawLine(currentPoint, nextPoint);
        }
        Handles.color = Color.white;
        Handles.DrawWireDisc(transform.position, transform.forward, _size);
    }
}