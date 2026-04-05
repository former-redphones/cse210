public class Exponent :  Request
{

    public float exp_base {get; set;}

    public int exp_power {get; set;}

    public const string RequestName = "exponent";     // static access
    public override string Type => RequestName; // instance access

    public override string HandleRequest()
    {
        float result = 1;
        for (int i = 0; i < exp_power; i++)
        {
            result *= exp_base;
        }

        return result.ToString();
    }
}
