using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NameGenerator
{
    private static NameGenerator gen;
    private Dictionary<String,PlayerNames> names;
    private FormulaBasketball.Random r;
    private Dictionary<Country, ActualCountry> countryConvert;
    private NameGenerator()
    {
        names = new Dictionary<String, PlayerNames>();
        r = new FormulaBasketball.Random();

        countryConvert = new Dictionary<Country, ActualCountry>();

        countryConvert.Add(Country.Aahrus, new ActualCountry(new String[]{"Aeridani"}, new int[]{1}, r));
        countryConvert.Add(Country.Aeridani, new ActualCountry(new String[] { "Aeridani" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Bongatar, new ActualCountry(new String[] { "Bongatar" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Dtersauuw_Sagua, new ActualCountry(new String[] { "Dtersauuw Sagua" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Blaist_Blaland, new ActualCountry(new String[] { "Blaland" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Red_Rainbow, new ActualCountry(new String[] { "Blaland" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Bielosia, new ActualCountry(new String[] { "Loviniosa" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Pyxanovia, new ActualCountry(new String[] { "Loviniosa" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Lyintaria, new ActualCountry(new String[] { "Loviniosa" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Holy_Yektonisa, new ActualCountry(new String[] { "Loviniosa" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Czalliso, new ActualCountry(new String[] { "Czalliso" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Holykol, new ActualCountry(new String[] { "Czalliso" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Norkute, new ActualCountry(new String[] { "Czalliso" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Darvincia, new ActualCountry(new String[] { "Darvincia" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Sagua, new ActualCountry(new String[] { "Sagua" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Height_Sagua, new ActualCountry(new String[] { "Sagua" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Key_to_Don, new ActualCountry(new String[] { "Sagua" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Nausicaa, new ActualCountry(new String[] { "Sagua", "Darvincia" }, new int[] { 12, 7 }, r));
        countryConvert.Add(Country.Oesa, new ActualCountry(new String[] { "Serkr" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Futiakep, new ActualCountry(new String[] { "Serkr" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Atapwa, new ActualCountry(new String[] { "Serkr" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Hinaika, new ActualCountry(new String[] { "Serkr" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Shmupland, new ActualCountry(new String[] { "Shmupland" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Auspikitan, new ActualCountry(new String[] { "Auspikitan" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Wyverncliff, new ActualCountry(new String[] { "Wyverncliff" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Barsein, new ActualCountry(new String[] { "Aeridani", "Issamore" }, new int[] { 326, 50 }, r));
        countryConvert.Add(Country.Solea, new ActualCountry(new String[] { "Solea" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Ethanthova, new ActualCountry(new String[] { "Ethanthova" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Dotruga, new ActualCountry(new String[] { "Dotruga" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Aiyota, new ActualCountry(new String[] { "Aiyota" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Tri_National_Dominion, new ActualCountry(new String[] { "TND" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Antarion, new ActualCountry(new String[] { "Issamore" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Nja, new ActualCountry(new String[] { "Issamore" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Pentadominion, new ActualCountry(new String[] { "Issamore" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Kaeshar, new ActualCountry(new String[] { "Auspikitan" }, new int[] { 1 }, r));
        countryConvert.Add(Country.Transhimalia, new ActualCountry(new String[] { "Himalia", "Aeridani", "Degeq'so" }, new int[] { 25, 370, 25 }, r));
        countryConvert.Add(Country.Other, new ActualCountry(new String[] { "Wyverncliff" }, new int[] { 1 }, r));




        String[] file = FormulaBasketball.Properties.Resources.names.Split('\n');


        foreach(String line in file)
        {
            String[] theNames = line.Replace("\r", "").Split('\t');
            if(!names.ContainsKey(theNames[0]))
            {
                names.Add(theNames[0], new PlayerNames(r));
            }
            names[theNames[0]].AddName(theNames[1], theNames[2]);
        }
    }
    public static NameGenerator Instance()
    {
        if(gen == null)
        {
            gen = new NameGenerator();
        }
        return gen;
    }

    public string GenerateName(Country country)
    {
        return names[countryConvert[country].GetCountry()].GetName();
    }
}
class ActualCountry
{
    private String[] countries;
    private int[] likelihoods;
    private int sum;
    private FormulaBasketball.Random r;
    public ActualCountry(String[] countries, int[] likelihoods, FormulaBasketball.Random r)
    {
        this.countries = countries;
        this.likelihoods = likelihoods;
        this.r = r;
        foreach(int i in likelihoods)
        {
            sum += i;
        }
    }
    public String GetCountry()
    {
        int num = r.Next(sum);
        int currSum = 0;

        for (int i = 0; i < likelihoods.Length; i++)
        {
            currSum += likelihoods[i];
            if (currSum > num)
            {
                return countries[i];
            }
        }
        return countries[0];
    }
}
class PlayerNames
{
    private List<String> firstNames;
    private List<String> lastNames;
    private FormulaBasketball.Random r;
    public PlayerNames (FormulaBasketball.Random r)
    {
        firstNames = new List<string>();
        lastNames = null;
        this.r = r;
    }

    public void AddName(String firstName, String lastName)
    {
        if(lastName != "")
        {
            if(lastNames == null)
            {
                lastNames = new List<string>();
            }
            lastNames.Add(lastName);
        }
        firstNames.Add(firstName);
    }

    public String GetName()
    {
        String lastName = "";
        if(lastNames != null)lastName = " " + r.Select(lastNames);
        return r.Select(firstNames) + lastName;
    }

}
