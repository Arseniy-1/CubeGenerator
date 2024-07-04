using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Target _target;

    private void Update()
    {
        transform.LookAt(_target.transform.position);
        transform.position += transform.forward * Time.deltaTime;
    }

    public void Initialize(Target target)
    {
        _target = target;
    }
}