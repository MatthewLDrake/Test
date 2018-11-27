
using System;
using System.Collections.Generic;

public class currentTeam
{
    public player pointGuard, shootingGuard, smallForward, powerForward, center;
    public int length = 5;
    public player superStar, playMaker, rebounder, shooter;
    public team team;
    public Coach coach;
    public player lastPlayer;
    private bool blowout;
    public currentTeam(team team)
    {
        blowout = false;
        pointGuard = null;
        shootingGuard = null;
        smallForward = null;
        powerForward = null;
        center = null;
        this.team = team;
        superStar = null;
        playMaker = null;
        rebounder = null;
        shooter = null;
        coach = team.getCoach();
        SetStarters();
        //substitutions(1, true);
    }
    private void SetStarters()
    {
        for (int i = 0; i < length; i++)
            set(i, team.getAllPlayer()[i]);
    }
    public player get(int i)
    {
        switch (i)
        {
            case 0:
                return center;
            case 1:
                return powerForward;
            case 2:
                return smallForward;
            case 3:
                return shootingGuard;
            case 4:
                return pointGuard;
        }
        return null;
    }
    public void set(int i, player player)
    {
        player.playedInAGame();
        switch (i)
        {
            case 0:
                center = player;
                break;
            case 1:
                powerForward = player;
                break;
            case 2:
                smallForward = player;
                break;
            case 3:
                shootingGuard = player;
                break;
            case 4:
                pointGuard = player;
                break;
        }

    }
    public int getPos(player player)
    {
        if (player.Equals(center)) return 1;
        else if (player.Equals(powerForward)) return 2;
        else if (player.Equals(smallForward)) return 3;
        else if (player.Equals(shootingGuard)) return 4;
        else if (player.Equals(pointGuard)) return 5;

        return -1;
    }

    public void checkTeam()
    {
        player[] arr = team.getPresets();
        if (arr != null)
        {
            if (arr[0].isPlaying()) superStar = arr[0];
            else superStar = null;
            if (arr[1].isPlaying()) playMaker = arr[1];
            else playMaker = null;
            if (arr[2].isPlaying()) rebounder = arr[2];
            else rebounder = null;
            if (arr[3].isPlaying()) shooter = arr[3];
            else shooter = null;
        }
        if (superStar == null)
        {
            superStar = findSuperStar();
        }
        if (playMaker == null)
        {
            playMaker = findPlayMaker();
        }
        if (rebounder == null)
        {
            rebounder = findRebounder();
        }
        if (shooter == null)
        {
            shooter = findShooter();
        }


    }
    private player findShooter()
    {
        int pos = 0;
        double highestTotal = 0.0;
        for (int i = 0; i < 5; i++)
        {
            player temp = get(i);
            double tempTotal = Math.Max(temp.getDunkRating(), temp.getLayupRating()) + temp.getJumpShotRating() + temp.getThreeShotRating();
            if (tempTotal > highestTotal)
            {
                highestTotal = tempTotal;
                pos = i;
            }
        }
        return get(pos);
    }
    private player findRebounder()
    {
        int pos = 0;

        double highestTotal = 0;
        for (int i = 0; i < 5; i++)
        {
            player temp = get(i);
            double tempTotal = temp.getJumpingRating();
            if (tempTotal > highestTotal)
            {
                highestTotal = tempTotal;
                pos = i;
            }
        }

        return get(pos);
    }
    private player findPlayMaker()
    {
        int pos = 0;

        double highestTotal = 0;
        for (int i = 4; i >= 0; i--)
        {
            player temp = get(i);
            double tempTotal = temp.getPassing();
            if (tempTotal > highestTotal)
            {
                highestTotal = tempTotal;
                pos = i;
            }
        }

        return get(pos);
    }
    private player findSuperStar()
    {
        int pos = 0;

        double highestTotal = 0;
        for (int i = 0; i < 5; i++)
        {
            player temp = get(i);
            double tempTotal = temp.getDefenseIQRating() + Math.Max(temp.getDunkRating(), temp.getLayupRating()) + temp.getShotContestRating() + temp.getJumpingRating() + temp.getJumpShotRating() + temp.getSeperation() + temp.getPassing() + temp.getThreeShotRating();
            //System.out.println(temp.getName() + " " + tempTotal);
            if (tempTotal > highestTotal)
            {
                highestTotal = tempTotal;
                pos = i;
            }
        }
        //System.out.println(get(pos).getName());
        return get(pos);
    }

