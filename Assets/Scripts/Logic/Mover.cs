using UnityEngine;

public class Mover : MonoBehaviour
{
    public float Distance
    {
        get
        {
            return _distance;
        }

        set
        {
            // Retrieve the initial starting position.
            _target -= transform.forward * _distance;

            _distance = value;

            // Add new extent to the initial starting position.
            _target += transform.forward * _distance;
        }
    }

    [Range(0.1f, 10.0f)]
    public float Speed = 5.0f;

    [Range(0.1f, 30.0f)]
    private float _distance = 20.0f;

    private Vector3 _target;

    private void Start()
    {
        _target = transform.position + (transform.forward * Distance);
    }

    private void Update()
    {
        if(Vector3.Distance(transform.position, _target) > 0.0f)
        {
            transform.position = Vector3.MoveTowards(transform.position, _target, Speed * Time.deltaTime);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
