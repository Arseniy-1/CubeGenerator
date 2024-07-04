using System.Collections;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private CubePool _cubePool;
    private bool _isTouched;
    private int _maxDelay = 5;
    private int _minDelay = 2;

    public void Initialize(CubePool cubePool)
    {
        _cubePool = cubePool;
    }

    private void OnEnable()
    {
        _isTouched = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Platform platform))
        {
            if(_isTouched)
                return;

            _isTouched = true;
            StartCoroutine(DestroingWithDelay());
        }
    }

    private IEnumerator DestroingWithDelay()
    {
        yield return new WaitForSeconds(Random.Range(_minDelay, _maxDelay));
        _cubePool.Return(this);
    }
}
