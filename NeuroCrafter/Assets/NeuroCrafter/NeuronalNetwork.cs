using System;
using UnityEngine;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class NeuronalNetwork : MonoBehaviour
{
    public int FitnessValue {  get; private set; }
    public int InputAmount;

    [SerializeField] private List<Layer> layers = new List<Layer>();
    [SerializeField] private float randomRange;

    private List<NeuronLayer> neuronLayers = new List<NeuronLayer>();

    private void Awake()
    {
        int inputSize = InputAmount;
        foreach (Layer layer in layers)
        {
            float[,] weights = CreateRandomWeightsForLayer(layer.neuronCount, inputSize);
            float[] bias = CreateRandomBias(layer.neuronCount);

            neuronLayers.Add(new NeuronLayer(layer.neuronCount, weights, bias, layer.activationMethode, layer.alpha));

            inputSize = layer.neuronCount;
        }
    }

    private float[,] CreateRandomWeightsForLayer(int _neuronCount, int _inputCount)
    {
        float[,] weights = new float[_neuronCount, _inputCount];

        for (int i = 0; i < _neuronCount; i++)
        {
            for (int j = 0; j < _inputCount; j++)
            {
                weights[i, j] = Random.Range(-randomRange, randomRange);
            }
        }

        return weights;
    }

    private float[] CreateRandomBias(int _size)
    {
        float[] bias = new float[_size];
        for (int i = 0;i < _size; i++)
        {
            bias[i] = Random.Range(-randomRange, randomRange);
        }
        return bias;
    }

    public void AddFitness(int _value)
    {
        FitnessValue += _value;
    }

    public float[] Run(float[] _inputs)
    {
        float[] inputs = _inputs;
        foreach (NeuronLayer layer in neuronLayers) 
        {
            inputs = layer.FeedForward(inputs);
        }
        return inputs;
    }
}