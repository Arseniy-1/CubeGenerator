using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector3 _direction;

    private void Update()
    {
        transform.position += _direction * Time.deltaTime;
    }

    public void Initialize(Vector3 direction)
    {
        _direction = direction;
    }
}