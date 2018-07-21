using System;
[Serializable]
public class Stadium
{

    private int capacityLevel, concessionLevel, overallQualityLevel;
    private float cheapSeatsPrice, averageSeatsPrice, highEndSeatsPrice, luxuryBoxesPrice;
    private long cheapSeatsCount, averageSeatsCount, highEndSeatsCount, luxuryBoxesCount;
    private Concessions concessions;
    public Stadium(float[] seatPrices)
    {
        capacityLevel = 1;
        concessionLevel = 1;
        overallQualityLevel = 1;

        cheapSeatsPrice = seatPrices[0];
        averageSeatsPrice = seatPrices[1];
        highEndSeatsPrice = seatPrices[2];
        luxuryBoxesPrice = seatPrices[3];

        startUp();
    }
    public Stadium(int[] levels, float[] seatPrices)
    {
        capacityLevel = levels[0];
        concessionLevel = levels[1];
        overallQualityLevel = levels[2];

        cheapSeatsPrice = seatPrices[0];
        averageSeatsPrice = seatPrices[1];
        highEndSeatsPrice = seatPrices[2];
        luxuryBoxesPrice = seatPrices[3];

        startUp();
    }
    private void startUp()
    {
        int maxCapacity = getMaxCapacity();

        cheapSeatsCount = (long)Math.Round(maxCapacity * 2.0 / 3.0);
        averageSeatsCount = (long)Math.Round(maxCapacity * .3);
        highEndSeatsCount = maxCapacity - (cheapSeatsCount + averageSeatsCount);
        luxuryBoxesCount = 5;

    }
    public void startConcessions(String foodName, double foodPrice, String drinkName, double drinkPrice)
    {
        concessions = new Concessions(foodName, foodPrice, drinkName, drinkPrice);
    }
    public void upgradeCapacity()
    {
        capacityLevel++;
        startUp();
    }
    public void upgradeConcessions()
    {
        concessionLevel++;
    }
    public void upgradeOverallQuality()
    {
        overallQualityLevel++;
    }
    public attendance getAttendance(team teamOne, team teamTwo, bool playoffs)
    {
        long numCheapSeats = cheapSeatsCount;
        long numAverageSeats = averageSeatsCount;
        long numHighEndSeats = highEndSeatsCount;
        long numLuxurySeats = luxuryBoxesCount * 10;
        long numLuxuryBoxesUsed = 5;
        if (!playoffs)
        {
            numCheapSeats = getCheapSeatsAttending(teamOne.getTeamResults(), teamTwo.getTeamResults());
            numAverageSeats = getAverageSeatsAttending(teamOne.getTeamResults(), teamTwo.getTeamResults());
            numHighEndSeats = getHighEndSeatsAttending(teamOne.getTeamResults(), teamTwo.getTeamResults());
            int[] temp = getLuxuryBoxSeatsAttending(teamOne.getTeamResults(), teamTwo.getTeamResults());
            numLuxurySeats = temp[0];
            numLuxuryBoxesUsed = temp[1];
        }
        int price = (int)Math.Round(numCheapSeats * cheapSeatsPrice + numAverageSeats * averageSeatsPrice + numHighEndSeats * highEndSeatsPrice + numLuxuryBoxesUsed * luxuryBoxesPrice);
        return new attendance(numCheapSeats + numAverageSeats + numHighEndSeats + numLuxurySeats, price);
    }
    public attendance[] getConcessions(attendance peopleAttending)
    {
        return concessions.getConcessionSales(peopleAttending);
    }
    private int[] getLuxuryBoxSeatsAttending(teamResults teamTier, teamResults teamTier2)
    {
        long max = 0;
        long min = 0;
        int peopleInBoxMin = 0;
        int peopleInBoxMax = 0;

        Random rand = new Random();

        if (teamTier.Equals(teamTier2))
        {
            max = luxuryBoxesCount;
            peopleInBoxMax = 10;
            peopleInBoxMin = peopleInBoxMax - (5 - overallQualityLevel);
            int temp = 0;
            if (overallQualityLevel == 1) temp = -3;
            else if (overallQualityLevel <= 3) temp = -2;
            else if (overallQualityLevel == 4) temp = -1;
            min = max + temp;
        }
        else if (teamTier.compareTo(teamTier2) > 0)
        {
            max = luxuryBoxesCount;
            peopleInBoxMax = 10;
            peopleInBoxMin = peopleInBoxMax - (8 - overallQualityLevel);
            int temp = overallQualityLevel - 6;
            min = max + temp;
        }
        else
        {
            max = luxuryBoxesCount;
            peopleInBoxMax = 10;
            peopleInBoxMin = peopleInBoxMax - (10 - (overallQualityLevel * 2));
            int temp = -1;
            if (overallQualityLevel <= 2) temp = -5;
            else if (overallQualityLevel <= 4) temp = -3;
            min = max + temp;
        }


        int tempMax = (int)max;
        int tempMin = (int)min;
        int randomNum = rand.Next((tempMax - tempMin) + 1) + tempMin;
        int sum = 0;
        for (int i = 0; i < randomNum; i++)
        {
            sum += rand.Next((peopleInBoxMax - peopleInBoxMin) + 1) + peopleInBoxMin;
        }

        return new int[] { sum, randomNum };
    }
    private long getHighEndSeatsAttending(teamResults teamTier, teamResults teamTier2)
    {
        long max = 0;
        long min = 0;
        if (highEndSeatsPrice < 60) return highEndSeatsCount;
        if (teamTier.Equals(teamTier2))
        {
            max = highEndSeatsCount;
            min = max - (5 - overallQualityLevel) * 10;
        }
        else if (teamTier.compareTo(teamTier2) > 0)
        {
            max = highEndSeatsCount;
            min = max - (5 - overallQualityLevel) * 25;
        }
        else
        {
            max = highEndSeatsCount - (5 - overallQualityLevel) * 10;
            min = Math.Max(max - (5 - overallQualityLevel) * 100, 0);
        }

        Random rand = new Random();
        int tempMax = (int)max;
        int tempMin = (int)min;
        int randomNum = rand.Next((tempMax - tempMin) + 1) + tempMin;
        return randomNum;
    }
    private long getAverageSeatsAttending(teamResults teamTier, teamResults teamTier2)
    {
        long max = 0;
        long min = 0;

        if (averageSeatsPrice < 30) return averageSeatsCount;

        if (teamTier.Equals(teamTier2))
        {
            max = averageSeatsCount;
            min = max - (5 - overallQualityLevel) * 50;
        }
        else if (teamTier.compareTo(teamTier2) > 0)
        {
            max = averageSeatsCount;
            min = max - (5 - overallQualityLevel) * 125;
        }
        else
        {
            max = averageSeatsCount - (5 - overallQualityLevel) * 50;
            min = max - (5 - overallQualityLevel) * 500;
        }

        Random rand = new Random();
        int tempMax = (int)max;
        int tempMin = (int)min;
        int randomNum = rand.Next((tempMax - tempMin) + 1) + tempMin;
        return randomNum;
    }
    private long getCheapSeatsAttending(teamResults teamTier, teamResults teamTier2)
    {
        long max = 0;
        long min = 0;

        if (cheapSeatsPrice < 10)
        {
            return cheapSeatsCount;
        }
        else if (cheapSeatsPrice < 25)
        {
            max = cheapSeatsCount;
            min = max - (5 - overallQualityLevel) * 100;
        }
        else
        {
            max = cheapSeatsCount - (5 - overallQualityLevel) * 100;
            min = max - (5 - overallQualityLevel) * 100;
        }
        Random rand = new Random();

        int tempMax = (int)max;
        int tempMin = (int)min;
        int randomNum = rand.Next((tempMax - tempMin) + 1) + tempMin;
        return randomNum;
    }
    public int getConcessionsSold(int attendance)
    {
        return attendance * this.concessionLevel;
    }
    private int getMaxCapacity()
    {
        int maxCapacity = 0;
        switch (capacityLevel)
        {
            case 1:
                maxCapacity = 10000;
                break;
            case 2:
                maxCapacity = 12500;
                break;
            case 3:
                maxCapacity = 15000;
                break;
            case 4:
                maxCapacity = 17500;
                break;
            case 5:
                maxCapacity = 20000;
                break;
        }
        return maxCapacity;
    }
}