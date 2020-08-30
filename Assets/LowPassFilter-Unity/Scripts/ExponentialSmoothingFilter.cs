// Copyright (c) 2020 Soichiro Sugimoto
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace LowPassFilter
{
    public class ExponentialSmoothingFilter : ILowPassFilter
    {
        float[] _LastOutput;
        float _Weight;

        public ExponentialSmoothingFilter(uint vectorSize, float weight = 0.1f)
        {
            _LastOutput = new float[vectorSize];
            _Weight = weight;
        }

        public bool Init(in float[] input)
        {
            if (input.Length != _LastOutput.Length)
            {
                return false;
            }

            for (int m = 0; m < input.Length; m++)
            {
                _LastOutput[m] = input[m];
            }

            return true;
        }

        public bool Apply(in float[] input, ref float[] output)
        {
            if ((input.Length != output.Length)
            ||  (input.Length != _LastOutput.Length))
            {
                return false;
            }

            for (int m = 0; m < input.Length; m++)
            {
                output[m] = _Weight * input[m] + (1.0f - _Weight) * _LastOutput[m];
                _LastOutput[m] = output[m];
            }

            return true;
        }
    }

    public class DoubleExponentialSmoothingFilter : ILowPassFilter
    {
        float[] _SmoothedValue;
        float[] _Trend;
        float[] _PrevSmoothedValue;
        float[] _PrevTrend;
        float _SmoothingFactor;
        float _TrendSmoothingFactor;

        public DoubleExponentialSmoothingFilter(uint vectorSize, float smoothingFactor = 0.5f, float trendSmoothingFactor = 0.5f)
        {
            _SmoothedValue = new float[vectorSize];
            _Trend = new float[vectorSize];

            _PrevSmoothedValue = new float[vectorSize];
            _PrevTrend = new float[vectorSize];

            _SmoothingFactor = smoothingFactor;
            _TrendSmoothingFactor = trendSmoothingFactor;
        }

        public bool Init(in float[] input)
        {
            if (input.Length != _PrevSmoothedValue.Length)
            {
                return false;
            }

            for (int m = 0; m < input.Length; m++)
            {
                _PrevSmoothedValue[m] = input[m];
                _PrevTrend[m] = 0.0f;
            }

            return true;
        }

        public bool Apply(in float[] input, ref float[] output)
        {
            if ((input.Length != output.Length)
            ||  (input.Length != _SmoothedValue.Length))
            {
                return false;
            }

            for (int k = 0; k < input.Length; k++)
            {
                _SmoothedValue[k] = _SmoothingFactor * input[k] + (1.0f - _SmoothingFactor) * (_PrevSmoothedValue[k] + _PrevTrend[k]);
                _Trend[k] = _TrendSmoothingFactor * (_SmoothedValue[k] - _PrevSmoothedValue[k]) + (1.0f - _TrendSmoothingFactor) * _PrevTrend[k];
            }

            for (int k = 0; k < input.Length; k++)
            {
                _PrevSmoothedValue[k] = _SmoothedValue[k];
                _PrevTrend[k] = _Trend[k];
            }

            for (int k = 0; k < input.Length; k++)
            {
                output[k] = _SmoothedValue[k] + _Trend[k];
            }

            return true;
        }
    }
}
