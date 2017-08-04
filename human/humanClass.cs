namespace ConsoleApplication 
{

    public class Human 
    {
        public string name;
        public int strength = 3;
        public int intelligence = 3;
        public int dexterity = 3;
        public int health = 100;
    
        public Human(string who)
        {
            name = who;
        }

        public Human(string who, int str, int intel, int dex, int hp) 
        {
            name = who;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }

        public void Attack(object badGuy)
        {
            Human exBadGuy = badGuy as Human;
            if(badGuy != null){
                exBadGuy.health -= 5 * strength;
            }
        }
        
    }
}
