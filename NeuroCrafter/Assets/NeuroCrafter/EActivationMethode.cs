public enum EActivationMethode
{
    None = -1,

    /// <summary>
    /// Returns values between 0 and 1.
    /// </summary>
    Sigmoid,

    /// <summary>
    /// Like LeakyReLU but exponential for negative values.
    /// </summary>
    Tanh,

    /// <summary>
    /// Returns a small slope for negative values instead of zero (default alpha = 0.01).
    /// </summary>
    ReLU,

    /// <summary>
    /// Returns 0 for negative values and the input itself for positive values. 
    /// </summary>
    LeakyReLU,

    /// <summary>
    /// Returns values between -1 and 1.
    /// </summary>
    ELU,

    /// <summary>
    /// Returns values between 0 and 1.
    /// </summary>
    Swish,

    /// <summary>
    /// Approximation of the Gaussian Error Linear Unit (GELU).
    /// </summary>
    GELU,
}
