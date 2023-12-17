using UnityEngine;

public class BulletSpeed : MonoBehaviour
{
    [SerializeField] private float speed = 10f;

    private void Update()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}