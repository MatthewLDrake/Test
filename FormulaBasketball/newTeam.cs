using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormulaBasketball
{
    [Serializable]
    public class NewTeam : IEnumerable<NewPlayer>, IComparable<NewTeam>
    {
        private List<NewPlayer> players, activePlayers;
        private List<Tuple<NewPlayer, int, int>> sevenDayInjury, fifteenInjury;
        private List<Tuple<NewPlayer, int>> injuredPlayers, seasonInjury;
        private NewRealCoach realCoach, offensiveAssistant, defensiveAssistant;
        private sbyte teamNum, streak, fanInterest;
        private string teamName;
        private byte playoffSeed, wins, losses, interviewNumber;
        private int pointsFor, pointsAgainst;
        private Dictionary<sbyte, Tuple<byte, byte, int, int>> teamDictionary;
        private List<NewDraftPick> currentSeasonPicks, nextSeasonPicks;
        private List<bool> lastTen;
        private List<Tuple<uint, int, List<Object>, List<Object>, string, string>> trades, offeredTrades;
        private long money, changeMoney;
        private GeneralManager generalManager, scout;
        private NewStadium stadium;
        public NewTeam(team oldStyle)
        {
            teamNum = (sbyte)oldStyle.getTeamNum();
            teamName = oldStyle.ToString();

            players = new List<NewPlayer>();
            foreach (player p in oldStyle)
            {
                players.Add(new NewPlayer(p));
                players[players.Count - 1].SetTeam(teamNum);
            }
            //coach = new NewCoach(oldStyle.ToString() + " Coach", new BalancedOffense(), new BalancedDefense(), new OverallPersonnel());
            //coach = new NewCoach(oldStyle.getCoach());
            activePlayers = new List<NewPlayer>();
            sevenDayInjury = new List<Tuple<NewPlayer, int, int>>();
            fifteenInjury = new List<Tuple<NewPlayer, int, int>>();
            injuredPlayers = new List<Tuple<NewPlayer, int>>();
            seasonInjury = new List<Tuple<NewPlayer, int>>();

            if (oldStyle.moreImportantTeam)
            {
                currentSeasonPicks = new List<NewDraftPick>();
                nextSeasonPicks = new List<NewDraftPick>();
                foreach (DraftPick pick in oldStyle.GetPicks())
                {
                    currentSeasonPicks.Add(new NewDraftPick(9, (byte)pick.GetRound(), (byte)pick.FromTeam(), (byte)teamNum));
                }
                foreach (DraftPick pick in oldStyle.GetNextSeasonPicks())
                {
                    nextSeasonPicks.Add(new NewDraftPick(10, (byte)pick.GetRound(), (byte)pick.FromTeam(), (byte)teamNum));
                }
            }
            lastTen = new List<bool>();
        }
        private Sponsor[] sponsors;
        public Sponsor[] GetSponsors()
        {
            return sponsors;
        }
        public void SetSponsor(int spot, Sponsor newSponsor)
        {
            sponsors[spot] = newSponsor;
        }
        private List<Sponsor> offeredSponsors;
        public List<Sponsor> GetOfferedSponsors()
        {
            if (offeredSponsors == null)
            {
                offeredSponsors = new List<Sponsor>();

                while(offeredSponsors.Count < 3)
                {
                    Sponsor temp;
                    switch(offeredSponsors.Count)
                    {
                        case 0:
                            temp = new Sponsor(teamNum, League.r, false, 1, League.r.Next(5, 11), League.r.Next(300,350) / 10.0, League.r.Next(100, 150)/10.0, false);
                            break;
                        case 1:
                            temp = new Sponsor(teamNum, League.r, false, 1, League.r.Next(2, 6), League.r.Next(150, 200) / 10.0, League.r.Next(50, 150) / 10.0, false);
                            break;
                        case 2:
                            temp = new Sponsor(teamNum, League.r, League.r.Next(5) == 2, 1, League.r.Next(3, 8), League.r.Next(10, 20) / 10.0, League.r.Next(50, 100) / 10.0, true);
                            break;
                        default:
                            continue;
                    }
                    bool flag = false;
                    foreach(Sponsor sponsor in offeredSponsors)
                    {
                        if (sponsor.GetName().Equals(temp.GetName()))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                        offeredSponsors.Add(temp);                   
                    
                }
                while (offeredSponsors.Count < 6)
                {
                    Sponsor temp;
                    switch (offeredSponsors.Count)
                    {
                        case 3:
                            temp = new Sponsor(teamNum, League.r, true, 2, League.r.Next(2, 8), League.r.Next(10, 25) / 10.0, League.r.Next(10, 15) / 10.0, false);
                            break;
                        case 4:
                            temp = new Sponsor(teamNum, League.r, true, 3, League.r.Next(2, 8), League.r.Next(10, 50) / 10.0, League.r.Next(5, 15) / 10.0, false);
                            break;
                        case 5:
                            temp = new Sponsor(teamNum, League.r, true, League.r.NextBool() ? 2 : 3, League.r.Next(5, 11), League.r.Next(175, 225) / 10.0, 0, false);
                            break;
                        default:
                            continue;
                    }
                    bool flag = false;
                    foreach (Sponsor sponsor in offeredSponsors)
                    {
                        if (sponsor.GetName().Equals(temp.GetName()))
                        {
                            flag = true;
                            break;
                        }
                    }
                    if (!flag)
                        offeredSponsors.Add(temp);

                }

                // TODO: Give offered sponsors
            }
            return offeredSponsors;
        }

        public void SetFanInterest(sbyte fanInterest)
        {
            this.fanInterest = fanInterest;
        }
        public sbyte GetFanInterest()
        {
            return fanInterest;
        }
        public NewStadium GetStadium()
        {
            return stadium;
        }
        private int capacityUpgrade, concessionsUpgrade, souvenirsUpgrade;
        private string concessionTypeUpgrade;
        public string UpgradeCapacity(int capacity)
        {
            int price = stadium.GetCapacityPrice(capacity);
            capacityUpgrade = capacity;
            return "Are you sure you want to spend " + string.Format("${0:n0}", price) + " on upgrading the capacity to level " + capacity + "? This is not a guarantee that if you confirm this upgrade it will go through, you may not have enough money or upgrade slots.";
        }
        public string UpgradeConcessions(int concessions)
        {
            int price = stadium.GetConcessionPrice(concessions);
            concessionsUpgrade = concessions;
            return "Are you sure you want to spend " + string.Format("${0:n0}", price) + " on upgrading the concessions to level " + concessions + "? This is not a guarantee that if you confirm this upgrade it will go through, you may not have enough money or upgrade slots.";
        }
        public string UpgradeSouvenirs(int souvenirs)
        {
            int price = stadium.GetSouvenirPrice(souvenirs);
            souvenirsUpgrade = souvenirs;
            return "Are you sure you want to spend " + string.Format("${0:n0}", price) + " on the upgrading the capacity to level " + souvenirs + "? This is not a guarantee that if you confirm this upgrade it will go through, you may not have enough money or upgrade slots.";
        }
        public string UpgradeConcessionsTypes(string concessionTypes)
        {
            string[] arr = concessionTypes.Split(',');
            concessionTypeUpgrade = concessionTypes;
            int price = stadium.GetConcessionPurchasePrice(arr.Length);

            string list = "";

            foreach(string str in arr)
            {
                list += stadium.ConcessionPurchases(int.Parse(str)) + ", ";
            }
            list = list.Remove(list.Length - 2, 2);

            return "Are you sure you want to spend " + string.Format("${0:n0}", price) + " on purchasing " + arr.Length + " additional concession types? Here are the types you would purchase: "+ list + ". This is not a guarantee that if you confirm this upgrade it will go through, you may not have enough money or upgrade slots.";
        }
        public string ConfirmCapacity()
        {
            if (capacityUpgrade == 0)
                return "There is no upgrade pending";

            int price = stadium.GetCapacityPrice(capacityUpgrade);

            if (price > money)
                return "You don't have enough money for this upgrade";

            int returnCode = stadium.UpgradeCapacity(capacityUpgrade);            

            switch(returnCode)
            {
                default:
                    money -= price;
                    return "Upgrade started!";
                case 1:
                    return "There is already a capacity upgrade in progress.";
                case 2:
                    return "You do not have enough upgrades available to upgrade the capacity of your stadium";
                case 3:
                    return "You are either already at this upgrade level, or are above it.";
            }

        }
        public string ConfirmConcessions()
        {
            if (concessionsUpgrade == 0)
                return "There is no upgrade pending";

            int price = stadium.GetConcessionPrice(concessionsUpgrade);
            if (price > money)
                return "You don't have enough money for this upgrade";
            int returnCode = stadium.UpgradeConcessionStyle(concessionsUpgrade);

            switch (returnCode)
            {
                default:
                    money -= price;
                    return "Upgrade started!";
                case 1:
                    return "There is already a concession upgrade in progress.";
                case 2:
                    return "You do not have enough upgrades available to upgrade the concession style of your stadium";
                case 3:
                    return "You are either already at this upgrade level, or are above it.";
            }

        }
        public double GetExpenses()
        {
            return 8500000;
        }
        public string ConfirmSouvenirs()
        {
            if (souvenirsUpgrade == 0)
                return "There is no upgrade pending";

            int price = stadium.GetSouvenirPrice(souvenirsUpgrade);
            if (price > money)
                return "You don't have enough money for this upgrade";
            int returnCode = stadium.UpgradeSouvenirShops(souvenirsUpgrade);

            

            switch (returnCode)
            {
                default:
                    money -= price;
                    return "Upgrade started!";
                case 1:
                    return "There is already a concession upgrade in progress.";
                case 2:
                    return "You do not have enough upgrades available to upgrade the concession style of your stadium";
                case 3:
                    return "You are either already at this upgrade level, or are above it.";
            }

        }
        public string ConfirmConcessionTypes()
        {
            if (concessionTypeUpgrade.Equals(""))
                return "There is no upgrade pending";

            string[] arr = concessionTypeUpgrade.Split(',');
            
            int price = stadium.GetConcessionPurchasePrice(arr.Length);

            if (price > money)
                return "You don't have enough money for this upgrade";

            if (stadium.GetUpgradesInProgress() + arr.Length > stadium.GetMaxUpgrades())
                return "You do not have enough upgrades available to add " + arr.Length + " concessions";
            else
            {
                foreach(string str in arr)
                {
                    if (stadium.GetConcessionStatus(int.Parse(str)))
                        return "You already have " + stadium.ConcessionPurchases(int.Parse(str));
                }
            }

            foreach (string str in arr)
            {
                stadium.UpgradeConcession(int.Parse(str));
                   
            }
            money -= price;

            return "You have upgraded concessions.";
        }
        public string CancelConcessionTypes()
        {
            if (concessionTypeUpgrade.Equals(""))
                return "Nothing to cancel";
            concessionTypeUpgrade = "";
            return "Successfully canceled concession type upgrade.";
        }
        public string CancelCapacity()
        {
            if (capacityUpgrade == 0)
                return "Nothing to cancel";
            capacityUpgrade = 0;
            return "Successfully canceled capacity upgrade.";
        }
        public string CancelSouvenirs()
        {
            if (souvenirsUpgrade == 0)
                return "Nothing to cancel";
            souvenirsUpgrade = 0;
            return "Successfully canceled souvenir upgrade.";
        }
        public string CancelConcessions()
        {
            if (concessionsUpgrade == 0)
                return "Nothing to cancel";
            concessionsUpgrade = 0;
            return "Successfully canceled concessions upgrade.";
        }
        public void AddPotentialTrade(Tuple<uint, int, List<Object>, List<Object>, string, string> trade)
        {
            if (trades == null)
                trades = new List<Tuple<uint, int, List<object>, List<object>, string, string>>();

            foreach(Tuple<uint, int, List<object>, List<object>, string, string> tuple in trades)
            {
                if(tuple.Item1 == trade.Item1)
                {
                    trades.Remove(tuple);
                    break;
                }
            }

            trades.Add(trade);
        }
        public void OfferTrade(Tuple<uint, int, List<Object>, List<Object>, string, string> trade)
        {
            if (offeredTrades == null)
                offeredTrades = new List<Tuple<uint, int, List<object>, List<object>, string, string>>();
            offeredTrades.Add(trade);
        }
        public double GetMoneyInMillions()
        {
            return money / 1000000.0;
        }
        public double GetMoney()
        {
            return money;
        }
        public double GetChangeMoneyInMillions()
        {
            return changeMoney / 1000000.0;
        }
        public double GetChangeMoney()
        {
            return changeMoney;
        }
        public void ChangeMoney(long money)
        {
            this.money += money;
            changeMoney = money;
        }
        
        public void SetMoney(long money)
        {
            this.money = money;
        }
        public void ResetInterviewNumber()
        {
            interviewNumber = 5;
        }
        public bool CanInterview()
        {
            return (interviewNumber > 0);            
        }
        public string Interview(NewRealCoach coach)
        {
            string retVal = "```This coach's name is " + coach.ToString() + "\n"; // TODO: add head coaching experience

            Random r = League.r;

            int num = r.Next(5);

            string temp = InterviewResult(Math.Max(1, Math.Min(10, (int)Math.Round(r.NextDoubleGaussian(coach.GetDevelopmentSkillForPosition(num + 1), .75))))) + "\n";

            switch(num)
            {
                default:
                    retVal += "We asked about the development of centers and " + temp;
                    break;
                case 1:
                    retVal += "We asked about the development of power forwards and " + temp;
                    break;
                case 2:
                    retVal += "We asked about the development of small forwards and " + temp;
                    break;
                case 3:
                    retVal += "We asked about the development of shooting guards and " + temp;
                    break;
                case 4:
                    retVal += "We asked about the development of point guards and " + temp;
                    break;
            }

            num = r.Next(10);

            temp = InterviewResult(Math.Max(1, Math.Min(10, (int)Math.Round(r.NextDoubleGaussian(coach.GetMaxRatingBoosts(num), .75))))) + "\n";

            switch (num)
            {
                default:
                    retVal += "We asked about how to improve inside scoring and " + temp;
                    break;
                case 1:
                    retVal += "We asked about how to improve jump shots and " + temp;
                    break;
                case 2:
                    retVal += "We asked about how to improve three pointers and " + temp;
                    break;
                case 3:
                    retVal += "We asked about how to improve offensive iq and " + temp;
                    break;
                case 4:
                    retVal += "We asked about how to improve defensive iq and " + temp;
                    break;
                case 5:
                    retVal += "We asked about how to improve shot contesting and " + temp;
                    break;
                case 6:
                    retVal += "We asked about how to improve jumping and " + temp;
                    break;
                case 7:
                    retVal += "We asked about how to improve seperation and " + temp;
                    break;
                case 8:
                    retVal += "We asked about how to improve passing and " + temp;
                    break;
                case 9:
                    retVal += "We asked about how to improve stamina and " + temp;
                    break;
            }

            num = r.Next(6);

            temp = InterviewResult(Math.Max(1, Math.Min(10, (int)Math.Round(r.NextDoubleGaussian(coach.GetSkill(num), .75))))) + "\n";

            switch (num)
            {
                default:
                    retVal += "We asked about how to improve early games and " + temp;
                    break;
                case 1:
                    retVal += "We asked about how to extend leads and " + temp;
                    break;
                case 2:
                    retVal += "We asked about how to make comebacks and " + temp;
                    break;
                case 3:
                    retVal += "We asked about how to close out games and " + temp;
                    break;
                case 4:
                    retVal += "We asked about how to do well in clutch basketball situations and " + temp;
                    break;
                case 5:
                    retVal += "We asked about how to they used drills to make players better and " + temp;
                    break;                
            }

            interviewNumber--;
            return retVal + "```";
        }
        private string InterviewResult(int num)
        {
            if (League.r.Next(10) == 3)
                return " we could not get a good grasp on their knowledge of this subject.";
            switch(num)
            {
                default:
                    return " they were seemingly oblivous to the fact that this was a part of being a basketball coach.";
                case 2:
                    return " they rambled about how they would go about handling this aspect of being a basketball coach with no direction.";
                case 3:
                    return " they realized that this was a part of basketball, but they clearly had no plan.";
                case 4:
                    return " they had a plan, but it seemed poorly thought out and might not work";
                case 5:
                    return " they had a decent, average plan for this.";
                case 6:
                    return " they showed they clearly understood the concept, and handled all the basics excellently";
                case 7:
                    return " they clearly understood the concept, and had the basics mastered, and had some unique ideas on how to handle it.";
                case 8:
                    return " they impressed us with in depth knowledge on this concept.";
                case 9:
                    return " they amazed us with their response, and had a plan that was specific for our team";
                case 10:
                    return " it seemed like they were perfect in every way about this topic.";
            }
        }
        public bool RejectTrade(uint tradeID)
        {
            foreach (Tuple<uint, int, List<Object>, List<Object>, string, string> trade in offeredTrades)
            {
                if (trade.Item1 == tradeID)
                {
                    offeredTrades.Remove(trade);
                    return true;
                }
            }
            return false;
        }
        public bool CancelTrade(uint tradeID)
        {
            foreach (Tuple<uint, int, List<Object>, List<Object>, string, string> trade in trades)
            {
                if (trade.Item1 == tradeID)
                {
                    trades.Remove(trade);
                    return true;
                }
            }
            return false;
        }
        public void SetTeamNum(int teamNum)
        {
            this.teamNum = (sbyte)teamNum;
        }
        public Tuple<uint, int, List<Object>, List<Object>, string, string> GetOfferedTrade(uint tradeID)
        {
            foreach (Tuple<uint, int, List<Object>, List<Object>, string, string> trade in offeredTrades)
            {
                if (trade.Item1 == tradeID)
                    return trade;
            }

            return null;
        }
        public Tuple<uint, int, List<Object>, List<Object>, string, string> GetTrade(uint tradeID)
        {
            foreach(Tuple<uint, int, List<Object>, List<Object>, string, string> trade in trades)
            {
                if (trade.Item1 == tradeID)
                    return trade;
            }

            return null;
        }
        public void ChangeName(string newName)
        {
            teamName = newName;
        }
        public void AddAssistantCoaches(GeneralManager generalManager, string offensiveAssistant = null, string defensiveAssistant = null, GeneralManager scout = null)
        {
            NameGenerator nameGenerator = NameGenerator.Instance();          
            
            this.offensiveAssistant = new NewRealCoach(offensiveAssistant ?? nameGenerator.GenerateName(realCoach.GetCountry()), realCoach.GetCountry(), realCoach.GetOffense(), CoachHelper.GenerateDefense(), CoachHelper.GeneratePersonnel(), CoachHelper.GeneratePersonality(), League.r.Next(30, 70), (int)League.league.coachID++, CoachHelper.GenerateDevelopmentRating(), CoachHelper.GenerateSkillRating(), CoachHelper.GenerateMaxRatingBoost());
                        
            this.defensiveAssistant = new NewRealCoach(defensiveAssistant ?? nameGenerator.GenerateName(realCoach.GetCountry()), realCoach.GetCountry(), CoachHelper.GenerateOffense(), realCoach.GetDefense(), CoachHelper.GeneratePersonnel(), CoachHelper.GeneratePersonality(), League.r.Next(30, 70), (int)League.league.coachID++, CoachHelper.GenerateDevelopmentRating(), CoachHelper.GenerateSkillRating(), CoachHelper.GenerateMaxRatingBoost());

            this.offensiveAssistant.SetTeam(new Contract(League.r.Next(1, realCoach.GetContract().GetYearsLeft()), .25), teamNum);
            this.defensiveAssistant.SetTeam(new Contract(League.r.Next(1, realCoach.GetContract().GetYearsLeft()), .25), teamNum);

            this.generalManager = generalManager;

            if (scout == null)
                this.scout = new GeneralManager(realCoach.GetCountry());
            else
                this.scout = scout;
        }
        public NewRealCoach GetOffensiveAssistant()
        {
            return offensiveAssistant;
        }
        public NewRealCoach GetDefensiveAssistant()
        {
            return defensiveAssistant;
        }
        public GeneralManager GetGeneralManager()
        {
            return generalManager;
        }
        public void RemoveCoach(object coach)
        {
            if (realCoach != null && realCoach.Equals(coach))
            {
                realCoach = null;
                (coach as NewRealCoach).SetTeam(null, -1);
            }
            else if (offensiveAssistant != null && offensiveAssistant.Equals(coach))
            {
                offensiveAssistant = null;
                (coach as NewRealCoach).SetTeam(null, -1);
            }
            else if (defensiveAssistant != null && defensiveAssistant.Equals(coach))
            {
                defensiveAssistant = null;
                (coach as NewRealCoach).SetTeam(null, -1);
            }
            else if (generalManager != null && generalManager == coach)
                generalManager = null;
            else if (scout != null && scout == coach)
                scout = null;

            
        }
        public GeneralManager GetScout()
        {
            return scout;
        }
        public void HireCoach(object coach, int spot)
        {
            if (spot == 0)
                realCoach = coach as NewRealCoach;
            else if (spot == 1)
                offensiveAssistant = coach as NewRealCoach;
            else if (spot == 2)
                defensiveAssistant = coach as NewRealCoach;
            else if (spot == 3)
                generalManager = coach as GeneralManager;
            else if (spot == 4)
                scout = coach as GeneralManager;
        }
        public void FireCoach(int spot)
        {
            if (spot == 0)
                realCoach = null;
            else if (spot == 1)
                offensiveAssistant = null;
            else if (spot == 2)
                defensiveAssistant = null;
            else if (spot == 3)
                generalManager = null;
            else if (spot == 4)
                scout = null;
        }
        public List<Object> GetAllCoaches(bool allowNull = false)
        {
            List<Object> retVal = new List<Object>();
            if (allowNull || realCoach != null)
                retVal.Add(realCoach);
            if (allowNull || offensiveAssistant != null)
                retVal.Add(offensiveAssistant);
            if (allowNull || defensiveAssistant != null)
                retVal.Add(defensiveAssistant);
            if (allowNull || generalManager != null)
                retVal.Add(generalManager);
            if (allowNull || scout != null)
                retVal.Add(scout);

            return retVal;
        }
        public void AddItems(List<Object> receiving, List<Object> sending)
        {
            foreach(Object obj in receiving)
            {
                if(obj is NewPlayer)
                {
                    AddPlayer(obj as NewPlayer);
                }
                else if(obj is double)
                {
                    money += (long)Math.Round((double)obj * 1000000);
                }
                else
                {
                    NewDraftPick pick = obj as NewDraftPick;
                    if (League.seasonNum + 1 == pick.GetSeason())
                        currentSeasonPicks.Add(pick);
                    else
                        nextSeasonPicks.Add(pick);

                    pick.SetOwner((byte)teamNum);
                }
            }
            foreach(Object obj in sending)
            {
                if (obj is NewPlayer)
                {
                    RemovePlayer(obj as NewPlayer, false);
                }
                else if (obj is double)
                {
                    money -= (long)Math.Round((double)obj * 1000000);
                }
                else
                {
                    NewDraftPick pick = obj as NewDraftPick;

                    foreach (NewDraftPick picks in currentSeasonPicks)
                    {
                        if (pick.GetSeason() == picks.GetSeason() && pick.GetRound() == picks.GetRound() && pick.GetTeam() == picks.GetTeam())
                        {
                            currentSeasonPicks.Remove(picks);
                            break;
                        }
                    }
                    foreach (NewDraftPick picks in nextSeasonPicks)
                    {
                        if (pick.GetSeason() == picks.GetSeason() && pick.GetRound() == picks.GetRound() && pick.GetTeam() == picks.GetTeam())
                        {
                            nextSeasonPicks.Remove(picks);
                            break;
                        }
                    }
                }
            }
        }
        public void AddCoach(NewRealCoach coach)
        {
            this.realCoach = coach;
        }
        public void UpdateTeam(string stadiumName = "")
        {
            foreach (NewPlayer p in players)
                p.SetTeam(teamNum);

            stadium = new NewStadium(stadiumName);
        }
        public void UpdatePicks()
        {
            currentSeasonPicks = new List<NewDraftPick>();
            nextSeasonPicks = new List<NewDraftPick>();
        }
        public void AddDraftPick(NewDraftPick pick)
        {
            if (pick.GetSeason() == League.seasonNum + 1)
            {
                currentSeasonPicks.Add(pick);
            }
            else
                nextSeasonPicks.Add(pick);
        }
        public Tuple<int, int, string> GetInjuryStatus(NewPlayer p)
        {
            foreach (Tuple<NewPlayer, int, int> player in sevenDayInjury)
            {
                if (p.GetPlayerID() == player.Item1.GetPlayerID())
                {
                    return new Tuple<int, int, string>(player.Item2, player.Item3, "7 Day");
                }
            }
            foreach (Tuple<NewPlayer, int, int> player in fifteenInjury)
            {
                if (p.GetPlayerID() == player.Item1.GetPlayerID())
                {
                    return new Tuple<int, int, string>(player.Item2, player.Item3, "15 Day");
                }
            }
            foreach (Tuple<NewPlayer, int> player in seasonInjury)
            {
                if (p.GetPlayerID() == player.Item1.GetPlayerID())
                {
                    return new Tuple<int, int, string>(player.Item2, 0, "Season");
                }
            }
            foreach (Tuple<NewPlayer, int> player in injuredPlayers)
            {
                if (p.GetPlayerID() == player.Item1.GetPlayerID())
                {
                    return new Tuple<int, int, string>(player.Item2, 0, "Injured");
                }
            }

            return new Tuple<int, int, string>(0, 0, "Healthy");
        }
        public void AddInjury(NewPlayer p, int injuryLength)
        {
            if (injuryLength < 6)
                injuredPlayers.Add(new Tuple<NewPlayer, int>(p, injuryLength));
            else if (injuryLength < 13)
                sevenDayInjury.Add(new Tuple<NewPlayer, int, int>(p, injuryLength, 7));
            else if (injuryLength < 84)
                fifteenInjury.Add(new Tuple<NewPlayer, int, int>(p, injuryLength, 15));
            else
                seasonInjury.Add(new Tuple<NewPlayer, int>(p, injuryLength));

            activePlayers.Remove(p);
        }
        public void AdvanceYear(bool dleague)
        {
            realCoach.AdvanceYear(new Record(wins, losses, dleague));
            offensiveAssistant.AdvanceYear(null);
            defensiveAssistant.AdvanceYear(null);
            
            foreach(NewPlayer p in players)
            {
                p.AdvanceYear();
            }

            wins = 0;
            losses = 0;

        }
        public void AdvanceInjuries()
        {
            List<NewPlayer> activePlayers = new List<NewPlayer>();
            List<Tuple<NewPlayer, int>> newInjuredPlayers = new List<Tuple<NewPlayer, int>>();
            List<Tuple<NewPlayer, int, int>> newSevenDay = new List<Tuple<NewPlayer, int, int>>();
            List<Tuple<NewPlayer, int, int>> newFifteenDay = new List<Tuple<NewPlayer, int, int>>();

            if(injuredPlayers == null)
            {
                injuredPlayers = new List<Tuple<NewPlayer, int>>();
                sevenDayInjury = new List<Tuple<NewPlayer, int, int>>();
                fifteenInjury = new List<Tuple<NewPlayer, int, int>>();
                seasonInjury = new List<Tuple<NewPlayer, int>>();
            }

            foreach (Tuple<NewPlayer, int> tuple in injuredPlayers)
            {
                if (tuple.Item2 <= 1)
                    activePlayers.Add(tuple.Item1);
                else
                    newInjuredPlayers.Add(new Tuple<NewPlayer, int>(tuple.Item1, tuple.Item2 - 1));
            }

            foreach(Tuple<NewPlayer, int, int> tuple in sevenDayInjury)
            {
                if (tuple.Item3 <= 1)
                {
                    if (tuple.Item2 <= 1)
                        activePlayers.Add(tuple.Item1);
                    else if (tuple.Item2 < 6)
                        newInjuredPlayers.Add(new Tuple<NewPlayer, int>(tuple.Item1, tuple.Item2 - 1));
                    else
                        newSevenDay.Add(new Tuple<NewPlayer, int, int>(tuple.Item1, tuple.Item2 - 1, 7));
                }
                else
                    newSevenDay.Add(new Tuple<NewPlayer,int, int>(tuple.Item1, tuple.Item2 - 1, tuple.Item3 - 1));
            }
            foreach (Tuple<NewPlayer, int, int> tuple in fifteenInjury)
            {
                if (tuple.Item3 <= 1)
                {
                    if (tuple.Item2 <= 1)
                        activePlayers.Add(tuple.Item1);
                    else if (tuple.Item2 < 6)
                        newInjuredPlayers.Add(new Tuple<NewPlayer, int>(tuple.Item1, tuple.Item2 - 1));
                    else if (tuple.Item2 < 13)
                        newSevenDay.Add(new Tuple<NewPlayer, int, int>(tuple.Item1, tuple.Item2 - 1, 7));
                    else
                        newFifteenDay.Add(new Tuple<NewPlayer, int, int>(tuple.Item1, tuple.Item2 - 1, 15));
                }
                else
                    newSevenDay.Add(new Tuple<NewPlayer, int, int>(tuple.Item1, tuple.Item2 - 1, tuple.Item3 - 1));
            }

            this.activePlayers = activePlayers;
            injuredPlayers = newInjuredPlayers;
            sevenDayInjury = newSevenDay;
            fifteenInjury = newFifteenDay;
        }
        public string ChangeOrder(int[] playerNums)
        {
            List<NewPlayer> newOrder = new List<NewPlayer>();

            foreach (int playerID in playerNums)
            {
                bool flag = false;
                foreach (NewPlayer p in players)
                {
                    if (p.GetPlayerID() == playerID)
                    {
                        newOrder.Add(p);
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    return "Couldn't find player ID: " + playerID;
                }
            }
            foreach (NewPlayer p in newOrder)
                players.Remove(p);

            foreach (NewPlayer p in players)
                newOrder.Add(p);

            players = newOrder;

            return "Successfully changed order.";
        }
        public void ClearPlayers()
        {
            players = new List<NewPlayer>();
        }
        public void AddPlayer(NewPlayer player)
        {
            players.Add(player);
            player.SetTeam(teamNum);

            activePlayers.Add(player);
        }
        public void RemovePlayer(NewPlayer player, bool setTeam = true)
        {
            foreach (NewPlayer p in players)
            {
                if (p.GetPlayerID() == player.GetPlayerID())
                {
                    players.Remove(p);
                    if(setTeam)
                        p.SetTeam(-1);
                    break;
                }
            }
        }
        public List<NewDraftPick> GetCurrentPicks()
        {
            return currentSeasonPicks;
        }
        public List<NewDraftPick> GetNextPicks()
        {
            return nextSeasonPicks;
        }
        public int GetWins()
        {
            return wins;
        }
        public int GetLosses()
        {
            return losses;
        }
        public sbyte GetTeamNum()
        {
            return teamNum;
        }
        public List<NewPlayer> GetActivePlayers()
        {
            return activePlayers;
        }
        public NewRealCoach GetCoach()
        {
            return realCoach;
        }
        public List<NewPlayer> GetPlayers()
        {
            return players;
        }
        public IEnumerator<NewPlayer> GetEnumerator()
        {
            return new PlayerEnum(players);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }
        public override string ToString()
        {
            return teamName;
        }
        public void SetSeed(int seed)
        {
            playoffSeed = (byte)seed;
        }
        public int GetSeed()
        {
            return playoffSeed;
        }
       
        public void SortPlayers()
        {
            activePlayers.Sort();
            players.Sort();
        }
        public int CompareTo(NewTeam other)
        {
            if(wins == other.wins)
            {
                if((pointsFor - pointsAgainst) == (other.pointsFor - other.pointsAgainst))
                {
                    return other.teamNum - teamNum;
                }
                return (other.pointsFor - other.pointsAgainst) - (pointsFor - pointsAgainst);
            }
            return other.wins - wins;
        }
        public int GetPointsFor()
        {
            int pointsFor = 0;
            foreach(KeyValuePair<sbyte, Tuple<byte, byte, int, int>> pair in teamDictionary)
            {
                pointsFor += pair.Value.Item3;
            }

            return pointsFor;
        }
        public int GetPointsAgainst()
        {
            int pointsAgainst = 0;
            foreach (KeyValuePair<sbyte, Tuple<byte, byte, int, int>> pair in teamDictionary)
            {
                pointsAgainst += pair.Value.Item4;
            }

            return pointsAgainst;
        }
        public int GetPointDifferential()
        {
            return pointsFor - pointsAgainst;
        }
        public String GetStreak()
        {
            String retVal = "";
            if (streak > 0) retVal = "W";
            else retVal = "L";

            retVal += "" + Math.Abs(streak);


            return retVal;
        }
        public String GetLastTen()
        {
            if(lastTen == null)
                lastTen = new List<bool>();
            int wins = 0, losses = 0;
            for (int i = 0; i < lastTen.Count; i++)
            {
                if (lastTen[i]) wins++;
                else losses++;
            }
            return wins + " - " + losses;
        }
        
        public void FinishGame(int score, int opponentScore, sbyte opposingTeam, bool playoffs)
        {
            if (!playoffs)
            {
                if (teamDictionary == null)
                {
                    teamDictionary = new Dictionary<sbyte, Tuple<byte, byte, int, int>>();
                    if(lastTen == null)
                        lastTen = new List<bool>();
                    
                }
                if (!teamDictionary.ContainsKey(opposingTeam))
                    teamDictionary.Add(opposingTeam, new Tuple<byte, byte, int, int>(0, 0, 0, 0));

                pointsFor += score;
                pointsAgainst += opponentScore;

                wins += (byte)(score > opponentScore ? 1 : 0);
                losses += (byte)(score < opponentScore ? 1 : 0);

                if (streak > 0 && score > opponentScore) streak++;
                else if (streak < 0 && score < opponentScore) streak--;
                else if (score < opponentScore) streak = -1;
                else streak = 1;

                if (lastTen.Count == 10)
                    lastTen.RemoveAt(0);

                lastTen.Add(score > opponentScore);

                teamDictionary[opposingTeam] = new Tuple<byte, byte, int, int>((byte)((score > opponentScore ? 1 : 0) + teamDictionary[opposingTeam].Item1), (byte)((score < opponentScore ? 1 : 0) + teamDictionary[opposingTeam].Item2), score + teamDictionary[opposingTeam].Item3, opponentScore + teamDictionary[opposingTeam].Item4);
            }
            foreach(NewPlayer p in this)
            {
                p.EndGame();                
            }
            AdvanceInjuries();
        }
        public void AddResult(int score, int opponentScore, sbyte opposingTeam, bool homeGame, bool playoffs)
        {
            if (!playoffs)
            {
                if (teamDictionary == null)
                {
                    teamDictionary = new Dictionary<sbyte, Tuple<byte, byte, int, int>>();
                    if (lastTen == null)
                        lastTen = new List<bool>();

                }
                if (!teamDictionary.ContainsKey(opposingTeam))
                    teamDictionary.Add(opposingTeam, new Tuple<byte, byte, int, int>(0, 0, 0, 0));

                pointsFor += score;
                pointsAgainst += opponentScore;

                wins += (byte)(score > opponentScore ? 1 : 0);
                losses += (byte)(score < opponentScore ? 1 : 0);

                if (streak > 0 && score > opponentScore) streak++;
                else if (streak < 0 && score < opponentScore) streak--;
                else if (score < opponentScore) streak = -1;
                else streak = 1;

                if (lastTen.Count == 10)
                    lastTen.RemoveAt(0);

                lastTen.Add(score > opponentScore);

                teamDictionary[opposingTeam] = new Tuple<byte, byte, int, int>((byte)((score > opponentScore ? 1 : 0) + teamDictionary[opposingTeam].Item1), (byte)((score < opponentScore ? 1 : 0) + teamDictionary[opposingTeam].Item2), score + teamDictionary[opposingTeam].Item3, opponentScore + teamDictionary[opposingTeam].Item4);
            }
            foreach (NewPlayer p in this)
            {
                p.EndGame();
            }
            // TODO: stadium
            if (homeGame)
            {
                Tuple<int, double> tuple = stadium.HostGame(fanInterest, League.league.GetTeam(opposingTeam).fanInterest, playoffs, League.r);
            }

            AdvanceInjuries();
        }



        public String GetThreeLetters()
        {
            if(teamName.StartsWith("Hol"))
            {
                string[] words = teamName.Split(' ');
                if (words.Length == 3)
                    return ("" + words[0][0] + words[1][0] + words[2][0]).ToUpper();
                else
                    return words[1].Substring(0, 3).ToUpper();
            }
            return teamName.Substring(0, 3).ToUpper();
        }
        public string GetRecordAgainst(int teamNum)
        {
            if (teamDictionary.ContainsKey((sbyte)teamNum))
                return "" + teamDictionary[(sbyte)teamNum].Item1 + " - " + teamDictionary[(sbyte)teamNum].Item2;
            else
                return "0 - 0";
        }
        private int seasons, places, championships, mostWins, leastWins = int.MaxValue, topResult, worstResult, totalWins, lastPlace;
        public int GetBestPlace()
        {
            return mostWins;
        }
        public int GetWorstPlace()
        {
            return leastWins;
        }
        public int GetChampionships()
        {
            return championships;
        }
        public void PrintInfo(string eventName)
        {
            int averageWins = totalWins / seasons;
            string record = averageWins + "-" + (84 - averageWins);
            Console.WriteLine("event:" + eventName + ":In 1000 simulations, the " + teamName + " won " + championships + " championships, and ended with an average regular season record of " + record + ".");

            record = mostWins + "-" + (84 - mostWins);

            Console.WriteLine("event:" + eventName + ":Their best season was a  " + record + " campaign, which ended in " + topResult + " place.");

            record = leastWins + "-" + (84 - leastWins);

            Console.WriteLine("event:" + eventName + ":Their worst season was a  " + record + " campaign, which ended in " + worstResult + " place.");
        }
        public void EndPlayoffs(int endPlace)
        {
            if (endPlace == 1)
                championships++;

            if (wins > mostWins || (wins == mostWins && endPlace < topResult))
            {
                mostWins = wins;
                topResult = endPlace;
            }

            if (wins < leastWins || (wins == leastWins && endPlace > worstResult))
            {
                leastWins = wins;
                worstResult = endPlace;
            }

            totalWins += wins;

            wins = 0;
            losses = 0;
            pointsAgainst = 0;
            pointsFor = 0;
            streak = 0;

            seasons++;
            places += endPlace;

            lastPlace = endPlace;
        }
        public int GetLastPlace()
        {
            if (lastPlace == 0)
                lastPlace = places;
            return lastPlace;
        }
        public void AdvancePicks()
        {
            currentSeasonPicks = nextSeasonPicks;
            nextSeasonPicks = new List<NewDraftPick>();
            nextSeasonPicks.Add(new NewDraftPick((byte)(League.seasonNum + 2), 1, (byte)teamNum, (byte)teamNum));
            nextSeasonPicks.Add(new NewDraftPick((byte)(League.seasonNum + 2), 2, (byte)teamNum, (byte)teamNum));
        }
        public void VerifyPicks(string[] picks)
        {
            currentSeasonPicks = new List<NewDraftPick>();
            nextSeasonPicks = new List<NewDraftPick>();
            foreach(string pick in picks)
            {
                string[] stats = pick.Split(',');
                int tempTeamNum = int.Parse(stats[0]);
                if (tempTeamNum == teamNum && int.Parse(stats[1]) == 10)                
                    currentSeasonPicks.Add(new NewDraftPick(10, byte.Parse(stats[2]), byte.Parse(stats[3]), (byte)teamNum));                
                else if(tempTeamNum == teamNum)
                    nextSeasonPicks.Add(new NewDraftPick(10, byte.Parse(stats[2]), byte.Parse(stats[3]), (byte)teamNum));
            }
        }
    }
    [Serializable]
    class PlayerEnum : IEnumerator<NewPlayer>
    {
        private List<NewPlayer> players;
        private int location = -1;
        public PlayerEnum(List<NewPlayer> players)
        {
            this.players = players;
        }

        public NewPlayer Current
        {
            get
            {
                try
                {
                    return players[location];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        object IEnumerator.Current { get { return Current; } }

        public void Dispose()
        {

        }

        public bool MoveNext()
        {
            location++;
            while (location < players.Count && players[location] == null) location++;
            return location < players.Count;
        }

        public void Reset()
        {
            location = -1;
        }
    }
    [Serializable]
    public class NewDraftPick
    {
        private byte season, round, team, owner;
        private uint player;
        public NewDraftPick(byte season, byte round, byte team, byte owner)
        {
            this.season = season;
            this.round = round;
            this.team = team;
            this.owner = owner;
        }
        public void SetPlayer(uint playerID)
        {
            player = playerID;
        }
        public int GetSeason()
        {
            return season;
        }
        public int GetRound()
        {
            return round;
        }
        public int GetTeam()
        {
            return team;
        }
        public int GetOwner()
        {
            return owner;
        }
        public void SetOwner(byte owner)
        {
            this.owner = owner;
        }
        public override string ToString()
        {
            return "P" + team + "R" + round + "S" + season;
        }
    }
}
