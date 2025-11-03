using UnityEngine;
using NUnit.Framework;
using NUnit.Framework.Internal;



public class PlayerTests
{
    [Test]
    public void Player_Starts_With_Correct_Health()
    {
        // Arrange - new instance of Player
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        // Act - get initial health
        int initialHealth = player.getHealth();

        // Assert - validate initial health is 100
        Assert.AreEqual(100, initialHealth);
    }

    [Test]
    public void Player_Takes_Damage_Correctly()
    {
        // Arrange - new instance of Player
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        int damage = 20;

        // Act - apply damage of 20
        player.takeDamage(damage);
        int currentHealth = player.getHealth();

        // Assert - validate health after damage is 80
        Assert.AreEqual(80, currentHealth);
    }

    [Test]
    public void Player_is_Dead_When_Health_Reaches_Zero()
    {
        // Arrange - new instance of Player
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        int damage = 100;

        // Act - apply damage of 100
        player.takeDamage(damage);
        bool isAlive = player.isAlive();

        // Assert - validate player is dead
        Assert.IsFalse(isAlive);
    }

    [Test]
    public void Player_Health_Does_Not_Go_Below_Zero()
    {
        // Arrange - new instance of Player
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        int damage = 150;

        // Act - apply damage of 150
        player.takeDamage(damage);
        int currentHealth = player.getHealth();

        // Assert - validate health does not go below 0
        Assert.AreEqual(0, currentHealth);
    }

    [Test]
    public void Player_Heals_Correctly()
    {
        // Arrange - new instance of Player
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        int damage = 50;

        // Act - apply damage 50 and then heal with medkit, adding 20 health
        player.takeDamage(damage);
        player.useMedkit();
        int currentHealth = player.getHealth();

        // Assert - validate health after healing is 70
        Assert.AreEqual(70, currentHealth);
    }


    [Test]
    public void Player_Health_Does_Not_Exceed_Maximum()
    {
        // Arrange - new instance of Player
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();


        // Act - use medkit at full health
        player.useMedkit();
        int currentHealth = player.getHealth();

        // Assert - validate health does not exceed 100
        Assert.AreEqual(100, currentHealth);
    }

    [Test]
    public void Player_Can_Only_Use_1_Medkit()
    {
        // Arrange - new instance of Player
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        int damage = 50;
        int availableMedkits = player.getMedkits();

        // Act - use medkit twice
        player.takeDamage(damage);
        player.useMedkit(); // Should succeed
        player.useMedkit(); // Should fail as only 1 medkit is available

        // Assert - validate only 1 medkit was available and used
        Assert.AreEqual(0, player.getMedkits());
    }
}

