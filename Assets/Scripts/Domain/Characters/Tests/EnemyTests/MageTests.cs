using UnityEngine;
using NUnit.Framework;
using NUnit.Framework.Internal;



public class MageTests
{
    // -----------------------------------------------
    // Normal tests
    // -----------------------------------------------

    [Test]
    public void Mage_Starts_With_Correct_Health()
    {
        // Arrange - new instance of Mage
        GameObject mageObject = new GameObject();
        Mage mage = mageObject.AddComponent<Mage>();

        // Act - get initial health
        int initialHealth = mage.getHealth();

        // Assert - validate initial health is 100
        Assert.AreEqual(100, initialHealth);
    }

    [Test]
    public void Mage_Takes_Damage_Correctly()
    {
        // Arrange - new instance of Mage
        GameObject mageObject = new GameObject();
        Mage mage = mageObject.AddComponent<Mage>();
        int damage = 20;

        // Act - apply damage of 20
        mage.takeDamage(damage);
        int currentHealth = mage.getHealth();

        // Assert - validate health after damage is 80
        Assert.AreEqual(80, currentHealth);
    }

    [Test]
    public void Mage_Heals_Correctly()
    {
        // Arrange - new instance of Mage
        GameObject mageObject = new GameObject();
        Mage mage = mageObject.AddComponent<Mage>();
        int damage = 50;

        // Act - apply damage of 50 and then heal with medkit, adding 20 health
        mage.takeDamage(damage);
        mage.useMedkit();
        int currentHealth = mage.getHealth();

        // Assert - validate health after healing is 70
        Assert.AreEqual(70, currentHealth);
    }

    [Test]
    public void Mage_is_Dead_When_Health_Reaches_Zero()
    {
        // Arrange - new instance of Mage
        GameObject mageObject = new GameObject();
        Mage mage = mageObject.AddComponent<Mage>();
        int damage = 100;

        // Act - apply damage of 100
        mage.takeDamage(damage);
        bool isAlive = mage.isAlive();

        // Assert - validate Mage is dead
        Assert.IsFalse(isAlive);
    }

    // -----------------------------------------------
    // Edge case tests
    // -----------------------------------------------

    [Test]
    public void Mage_Health_Does_Not_Go_Below_Zero()
    {
        // Arrange - new instance of Mage
        GameObject mageObject = new GameObject();
        Mage mage = mageObject.AddComponent<Mage>();
        int damage = 150;

        // Act - apply damage of 150
        mage.takeDamage(damage);
        int currentHealth = mage.getHealth();

        // Assert - validate health does not go below 0
        Assert.AreEqual(0, currentHealth);

    }

    [Test]
    public void Mage_Health_Does_Not_Exceed_Maximum()
    {
        // Arrange - new instance of Mage
        GameObject mageObject = new GameObject();
        Mage mage = mageObject.AddComponent<Mage>();


        // Act - use medkit at full health
        mage.useMedkit();
        int currentHealth = mage.getHealth();

        // Assert - validate health does not exceed 100
        Assert.AreEqual(100, currentHealth);
    }

    [Test]
    public void Mage_Can_Only_Use_1_Medkit()
    {
        // Arrange - new instance of Mage
        GameObject mageObject = new GameObject();
        Mage mage = mageObject.AddComponent<Mage>();
        int damage = 50;
        int availableMedkits = mage.getMedkits();

        // Act - use medkit twice
        mage.takeDamage(damage);
        mage.useMedkit(); // Should succeed
        mage.useMedkit(); // Should fail as only 1 medkit is available

        // Assert - validate only 1 medkit was available and used
        Assert.AreEqual(0, mage.getMedkits());
    }

    // -----------------------------------------------
    // Invalid input tests
    // -----------------------------------------------

    [Test]
    public void Mage_Health_Stays_100_When_Instantiated_with_500_Health()
    {
        // Arrange - new instance of Mage with 500 health
        GameObject mageObject = new GameObject();
        Mage mage = mageObject.AddComponent<Mage>();
        mage.setHealth(500);

        // Act - get current health
        int currentHealth = mage.getHealth();

        // Assert - validate health stays at 100
        Assert.AreEqual(100, currentHealth);

    }

    [Test]
    public void Mage_Health_Stays_0_When_Health_Set_To_Negative()
    {
        // Arrange - new instance of Mage
        GameObject mageObject = new GameObject();
        Mage mage = mageObject.AddComponent<Mage>();
        mage.setHealth(-50);

        // Act - get current health
        int currentHealth = mage.getHealth();

        // Assert - validate health stays at 0
        Assert.AreEqual(0, currentHealth);
    }
}

