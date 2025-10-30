using UnityEngine;
using NUnit.Framework;
using NUnit.Framework.Internal;
public class PlayerTests
{
    [Test]
    public void Player_Starts_With_Correct_Health()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();

        // Act
        int initialHealth = player.getHealth();

        // Assert
        Assert.AreEqual(100, initialHealth);
    }

    [Test]
    public void Player_Takes_Damage_Correctly()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        int damage = 20;

        // Act
        player.takeDamage(damage);
        int currentHealth = player.getHealth();

        // Assert
        Assert.AreEqual(80, currentHealth);
    }

    [Test]
    public void Player_is_Dead_When_Health_Reaches_Zero()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        int damage = 100;

        // Act
        player.takeDamage(damage);
        bool isAlive = player.isAlive();

        // Assert
        Assert.IsFalse(isAlive);
    }

    [Test]
    public void Player_Health_Does_Not_Go_Below_Zero()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        int damage = 150;

        // Act
        player.takeDamage(damage);
        int currentHealth = player.getHealth();

        // Assert
        Assert.AreEqual(0, currentHealth);
    }

    [Test]
    public void Player_Heals_Correctly()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();
        int damage = 50;

        // Act
        player.takeDamage(damage);
        player.useMedkit();
        int currentHealth = player.getHealth();

        // Assert
        Assert.AreEqual(70, currentHealth);
    }


    [Test]
    public void Player_Health_Does_Not_Exceed_Maximum()
    {
        // Arrange
        GameObject playerObject = new GameObject();
        Player player = playerObject.AddComponent<Player>();


        // Act
        player.useMedkit();
        int currentHealth = player.getHealth();

        // Assert
        Assert.AreEqual(100, currentHealth);
    }
}

