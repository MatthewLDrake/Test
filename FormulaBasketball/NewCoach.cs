using System;
using System.ComponentModel;

namespace FormulaBasketball
{
    [Serializable]
    public class NewRealCoach
    {
        private OffenseType offense;
        private DefenseType defense;
        private PersonnelType personnel;
        private Personality personality;
        private string name, skill, maxRatingBoost, development;
        private Country country;
        private Contract contract;
        private int teamNum, age, coachID;
        
        public NewRealCoach(string name, Country country, OffenseType offense, DefenseType defense, PersonnelType personnel, Personality personality, int age, int coachID, string development, string skill, string maxRatingBoost)
        {
            this.offense = offense;
            this.defense = defense;
            this.personnel = personnel;
            this.country = country;
            this.name = name;
            this.personality = personality;
            this.age = age;
            this.coachID = coachID;
            this.skill = skill;
            this.maxRatingBoost = maxRatingBoost;
            this.development = development;
        }
        public void SetTeam(Contract contract, int teamNum)
        {
            this.contract = contract;
            this.teamNum = teamNum;
        }
        public OffenseType GetOffense()
        {
            return offense;
        }
        public override string ToString()
        {
            return offense.ToString() + " " + defense.ToString() + Environment.NewLine + personnel.ToString() + " " + personality.ToString();
        }
    }
    public static class CoachHelper
    {
        public static NewPlayer[] GetStarters(NewTeam team, OffenseType offense)
        {
            switch(offense)
            {
                case OffenseType.BALANCED_OFFENSE:
                    return BalancedStarters(team);
                case OffenseType.BIG_BALL_OFFENSE:
                    return BigBallStarters(team);
                case OffenseType.PERIMETER_CENTRIC_OFFENSE:
                    return PerimeterCentricStarters(team);
                case OffenseType.PICK_OFFENSE:
                    return PickStarters(team);
                case OffenseType.PRINCETON_OFFENSE:
                    return PrincetonStarters(team);
                case OffenseType.SEVEN_SECOND_OFFENSE:
                    return SevenSecondStarters(team);
                case OffenseType.SMALL_BALL_OFFENSE:
                    return SmallBallStarters(team);
                case OffenseType.SUPERSTAR_FIRST_OFFENSE:
                    return SuperstarFirstStarters(team);
                default:
                    return null;
            }
        }
        private static NewPlayer[] PerimeterCentricStarters(NewTeam team)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            int counter = 0;
            double overallBest = 0;
            while (counter < 5)
            {
                NewPlayer[] starters = new NewPlayer[5];
                int loc = counter;
                double totalBest = 0;
                for (int i = 0; i < starters.Length; i++)
                {
                    int temp = (loc + i) % 5;
                    if (starters[temp] == null)
                    {
                        double bestrating = 0;
                        NewPlayer currBest = null;
                        switch (temp)
                        {
                            case 0:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsCenter(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsCenter(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPowerForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPowerForward(false);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsSmallForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsSmallForward(false);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsShootingGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsShootingGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 4:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPointGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPointGuard(false);
                                        }
                                    }
                                }
                                break;
                        }

                        starters[temp] = currBest;
                        totalBest += bestrating;
                    }
                    if (overallBest < totalBest)
                    {
                        overallBest = totalBest;
                        actualStarters = starters;
                    }
                }
                counter++;
            }
            return actualStarters;
        }
        private static NewPlayer[] PickStarters(NewTeam team)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            for(int i = 0; i < actualStarters.Length; i++)
            {
                double bestrating = 0;
                NewPlayer currBest = null;
                foreach(NewPlayer p in team)
                {
                    if (p.GetBestOverall() > bestrating)
                    {
                        bool flag = false;
                        for (int j = 0; j < actualStarters.Length; j++)
                        {
                            if (actualStarters[j] != null && actualStarters[j].GetPlayerID() == p.GetPlayerID())
                            {
                                flag = true;
                                break;
                            }
                        }
                        if (!flag)
                        {
                            currBest = p;
                            bestrating = p.GetBestOverall();
                        }
                    }
                    
                }
                actualStarters[i] = currBest;
            }
            return actualStarters;
        }
        private static NewPlayer[] PrincetonStarters(NewTeam team)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            int counter = 0;
            double overallBest = 0;
            while (counter < 5)
            {
                NewPlayer[] starters = new NewPlayer[5];
                int loc = counter;
                double totalBest = 0;
                for (int i = 0; i < starters.Length; i++)
                {
                    int temp = (loc + i) % 5;
                    if (starters[temp] == null)
                    {
                        double bestrating = 0;
                        NewPlayer currBest = null;
                        switch (temp)
                        {
                            case 0:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsCenter(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsCenter(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPowerForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPowerForward(false);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsSmallForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsSmallForward(false);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsShootingGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsShootingGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 4:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPointGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPointGuard(false);
                                        }
                                    }
                                }
                                break;
                        }

                        starters[temp] = currBest;
                        totalBest += bestrating;
                    }
                    if (overallBest < totalBest)
                    {
                        overallBest = totalBest;
                        actualStarters = starters;
                    }
                }
                counter++;
            }
            return actualStarters;
        }
        private static NewPlayer[] SevenSecondStarters(NewTeam team)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            int counter = 0;
            double overallBest = 0;
            while (counter < 5)
            {
                NewPlayer[] starters = new NewPlayer[5];
                int loc = counter;
                double totalBest = 0;
                for (int i = 0; i < starters.Length; i++)
                {
                    int temp = (loc + i) % 5;
                    if (starters[temp] == null)
                    {
                        double bestrating = 0;
                        NewPlayer currBest = null;
                        switch (temp)
                        {
                            case 0:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsCenter(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsCenter(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPowerForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPowerForward(false);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsSmallForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsSmallForward(false);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsShootingGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsShootingGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 4:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPointGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPointGuard(false);
                                        }
                                    }
                                }
                                break;
                        }

                        starters[temp] = currBest;
                        totalBest += bestrating;
                    }
                    if (overallBest < totalBest)
                    {
                        overallBest = totalBest;
                        actualStarters = starters;
                    }
                }
                counter++;
            }
            return actualStarters;
        }
        private static NewPlayer[] BalancedStarters(NewTeam team)
        {
            NewPlayer[] starters = new NewPlayer[5];

            foreach(NewPlayer p in team)
            {
                NewPlayer curr = starters[p.GetPosition() - 1];
                if (curr == null || curr.GetMainOverall() < p.GetMainOverall())
                    starters[p.GetPosition() - 1] = p;
            }
            for(int i = 0; i < starters.Length; i++)
            {
                if(starters[i] == null)
                {
                    double bestrating = 0;
                    NewPlayer currBest = null;
                    switch (i)
                    {
                        case 0:
                            foreach (NewPlayer p in team)
                            {
                                if(p.GetRatingAsCenter(false) > bestrating)
                                {
                                    bool flag = false;
                                    for(int j = 0; j < starters.Length; j++)
                                    {
                                        if(starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if(!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsCenter(false);
                                    }
                                }
                            }
                            break;
                        case 1:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsPowerForward(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsPowerForward(false);
                                    }
                                }
                            }
                            break;
                        case 2:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsSmallForward(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsSmallForward(false);
                                    }
                                }
                            }
                            break;
                        case 3:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsShootingGuard(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsShootingGuard(false);
                                    }
                                }
                            }
                            break;
                        case 4:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsPointGuard(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsPointGuard(false);
                                    }
                                }
                            }
                            break;
                    }

                    starters[i] = currBest;
                }
            }

            return starters;
        }
        private static NewPlayer[] BigBallStarters(NewTeam team)
        {
            NewPlayer[] starters = new NewPlayer[5];

            for (int i = 0; i < starters.Length; i++)
            {
                if (starters[i] == null)
                {
                    double bestrating = 0;
                    NewPlayer currBest = null;
                    switch (i)
                    {
                        case 0:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsCenter(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsCenter(false);
                                    }
                                }
                            }
                            break;
                        case 1:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsCenter(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsCenter(false);
                                    }
                                }
                            }
                            break;
                        case 2:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetRatingAsPowerForward(false) > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetRatingAsPowerForward(false);
                                    }
                                }
                            }
                            break;
                        case 3:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetBestOverall() > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetBestOverall();
                                    }
                                }
                            }
                            break;
                        case 4:
                            foreach (NewPlayer p in team)
                            {
                                if (p.GetBestOverall() > bestrating)
                                {
                                    bool flag = false;
                                    for (int j = 0; j < starters.Length; j++)
                                    {
                                        if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                        {
                                            flag = true;
                                            break;
                                        }
                                    }
                                    if (!flag)
                                    {
                                        currBest = p;
                                        bestrating = p.GetBestOverall();
                                    }
                                }
                            }
                            break;
                    }

                    starters[i] = currBest;
                }
            }


            return starters;
        }
        private static NewPlayer[] SuperstarFirstStarters(NewTeam team)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            int counter = 0;
            double overallBest = 0;
            while (counter < 5)
            {
                NewPlayer[] starters = new NewPlayer[5];
                int loc = counter;
                double totalBest = 0;
                for (int i = 0; i < starters.Length; i++)
                {
                    int temp = (loc + i) % 5;
                    if (starters[temp] == null)
                    {
                        double bestrating = 0;
                        NewPlayer currBest = null;
                        switch (temp)
                        {
                            case 0:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsCenter(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsCenter(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPowerForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPowerForward(false);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsSmallForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsSmallForward(false);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsShootingGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsShootingGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 4:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPointGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPointGuard(false);
                                        }
                                    }
                                }
                                break;
                        }

                        starters[temp] = currBest;
                        totalBest += bestrating;
                    }
                    if (overallBest < totalBest)
                    {
                        overallBest = totalBest;
                        actualStarters = starters;
                    }
                }
                counter++;
            }
            return actualStarters;
        }
        private static NewPlayer[] SmallBallStarters(NewTeam team)
        {
            NewPlayer[] actualStarters = new NewPlayer[5];
            int counter = 0;
            double overallBest = 0;
            while(counter < 5)
            {
                NewPlayer[] starters = new NewPlayer[5];
                int loc = counter;
                double totalBest = 0;
                for (int i = 0; i < starters.Length; i++)
                {
                    int temp = (loc + i) % 5;
                    if (starters[temp] == null)
                    {
                        double bestrating = 0;
                        NewPlayer currBest = null;
                        switch (temp)
                        {
                            case 0:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsSmallForward(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsSmallForward(false);
                                        }
                                    }
                                }
                                break;
                            case 1:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsShootingGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsShootingGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 2:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetRatingAsPointGuard(false) > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetRatingAsPointGuard(false);
                                        }
                                    }
                                }
                                break;
                            case 3:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetMainOverall() > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetMainOverall();
                                        }
                                    }
                                }
                                break;
                            case 4:
                                foreach (NewPlayer p in team)
                                {
                                    if (p.GetMainOverall() > bestrating)
                                    {
                                        bool flag = false;
                                        for (int j = 0; j < starters.Length; j++)
                                        {
                                            if (starters[j] != null && starters[j].GetPlayerID() == p.GetPlayerID())
                                            {
                                                flag = true;
                                                break;
                                            }
                                        }
                                        if (!flag)
                                        {
                                            currBest = p;
                                            bestrating = p.GetMainOverall();
                                        }
                                    }
                                }
                                break;
                        }

                        starters[temp] = currBest;
                        totalBest += bestrating;
                    }
                    if(overallBest < totalBest)
                    {
                        overallBest = totalBest;
                        actualStarters = starters;
                    }
                }
                counter++;
            }
            


            return actualStarters;
        }
    }
    [Serializable]
    public enum OffenseType
    {
        [Description("Balanced Offense")]
        BALANCED_OFFENSE,
        [Description("Superstar First Offense")]
        SUPERSTAR_FIRST_OFFENSE,
        [Description("Seven Second Offense")]
        SEVEN_SECOND_OFFENSE,
        [Description("Perimeter Centric Offense")]
        PERIMETER_CENTRIC_OFFENSE,
        [Description("Small Ball Offense")]
        SMALL_BALL_OFFENSE,
        [Description("Big Ball Offense")]
        BIG_BALL_OFFENSE,
        [Description("Pick Offense")]
        PICK_OFFENSE,
        [Description("Princeton Offense")]
        PRINCETON_OFFENSE
    }
    [Serializable]
    public enum DefenseType
    {
        [Description("Man Switch")]
        MAN_SWITCH_DEFENSE,
        [Description("Man No Switch")]
        MAN_NO_SWITCH_DEFENSE,
        [Description("2-3 Zone")]
        TWO_THREE_ZONE_DEFENSE,
        [Description("3-2 Zone")]
        THREE_TWO_ZONE_DEFENSE,
        [Description("Match-Up Zone")]
        MATCHUP_ZONE_DEFENSE
    }
    [Serializable]
    public enum PersonnelType
    {
        [Description("Overall Based")]
        OVERALL_BASED,
        [Description("Schedule Based")]
        SCHEDULE_BASED,
        [Description("Streak Based")]
        STREAK_BASED,
        [Description("Stamina Based")]
        STAMINA_BASED,
        [Description("Matchup Based")]
        MATCHUP_BASED
    }
    [Serializable]
    public enum Personality
    {
        [Description("Team Leader")]
        TEAM_LEADER,
        [Description("Player's Coach")]
        PLAYERS_COACH,
        [Description("Inspiring")]
        INSPIRING,
        [Description("Analytical")]
        ANALYTICAL,
        [Description("Laid Back")]
        LAID_BACK
    }
    [Serializable]
    public class NewCoach
    {
        private NewOffensivePhilosophy offense;
        private NewDefensivePhilosophy defense;
        private PlayerPhilosophy personnel;
        public NewCoach(string name, NewOffensivePhilosophy offensivePersonality, NewDefensivePhilosophy defensivePersonality, PlayerPhilosophy personnelPhilosophy)
        {
            offense = offensivePersonality;
            defense = defensivePersonality;
            personnel = personnelPhilosophy;
        }
        public NewOffensivePhilosophy PreviousPhilosophy()
        {
            return offense;
        }
        public NewOffensivePhilosophy GetOffensivePhilosophy()
        {
            return offense;
        }
        public NewDefensivePhilosophy GetDefensivePhilosophy()
        {
            return defense;
        }
        public PlayerPhilosophy GetPlayerPhilosophy()
        {
            return personnel;
        }
        public NewPlayer[] GetStartingFive(NewTeam team)
        {
            return personnel.GetStartingFive(team);
        }


    }
     public class AdvancedNewCoach
     {
         private string name;
         private CoachingPersonalities personality;
         public AdvancedNewCoach(string name, CoachingPersonalities personality)
         {
             this.personality = personality;
             this.name = name;
         }
         public byte TakeShot(NewCurrentTeam team, NewCurrentTeam opponent,ShotType type, ref NewPlayer starter, NewPlayer previousPlayer = null)
         {
             NewPlayer shooter;
             bool three = true;
             switch(type)
             {
                 case ShotType.LAYUP:
                 case ShotType.DUNK:
                     three = false;
                     shooter = personality.GetInsideShooter(team, starter);
                     break;
                 case ShotType.JUMP:
                     three = false;
                     shooter = personality.GetJumpShooter(team, starter);
                     break;
                 case ShotType.CORNER_THREE:
                 case ShotType.TOP_THREE:
                     shooter = personality.GetJumpShooter(team, starter);
                     break;
                 default:
                     shooter = personality.GetThreeShooter(team, starter);
                     break;
             }
             /*double randBarrier = 0;

             if (previousPlayer != null)
             {
                 //NewPlayer passDefender = opponent.GetCoach().GetPersonality().GetDefender(previousPlayer, opponent, team);

                 //randBarrier += previousPlayer.GetPassingRating(true, false) + previousPlayer.GetOffenseIQRating(true, false) * .5 - passDefender.GetDefenseIQRating(true, false) * 1.5;

             }


             //NewPlayer shotDefender = opponent.GetCoach().GetPersonality().GetDefender(shooter, opponent, team);
             //randBarrier += shooter.GetSeperationRating(true, false) + shooter.GetOffenseIQRating(true, false) * .5 - shotDefender.GetDefenseIQRating(true, false) * 1.5;




             //ShotResult result = NewShots.TakeShot(type, false, shooter, shotDefender, League.r.NextGaussian((int)randBarrier, 5));


             bool made = result.Type != ResultType.MISS;

             if (made)
                 return (byte)(three ? 3 : 2);
             else*/
                 return 0;
         }
         public PlayResult DoNormalPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter = null)
         {
             Tuple<ShotType, int, NewPlayer> shotType = personality.DoNormalPlay(team, opponent, starter);

             if (shotType.Item1 == ShotType.OFFENSIVE_FOUL || shotType.Item1 == ShotType.STEAL || shotType.Item1 == ShotType.TURNOVER)
                 return new PlayResult(0, 0, shotType.Item2, shotType.Item3);

             byte score = TakeShot(team, opponent, shotType.Item1, ref starter);
             byte awayScore = 0, homeScore = 0;

             if (team.IsAwayTeam())
                 awayScore = score;
             else
                 homeScore = score;
             return new PlayResult(awayScore, homeScore, shotType.Item2, starter);
         }
         public PlayResult DoLessRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter = null)
         {
             Tuple<ShotType, int, NewPlayer> shotType = personality.DoLessRiskyPlay(team, opponent, starter);

             if (shotType.Item1 < 0)
                 return new PlayResult(0, 0, shotType.Item2, shotType.Item3);

             byte score = TakeShot(team, opponent, shotType.Item1, ref starter);
             byte awayScore = 0, homeScore = 0;

             if (team.IsAwayTeam())
                 awayScore = score;
             else
                 homeScore = score;
             return new PlayResult(awayScore, homeScore, shotType.Item2, starter);
         }
         public PlayResult DoMoreRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter = null)
         {
             Tuple<ShotType, int, NewPlayer> shotType = personality.DoMoreRiskyPlay(team, opponent, starter);

             if (shotType.Item1 < 0)
                 return new PlayResult(0, 0, shotType.Item2, shotType.Item3);

             byte score = TakeShot(team, opponent, shotType.Item1, ref starter);
             byte awayScore = 0, homeScore = 0;

             if (team.IsAwayTeam())
                 awayScore = score;
             else
                 homeScore = score;
             return new PlayResult(awayScore, homeScore, shotType.Item2, starter);
         }
         public NewPlayer[] GetStartingFive(NewTeam team)
         {
             return personality.GetStartingFive(team);
         }
         public PlayResult InboundPlay(NewCurrentTeam team, NewCurrentTeam opponent)
         {
             return null;
         }
         // Update this so they have a chance of being any personality
         public CoachingPersonalities GetPersonality()
         {
             return personality;
         }

     }
    // This class outlines the differences in coaching personalities, and is what the difference is
    // between each coach. The different personalities are all listed in the CoachingPersonalities.cs file
    // and all implement the various methods listed in here.
    [Serializable]
    public abstract class CoachingPersonalities
    {
        public CoachingPersonalities()
        {

        }
        // Shooters
        public abstract NewPlayer GetThreeShooter(NewCurrentTeam team, NewPlayer starter);
        public abstract NewPlayer GetJumpShooter(NewCurrentTeam team, NewPlayer starter);
        public abstract NewPlayer GetInsideShooter(NewCurrentTeam team, NewPlayer starter);

        // Various different players
        public abstract NewPlayer GetDefender(NewPlayer shooter, NewCurrentTeam team, NewCurrentTeam opponent);
        public abstract NewPlayer GetPlayStarter(NewCurrentTeam team);

        // Plays
        public abstract Tuple<ShotType, int, NewPlayer> DoNormalPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter);
        public abstract Tuple<ShotType, int, NewPlayer> DoLessRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter);
        public abstract Tuple<ShotType, int, NewPlayer> DoMoreRiskyPlay(NewCurrentTeam team, NewCurrentTeam opponent, NewPlayer starter);

        public abstract NewPlayer[] GetStartingFive(NewTeam team);

    }
}