// Copyright (c) 2020 Soichiro Sugimoto
// Licensed under the MIT License. See LICENSE in the project root for license information.

namespace LowPassFilter
{
    public interface ILowPassFilter
    {
        bool Init(in float[] input);
        bool Apply(in float[] input, ref float[] output);
    }
}
