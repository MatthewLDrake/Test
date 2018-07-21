using System;

public class StringUtils
{
    public StringUtils()
    {
    }
    public String rightPad(String teamName, int i)
    {
        if (teamName.Length >= i) return teamName;
        for (int j = teamName.Length; j < i; j++)
        {
            teamName = teamName + " ";
        }


        return teamName;
    }
}