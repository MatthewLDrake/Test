
public class DoubleDoubles
{

    public double average;
    public int i;
    public DoubleDoubles(double average, int i)
    {
        this.average = average;
        this.i = i;
    }

    public int compareTo(DoubleDoubles o)
    {
        return (int)(average - o.average);
    }

}
