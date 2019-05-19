using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Event
{
    private string title, text;
    public Event(String title, String text)
    {
        this.title = title;
        this.text = text;
    }
    public string GetTitle()
    {
        return title;
    }
    public string GetText()
    {
        return text;
    }
}

