using System;
[Serializable]
public class player : IComparable<player>
{

    protected bool isPlayingBool, isStarterBool;
    protected int gameFouls, injuryTotal, position;
    protected double stamina, shootingModifier, otherModifier, defensiveModifier;
    protected int[] stats, gameStats;
    protected String name;
    protected team team;
    protected bool isInjuredBool;
    protected int injuryLength;
    protected int gamesPlayed;
    protected bool firstTimeInGame;
    protected int pointDiff;
    protected int playerAge;
    protected Country country;
    protected int starts;
    protected bool careerEnded;
    protected double[] ratings;
    protected Contract contract;
    public player(int pos, int layupStat, int dunkStat, int jumpStat, int threePoint, int passing, int shotContest, int defenseIQ, int jumping, int separation, int durability, int stamina, int age, String name, Country country, bool starting)
    {
        careerEnded = false;
        starts = 0;
        this.country = country;
        pointDiff = 0;
        gamesPlayed = 0;
        firstTimeInGame = true;
        setPosition(pos);

        ratings = new double[11];

        setLayupRating(layupStat);
        setDunkRating(dunkStat);
        setJumpShotRating(jumpStat);
        setThreeShotRating(threePoint);
        setDurabilityRating(durability);
        setShotContestRating(shotContest);
        setDefenseIQRating(defenseIQ);
        setJumpingRating(jumping);
        setSeperation(separation);
        setPassing(passing);
        setStaminaRating(stamina);
        isPlayingBool = starting;
        isStarterBool = starting;
        this.stamina = 100;
        shootingModifier = 0.0;
        otherModifier = 0.0;
        defensiveModifier = 0.0;
        stats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameFouls = 0;
        this.name = name;
        this.playerAge = age;


    }
    public player(int pos, int layupStat, int dunkStat, int jumpStat, int threePoint, int passing, int shotContest, int defenseIQ, int jumping, int separation, int durability, int stamina, String name, bool starting)
    {
        ratings = new double[11];

        this.country = Country.Other;
        careerEnded = false;
        starts = 0;
        pointDiff = 0;
        gamesPlayed = 0;
        firstTimeInGame = true;
        setPosition(pos);
        setLayupRating(layupStat);
        setDunkRating(dunkStat);
        setJumpShotRating(jumpStat);
        setThreeShotRating(threePoint);
        setDurabilityRating(durability);
        setShotContestRating(shotContest);
        setDefenseIQRating(defenseIQ);
        setJumpingRating(jumping);
        setSeperation(separation);
        setPassing(passing);
        setStaminaRating(stamina);
        isPlayingBool = starting;
        isStarterBool = starting;
        stamina = 100;
        shootingModifier = 0.0;
        otherModifier = 0.0;
        defensiveModifier = 0.0;
        stats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameFouls = 0;
        this.name = name;
        this.playerAge = 0;



    }

