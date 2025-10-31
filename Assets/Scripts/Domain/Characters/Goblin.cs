
public class Goblin : Enemy
{
    public Goblin() : base()
    {
    }
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