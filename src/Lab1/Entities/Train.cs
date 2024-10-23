namespace ITMO.ObjectOrientedProgramming.Lab1.Entities;

public class Train
{
    public double Mass { get; private set; }

    public double Speed { get; private set; }

    public double Accelaration { get; private set; }

    public double MaximumPermissibleForce { get; private set; }

    public Train(double mass, double maximumPermissibleForce)
    {
        if (mass < 0) throw new Exception("Mass cannot be negative");

        Mass = mass;
        MaximumPermissibleForce = maximumPermissibleForce;
        Speed = 0;
    }

    public void ApplyForce(double forceValue)
    {
        Accelaration = forceValue / Mass;
    }

    public void SpeedUp(int accuracy)
    {
        Speed += Accelaration * accuracy;
    }

    public void ResetAcceleration()
    {
        Accelaration = 0;
    }
}