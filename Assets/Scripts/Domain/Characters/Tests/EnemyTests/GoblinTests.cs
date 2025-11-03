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
}

