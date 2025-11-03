
public class Goblin : Enemy
{
    public Goblin() : base()
    {
    }

    // Implement abstract method to get attack power and add Goblin-specific bonus
    public override int getAttackPower() 
    {
        return getDefaultAttackPower() + 3;
    }
    public override void attack(Character target)
    {
        int damage = getAttackPower(); // Goblin's attack power
        target.takeDamage(damage); // Attack player
    }



}