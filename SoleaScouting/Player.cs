using System;
[Serializable]
public class Player
{
    private string name;
    private string country;
    private int position;
    private string layup;
    private string dunk;
    private string jumpshot;
    private string threepoint;
    private string pass;
    private string shotcontest;
    private string defenseiq;
    private string jumping;
    private string seperation;
    private string durability;
    private string stamina;
    private int age;
    private int peakstart;
    private int peakend;
    private int development;
    private string university;
    private double[] stats;
    private const int SCOUT_SKILL = 2;
    private Random r;
    private string potential;
    private bool isScouted;
    public Player(string name, string country, int position, int layup, int dunk, int jumpshot, int threepoint, int pass, int shotcontest, int defenseiq, int jumping, int seperation, int durability, int stamina, int age, int peakstart, int peakend, int development, string university, double[] stats, Random r)
    {
        this.r = r;
        this.name = name;
        this.country = country;
        this.position = position;

        int[] elevens = new int[11];
        for(int i = 0; i < elevens.Length; i++)
        {
            elevens[i] = r.Next(-SCOUT_SKILL, 0);
        }

        this.layup = "" + (elevens[0] + layup) + " -> " + (elevens[0] + layup + SCOUT_SKILL);
        this.dunk = "" + (elevens[1] + dunk) + " -> " + (elevens[1] + dunk + SCOUT_SKILL);
        this.jumpshot = "" + (elevens[2] + jumpshot) + " -> " + (elevens[2] + jumpshot + SCOUT_SKILL);
        this.threepoint = "" + (elevens[3] + threepoint) + " -> " + (elevens[3] + threepoint + SCOUT_SKILL);
        this.pass = "" + (elevens[4] + pass) + " -> " + (elevens[4] + pass + SCOUT_SKILL);
        this.shotcontest = "" + (elevens[5] + shotcontest) + " -> " + (elevens[5] + shotcontest + SCOUT_SKILL);
        this.defenseiq = "" + (elevens[6] + defenseiq) + " -> " + (elevens[6] + defenseiq + SCOUT_SKILL);
        this.jumping = "" + (elevens[7] + jumping) + " -> " + (elevens[7] + jumping + SCOUT_SKILL);
        this.seperation = "" + (elevens[8] + seperation) + " -> " + (elevens[8] + seperation + SCOUT_SKILL);
        this.durability = "" + (elevens[9] + durability) + " -> " + (elevens[9] + durability + SCOUT_SKILL);
        this.stamina = "" + (elevens[10] + stamina) + " -> " + (elevens[10] + stamina + SCOUT_SKILL);
        
        this.age = age;
        this.peakstart = peakstart;
        this.peakend = peakend;
        this.development = development;
        this.university = university;
        this.stats = stats;

        int normalizedPS = (peakstart - 27) * 2;
        int normalizedPE = (peakend - 30) * 2;

        int average = (normalizedPE + normalizedPS + development * 3) / 5;

        int temp = Math.Max(1,Math.Min(10,r.Next(-2, 2) + average));
        switch(temp)
        {
            case 1:
                potential = "F";
                break;
            case 2:
                potential = "F+";
                break;
            case 3:
                potential = "D";
                break;
            case 4:
                potential = "D+";
                break;
            case 5:
                potential = "C";
                break;
            case 6:
                potential = "C+";
                break;
            case 7:
                potential = "B";
                break;
            case 8:
                potential = "B+";
                break;
            case 9:
                potential = "A";
                break;
            case 10:
                potential = "A+";
                break;
        }
        isScouted = false;
    }

    public bool scout
    {
        get => isScouted;
        set => isScouted = value;
    }
    public double[] GetStats()
    {
        return stats;
    }
    public string GetUniversity()
    {
        return university;
    }
    public int GetPosition()
    {
        return position;
    }
    public string GetCountry()
    {
        return country;
    }
    override
    public string ToString()
    {
        return name;
    }    
    public string GetLayup()
    {
        return layup;
    }
    public string GetDunk()
    {
        return dunk;
    }
    public string GetJumpshot()
    {
        return jumpshot;
    }
    public string GetThreePoint()
    {
        return threepoint;
    }
    public string GetPass()
    {
        return pass;
    }
    public string GetShotContest()
    {
        return shotcontest;
    }
    public string GetDefenseIQ()
    {
        return defenseiq;
    }
    public string GetJumping()
    {
        return jumping;
    }
    public string GetSeperation()
    {
        return seperation;
    }
    public string GetDurability()
    {
        return durability;
    }
    public string GetStamina()
    {
        return stamina;
    }
    public int GetAge()
    {
        return age;
    }
    public string GetPotential()
    {      
        return potential;
    }
}