    public player(int pos, int layupStat, int dunkStat, int jumpStat, int threePoint, int passing, int shotContest, int defenseIQ, int jumping, int separation, int durability, int stamina, int age, String name, bool starting, int peakStart, int peakEnd, int development)
    {
        ratings = new double[11];
        this.playerAge = age;
        this.country = Country.Other;
        careerEnded = false;
        starts = 0;
        pointDiff = 0;
        gamesPlayed = 0;
        firstTimeInGame = true;
        setPosition(pos);
        setLayupRating(layupStat);
        setDunkRating(dunkStat);
        setJumpShotRating(jumpStat);
        setThreeShotRating(threePoint);
        setDurabilityRating(durability);
        setShotContestRating(shotContest);
        setDefenseIQRating(defenseIQ);
        setJumpingRating(jumping);
        setSeperation(separation);
        setPassing(passing);
        setStaminaRating(stamina);
        isPlayingBool = starting;
        isStarterBool = starting;
        stamina = 100;
        shootingModifier = 0.0;
        otherModifier = 0.0;
        defensiveModifier = 0.0;
        stats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameFouls = 0;
        this.name = name;

        this.peakEnd = peakEnd;
        this.peakStart = peakStart;
        this.development = development;

    }
    public player(int pos, int layupStat, int dunkStat, int jumpStat, int threePoint, int passing, int shotContest, int defenseIQ, int jumping, int separation, int durability, int stamina, int age, String name, bool starting, int peakStart, int peakEnd, int development, Country country, int playerID)
    {
        ratings = new double[11];
        this.playerAge = age;
        this.country = country;
        this.playerID = playerID;
        careerEnded = false;
        starts = 0;
        pointDiff = 0;
        gamesPlayed = 0;
        firstTimeInGame = true;
        setPosition(pos);
        setLayupRating(layupStat);
        setDunkRating(dunkStat);
        setJumpShotRating(jumpStat);
        setThreeShotRating(threePoint);
        setDurabilityRating(durability);
        setShotContestRating(shotContest);
        setDefenseIQRating(defenseIQ);
        setJumpingRating(jumping);
        setSeperation(separation);
        setPassing(passing);
        setStaminaRating(stamina);
        isPlayingBool = starting;
        isStarterBool = starting;
        stamina = 100;
        shootingModifier = 0.0;
        otherModifier = 0.0;
        defensiveModifier = 0.0;
        stats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameFouls = 0;
        this.name = name;

        this.peakEnd = peakEnd;
        this.peakStart = peakStart;
        this.development = development;

    }
    public string GetPositionAsString()
    {
        switch(position)
        {
            case 1:
                return "C";
            case 2:
                return "PF";
            case 3:
                return "SF";
            case 4:
                return "SG";
            case 5:
                return "PG";
            default:
                return "";

        }
    }
    private int peakStart, peakEnd, development;
    public void generateDevelopment(FormulaBasketball.Random rand)
    {
        peakStart = rand.NextGaussian(30, 1);
        peakEnd = peakStart + Math.Max(1,rand.NextGaussian(3, 1));

        development = Math.Min(Math.Max(1,rand.NextGaussian(6, 1)), 10);
        
    }
    private double[] modifiers = null;
    public void Develop(FormulaBasketball.Random rand)
    {
        if (playerAge >= peakStart && playerAge <= peakEnd) return;
        if(modifiers == null)
        {
            modifiers = new double[ratings.Length];

            SetModifiers();

        }
        if(playerAge < peakStart)
        {
            Upgrade(rand);
        }
        else
        {
            Regress(rand);
        }

    }
    private void SetModifiers()
    {
        if (position == 1)
        {
            modifiers[0] = 5;
            modifiers[1] = 5;
            modifiers[2] = 2;
            modifiers[3] = 3;
            modifiers[4] = 3;
            modifiers[5] = 6.5;
            modifiers[6] = 3;
            modifiers[7] = 1.5;
            modifiers[8] = 2;
            modifiers[9] = .5;
            modifiers[10] = 1;
        }
        else if(position == 2)
        {
            modifiers[0] = 4.5;
            modifiers[1] = 4.5;
            modifiers[2] = 3;
            modifiers[3] = 3;
            modifiers[4] = 3;
            modifiers[5] = 6;
            modifiers[6] = 3;
            modifiers[7] = 1.5;
            modifiers[8] = 2;
            modifiers[9] = 1;
            modifiers[10] = 1;
        }
        else if(position == 3)
        {
            modifiers[0] = 4;
            modifiers[1] = 4;
            modifiers[2] = 4;
            modifiers[3] = 3;
            modifiers[4] = 3;
            modifiers[5] = 3;
            modifiers[6] = 4;
            modifiers[7] = 2.5;
            modifiers[8] = 2;
            modifiers[9] = 2;
            modifiers[10] = 1;
        }
        else if(position == 4)
        {
            modifiers[0] = 3;
            modifiers[1] = 3;
            modifiers[2] = 5;
            modifiers[3] = 3;
            modifiers[4] = 3;
            modifiers[5] = 1.5;
            modifiers[6] = 4;
            modifiers[7] = 3;
            modifiers[8] = 2;
            modifiers[9] = 4;
            modifiers[10] = 1;
        }
        else if(position == 5)
        {
            modifiers[0] = 3;
            modifiers[1] = 2;
            modifiers[2] = 4;
            modifiers[3] = 3;
            modifiers[4] = 3;
            modifiers[5] = 1.5;
            modifiers[6] = 4;
            modifiers[7] = 5.5;
            modifiers[8] = 2;
            modifiers[9] = 3.5;
            modifiers[10] = 1;
        }

        for(int i = 0; i < modifiers.Length; i++)
        {
            modifiers[i] = modifiers[i] * (development*1.5);
        }

    }
    public bool ContractExpired()
    {
        return contract.IsExpired();
    }
    /*
     * Ratings: 
     * 
     * ratings[0] = layup
     * ratings[1] = dunk
     * ratings[2] = jumpshot
     * ratings[3] = shot contest
     * ratings[4] = defense iq
     * ratings[5] = jumping
     * ratings[6] = seperation
     * ratings[7] = passing
     * ratings[8] = stamina
     * ratings[9] = threepoint
     * ratings[10] = durability
     */

