namespace ConsoleApplication 
{

    public class Human 
    {
        public string name;
        
        //The {get; set;} format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public int health { get; set; }
    
        public Human(string who)
        {
            name = who;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
        }

        public Human(string who, int str, int intel, int dex, int hp) 
        {
            name = who;
            strength = str;
            intelligence = intel;
            dexterity = dex;
            health = hp;
        }

        public void attack(object badGuy)
        {
            Human exBadGuy = badGuy as Human;
            if(badGuy != null){
                exBadGuy.health -= 5 * strength;
            }
        }
        
    }
}
