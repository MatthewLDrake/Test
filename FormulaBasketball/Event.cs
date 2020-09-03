using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[Serializable]
public class Event
{
    private string title, text;
    private List<int> teamsAffected;
    public Event(String title, String text, params int[] teamsAffected)
    {
        this.title = title;
        this.text = text;
        this.teamsAffected = new List<int>(teamsAffected);
    }
    public List<int> GetTeamsAffected()
    {
        return teamsAffected;
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

