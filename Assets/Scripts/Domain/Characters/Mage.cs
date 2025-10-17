
public class Mage : Enemy
{
    public Mage() : base()
    {
    }
    public override void attack(Character target)
    {
        int damage = 20; // Mage's attack power
        target.takeDamage(damage); // Attack player
    }
}