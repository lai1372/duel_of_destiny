using UnityEngine;
using NUnit.Framework;
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
}

