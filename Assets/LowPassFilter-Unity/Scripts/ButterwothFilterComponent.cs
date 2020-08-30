// Copyright (c) 2020 Soichiro Sugimoto
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace LowPassFilter
{
    public class ButterwothFilterComponent : LowPassFilterComponent
    {
        [SerializeField] uint _Order = 2;
        [SerializeField] float _CutoffFrequency = 10; // [Hz]
        [SerializeField] float _SamplingFrequency = 60; // [Hz]
        [SerializeField] uint _VectorSize = 3;

        void Awake()
        {
            Debug.Log("Cutoff frequency: " + _CutoffFrequency + " [Hz]");
            Debug.Log("Sampling frequency: " + _SamplingFrequency + " [Hz]");
            _LowPassFilter = new ButterworthFilter(_Order, _SamplingFrequency, _CutoffFrequency, _VectorSize);
        }
    }
}
