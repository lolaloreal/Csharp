using System;

namespace dojoDachi.Models
{
    public class Dachi{
    public int happiness { get; set; }

    public int fullness { get; set; }

    public int meals { get; set; }

    public int energy { get; set; }

    public string status { get; set; }
    

    public Dachi() 
    {
        happiness = 20;
        fullness = 20;
        meals = 3;
        energy = 50;
        status = "Play time";
    }

    public Dachi feed()
    {
        Random rand = new Random();
        this.meals -= 1;
        if(rand.Next(0, 4) != 0){
            int amount = rand.Next(5, 11);
            this.fullness += amount;
            this.status = $"Your dachi just fed and is {amount} fuller.";
        }
        else
        {
            this.status = $"You are a bad cook.";
        }
        return this;
    }

    public Dachi work()
    {
        Random rand = new Random();
        this.energy -= 5;
        int amount = rand.Next(1, 4);
        this.meals += amount;
        this.status = $"Your dachi worked and earned {amount} meals!";
        return this;
    }

    public Dachi play()
    {
        this.energy -= 5;
        Random rand = new Random();
        if(rand.Next(0, 4) != 0){
            int amount = rand.Next(5, 11);
            this.happiness += amount;
            this.status = $"Your dachi played and is {amount} happier!";
        }
        else{
            this.status = $"Your dachi says no.";
        }
        return this;
    }

    public Dachi sleep()
    {
        this.energy += 15;
        this.fullness -= 5;
        this.happiness -= 5;
        this.status = "Your dachi is sleeping";
        if (fullness < 0 || happiness < 0)
        {
            this.status = "Your dachi done did died.";
        }
        return this;
    }



    }
}