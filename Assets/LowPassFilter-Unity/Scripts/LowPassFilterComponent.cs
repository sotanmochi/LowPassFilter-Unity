// Copyright (c) 2020 Soichiro Sugimoto
// Licensed under the MIT License. See LICENSE in the project root for license information.

using UnityEngine;

namespace LowPassFilter
{
    public class LowPassFilterComponent : MonoBehaviour
    {
        protected ILowPassFilter _LowPassFilter;

        public bool Init(in float[] input)
        {
            return _LowPassFilter.Init(input);
        }

        public bool Apply(in float[] input, ref float[] output)
        {
            return _LowPassFilter.Apply(input, ref output);
        }
    }
}
