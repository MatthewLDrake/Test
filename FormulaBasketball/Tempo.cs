using System;
using FormulaBasketball;
[Serializable]
public class Tempo
{
    private int value;
    private TempoHolder[] tempos = new TempoHolder[] { new TempoHolder(12, 12), new TempoHolder(14, 8), new TempoHolder(10, 8) };
    
    public Tempo(int i)
    {
        value = i;
    }
    
    

    public int getRandomTime()
    {
        return tempos[value].getRandomTime();
    }
    public int getMinimumTime()
    {
        return tempos[value].getMinimumTime();
    }

}

