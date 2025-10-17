
public class Goblin : Enemy
{
    public Goblin() : base()
    {
    }
    public override void attack(Character target)
    {
        int damage = 10; // Goblin's attack power
        target.takeDamage(damage); // Attack player
    }
}