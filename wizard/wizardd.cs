namespace ConsoleApplication
{
    public class Wizard
    {
        int intelligence = 25;
        int health = 50;      
    
    
    public void heal(object wiz)
    {
        Wizard wizardPerson = wiz as Wizard;
        health += 10 * intelligence;
    }

    public void fireball(object wiz)
    {
        
    }

    }
}