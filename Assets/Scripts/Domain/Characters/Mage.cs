
public class Mage : Enemy
{
    public Mage() : base()
    {
    }

    // Implement abstract method to get attack power and add Mage-specific bonus
    public override int getAttackPower()
    {
        return getDefaultAttackPower() + 5;
    }
    public override void attack(Character target)
    {
        int damage = getAttackPower(); // Mage's attack power
        target.takeDamage(damage); // Attack player
    }
}