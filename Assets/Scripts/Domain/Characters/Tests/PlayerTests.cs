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
}

