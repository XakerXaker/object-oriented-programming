namespace ITMO.ObjectOrientedProgramming.Lab1.Entities;

public class Train
{
    public Mass Mass { get; private set; }

    public double Speed { get; private set; }

    public double Accelaration { get; private set; }

    public double MaximumPermissibleForce { get; private set; }

    public Time TravelTime { get; set; }

    public Train(double mass, double maximumPermissibleForce)
    {
        Mass = new Mass(mass);
        MaximumPermissibleForce = maximumPermissibleForce;
        Speed = 0;
        TravelTime = new Time(0);
    }

    public void ApplyForce(double forceValue)
    {
        Accelaration = forceValue / Mass.Value;
    }

    public void SpeedUp(int accuracy)
    {
        Speed += Accelaration * accuracy;
    }

    public void ResetAcceleration()
    {
        Accelaration = 0;
    }

    public void PassDistance(Length lenght, int accuracy)
    {
        double distanseTravelled = 0;
        while (lenght.Value - distanseTravelled > 0)
        {
            double left_op = Math.Abs(Speed) * accuracy;
            double right_op = Math.Abs(Accelaration) * accuracy * accuracy / 2;
            distanseTravelled += left_op + right_op;

            TravelTime.Value += accuracy;
            SpeedUp(accuracy);
        }
    }
}