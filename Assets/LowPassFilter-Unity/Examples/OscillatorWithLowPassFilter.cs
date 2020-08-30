using UnityEngine;
using LowPassFilter;

public class OscillatorWithLowPassFilter : MonoBehaviour
{
    [SerializeField] float _Frequency = 1; // [Hz]
    [SerializeField] float _Amplitude = 2;
    [SerializeField] bool _UseLowPassFilter = false;
    [SerializeField] LowPassFilterComponent _LowPassFilter;

    private Vector3 _Position;
    float[] _PositionBuffer = new float[3];
    float[] _FilteredPos = new float[3];

    void Start()
    {
        _PositionBuffer[0] = transform.position.x;
        _PositionBuffer[1] = transform.position.y;
        _PositionBuffer[2] = transform.position.z;
        _LowPassFilter.Init(_PositionBuffer);
    }

    void Update()
    {
        float time = Time.realtimeSinceStartup;
        _Position = transform.position;
        _Position.y = _Amplitude * Mathf.Sin(2 * Mathf.PI * _Frequency * time);

        if (_UseLowPassFilter)
        {
            _PositionBuffer[0] = _Position.x;
            _PositionBuffer[1] = _Position.y;
            _PositionBuffer[2] = _Position.z;

            _LowPassFilter.Apply(_PositionBuffer, ref _FilteredPos);

            _Position.x = _FilteredPos[0];
            _Position.y = _FilteredPos[1];
            _Position.z = _FilteredPos[2];
        }

        transform.position = _Position;        
    }
}
