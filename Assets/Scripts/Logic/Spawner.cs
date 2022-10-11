using System.Collections;

using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public UnityEvent<GameObject> OnObjectSpawned = new UnityEvent<GameObject>();
    
    [Range(0.1f, 10.0f)]
    public float SpawnDelay = 3.0f;

    [SerializeField]
    private GameObject _spawnable = null;
    
    public void Spawn()
    {
        GameObject spawnedObject = Instantiate(_spawnable, transform.position, transform.rotation, transform.parent);

        OnObjectSpawned?.Invoke(spawnedObject);
    }

    private void Start()
    {
        if(_spawnable == null)
        {
            enabled = false;

            return;
        }

        StartCoroutine(SpawnCycle());
    }

    private IEnumerator SpawnCycle()
    {
        while(true)
        {
            Spawn();

            yield return new WaitForSeconds(SpawnDelay);
        }
    }
}
