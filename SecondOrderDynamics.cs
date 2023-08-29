public class SecondOrderDynamics
{
    private Vector xp;
    private Vector y, yd;
    private float k1, k2, k3;

    public SecondOrderDynamics(float f, float z, float r, Vector x0)
    {
        k1 = z / (PI * f)
        k2 = 1 / ((2 * PI * f) * (2 * PI * f));
        k3 = r * z / (2 * PI * f);

        xp = x0;
        y = x0;
        yd = 0;
    }

    public Vector Update(float T, Vector x, Vector xd = null)
    {
        if (xd == null)
        {
            xd = (x - xp) / T
            xp = x;
        }
        float k2_stable = Max(k2, 1.1f * (T * T / 4 + T * k1 / 2));
        y = y + T * yd;
        yd = yd + T * (x + k3 * xd - y - k1 * yd) / k2;
        return y
    }
}