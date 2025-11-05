using UnityEngine;
using NUnit.Framework;
using NUnit.Framework.Internal;



public class GoblinTests
{
    [Test]
    public void Goblin_Starts_With_Correct_Health()
    {
        // Arrange - new instance of Goblin
        GameObject goblinObject = new GameObject();
        Goblin goblin = goblinObject.AddComponent<Goblin>();

        // Act - get initial health
        int initialHealth = goblin.getHealth();

        // Assert - validate initial health is 100
        Assert.AreEqual(100, initialHealth);
    }

    [Test]
    public void Goblin_Takes_Damage_Correctly()
    {
        // Arrange - new instance of Goblin
        GameObject goblinObject = new GameObject();
        Goblin goblin = goblinObject.AddComponent<Goblin>();
        int damage = 30;

        // Act - apply damage of 30
        goblin.takeDamage(damage);
        int currentHealth = goblin.getHealth();

        // Assert - validate health after damage is 70
        Assert.AreEqual(70, currentHealth);
    }

    [Test]
    public void Goblin_is_Dead_When_Health_Reaches_Zero()
    {
        // Arrange - new instance of Goblin
        GameObject goblinObject = new GameObject();
        Goblin goblin = goblinObject.AddComponent<Goblin>();
        int damage = 100;

        // Act - apply damage of 100
        goblin.takeDamage(damage);
        bool isAlive = goblin.isAlive();

        // Assert - validate goblin is dead
        Assert.IsFalse(isAlive);
    }


    [Test]
    public void Goblin_Health_Does_Not_Go_Below_Zero()
    {
        // Arrange - new instance of Goblin
        GameObject goblinObject = new GameObject();
        Goblin goblin = goblinObject.AddComponent<Goblin>();
        int damage = 150;

        // Act - apply damage of 150
        goblin.takeDamage(damage);
        int currentHealth = goblin.getHealth();

        // Assert - validate health does not go below 0
        Assert.AreEqual(0, currentHealth);

    }

    [Test]
    public void Goblin_Heals_Correctly()
    {
        // Arrange - new instance of Goblin
        GameObject goblinObject = new GameObject();
        Goblin goblin = goblinObject.AddComponent<Goblin>();
        int damage = 50;

        // Act - apply damage of 50 and then heal with medkit, adding 20 health
        goblin.takeDamage(damage);
        goblin.useMedkit();
        int currentHealth = goblin.getHealth();

        // Assert - validate health after healing is 70
        Assert.AreEqual(70, currentHealth);
    }


    [Test]
    public void Goblin_Health_Does_Not_Exceed_Maximum()
    {
        // Arrange - new instance of Goblin
        GameObject goblinObject = new GameObject();
        Goblin goblin = goblinObject.AddComponent<Goblin>();


        // Act - use medkit at full health
        goblin.useMedkit();
        int currentHealth = goblin.getHealth();

        // Assert - validate health does not exceed 100
        Assert.AreEqual(100, currentHealth);
    }

    [Test]
    public void Goblin_Can_Only_Use_1_Medkit()
    {
        // Arrange - new instance of Goblin
        GameObject goblinObject = new GameObject();
        Goblin goblin = goblinObject.AddComponent<Goblin>();

        int damage = 50;
        int availableMedkits = goblin.getMedkits();

        // Act - use medkit twice
        goblin.takeDamage(damage);
        goblin.useMedkit(); // Should succeed
        goblin.useMedkit(); // Should fail as only 1 medkit is available

        // Assert - validate only 1 medkit was available and used
        Assert.AreEqual(0, goblin.getMedkits());
    }

    [Test]
    public void Goblin_Health_Stays_100_When_Instantiated_with_500_Health()
    {
        // Arrange - new instance of Goblin with 500 health
        GameObject goblinObject = new GameObject();
        Goblin goblin = goblinObject.AddComponent<Goblin>();
        goblin.setHealth(500);

        // Act - get current health
        int currentHealth = goblin.getHealth();

        // Assert - validate health stays at 100
        Assert.AreEqual(100, currentHealth);

    }

    [Test]
    public void Goblin_Health_Stays_0_When_Health_Set_To_Negative()
    {
        // Arrange - new instance of Goblin
        GameObject goblinObject = new GameObject();
        Goblin goblin = goblinObject.AddComponent<Goblin>();
        goblin.setHealth(-50);

        // Act - get current health
        int currentHealth = goblin.getHealth();

        // Assert - validate health stays at 0
        Assert.AreEqual(0, currentHealth);
    }

}

