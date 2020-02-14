using System;
using System.Collections.Generic;
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
    public double[] ratings;
    protected Contract contract;
    protected PlayerRecords playerRecords;
    /*
     * 0: Inside
     * 1: Jump
     * 7: Three Point
     * 6: Passing
     * 2: Shot Contest
     * 3: Defense IQ
     * 4: Jumping
     * 5: Seperation
     * 8: Stamina
     */
     public override string ToString()
    {
        return name + " " + getOverall().ToString("0.##");
    }
    private static int[][] probabilites = new int[][] {new int[]{ 25, 5, 15, 15, 30, 15, 5, 2 }, new int[]{ 25, 10, 15, 15, 20, 15, 10, 5 }, new int[] { 20, 10, 15, 15, 15, 15, 10, 5 }, new int[] { 15, 25, 20, 20, 5, 15, 15, 15 }, new int[] { 20, 20, 15, 15, 5, 25, 10, 15 },new int[] { 10, 20, 15, 15, 10, 15, 35, 20 } };
    public static player GeneratePlayer(int pos, Country country, int overall, int age, int development, int peakStart, int peakEnd, FormulaBasketball.Random r)
    {
        NameGenerator gen = NameGenerator.Instance();
        String name = gen.GenerateName(country);
        overall += 5;
        int[] ratings = new int[] {1,1,1,1,1,1,1,1,r.Next(5,10), r.Next(1,10) };

        double currentOverall = getOverall(pos, ratings);
        int[] selectedProbability;
        if (pos < 3 || (pos == 3 && r.NextBool()))
        {
            selectedProbability = probabilites[pos - 1];
        }
        else
        {
            selectedProbability = probabilites[pos];
        }
        int sum = 0;
        foreach(int num in selectedProbability)
        {
            sum += num;
        }

        int selected = r.Next(sum);
        int currSum = 0;
        int i;
        while (currentOverall < overall)
        {
            selected = r.Next(sum);
            currSum = 0;
            for (i = 0; i < selectedProbability.Length - 1; i++)
            {
                if (selected < selectedProbability[i] + currSum)
                {
                    break;
                }
                currSum += selectedProbability[i];
            }
            if (ratings[i] == 10) continue;
            ratings[i]++;
            currentOverall = getOverall(pos, ratings);
        }
        selected = r.Next(sum);
        currSum = 0;
        for (i = 0; i < selectedProbability.Length - 1; i++)
        {
            if (selected < selectedProbability[i] + currSum)
            {
                break;
            }
            currSum += selectedProbability[i];
        }
        if (ratings[i] != 10)
           ratings[i]++;
        return new player(pos, ratings, age, name, country, development, peakStart, peakEnd, r);
        
    }
    public player(int pos, int[] ratings, int age, string name, Country country, int development, int peakStart, int peakEnd,  FormulaBasketball.Random r)
    {
        this.ratings = new double[11];
        stats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        careerStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        stamina = 100;

        this.name = name;
        this.age = age;
        this.position = pos;
        this.country = country;
        this.development = development;
        this.peakStart = peakStart;
        this.peakEnd = peakEnd;

        if(r.NextBool())
        {
            this.ratings[0] = Math.Max(1, ratings[0] - r.Next(1, 3)) * 10 + r.Next(-5, 5);
            this.ratings[1] = ratings[0] *10 + r.Next(-5, 5);
        }
        else
        {
            this.ratings[1] = Math.Max(1, ratings[0] - r.Next(1, 3)) * 10 + r.Next(-5, 5);
            this.ratings[0] = ratings[0] * 10 + r.Next(-5, 5);
        }
        this.ratings[2] = ratings[1] * 10 + r.Next(-5, 5);
        this.ratings[3] = ratings[2] * 10 + r.Next(-5, 5);
        this.ratings[4] = ratings[3] * 10 + r.Next(-5, 5);
        this.ratings[5] = ratings[4] * 10 + r.Next(-5, 5);
        this.ratings[6] = ratings[5] * 10 + r.Next(-5, 5);
        this.ratings[7] = ratings[6] * 10 + r.Next(-5, 5);
        this.ratings[8] = ratings[8] * 10 + r.Next(-5, 5);
        this.ratings[9] = ratings[7] * 10 + r.Next(-5, 5);
        this.ratings[10] = ratings[9] * 10 + r.Next(-5, 5);

    }
    public string SavePlayer()
    {
        if (contract == null) contract = new Contract(0, 0);
        String content = "<player>" + name + "," + playerAge + "," + country.ToString() + "," + contract.ToString() + "," + position + "," + peakStart + "," + peakEnd + "," + development + "," + gamesPreviousPlayed + "," + prevPointDiff + "," + (isRookie ? 1 : 0);
        for (int i = 0; i < ratings.Length; i++)
        {
            content += "," + ratings[i];
        }
        for (int i = 0; i < careerStats.Length; i++)
        {
            content += "," + careerStats[i];
        }
        if (previousSeasonStats == null) previousSeasonStats = new int[careerStats.Length];
        for (int i = 0; i < previousSeasonStats.Length; i++)
        {
            content += "," + previousSeasonStats[i];
        }
        return content;

    }
    public player(String info)
    {
        String[] arr = info.Split(',');
        name = arr[0].Replace("<player>", "");
        playerAge = int.Parse(arr[1]);
       
        country = StringUtils.GetCountryFromString(arr[2]);
        playerID = createTeams.nextID;
        createTeams.nextID++;
       
        contract = new Contract(arr[3]);
        position = int.Parse(arr[4]);
        peakStart = int.Parse(arr[5]);
        peakEnd = int.Parse(arr[6]);
        development = int.Parse(arr[7]);
        gamesPlayed = int.Parse(arr[8]);
        pointDiff = int.Parse(arr[9]);
        isRookie = int.Parse(arr[10]) == 1;
        ratings = new double[11];
        stats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        careerStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        stamina = 100;
        int location = 11;
        for (int i = 0; i < ratings.Length; i++)
        {
            ratings[i] += double.Parse(arr[location]);
            location++;
        }
        for (int i = 0; i < careerStats.Length; i++)
        {
           careerStats[i] += int.Parse(arr[location]);
           location++;
        }
        for (int i = 0; i < careerStats.Length; i++)
        {
            stats[i] += int.Parse(arr[location]);
            location++;
        }
    }
    public player(CollegePlayer player, int id)
    {
        ratings = new double[11];
        stats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        careerStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        country = player.GetCountry();
        contract = null;

        playerID = id;
        position = player.position;
        name = player.name;

        shootingModifier = 0.0;
        otherModifier = 0.0;
        defensiveModifier = 0.0;
        gameFouls = 0;

        setLayupRating((int)player.getLayupRating(false));
        setDunkRating((int)player.getDunkRating(false));
        setJumpShotRating((int)player.getJumpShotRating(false));
        setThreeShotRating((int)player.getThreeShotRating(false));
        setDurabilityRating((int)player.getDurabilityRating(false));
        setShotContestRating((int)player.getShotContestRating(false));
        setDefenseIQRating((int)player.getDefenseIQRating(false));
        setJumpingRating((int)player.getJumpingRating(false));
        setSeperation((int)player.getSeperation(false));
        setPassing((int)player.getPassing(false));
        setStaminaRating((int)player.getStaminaRating(false));

        stamina = 100;

        playerAge = player.age;
        peakStart = player.peakStart;
        peakEnd = player.peakEnd;
        development = player.development;
    }
    public player(player player, int id)
    {
        ratings = new double[11];
        stats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        careerStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        country = player.GetCountry();
        contract = null;

        playerID = id;
        position = player.position;
        name = player.name;

        shootingModifier = 0.0;
        otherModifier = 0.0;
        defensiveModifier = 0.0;
        gameFouls = 0;

        setLayupRating((int)player.getLayupRating(false));
        setDunkRating((int)player.getDunkRating(false));
        setJumpShotRating((int)player.getJumpShotRating(false));
        setThreeShotRating((int)player.getThreeShotRating(false));
        setDurabilityRating((int)player.getDurabilityRating(false));
        setShotContestRating((int)player.getShotContestRating(false));
        setDefenseIQRating((int)player.getDefenseIQRating(false));
        setJumpingRating((int)player.getJumpingRating(false));
        setSeperation((int)player.getSeperation(false));
        setPassing((int)player.getPassing(false));
        setStaminaRating((int)player.getStaminaRating(false));

        stamina = 100;

        playerAge = player.age;
        peakStart = player.peakStart;
        peakEnd = player.peakEnd;
        development = player.development;
    }
    public player(int pos, double[] ratings, int age, String name, int peakStart, int peakEnd, int development, Country country, int playerID)
    {
        careerEnd = false;
        starts = 0;
        this.country = country;
        pointDiff = 0;
        gamesPlayed = 0;
        firstTimeInGame = true;
        setPosition(pos);
        
        this.ratings = ratings;

        this.stamina = 100;
        shootingModifier = 0.0;
        otherModifier = 0.0;
        defensiveModifier = 0.0;
        stats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameStats = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        gameFouls = 0;
        this.name = name;
        this.playerAge = age;
        this.peakEnd = peakEnd;
        this.peakStart = peakStart;
        this.development = development;
        this.playerID = playerID;
    }
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
    private bool isRookie;
    public void IsRookie(bool rookie = true)
    {
        isRookie = rookie;
    }
    public bool Rookie()
    {
        return isRookie;
    }
    public void updatePlayerRecords(int gameNum, string opposingTeam)
    {
        if(playerRecords == null)
        {
            playerRecords = new PlayerRecords(name);
        }
        playerRecords.CheckRecords(this, gameNum, opposingTeam);
    }
    public void Print()
    {
        playerRecords.Print();
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
    public bool FreeAgentSigned()
    {
        return sign;
    }
    private bool sign = false;
    int personality = 0, singingPersonality = 0;
    public bool Signed(FormulaBasketball.Random r, bool last, createTeams create)
    {        
        if (contractOffers != null && contractOffers.Count > 0)
        {
            double highestScore = -1240100;
            int highestTeam = -1;

            foreach (KeyValuePair<int, Contract> contract in contractOffers)
            {
                if (singingPersonality == 0) personality = r.Next(1, 3);

                if (singingPersonality == 1)
                {
                    double score = 26.036253880057 - 1.0221013187906 * (32 - create.getTeam(contract.Key).GetDraftPlace()) - 0.014819245082403 * (32 - create.getTeam(contract.Key).GetDraftPlace()) * (32 - create.getTeam(contract.Key).GetDraftPlace()) + 0.00066668381608959 * (32 - create.getTeam(contract.Key).GetDraftPlace()) * (32 - create.getTeam(contract.Key).GetDraftPlace()) * (32 - create.getTeam(contract.Key).GetDraftPlace());
                    double minResult = .8 * getOverall() - 43;

                    minResult = Math.Max(1, Math.Min(25, minResult));


                    double moneyDiff = contract.Value.GetMoney() - minResult;

                    if (moneyDiff > 0)
                    {
                        score += 0.04762 * moneyDiff * moneyDiff + 6.524 * moneyDiff + 30.00;
                    }
                    else
                    {
                        score += 0.5238 * moneyDiff * moneyDiff + 18.24 * moneyDiff + 30.00;
                    }
                    if(score > highestScore)
                    {
                        highestScore = score;
                        highestTeam = contract.Key;
                    }
                }
                // playingTime
                else if (singingPersonality == 2)
                {
                    double score = 0;
                    player bestPlayer = null;
                    foreach (player p in create.getTeam(contract.Key).getAllPlayer())
                    {
                        if(p.getPosition() == getPosition())
                        {
                            if (bestPlayer == null || bestPlayer.getOverall() < p.getOverall()) bestPlayer = p;
                        }
                    }
                    if (getOverall() > bestPlayer.getOverall()) score = 1000;
                    else
                    {
                        foreach (player p in create.getTeam(contract.Key).getAllPlayer())
                        {
                            int rank = 1;
                            if (p.getPosition() == getPosition())
                            {
                                if (p.getOverall() > getOverall()) rank++;
                                
                            }
                            score = 145 - 48.75 * rank + 8.125 * rank * rank - 0.625 * rank * rank * rank;
                        }
                    }

                    if(score == 1000 && highestScore == 1000)
                    {
                        if (create.getTeam(contract.Key).GetDraftPlace() < create.getTeam(highestTeam).GetDraftPlace())
                        {
                            highestTeam = contract.Key;
                        }
                    }

                    if (score > highestScore)
                    {
                        highestScore = score;
                        highestTeam = contract.Key;
                    }
                    else if(score == highestScore)
                    {
                        if (create.getTeam(contract.Key).GetDraftPlace() < create.getTeam(highestTeam).GetDraftPlace())
                        {
                            highestTeam = contract.Key;
                        }
                    }
                }
                // money only
                else
                {
                    double score = 0;
                    double minResult = .8 * getOverall() - 43;

                    minResult = Math.Max(1, Math.Min(25, minResult));


                    double moneyDiff = contract.Value.GetMoney() - minResult;

                    if (moneyDiff > 0)
                    {
                        score += 0.04762 * moneyDiff * moneyDiff + 6.524 * moneyDiff + 30.00;
                    }
                    else
                    {
                        score += 0.5238 * moneyDiff * moneyDiff + 18.24 * moneyDiff + 30.00;
                    }
                    if (score > highestScore)
                    {
                        highestScore = score;
                        highestTeam = contract.Key;
                    }
                }

            }
            double num = 1.6666666666667 * highestScore - 0.012 * highestScore * highestScore + 5.3333333333333E-5 * highestScore * highestScore * highestScore;
            if (last || r.Next(100) < num)
            {
                //highestTeam.GetTeam().addPlayer(this);
                //contract = highestTeam.GetContract();
                sign = true;
            }

        }
        
        return sign;
    }
    public void SetFreeAgent()
    {
        if(contractOffers == null)
            contractOffers = new Dictionary<int, Contract>();
    }
    private int offerCount, status;
    public int GetStatus()
    {
        return status;
    }
    public void SetStatus(int newStatus)
    {
        status = newStatus;
    }
    public void SetAdditionalOffers(int offer)
    {
        offerCount = offer;
    }
    public int GetOffers()
    {
        return contractOffers.Count + offerCount;
    }
    public Dictionary<int, Contract> GetFreeAgentOffers()
    {
        if(playerID == 373)
        {
            Console.WriteLine("Test for alomundi");
        }
        return contractOffers;
    }
    private Dictionary<int, Contract> contractOffers;
    public void OfferFreeAgentContract(Contract contract, team team)
    {
        if (playerID == 373)
        {
            Console.WriteLine("Test for alomundi");
        }
        if (contractOffers == null) contractOffers = new Dictionary<int, Contract>();
        if (contractOffers.ContainsKey(team.getTeamNum())) contractOffers[team.getTeamNum()] = contract;
        else contractOffers.Add(team.getTeamNum() ,contract);
    }
    public void Stamina()
    {
        stamina = 100;
    }
    public bool HasOfferFromTeam(team team)
    {
        if (playerID == 373)
        {
            Console.WriteLine("Test for alomundi");
        }
        if (contractOffers == null) return false;
        return contractOffers.ContainsKey(team.getTeamNum());
    }
    public Contract GetOfferFromTeam(team team)
    {
        if (playerID == 373)
        {
            Console.WriteLine("Test for alomundi");
        }
        if (contractOffers.ContainsKey(team.getTeamNum())) return contractOffers[team.getTeamNum()];
        
        return null;
    }
    public bool RemoveFreeAgentOffer(team team)
    {
        if (playerID == 373)
        {
            Console.WriteLine("Test for alomundi");
        }
        return contractOffers.Remove(team.getTeamNum());
    }
    public int peakStart, peakEnd, development;
    public void generateDevelopment(FormulaBasketball.Random rand)
    {
        peakStart = rand.NextGaussian(30, 1);
        peakEnd = peakStart + Math.Max(1,rand.NextGaussian(3, 1));

        development = Math.Min(Math.Max(1,rand.NextGaussian(6, 1)), 10);
        
    }
    private double[] modifiers = null;
    public void Develop(FormulaBasketball.Random rand)
    {
        if (highestRating == null)
        {
            highestRating = new double[ratings.Length];
        }
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
        
        for(int i = 0; i < ratings.Length; i++)
            if (ratings[i] > highestRating[i]) highestRating[i] = ratings[i];

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
    private double[] highestRating;
    private void Upgrade(FormulaBasketball.Random rand)
    {
        
        for (int i = 0; i < ratings.Length; i++)
        {
            
            if(rand.Next(100) <= modifiers[i])
            {
                ratings[i] = IncreaseRatings(peakStart - playerAge, ratings[i], development, rand);
                /*switch(development)
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
                }*/
            }
        }
    }

    private double IncreaseRatings(int yearsLeft, double rating, int development, FormulaBasketball.Random r)
    {
        if (yearsLeft >= 10 && development > 8)
        {
            return rating + Math.Min(7, Math.Max(3, r.NextGaussian(5, 1)));
        }
        else if(yearsLeft >= 10 && development > 4)
        {
            return rating + Math.Min(6, Math.Max(2, r.NextGaussian(4, 1)));
        }
        else if(yearsLeft >= 10)
        {
            return rating + Math.Min(5, Math.Max(2, r.NextGaussian(3, 1)));
        }
        else if ((yearsLeft == 1 && development < 8) || (rating > 90 && development < 7)) return rating + 1;
        else if(rating < 60 && development > 5)
        {
            return rating + Math.Min(5, Math.Max(2, r.NextGaussian(4, 1)));
        }
        else if(rating < 60)
        {
            return rating + Math.Min(4, Math.Max(2, r.NextGaussian(3, 1)));
        }
        else
        {
            return rating + Math.Min(3, Math.Max(1, r.NextGaussian(2, 1)));
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
            if(ratings[i] != 8)ratings[i] = Math.Max(0, ratings[i]);
            else ratings[i] = Math.Max(50, ratings[i]);
            ratings[i] = Math.Max(highestRating[i] / 2, ratings[i]);
            
        }


    }
    private int[] careerStats, previousSeasonStats;
    private int gamesPreviousPlayed;
    private int prevPointDiff;
    public void endSeason()
    {        
        if(contract != null)
        {
            contract.AdvanceYear();
        }
        ResetStats();
        isRookie = false;
        age++;
    }
    public void ResetStats()
    {
        if (careerStats == null)
        {
            careerStats = new int[stats.Length];
        }
        for (int i = 0; i < careerStats.Length; i++)
        {
            careerStats[i] += stats[i];
            stats[i] = 0;
        }
        gamesPlayed = 0;
        pointDiff = 0;
        starts = 0;
        injuryLength = 0;
        isInjuredBool = false;
        stamina = 100;
        
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
        double bonus = 0;
        List<Promises> promises = new List<Promises>();
        double minResult = .8 * getOverall() - 43;
        switch (personality)
        {
            case 1:
                years = previousOffer.GetYearsLeft();
                money = minResult + (r.Next(0, 25) / 10);
                if(previousPlayer != null)
                {
                    if(money >= previousPlayer.GetMoney())
                    {
                        money = minResult;
                    }
                }
                bonus = money * (r.Next(5, 150) / 100);
                promises = new List<Promises>(previousOffer.GetPromises());
                break;
            case 2:

                years = previousOffer.GetYearsLeft();

                money = minResult + (r.Next(0, 25) / 10);
                if (previousPlayer != null)
                {
                    if (money >= previousPlayer.GetMoney())
                    {
                        money = minResult;
                    }
                }
                bonus = money * (r.Next(5, 150) / 100);
                promises = new List<Promises>(previousOffer.GetPromises());

                if (getOverall() > 70 && !promises.Contains(Promises.Year_One_Starter))promises.Add(Promises.Year_One_Starter);


                break;

            case 3:
                promises = new List<Promises>(previousOffer.GetPromises());
                years = previousOffer.GetYearsLeft();
                bonus = Math.Max(previousOffer.GetMoney() * .1, previousOffer.GetBonus());
                money = previousOffer.GetMoney();
                break;
            case 4:
                minResult += 2.5;

                minResult = Math.Min(25, minResult);
                years = previousOffer.GetYearsLeft();

                money = minResult + (r.Next(0, 25) / 10);
                if (previousPlayer != null)
                {
                    if (money >= previousPlayer.GetMoney())
                    {
                        money = minResult;
                    }
                }
                bonus = money * (r.Next(5, 150) / 100);
                promises = new List<Promises>(previousOffer.GetPromises());
                break; 
            default:
                years = previousOffer.GetYearsLeft();

                money = minResult + (r.Next(0, 25) / 10);
                if (previousPlayer != null)
                {
                    if (money >= previousPlayer.GetMoney())
                    {
                        money = minResult;
                    }
                }
                bonus = money * (r.Next(5, 150) / 100);
                promises = new List<Promises>(previousOffer.GetPromises());
                break;
        }

        return new Contract(years,money, 0 , bonus, promises);
    }
    private int playerHappiness = 0;//, personality = 0;
    public ContractResult ContractNegotiate(Contract newContract, FormulaBasketball.Random r)
    {

        double minResult = .7 * getOverall() - 43;
        if (playerHappiness == 0)
            playerHappiness = r.Next(20, 80);
        minResult = Math.Max(contract.GetMoney(), Math.Min(25, minResult));
        if(personality == 0)
        {
            int num = r.Next(80);
            // Winning Only
            if (num < 10)
            {
                personality = 1;
                if (team.GetDraftPlace() < 26)
                {
                    if (minResult <= contract.GetMoney() && newContract.GetPromises().Contains(Promises.Win_Conference)) 
                    {
                        return ContractResult.Accept;
                    }
                    return ContractResult.Reject;
                }
                else if (minResult <= contract.GetMoney()) return ContractResult.Accept;
                else return ContractResult.Continue;
            }
            // Balanced
            else if (num < 25)
            {
                personality = 2;

                double score = 0;

                double moneyDiff = newContract.GetMoney() - minResult;

                List<Promises> promises = newContract.GetPromises();

                if (playerHappiness < 40) score -= 1000;

                if(promises != null)
                {
                    if (promises.Contains(Promises.Make_Playoffs))
                        score += 10;
                    if (promises.Contains(Promises.No_Trade))
                        score += 20;
                    if (promises.Contains(Promises.Win_Championship))
                        score += 100;
                    if (promises.Contains(Promises.Win_Conference))
                        score += 25;
                    if (promises.Contains(Promises.Win_Division))
                        score += 20;
                    if (promises.Contains(Promises.Year_One_Starter))
                        score += 20;
                }

                score += playerHappiness - 55;

                if (moneyDiff > 5) score += 900;
                else if (moneyDiff > 0) score += 50;
                else if (moneyDiff > -2) score -= 20;
                else score -= 500;

                if (score >= 50) return ContractResult.Accept;
                else if (score >= 0) return ContractResult.Continue;
                else return ContractResult.Reject;

            }
            // Championship Required
            else if (num < 27)
            {
                personality = 3;
                if (newContract.GetMoney() - 1 >= contract.GetMoney() && newContract.GetPromises().Contains(Promises.Win_Championship)) return ContractResult.Accept;
                else if (newContract.GetPromises().Contains(Promises.Win_Championship) || newContract.GetMoney() - 1 >= contract.GetMoney()) return ContractResult.Continue;
                else return ContractResult.Reject;
            }
            else if (num < 70)
            {
                minResult += 2.5;
                personality = 4;

                minResult = Math.Min(25, minResult);


                double moneyDiff = newContract.GetMoney() - minResult;

                if (moneyDiff < -17)
                {
                    return ContractResult.Reject;
                }

                if (minResult < newContract.GetMoney() && playerHappiness > 35) return ContractResult.Accept;



                if (newContract.GetMoney() < contract.GetMoney()) return ContractResult.Reject;

                if (playerHappiness < 40) return ContractResult.Reject;

                if (newContract.GetMoney() - minResult < 2.5 && playerHappiness > 70) return ContractResult.Accept;

                return ContractResult.Continue;
            }
            else
            {
                personality = 5;
                


                double moneyDiff = newContract.GetMoney() - minResult;

                if (moneyDiff < -17)
                {
                    return ContractResult.Reject;
                }

                if (minResult < newContract.GetMoney() && playerHappiness > 35) return ContractResult.Accept;



                if (newContract.GetMoney() < contract.GetMoney()) return ContractResult.Reject;

                if (playerHappiness < 40) return ContractResult.Reject;

                if (newContract.GetMoney() - minResult < 2.5 && playerHappiness > 70) return ContractResult.Accept;

                return ContractResult.Continue;
            }
        }
        else
        {
            switch (personality)
            {
                case 1:
                    if (team.GetDraftPlace() < 26)
                    {
                        if (minResult <= contract.GetMoney() && newContract.GetPromises().Contains(Promises.Win_Conference))
                        {
                            return ContractResult.Accept;
                        }
                        return ContractResult.Reject;
                    }
                    else if (minResult <= contract.GetMoney()) return ContractResult.Accept;
                    else return ContractResult.Continue;
                case 2:
                     double score = 0;

                    double moneyDiff = newContract.GetMoney() - minResult;

                    List<Promises> promises = newContract.GetPromises();

                    if (playerHappiness < 40) score -= 1000;

                    if(promises != null)
                    {
                        if (promises.Contains(Promises.Make_Playoffs))
                            score += 10;
                        if (promises.Contains(Promises.No_Trade))
                            score += 20;
                        if (promises.Contains(Promises.Win_Championship))
                            score += 100;
                        if (promises.Contains(Promises.Win_Conference))
                            score += 25;
                        if (promises.Contains(Promises.Win_Division))
                            score += 20;
                        if (promises.Contains(Promises.Year_One_Starter))
                            score += 20;
                    }

                    score += playerHappiness - 55;

                    if (moneyDiff > 5) score += 900;
                    else if (moneyDiff > 0) score += 50;
                    else if (moneyDiff > -2) score -= 20;
                    else score -= 500;

                    if (score >= 50) return ContractResult.Accept;
                    else if (score >= 0) return ContractResult.Continue;
                    else return ContractResult.Reject;

                case 3:
                    if (newContract.GetMoney() - 1 >= contract.GetMoney() && newContract.GetPromises().Contains(Promises.Win_Championship)) return ContractResult.Accept;
                    else if (newContract.GetPromises().Contains(Promises.Win_Championship) || newContract.GetMoney() - 1 >= contract.GetMoney()) return ContractResult.Continue;
                    else return ContractResult.Reject;
                case 4:
                    minResult += 2.5;

                    minResult = Math.Min(25, minResult);


                    moneyDiff = newContract.GetMoney() - minResult;

                    if (moneyDiff < -17)
                    {
                        return ContractResult.Reject;
                    }

                    if (minResult < newContract.GetMoney() && playerHappiness > 35) return ContractResult.Accept;



                    if (newContract.GetMoney() < contract.GetMoney()) return ContractResult.Reject;

                    if (playerHappiness < 40) return ContractResult.Reject;

                    if (newContract.GetMoney() - minResult < 2.5 && playerHappiness > 70) return ContractResult.Accept;

                    return ContractResult.Continue;
                default:


                    moneyDiff = newContract.GetMoney() - minResult;

                    if (moneyDiff < -17)
                    {
                        return ContractResult.Reject;
                    }

                    if (minResult < newContract.GetMoney() && playerHappiness > 35) return ContractResult.Accept;



                    if (newContract.GetMoney() < contract.GetMoney()) return ContractResult.Reject;

                    if (playerHappiness < 40) return ContractResult.Reject;

                    if (newContract.GetMoney() - minResult < 2.5 && playerHappiness > 70) return ContractResult.Accept;

                    return ContractResult.Continue;

            }
            
        }

       



        
    }
    public string layupStr;
    public string dunkStr;
    public string jumpshotStr;
    public string threepointStr;
    public string passStr;
    public string shotcontestStr;
    public string defenseiqStr;
    public string jumpingStr;
    public string seperationStr;
    public string durabilityStr;
    public string staminaStr;
    public string potential;
    public bool scout;
    public void Scout(FormulaBasketball.Random r, int scoutSkill)
    {
        scout = false;
        int[] elevens = new int[11];
        for (int i = 0; i < elevens.Length; i++)
        {
            elevens[i] = r.Next(-scoutSkill, 0);
        }

        layupStr = "" + (elevens[0] + getLayupRating(false)) + " -> " + (elevens[0] + getLayupRating(false) + scoutSkill);
        dunkStr = "" + (elevens[1] + getDunkRating(false)) + " -> " + (elevens[1] + getDunkRating(false) + scoutSkill);
        jumpshotStr = "" + (elevens[2] + getJumpShotRating(false)) + " -> " + (elevens[2] + getJumpShotRating(false) + scoutSkill);
        threepointStr = "" + (elevens[3] + getThreeShotRating(false)) + " -> " + (elevens[3] + getThreeShotRating(false) + scoutSkill);
        passStr = "" + (elevens[4] + getPassing(false)) + " -> " + (elevens[4] + getPassing(false) + scoutSkill);
        shotcontestStr = "" + (elevens[5] + getShotContestRating(false)) + " -> " + (elevens[5] + getShotContestRating(false) + scoutSkill);
        defenseiqStr = "" + (elevens[6] + getDefenseIQRating(false)) + " -> " + (elevens[6] + getDefenseIQRating(false) + scoutSkill);
        jumpingStr = "" + (elevens[7] + getJumpingRating(false)) + " -> " + (elevens[7] + getJumpingRating(false) + scoutSkill);
        seperationStr = "" + (elevens[8] + getSeperation(false)) + " -> " + (elevens[8] + getSeperation(false) + scoutSkill);
        durabilityStr = "" + (elevens[9] + getDurabilityRating(false)) + " -> " + (elevens[9] + getDurabilityRating(false) + scoutSkill);
        staminaStr = "" + (elevens[10] + getStaminaRating(false)) + " -> " + (elevens[10] + getStaminaRating(false) + scoutSkill);

        int normalizedPS = (peakStart - 27) * 2;
        int normalizedPE = (peakEnd - 30) * 2;

        int average = (normalizedPE + normalizedPS + development * 3) / 5;

        int temp = Math.Max(1, Math.Min(10, r.Next(-(scoutSkill/10), scoutSkill/10) + average));
        switch (temp)
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

        if (getOverall() < 40 && (playerAge > 30 || gamesPlayed == 0)) return retirements.Skill;

        double totalFactors = 0.0;

        double a = 1.6641;
        double b = 1.20185085;

        double ageRelatedFactors = a * Math.Pow(playerAge - 18, b);

        //85 - gamesStarted

       /* a = 0.95774384;
        b = 1.044120524;

        double gamesStartedFactors = (a * Math.Pow(85 - gamesPlayed, b) - 26) / 10;*/

        stamina = 100;

        a = 0.909748899;
        b = 1.099204408;
        double overallRatedFactors = a * Math.Pow(85 - getOverall(null), b) - 21;

        

        totalFactors = ageRelatedFactors + overallRatedFactors;

        int num = r.Next(30, 100);

        if (num < totalFactors)
        { 
            return retirements.Personal; 
        }
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
    public double getLayupRating(bool game = true)
    {
        //if (name.Equals("Atakri Kalauni")) Console.WriteLine(((ratings[0] + shootingModifier) * getStamina() / 100 )+ " " + ((ratings[0] * getStamina() / 100)));
        if (game) return (ratings[0] / 10 + shootingModifier) * getStamina() / 100;
        else return ratings[0];
    }
    private void setLayupRating(int rating)
    {
        this.ratings[0] = rating;
    }
    public double getDunkRating(bool game = true)
    {
        if (game)
            return (ratings[1] / 10 + shootingModifier) * getStamina() / 100;
        else
            return ratings[1];
    }
    private void setDunkRating(int rating)
    {
        this.ratings[1] = rating;
    }
    public double getJumpShotRating(bool game = true)
    {
        if (game)
            return (ratings[2] / 10 + shootingModifier) * getStamina() / 100;
        else return ratings[2];
    }
    private void setJumpShotRating(int rating)
    {
        
        this.ratings[2] = rating;
    }
    public double getShotContestRating(bool game = true)
    {
        if (game)
            return (ratings[3] / 10 + defensiveModifier) * getStamina() / 100;
        else
            return ratings[3]; 
    }
    private void setShotContestRating(int rating)
    {
        this.ratings[3] = rating;
    }
    public double getDefenseIQRating(bool game = true)
    {
        if (game)
            return (ratings[4] / 10 + defensiveModifier) * getStamina() / 100;
        else return ratings[4];
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
    public double getJumpingRating(bool game = true)
    {
        if (game)
            return (ratings[5] / 10 + otherModifier) * getStamina() / 100;
        else return ratings[5];
    }
    private void setJumpingRating(int rating)
    {
        this.ratings[5] = rating;
    }
    public double getSeperation(bool game = true)
    {
        if (game)
            return (ratings[6] / 10 + otherModifier) * getStamina() / 100;
        else return ratings[6];
    }
    private void setSeperation(int rating)
    {
        this.ratings[6] = rating;
    }
    public double getPassing(bool game = true)
    {
        if (game)
            return (ratings[7] / 10 + otherModifier) * getStamina() / 100;
        else return ratings[7];
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
    public double getStaminaRating(bool game = true)
    {
        if (game) return ratings[8] / 10;
        else return ratings[8];
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
    private team previousTeam;
    public void setTeam(team team)
    {
        if(this.team != null)
            previousTeam = this.team;
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
    public double GetBonus()
    {
        return contract.GetBonus();
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
    public double getThreeShotRating(bool game = true)
    {
        if (game)
            return (ratings[9] / 10 + shootingModifier) * getStamina() / 100;
        else return ratings[9];
    }
    private void setThreeShotRating(int rating)
    {
        this.ratings[9] = rating;
    }
    public double getDurabilityRating(bool game = true)
    {
        if (game) return ratings[10] / 10;
        else return ratings[10];
    }
    private void setDurabilityRating(int rating)
    {
        this.ratings[10] = rating;
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if(this is CollegePlayer || obj is CollegePlayer)
        {
            CollegePlayer player = obj as CollegePlayer;
            if (player == null) return false;
            if (this.name.Equals(player.name))
            {
                for(int i = 0; i < ratings.Length; i++)
                {
                    if (ratings[i] != player.ratings[i]) return false;
                }
                return true;
            }
        }
        else if(obj is player)
        {
            player other = obj as player;
            if (playerID == other.GetPlayerID()) return true;
        }
        return false;
    }
    public int CompareTo(player other)
    {

        if (this.getOverall() - other.getOverall() > 0) return 1;
        else if (other.getOverall() - this.getOverall() > 0) return -1;
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
    /*
     * 0: Inside
     * 1: Jump
     * 7: Three Point
     * 6: Passing
     * 2: Shot Contest
     * 3: Defense IQ
     * 4: Jumping
     * 5: Seperation
     * 8: Stamina
     */
    /*
* Ratings: 
* 
* 
* collegeProbabilties[1] = inside
* collegeProbabilties[2] = jumpshot
* collegeProbabilties[3] = shot contest
* collegeProbabilties[4] = defense iq
* collegeProbabilties[5] = jumping
* collegeProbabilties[6] = seperation
* collegeProbabilties[7] = passing
* collegeProbabilties[8] = threepoint
*/
    public static double getOverall(int pos, int[] rating)
    {
        double retVal = 0.0;
        if (pos == 1)
        {
            retVal += rating[0] * 14;
            retVal += rating[1] * 10;
            retVal += rating[7] * 7;
            retVal += rating[6] * 6;
            retVal += rating[2] * 14;
            retVal += rating[3] * 14;
            retVal += rating[4] * 14;
            retVal += rating[5] * 16;
            retVal += rating[8] * 5;

        }
        // 8
        else if (pos == 2)
        {
            retVal += rating[0] * 14;
            retVal += rating[1] * 11;
            retVal += rating[7] * 6;
            retVal += rating[6] * 6;
            retVal += rating[2] * 14;
            retVal += rating[3] * 14;
            retVal += rating[4] * 15;
            retVal += rating[5] * 16;
            retVal += rating[8] * 5;

        }
        // 9
        else if (pos == 3)
        {
            retVal += rating[0] * 13;
            retVal += rating[1] * 12;
            retVal += rating[7] * 10;
            retVal += rating[6] * 10;
            retVal += rating[2] * 12;
            retVal += rating[3] * 12;
            retVal += rating[4] * 10;
            retVal += rating[5] * 16;
            retVal += rating[8] * 5;
        }
        else if (pos == 4)
        {
            retVal += rating[0] * 12;
            retVal += rating[1] * 14;
            retVal += rating[7] * 14;
            retVal += rating[6] * 11;
            retVal += rating[2] * 10.5;
            retVal += rating[3] * 10.5;
            retVal += rating[4] * 7;
            retVal += rating[5] * 15;
            retVal += rating[8] * 5;
        }
        else
        {
            retVal += rating[0] * 12;
            retVal += rating[1] * 12;
            retVal += rating[7] * 12;
            retVal += rating[6] * 15;
            retVal += rating[2] * 13;
            retVal += rating[3] * 13;
            retVal += rating[4] * 6;
            retVal += rating[5] * 10;
            retVal += rating[8] * 5;
        }

        retVal = Math.Min(99.99, ((retVal / 10) / 90) * 100);

        return retVal;

    }
    public double getOverall(player player = null, bool developmentIncluded = false)
    {
        if (player == null) player = this;
        double inside = Math.Max(player.ratings[0], player.ratings[1])/10;
        double retVal = 0;
        // 8.7
        if (player.position == 1)
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
        else if (player.position == 2)
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
        else if (player.position == 3)
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
        else if (player.position == 4)
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
[Serializable]
public enum Promises
{    
   Year_One_Starter, Win_Division, Win_Conference, Win_Championship, Make_Playoffs, No_Trade
    
}