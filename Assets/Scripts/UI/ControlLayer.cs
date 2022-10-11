using UnityEngine;

using TMPro;

public class ControlLayer : MonoBehaviour
{
    [SerializeField]
    private TMP_InputField _spawnDelayInput;

    [SerializeField]
    private TMP_InputField _distanceInput;

    [SerializeField]
    private TMP_InputField _speedInput;

    [SerializeField]
    private Spawner _targetSpawner;

    private float _enteredSpawnDelay = 3.0f;
    private float _enteredDistance = 10.0f;
    private float _enteredSpeed = 5.0f;

    public void HandleControlChange()
    {
        ApplyControls();
    }

    public void HandleSpawn(GameObject entity)
    {
        Mover moverComponent = entity.GetComponent<Mover>();
        if (moverComponent != null)
        {
            moverComponent.Speed = _enteredSpeed;
            moverComponent.Distance = _enteredDistance;
        }
    }

    private void Start()
    {
        ApplyControls();
    }

    private void ApplyControls()
    {
        float.TryParse(_spawnDelayInput.text, out _enteredSpawnDelay);
        float.TryParse(_distanceInput.text, out _enteredDistance);
        float.TryParse(_speedInput.text, out _enteredSpeed);

        ApplySpawnerSettings();
        UpdateExistingObjects();
    }

    private void ApplySpawnerSettings()
    {
        if (_targetSpawner != null)
        {
            _targetSpawner.SpawnDelay = _enteredSpawnDelay;
        }
    }

    private void UpdateExistingObjects()
    {
        foreach(Mover moverObject in FindObjectsOfType<Mover>())
        {
            moverObject.Speed = _enteredSpeed;
            moverObject.Distance = _enteredDistance;
        }
    }
}
