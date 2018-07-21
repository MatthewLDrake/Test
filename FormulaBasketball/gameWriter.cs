using System;
using System.IO;
using System.Collections.Generic;
public class gameWriter
{
    private String writer;
    public List<String> listOfStrings;
    private int gameNum;
    public gameWriter(int gameNum)
    {
        this.gameNum = gameNum;
        listOfStrings = new List<String>();
    }
    public void writeLines()
    {
        writer ="Game " + gameNum + ".txt";

        string temp = "";
        
        foreach (String s in listOfStrings)
        {
            temp += s + "\n";
        }
        File.WriteAllText(writer, temp);

    }
}
