public class Chef
{
    public void Cook()
    {
        Bowl bowl = this.GetBowl();

        Carrot carrot = this.GetCarrot();
        Peel(carrot);
        this.Cut(carrot);
        bowl.Add(carrot);

        Potato potato = this.GetPotato();
        Peel(potato);
        this.Cut(potato);
        bowl.Add(potato);
    }

    private Bowl GetBowl()
    {
        // ...
    }

    private Carrot GetCarrot()
    {
        // ...
    }

    private Potato GetPotato()
    {
        // ...
    }

    private void Cut(Vegetable vegetable)
    {
        // ...
    }
}