    private void Upgrade(FormulaBasketball.Random rand)
    {
        for(int i = 0; i < ratings.Length; i++)
        {
            if(rand.Next(100) <= modifiers[i])
            {
                switch(development)
                {
                    case 1:
                        ratings[i] += Math.Max(1, rand.NextGaussian(1, 1));
                        break;
                    case 2:
                        ratings[i] += Math.Max(1, rand.NextGaussian(2, 1));
                        break;
                    case 3:
                        ratings[i] += Math.Max(2, rand.NextGaussian(2, 1));
                        break;
                    case 4:
                        ratings[i] += Math.Max(2, rand.NextGaussian(4, 1));
                        break;
                    case 5:
                        ratings[i] += Math.Max(3, rand.NextGaussian(4, 1));
                        break;
                    case 6:
                        ratings[i] += Math.Max(3, rand.NextGaussian(6, 1));
                        break;
                    case 7:
                        ratings[i] += Math.Max(4, rand.NextGaussian(6, 1));
                        break;
                    case 8:
                        ratings[i] += Math.Max(4, rand.NextGaussian(5, rand.Next(1,3)));
                        break;
                    case 9:
                        ratings[i] += Math.Max(5, rand.NextGaussian(5, rand.Next(1, 3)));
                        break;
                    case 10:
                        ratings[i] += Math.Max(5, rand.NextGaussian(8, 1));
                        break;
                }
            }
        }
    }
    public void Regress(FormulaBasketball.Random rand)
    {
        for (int i = 0; i < ratings.Length; i++)
        {
            // TODO: work on number based on age, younger old people should go down less than older old people
            double number = 100-modifiers[i];
            if (rand.Next(100) < number)
            {
                switch (development)
                {
                    case 10:
                        ratings[i] -= Math.Max(1, rand.NextGaussian(1, 1));
                        break;
                    case 9:
                        ratings[i] -= Math.Max(1, rand.NextGaussian(2, 1));
                        break;
                    case 8:
                        ratings[i] -= Math.Max(2, rand.NextGaussian(2, 1));
                        break;
                    case 7:
                        ratings[i] -= Math.Max(2, rand.NextGaussian(4, 1));
                        break;
                    case 6:
                        ratings[i] -= Math.Max(3, rand.NextGaussian(4, 1));
                        break;
                    case 5:
                        ratings[i] -= Math.Max(3, rand.NextGaussian(6, 1));
                        break;
                    case 4:
                        ratings[i] -= Math.Max(4, rand.NextGaussian(6, 1));
                        break;
                    case 3:
                        ratings[i] -= Math.Max(4, rand.NextGaussian(5, rand.Next(1, 3)));
                        break;
                    case 2:
                        ratings[i] -= Math.Max(5, rand.NextGaussian(5, rand.Next(1, 3)));
                        break;
                    case 1:
                        ratings[i] -= Math.Max(5, rand.NextGaussian(8, 1));
                        break;
                }
            }
        }


    }
    private int[] careerStats;
    public void endSeason()
    {
        if(careerStats == null)
        {
            careerStats = new int[stats.Length];
        }
        if(contract != null)
        {
            contract.AdvanceYear();
        }
        for(int i = 0; i < careerStats.Length; i++)
        {
            careerStats[i] += stats[i];
            stats[i] = 0;
        }
        gamesPlayed = 0;
        pointDiff = 0;
        starts = 0;

        age++;
    }
    public void Reset()
    {
        
        for (int i = 0; i < stats.Length; i++)
        {
            stats[i] = 0;
        }
        gamesPlayed = 0;
        pointDiff = 0;
        starts = 0;
        injuryLength = 0;
        isInjuredBool = false;
        stamina = 100;
    }
    private int playerID = 0;
    public void addPlayerID(int playerIDs)
    {
        this.playerID = playerIDs;
    }

    

    public void updateRatings(FormulaBasketball.Random r)
    {
        for(int i = 0; i < ratings.Length;i++)
        {
            int oldRatings = (int)ratings[i] * 10;
            ratings[i] = r.Next(oldRatings - 5, oldRatings + 5);
        }
    }

    

