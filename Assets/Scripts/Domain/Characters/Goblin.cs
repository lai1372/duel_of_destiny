
public class Goblin : Enemy
{
    public Goblin() : base()
    {
    }
    public override void attack(Character target)
    {
        int damage = getDefaultAttackPower() + 3; // Goblin's attack power
        target.setHealth(target.getHealth() - damage); // Attack player
    }
}