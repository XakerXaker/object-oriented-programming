namespace ITMO.ObjectOrientedProgramming.Lab1.Entities;

public class Train
{
    public Mass Mass { get; init; }

    public double Speed { get; private set; }

    public double Accelaration { get; private set; }

    public double MaximumPermissibleForce { get; init; }

    public Time TravelTime { get; private set; }

    public Train(Mass mass, double maximumPermissibleForce)
    {
        Mass = mass;
        MaximumPermissibleForce = maximumPermissibleForce;
        Speed = 0;
        TravelTime = new Time(0);
    }

    public bool IsForceAcceptable(double forceValue)
    {
        if (forceValue > MaximumPermissibleForce) return false;
        return true;
    }

    public void ApplyForce(double forceValue)
    {
        if (IsForceAcceptable(forceValue))
        {
            Accelaration = forceValue / Mass.Value;
        }
    }

    public void SpeedUp(Time accuracy)
    {
        Speed += Accelaration * accuracy.Value;
    }

    public void ResetAcceleration()
    {
        Accelaration = 0;
    }

    public void PassDistance(Length lenght, Time accuracy)
    {
        double distanseTravelled = 0;
        while (lenght.Value - distanseTravelled > 0)
        {
            double left_op = Math.Abs(Speed) * accuracy.Value;
            double right_op = Math.Abs(Accelaration) * accuracy.Value * accuracy.Value / 2;
            distanseTravelled += left_op + right_op;

            TravelTime.Value += accuracy.Value;
            SpeedUp(accuracy);
        }
    }
}