    public string getRatingsAsString()
    {
        string retVal = "";
        //if(team != null) retVal = team.ToString() + "\t" + name + "\t" + getPosition() + "\t";
        //else 
        retVal = country + "\t" + name + "\t" + getPosition() + "\t";

        retVal += ratings[0] + "\t" + ratings[1] + "\t" + ratings[2] + "\t" + ratings[9] + "\t" + ratings[7] + "\t" + ratings[3] + "\t" + ratings[4] + "\t" + ratings[5] + "\t" + ratings[6] + "\t" + ratings[10] + "\t" + ratings[8] + "\t";
        if(contract == null)
        {
            contract = new Contract(1, 1);
        }
        retVal += getDevelopment() + "\t" + playerAge + "\t" + String.Format("{0:0.00}", getOverall(this)) + "\t" + playerID + "\t" + contract.ToString() + "\t" + positionRank + "\t" + overallRank + "\n";
        return retVal;
    }
    public void SetNewContract(Contract newContract)
    {
        contract = newContract;
    }
    public double GetMoneyPerYear()
    {
        return contract.GetMoney();
    }
    public int GetYearsLeft()
    {
        return contract.GetYearsLeft();
    }
    public Contract GetCounterOffer(Contract previousOffer, FormulaBasketball.Random r, Contract previousPlayer = null)
    {
        int years = 0;
        double money = 0;

        if (age < 26)
        {
            if (previousOffer.GetYearsLeft() > 3)
            {
                years = 1;
                if (previousPlayer == null)
                {
                    money = previousOffer.GetMoney() + (r.Next(0, 40) / 10);
                }
                else
                {
                    if (previousOffer.GetMoney() > previousPlayer.GetMoney()) money = previousOffer.GetMoney();
                    else money = r.Next(Convert.ToInt32(previousOffer.GetMoney() * 10), Convert.ToInt32(previousPlayer.GetMoney() * 10));
                }
            }
            else
            {
                years = previousOffer.GetYearsLeft();
                if (previousPlayer == null)
                    money = previousOffer.GetMoney() + (r.Next(5, 40) / 10);
                else
                {
                    if (previousOffer.GetMoney() > previousPlayer.GetMoney()) money = previousOffer.GetMoney();
                    else money = r.Next(Convert.ToInt32(previousOffer.GetMoney() * 10), Convert.ToInt32(previousPlayer.GetMoney() * 10))/10;
                }
            }
        }
        else if(age > 33)
        {
            //TODO: Worry about this later
        }
        else
        {
            if (previousPlayer == null)
                money = previousOffer.GetMoney() + (r.Next(5, 40) / 10);
            else
            {
                if (previousOffer.GetMoney() > previousPlayer.GetMoney()) money = previousOffer.GetMoney();
                else money = r.Next(Convert.ToInt32(previousOffer.GetMoney() * 10), Convert.ToInt32(previousPlayer.GetMoney() * 10));
            }

            years = previousOffer.GetYearsLeft();
            
                
            if (money == previousOffer.GetMoney())
            {
                while (years == previousOffer.GetYearsLeft()) years = r.Next(1, 5);
            }

        }

        if (money > 25) money = 25;

        return new Contract(years,money);
    }
    private int playerHappiness = 0;
    public ContractResult ContractNegotiate(Contract newContract, FormulaBasketball.Random r)
    {

        double score = 0;

        double minResult = .8 * getOverall() - 43;

        minResult = Math.Max(1,Math.Min(25, minResult));

        if (playerHappiness == 0)
            playerHappiness = r.Next(20, 80);

        score += -80 + 3.2 * playerHappiness - 0.048 * playerHappiness * playerHappiness + 0.00032 * playerHappiness * playerHappiness * playerHappiness;

        double moneyDiff = newContract.GetMoney() - minResult;

        if(moneyDiff > 0)
        {
            score += 0.04762 * moneyDiff * moneyDiff + 6.524 * moneyDiff + 30.00;
        }
        else if(moneyDiff < -17)
        {
            return ContractResult.Reject;
        }
        else
        {
            score += 0.5238 * moneyDiff * moneyDiff + 18.24 * moneyDiff + 30.00;
        }

        if (minResult < newContract.GetMoney() && playerHappiness > 35) return ContractResult.Accept;

       

        if (newContract.GetMoney() < contract.GetMoney()) return ContractResult.Reject;

        if (playerHappiness < 40) return ContractResult.Reject;

        if (newContract.GetMoney() - minResult < 2.5 && playerHappiness > 70) return ContractResult.Accept;



        return ContractResult.Continue;
    }
    public string getDevelopment()
    {
        string potential = "";
        int normalizedPS = (peakStart - 27) * 2;
        int normalizedPE = (peakEnd - 30) * 2;

        int average =  Math.Max(1, Math.Min(10, ((normalizedPE + normalizedPS + development * 3) / 5)));

        switch (average)
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
        return potential;
    }
    public int GetPlayerID()
    {
        return playerID;
    }
    public Country GetCountry()
    {
        return country;
    }
    string theUniversity = "";
    public string University
    {
        get { return theUniversity; }
        set { theUniversity = value; }
    }
    public int age
    {
        get { return playerAge; }
        set { playerAge = value; }

    }
    public int teamPoints
    {
        get { return pointDiff; }
        set { pointDiff = value; }
    }
    public bool careerEnd
    {
        get { return careerEnded; }
        set { careerEnded = value; }
    }

    public int getGamesPlayed()
    {
        return gamesPlayed;
    }
    public void playedInAGame()
    {
        if (firstTimeInGame)
        {
            gamesPlayed++;
            firstTimeInGame = false;
        }
    }
    public retirements retire(FormulaBasketball.Random r, bool print = false)
    {
        if (playerAge == 34) return retirements.Age;
        if (careerEnd) return retirements.Injury;

        if (getOverall(null) < 40 && (playerAge > 30 || gamesPlayed == 0)) return retirements.Skill;

        double totalFactors = 0.0;

        double a = 1.6641;
        double b = 1.20185085;

        double ageRelatedFactors = a * Math.Pow(playerAge - 18, b);

        //85 - gamesStarted

        a = 0.95774384;
        b = 1.044120524;

        double gamesStartedFactors = a * Math.Pow(85 - starts, b) - 26;

        a = 0.909748899;
        b = 1.099204408;
        double overallRatedFactors = a * Math.Pow(85 - getOverall(null), b) - 21;

        

        totalFactors = ageRelatedFactors + gamesStartedFactors + overallRatedFactors;

        int num = r.Next(0, 100);

        if (num < totalFactors) return retirements.Personal;
        return retirements.None;

        //return false;
    }

