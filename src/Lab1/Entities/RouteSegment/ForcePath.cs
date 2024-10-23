namespace ITMO.ObjectOrientedProgramming.Lab1.Entities.RouteSegment;

public class ForcePath : PathSegment
{
    private readonly double forceValue;

    public ForcePath(double lenght, double forceValue, PowerModule? powerModule) : base(lenght, powerModule)
    {
        this.forceValue = forceValue;
    }

    public override MovementResult MoveTrain(Train train, int accuracy)
    {
        if (forceValue > train.MaximumPermissibleForce)
        {
            return new MovementResult.Failure();
        }
        else
        {
            train.ApplyForce(forceValue);
            double distanseTravelled = 0;
            while (true)
            {
                double left_op = Math.Abs(train.Speed) * accuracy;
                double right_op = Math.Abs(train.Accelaration) * accuracy * accuracy / 2;
                distanseTravelled += left_op + right_op;

                TravelTime += accuracy;
                train.SpeedUp(accuracy);

                if ((Length - distanseTravelled) <= 0)
                {
                    train.ResetAcceleration();
                    break;
                }

                if (train.Speed <= 0)
                {
                    return new MovementResult.Failure();
                }

                if (PowerModule is not null && train.Speed > PowerModule.SpeedLimit)
                {
                    return new MovementResult.Failure();
                }
            }

            return new MovementResult.Success();
        }
    }
}