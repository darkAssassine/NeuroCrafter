using System;

/// <summary>
/// Inspector-only configuration class for defining a neural network layer's properties.
/// Used to initialize NeuronLayer at runtime.
/// </summary>
[Serializable]
public class Layer
{
    public int neuronCount;
    public EActivationMethode activationMethode;
    public float alpha = 0;
}