    public void replaceAttributes(int layupStat, int dunkStat, int jumpStat, int threePoint, int passing, int shotContest, int defenseIQ, int jumping, int separation, int durability, int stamina)
    {
        setLayupRating(layupStat);
        setDunkRating(dunkStat);
        setJumpShotRating(jumpStat);
        setThreeShotRating(threePoint);
        setDurabilityRating(durability);
        setShotContestRating(shotContest);
        setDefenseIQRating(defenseIQ);
        setJumpingRating(jumping);
        setSeperation(separation);
        setPassing(passing);
        setStaminaRating(stamina);
    }
    public double[] getActualAttributes()
    {
        return ratings;
    }
    public void changePosition(int newPosition)
    {
        setPosition(newPosition);
    }
    
    public void addStart()
    {
        starts++;
    }
    public double getStamina()
    {
        return stamina;
    }
    public void setStamina(double d)
    {
        stamina = d;
    }
    public void setStarter(bool b)
    {
        isStarterBool = b;
        isPlayingBool = b;
    }
    public bool isStarter()
    {
        return isStarterBool;
    }

    public void changeStamina(double d)
    {
        double modifier = 0;
        if (d > 0)
        {
            modifier = 1;
        }
        else
        {

            double staminaRating = getStaminaRating();
            if (staminaRating <= 1)
            {
                modifier = 10;
            }
            else if (staminaRating <= 2)
            {
                modifier = 5.625;
            }
            else if (staminaRating <= 3)
            {
                modifier = 3.913043478;
            }
            else if (staminaRating <= 4)
            {
                modifier = 3;
            }
            else if (staminaRating <= 5)
            {
                modifier = 2.43243243243243;
            }
            else if (staminaRating <= 6)
            {
                modifier = 2.04545454545455;
            }
            else if (staminaRating <= 7)
            {
                modifier = 1.76470588235294;
            }
            else if (staminaRating <= 8)
            {
                modifier = 1.55172413793103;
            }
            else if (staminaRating <= 9)
            {
                modifier = 1.38461538461538;
            }
            else
            {
                modifier = 1.25;
            }
            //System.out.println("" + stamina + " " + modifier + " " + d + " " + getStaminaRating() +"");
        }

        stamina = stamina + (modifier * d);


        checkStamina();
    }
    private void checkStamina()
    {
        if (stamina >= 100) stamina = 100;
    }
    public int getPosition()
    {
        return position;
    }
    private void setPosition(int position)
    {
        this.position = position;
    }
    public double getLayupRating()
    {
        //if (name.Equals("Atakri Kalauni")) Console.WriteLine(((ratings[0] + shootingModifier) * getStamina() / 100 )+ " " + ((ratings[0] * getStamina() / 100)));
        return (ratings[0]/10 + shootingModifier) * getStamina() / 100;
    }
    private void setLayupRating(int rating)
    {
        this.ratings[0] = rating;
    }
    public double getDunkRating()
    {
        return (ratings[1] / 10 + shootingModifier) * getStamina() / 100;
    }
    private void setDunkRating(int rating)
    {
        this.ratings[1] = rating;
    }
    public double getJumpShotRating()
    {
        return (ratings[2] / 10 + shootingModifier) * getStamina() / 100;
    }
    private void setJumpShotRating(int rating)
    {
        this.ratings[2] = rating;
    }
    public double getShotContestRating()
    {
        return (ratings[3] / 10 + defensiveModifier) * getStamina() / 100;
    }
    private void setShotContestRating(int rating)
    {
        this.ratings[3] = rating;
    }
    public double getDefenseIQRating()
    {
        return (ratings[4] / 10 + defensiveModifier) * getStamina() / 100;
    }
    private void setDefenseIQRating(int rating)
    {
        this.ratings[4] = rating;
    }
    public String getName()
    {
        return name;
    }
    public bool isPlaying()
    {
        return isPlayingBool;
    }
    public void setIsPlaying(bool b)
    {
        isPlayingBool = b;
    }
    public double getJumpingRating()
    {
        return (ratings[5] / 10 + otherModifier) * getStamina() / 100;
    }
    private void setJumpingRating(int rating)
    {
        this.ratings[5] = rating;
    }
    public double getSeperation()
    {
        return (ratings[6] / 10 + otherModifier) * getStamina() / 100;
    }
    private void setSeperation(int rating)
    {
        this.ratings[6] = rating;
    }
    public double getPassing()
    {
        return (ratings[7] / 10 + otherModifier) * getStamina() / 100;
    }
    private void setPassing(int rating)
    {
        this.ratings[7] = rating;
    }
    public int getPoints()
    {
        return stats[0];
    }
    public int getGamePoints()
    {
        return gameStats[0];
    }
    public void addPoints(int p)
    {
        stats[0] += p;
        gameStats[0] += p;
    }
    public int getShotsTaken()
    {
        return stats[1];
    }
    public int getGameShotsTaken()
    {
        return gameStats[1];
    }
    public void addShotTaken(int p)
    {
        stats[1] += p;
        gameStats[1] += p;
    }
    public int getShotsMade()
    {
        return stats[2];
    }
    public int getGameShotsMade()
    {
        return gameStats[2];
    }
    public void addShotMade(int p)
    {
        stats[2] += p;
        gameStats[2] += p;
    }
    public int getAssists()
    {
        return stats[3];
    }
    public int getGameAssists()
    {
        return gameStats[3];
    }
    public void addAssists(int p)
    {
        stats[3] += p;
        gameStats[3] += p;
    }
    public int getTurnovers()
    {
        return stats[4];
    }
    public int getGameTurnovers()
    {
        return gameStats[4];
    }
    public void addTurnovers(int p)
    {
        stats[4] += p;
        gameStats[4] += p;
    }
    public int getSteals()
    {
        return stats[5];
    }
    public int getGameSteals()
    {
        return gameStats[5];
    }
    public void addSteals(int p)
    {
        stats[5] += p;
        gameStats[5] += p;
    }
    public int getMinutes()
    {
        return (int)Math.Round(stats[6] / 60.0);
    }
    public int getGameMinutes()
    {
        return (int)Math.Round(gameStats[6] / 60.0);
    }
    public void addMinutes(int p)
    {
        stats[6] += p;
        gameStats[6] += p;
        seconds += p;
    }
    public double getStaminaRating()
    {
        return ratings[8] / 10;
    }
    private void setStaminaRating(int rating)
    {
        this.ratings[8] = rating;
    }
    public void addRebound(int i)
    {
        stats[7] += i;
        gameStats[7] += i;
    }
    public int getRebounds()
    {
        return stats[7];
    }
    public int getGameRebounds()
    {
        return gameStats[7];
    }
    public void addOffensiveRebound(int i)
    {
        stats[8] += i;
        gameStats[8] += i;

    }
    public int getOffensiveRebounds()
    {
        return stats[8];
    }
    public int getGameOffensiveRebounds()
    {
        return gameStats[8];
    }
    public void addDefensiveRebound(int i)
    {
        stats[9] += i;
        gameStats[9] += i;

    }
    public int getDefensiveRebounds()
    {
        return stats[9];
    }
    public int getGameDefensiveRebounds()
    {
        return gameStats[9];
    }
    public void addFoul(int i)
    {
        stats[10] += i;
        gameFouls += i;
        //if (gameFouls == 6) Console.WriteLine("tf");
    }
    public int getFouls()
    {
        return stats[10];
    }
    public void resetGame()
    {
        firstTimeInGame = true;
        gameFouls = 0;
        if (injuryLength == 0) isInjuredBool = false;
    }
    public int getBoxScoreFouls()
    {
        return gameStats[10];
    }
    public int getGameFouls()
    {
        gameStats[10] = gameFouls;
        return gameFouls;
    }
    public void setShootingModifier(double d)
    {
        this.shootingModifier = d;
    }
    public void setDefensiveModifier(double defenseModifier)
    {
        this.defensiveModifier = defenseModifier;

    }
    public void setOtherModifier(double otherModifier)
    {
        this.otherModifier = otherModifier;

    }
    public void addThreeTaken(int i)
    {
        stats[11] += i;
        gameStats[11] += i;

    }
    public int getThreesTaken()
    {
        return stats[11];
    }
    public int getGameThreesTaken()
    {
        return gameStats[11];
    }
    public void addFreeThrowsTaken(int i)
    {
        stats[12] += i;
        gameStats[12] += i;
    }
    public void addFreeThrowsMade(int i)
    {
        stats[13] += i;
        gameStats[13] += i;

    }
    public int getFreeThrowsTaken()
    {
        return stats[12];
    }
    public int getFreeThrowsMade()
    {
        return stats[13];
    }
    public int getGameFreeThrowsTaken()
    {
        return gameStats[12];
    }
    public int getGameFreeThrowsMade()
    {
        return gameStats[13];
    }
    public void addThreePointerMade(int i)
    {
        stats[14] += i;
        gameStats[14] += i;
    }
    public int getThreePointersMade()
    {
        return stats[14];
    }
    public int getGameThreePointersMade()
    {
        return gameStats[14];
    }
    public void addShotsAttemptedAgainst(int i)
    {
        stats[15] += i;
        gameStats[15] += i;
    }
    public int getShotsAttemptedAgainst()
    {
        return stats[15];
    }
    public int getGameShotsAttemptedAgainst()
    {
        return gameStats[15];
    }
    public void addShotsMadeAgainst(int i)
    {
        stats[16] += i;
        gameStats[16] += i;
    }
    public int getShotsMadeAgainst()
    {
        return stats[16];
    }
    public int getGameShotsMadeAgainst()
    {
        return gameStats[16];
    }
    public void resetGameStats()
    {
        gameStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }
    public void setName(String newName)
    {
        name = newName;

    }
    /*public int compareTo(player otherPlayer)
    {
        return String.Compare(this.getName(), otherPlayer.getName());
    }*/
    public void setTeam(team team)
    {
        this.team = team;

    }
    public team getTeam()
    {
        return team;
    }
    public int getInjuryLength()
    {
        return injuryLength;
    }
    public void setInjuryLength(int injuryLength)
    {
        this.injuryLength = injuryLength;
    }
    public bool isInjured()
    {

        return isInjuredBool;
    }
    public void setInjured(bool b)
    {
        injuryTotal++;
        isInjuredBool = b;
    }
    public int getInjuryTotal()
    {
        return injuryTotal;
    }
    public void decrementDay()
    {
        injuryLength--;

    }
    public void resetAllStats()
    {
        stats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
    }
    public void addShootingModifier(double d)
    {
        this.shootingModifier += d;
    }
    public void addDefensiveModifier(double defenseModifier)
    {
        this.defensiveModifier += defenseModifier;

    }
    public void addOtherModifier(double otherModifier)
    {
        this.otherModifier += otherModifier;

    }
    public double getThreeShotRating()
    {
        return (ratings[9] / 10 + shootingModifier) * getStamina() / 100;
    }
    private void setThreeShotRating(int rating)
    {
        this.ratings[9] = rating;
    }
    public double getDurabilityRating()
    {
        return ratings[10] / 10;
    }
    private void setDurabilityRating(int rating)
    {
        this.ratings[10] = rating;
    }
    public override bool Equals(object obj)
    {
        if(obj is player)
        {
            player other = obj as player;
            if (playerID == other.GetPlayerID()) return true;
        }
        return false;
    }
    public int CompareTo(player other)
    {

        if (getOverall(this) - getOverall(other) > 0) return 1;
        else if (getOverall(other) - getOverall(this) > 0) return -1;
        else return 0;
    }
    /*
     * Ratings: 
     * 
     * ratings[0] = layup
     * ratings[1] = dunk
     * ratings[2] = jumpshot
     * ratings[3] = shot contest
     * ratings[4] = defense iq
     * ratings[5] = jumping
     * ratings[6] = seperation
     * ratings[7] = passing
     * ratings[8] = stamina
     * ratings[9] = threepoint
     * ratings[10] = durability
     */
    private double previousOverall = 0;
    public double GetOldOverall()
    {
        player player = this;
        double inside = Math.Max(player.ratings[0], player.ratings[1]) / 10;
        double retVal = 0;
        // 8.7
        if (position == 1)
        {
            retVal += inside * 1.4;
            retVal += player.ratings[2] * 1;
            retVal += player.ratings[9] * .7;
            retVal += player.ratings[7] * .6;
            retVal += player.ratings[3] * 1.4;
            retVal += player.ratings[4] * 1.4;
            retVal += player.ratings[5] * 1.4;
            retVal += player.ratings[6] * 1.6;
            retVal += player.ratings[8] * .5;

        }
        // 8
        else if (position == 2)
        {
            retVal += inside * 1.4;
            retVal += player.ratings[2] * 1.1;
            retVal += player.ratings[9] * .6;
            retVal += player.ratings[7] * .6;
            retVal += player.ratings[3] * 1.4;
            retVal += player.ratings[4] * 1.4;
            retVal += player.ratings[5] * 1.5;
            retVal += player.ratings[6] * 1.6;
            retVal += player.ratings[8] * .5;

        }
        // 9
        else if (position == 3)
        {
            retVal += inside * 1.3;
            retVal += player.ratings[2] * 1.2;
            retVal += player.ratings[9] * 1;
            retVal += player.ratings[7] * 1;
            retVal += player.ratings[3] * 1.2;
            retVal += player.ratings[4] * 1.2;
            retVal += player.ratings[5] * 1;
            retVal += player.ratings[6] * 1.6;
            retVal += player.ratings[8] * .5;
        }
        else if (position == 4)
        {
            retVal += inside * 1.2;
            retVal += player.ratings[2] * 1.4;
            retVal += player.ratings[9] * 1.4;
            retVal += player.ratings[7] * 1.1;
            retVal += player.ratings[3] * 1.05;
            retVal += player.ratings[4] * 1.05;
            retVal += player.ratings[5] * .7;
            retVal += player.ratings[6] * 1.5;
            retVal += player.ratings[8] * .5;
        }
        else
        {
            retVal += inside * 1.2;
            retVal += player.ratings[2] * 1.2;
            retVal += player.ratings[9] * 1.2;
            retVal += player.ratings[7] * 1.5;
            retVal += player.ratings[3] * 1.3;
            retVal += player.ratings[4] * 1.3;
            retVal += player.ratings[5] * .6;
            retVal += player.ratings[6] * 1;
            retVal += player.ratings[8] * .5;
        }
        
        retVal = Math.Min(99.99, ((retVal) / 90) * 100);
        if (player.Equals(this)) previousOverall = retVal;

        return retVal;
    }
    public double getOverall(player player = null, bool developmentIncluded = false)
    {
        if (player == null) player = this;
        double inside = Math.Max(player.ratings[0], player.ratings[1])/10;
        double retVal = 0;
        // 8.7
        if (position == 1)
        {
            retVal += inside * 1.4;
            retVal += player.ratings[2] * 1;
            retVal += player.ratings[9] * .7;
            retVal += player.ratings[7] * .6;
            retVal += player.ratings[3] * 1.4;
            retVal += player.ratings[4] * 1.4;
            retVal += player.ratings[5] * 1.4;
            retVal += player.ratings[6] * 1.6;
            retVal += player.ratings[8] * .5;

        }
        // 8
        else if (position == 2)
        {
            retVal += inside * 1.4;
            retVal += player.ratings[2] * 1.1;
            retVal += player.ratings[9] * .6;
            retVal += player.ratings[7] * .6;
            retVal += player.ratings[3] * 1.4;
            retVal += player.ratings[4] * 1.4;
            retVal += player.ratings[5] * 1.5;
            retVal += player.ratings[6] * 1.6;
            retVal += player.ratings[8] * .5;

        }
        // 9
        else if (position == 3)
        {
            retVal += inside * 1.3;
            retVal += player.ratings[2] * 1.2;
            retVal += player.ratings[9] * 1;
            retVal += player.ratings[7] * 1;
            retVal += player.ratings[3] * 1.2;
            retVal += player.ratings[4] * 1.2;
            retVal += player.ratings[5] * 1;
            retVal += player.ratings[6] * 1.6;
            retVal += player.ratings[8] * .5;
        }
        else if (position == 4)
        {
            retVal += inside * 1.2;
            retVal += player.ratings[2] * 1.4;
            retVal += player.ratings[9] * 1.4;
            retVal += player.ratings[7] * 1.1;
            retVal += player.ratings[3] * 1.05;
            retVal += player.ratings[4] * 1.05;
            retVal += player.ratings[5] * .7;
            retVal += player.ratings[6] * 1.5;
            retVal += player.ratings[8] * .5;
        }
        else
        {
            retVal += inside * 1.2;
            retVal += player.ratings[2] * 1.2;
            retVal += player.ratings[9] * 1.2;
            retVal += player.ratings[7] * 1.5;
            retVal += player.ratings[3] * 1.3;
            retVal += player.ratings[4] * 1.3;
            retVal += player.ratings[5] * .6;
            retVal += player.ratings[6] * 1;
            retVal += player.ratings[8] * .5;
        }
        if(developmentIncluded)
        {
            retVal = retVal / 2;
            
            int normalizedPS = (peakStart - 27) * 2;
            int normalizedPE = (peakEnd - 30) * 2;

            retVal += Math.Max(1, Math.Min(10, ((normalizedPE + normalizedPS + development * 3) / 5))) * 5;
        }
        retVal = Math.Min(99.99, ((retVal / 10) / 90) * 100);
        if (player.Equals(this)) previousOverall = retVal;

        return retVal;
    }
    public void ResetPlayerSkills(int pos, int layupStat, int dunkStat, int jumpStat, int threePoint, int passing, int shotContest, int defenseIQ, int jumping, int separation, int durability, int stamina, int years, double money)
    {
        setPosition(pos);
        setLayupRating(layupStat);
        setDunkRating(dunkStat);
        setJumpShotRating(jumpStat);
        setThreeShotRating(threePoint);
        setDurabilityRating(durability);
        setShotContestRating(shotContest);
        setDefenseIQRating(defenseIQ);
        setJumpingRating(jumping);
        setSeperation(separation);
        setPassing(passing);
        setStaminaRating(stamina);
        contract = new Contract(years, money);
    }

    public double GetMoney()
    {
        if(contract == null)contract = new Contract(1,1);
        return contract.GetMoney();
    }
    private int positionRank, overallRank;
    public void SetPositionRank(int rank)
    {
        positionRank = rank;
    }
    public void SetOverallRank(int rank)
    {
        overallRank = rank;
    }
    private double seconds = 0;
    public double MinutesInRow()
    {
        return seconds / 60;
    }
    public bool StartedGame()
    {
        return started;
    }
    private bool started = false;
    public void SetStartedGame(bool started)
    {
        this.started = started;
    }
    public void Pulled()
    {
        seconds = 0;
    }
}