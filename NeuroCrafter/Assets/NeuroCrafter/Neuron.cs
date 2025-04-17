using System;
using UnityEngine;

public class Neuron
{
    private float[] weights;
    private float bias;
    private float alpha;

    private EActivationMethode activationMethode;

    public Neuron(float[] _weights, float _bias, EActivationMethode _activationMethode, float _alpha = 0.1f)
    {
        weights = _weights;
        bias = _bias;
        activationMethode = _activationMethode;
        alpha = _alpha;
    }
    public float GetValue(float[] _inputs)
    {
        float value = 0;

        for(int i = 0; i < _inputs.Length; i ++)
        {
            value += (_inputs[i] * weights[i]);
        }
        value += bias;

        return Activate(value);
    }

    public float Activate(float _value)
    {
        switch (activationMethode)
        {
            case EActivationMethode.Sigmoid:
                return Sigmoid(_value);

            case EActivationMethode.Tanh:
                return Tanh(_value);

            case EActivationMethode.ReLU:
                return ReLU(_value);

            case EActivationMethode.LeakyReLU: 
                return LeakyReLU(_value);

            case EActivationMethode.ELU:
                return ELU(_value);

            case EActivationMethode.Swish:
                return Swish(_value);

            case EActivationMethode.GELU:
                return GELU(_value);

            case EActivationMethode.None:
            default:
                throw new NotImplementedException();
        }
    }

    private float Sigmoid(float _value)
    {
        return 1f/ (1f + Mathf.Exp(-_value));
    }

    private float Tanh(float _value)
    {
        return (float)Math.Tanh(_value);
    }

    private float ReLU(float _value)
    {
        return Mathf.Max(0f, _value);
    }

    private float LeakyReLU(float _value)
    {
        return _value > 0f ? _value : alpha * _value;
    }

    private float ELU(float _value)
    {
        return _value > 0f ? _value : alpha * (Mathf.Exp(_value) - 1f);
    }

    private float Swish(float _value)
    {
        return _value / (1f + Mathf.Exp(-_value));
    }

    private float GELU(float _value)
    {
        return 0.5f * _value * (1f + (float)Math.Tanh(Mathf.Sqrt(2f / Mathf.PI) * (_value + 0.044715f * Mathf.Pow(_value, 3))));
    }
}
