
public class Mage : Enemy
{
    public Mage() : base()
    {
    }
    public override void attack(Character target)
    {
        int damage = getDefaultAttackPower() + 5; // Mage's attack power
        target.setHealth(target.getHealth() - damage); // Attack player
    }
}