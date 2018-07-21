using System;
[Serializable]
public class Concessions
{
    private String foodType, drinkType;
    private double foodPrice, drinkPrice;
    public Concessions(String foodType, double foodPrice, String drinkType, double drinkPrice)
    {
        this.foodPrice = foodPrice;
        this.foodType = foodType;
        this.drinkPrice = drinkPrice;
        this.drinkType = drinkType;
    }
    public attendance[] getConcessionSales(attendance people)
    {
        int peopleAttending = (int)people.numberAttending;

        return new attendance[] { new attendance(peopleAttending, (long)(peopleAttending * foodPrice)), new attendance(peopleAttending, (long)(peopleAttending * drinkPrice)) };

    }
}
