using System;
using Unity.VisualScripting;

public class NeuronLayer
{
    private int neuronCount;
    private Neuron[] neurons;

    public NeuronLayer(int _neuronCount, float[,] _weights, float[] _bias, EActivationMethode _activationMethode, float _alpha = 0.1f) 
    {
        neuronCount = _neuronCount;
        neurons = new Neuron[neuronCount];

        for(int i = 0; i < neuronCount; i++)
        {
            float[] weights = GetRow(_weights, i);
            neurons[i] = new Neuron(weights, _bias[i], _activationMethode, _alpha);
        }
    }

    private float[] GetRow(float[,] array, int rowIndex)
    {
        int columnCount = array.GetLength(1);
        float[] row = new float[columnCount];

        for (int i = 0; i < columnCount; i++)
        {
            row[i] = array[rowIndex, i];
        }

        return row;
    }

    public float[] FeedForward(float[] inputs)
    {
        float[] outputs = new float[neurons.Length];

        for (int i = 0; i < neuronCount; i++)
        {
            outputs[i] = neurons[i].GetValue(inputs);
        }
        return outputs;
    }
}
