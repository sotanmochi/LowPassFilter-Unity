// Copyright (c) 2020 Soichiro Sugimoto
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace LowPassFilter
{
    public class ExponentialSmoothingFilterComponent : LowPassFilterComponent
    {
        [SerializeField] float _SmoothingFactorA = 0.2f;
        [SerializeField] float _SmoothingFactorB = 0.2f;
        [SerializeField] uint _VectorSize = 3;

        void Awake()
        {
            // _LowPassFilter = new ExponentialSmoothingFilter(_VectorSize, _SmoothingFactorA);
            _LowPassFilter = new DoubleExponentialSmoothingFilter(_VectorSize, _SmoothingFactorA, _SmoothingFactorB);
        }
    }
}
