using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
[Serializable]
public class Event
{
    private string title, text;
    private int teamAffected;
    public Event(String title, String text, int teamAffected)
    {
        this.title = title;
        this.text = text;
        this.teamAffected = teamAffected;
    }
    public int GetTeamAffected()
    {
        return teamAffected;
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