    public void substitutions(int quarterNum, int timeLeft, bool isWinning, int scoreDifference)
    {
        if (blowout)
        {
            if (scoreDifference > 10) return;

        }
        else if ((quarterNum == 4 && timeLeft < 400 && scoreDifference > 20))
        {
            blowout = true;
            for (int i = 0; i < length; i++)
            {
                // set to third strings
                set(i, team.getAllPlayer()[10 + i]);
            }
        }


        for (int i = 0; i < length; i++)
        {
            if (get(i).isInjured())
            //|| ) (check for whether he should be pulled by the team
            {
                get(i).Pulled();
                set(i, null);
            }
        }
        for (int i = 0; i < length; i++)
        {
            if (get(i) == null)
            {
                // FIGURE OUT HOW TO GET NEW PLAYER
                set(i, null);
            }
        }
    }
    public void substitutions(int quarterNum, bool isWinning)
    {
        foreach (player p in team.getAllPlayer())
        {
            p.setIsPlaying(false);
        }
        for (int i = 0; i < 5; i++)
        {
            get(i).setIsPlaying(true);
        }

        for (int i = 0; i < length; i++)
        {
            List<player> temp = new List<player>();
            double tempHolder = 0;
            int newMember = 0;

            bool bob = false;
            if (!get(i).isStarter())
            {

                for (int j = 0; j < team.getSize(); j++)
                {
                    if (i + 1 == team.getPlayer(j).getPosition())
                    {
                        if (team.getPlayer(j).isStarter() && !team.getPlayer(j).isInjured() && acceptableAmountOfFouls(team.getPlayer(j), quarterNum))
                        {

                            if (team.getPlayer(j).getStamina() > coach.getStaminaSubOut() && acceptableAmountOfFouls(team.getPlayer(j), quarterNum))
                            {
                                bob = true;
                            }
                        }
                    }
                }
            }

            if (get(i).isInjured() || get(i).getStamina() < coach.getStaminaSubIn() || bob || !acceptableAmountOfFouls(get(i), quarterNum))
            {
                bool useOtherPositions = false;
                int num = 0;
                while (true)
                {
                    num++;
                    //Console.WriteLine("Substitutions Test for infinite loop");
                    if (num > 100)
                    {
                        Console.WriteLine("Problem occurred");
                        //Environment.Exit(-1);
                    }
                    if (bob)
                    {
                        temp = new List<player>();
                        for (int j = 0; j < team.getSize(); j++)
                        {
                            if (i + 1 == team.getPlayer(j).getPosition() && team.getPlayer(j).isStarter()) temp.Add(team.getPlayer(j));
                        }
                    }
                    else if (!get(i).isInjured() && !useOtherPositions)
                    {


                        temp = new List<player>();
                        for (int j = 0; j < team.getSize(); j++)
                        {
                            if (i + 1 == team.getPlayer(j).getPosition() && !team.getPlayer(j).isPlaying() && !team.getPlayer(j).isInjured() && acceptableAmountOfFouls(team.getPlayer(j), quarterNum))
                            {
                                temp.Add(team.getPlayer(j));
                            }
                        }
                        double[] relevantStats = new double[temp.Count];
                        for (int j = 0; j < temp.Count; j++)
                        {
                            if (isWinning)
                            {
                                relevantStats[j] = temp[j].getDefenseIQRating() + temp[j].getShotContestRating();
                            }
                            else
                            {
                                relevantStats[j] = temp[j].getDunkRating() + temp[j].getJumpShotRating() + temp[j].getLayupRating();
                            }

                        }

                        for (int j = 0; j < temp.Count; j++)
                        {
                            if (relevantStats[j] > tempHolder)
                            {
                                newMember = j;
                                tempHolder = relevantStats[j];
                            }
                        }
                    }
                    else
                    {
                        temp = new List<player>();
                        for (int j = 0; j < team.getSize(); j++)
                        {
                            if (get(i).getPosition() == team.getPlayer(j).getPosition() && !team.getPlayer(j).isPlaying() && acceptableAmountOfFouls(team.getPlayer(j), 4) && !team.getPlayer(j).isInjured())
                            {
                                temp.Add(team.getPlayer(j));
                            }

                        }
                        for (int j = 0; j < team.getSize(); j++)
                        {
                            if (temp.Count == 0)
                            {
                                player p = team.getPlayer(j);
                                double stamina = p.getStamina();
                                bool notInjured = !p.isInjured();
                                bool acceptable = acceptableAmountOfFouls(p, 4);
                                bool notPlaying = !p.isPlaying();
                                if (!p.isPlaying() && acceptableAmountOfFouls(p, 4) && !p.isInjured() && p.getStamina() > 70)
                                {
                                    temp.Add(team.getPlayer(j));
                                }
                            }
                        }
                        double[] relevantStats = new double[temp.Count];
                        for (int j = 0; j < temp.Count; j++)
                        {
                            if (isWinning)
                            {
                                relevantStats[j] = temp[j].getDefenseIQRating() + temp[j].getShotContestRating();
                            }
                            else
                            {
                                relevantStats[j] = Math.Max(temp[j].getDunkRating(), temp[j].getLayupRating()) + temp[j].getJumpShotRating() + temp[j].getSeperation();
                            }

                        }

                        for (int j = 0; j < temp.Count; j++)
                        {
                            if (relevantStats[j] > tempHolder)
                            {
                                newMember = j;
                                tempHolder = relevantStats[j];
                            }
                        }
                    }

                    if (temp.Count != 0)
                    {
                        get(i).setIsPlaying(false);
                        set(i, temp[newMember]);
                        get(i).setIsPlaying(true);
                        break;
                    }
                    else
                    {
                        useOtherPositions = true;
                    }
                }
            }
        }
        for (int i = 0; i < length; i++)
        {
            if (get(i).isInjured())
            {
                //Console.WriteLine(get(i).getName() + " is playing hurt tf");
                //System.exit(0);
            }
        }
    }
    private bool acceptableAmountOfFouls(player player, int quarterNum)
    {
        if (quarterNum == 1) return player.getGameFouls() < 2;
        else if (quarterNum == 2) return player.getGameFouls() < 3;
        else if (quarterNum == 3) return player.getGameFouls() < 4;
        else return player.getGameFouls() < 5;
    }

}
