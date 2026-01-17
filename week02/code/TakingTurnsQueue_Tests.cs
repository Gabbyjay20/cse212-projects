using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 1 - Run test cases and record any defects the test code finds in the comment above the test method.
// DO NOT MODIFY THE CODE IN THE TESTS in this file, just the comments above the tests. 
// Fix the code being tested to match requirements and make all tests pass. 

[TestClass]
public class TakingTurnsQueueTests
{
    // TEST CASE:
    // Create a queue with Bob (2), Tim (5), Sue (3) and run until empty.
    // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    //
    // TEST RESULT:
    // ❌ Failed before fix
    // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Actual: Wrong order and premature removal due to stack implementation and incorrect re-enqueue logic.
    // ERROR FOUND:
    // PersonQueue used LIFO instead of FIFO; infinite turns not handled correctly.
    //
    // RESULT AFTER FIX:
    // ✅ Passed
    [TestMethod]
    public void TestTakingTurnsQueue_FiniteRepetition()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        while (players.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
            i++;
        }
    }

    // TEST CASE:
    // Create a queue with Bob (2), Tim (5), Sue (3), run 5 times, add George (3), run until empty.
    // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    //
    // TEST RESULT:
    // ❌ Failed before fix
    // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, George, Sue, Tim, George, Tim, George
    // Actual: Wrong order and incorrect handling of added player due to stack and logic errors.
    // ERROR FOUND:
    // PersonQueue LIFO caused wrong order; re-enqueue logic failed for infinite and finite turns.
    //
    // RESULT AFTER FIX:
    // ✅ Passed
    [TestMethod]
    public void TestTakingTurnsQueue_AddPlayerMidway()
    {
        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", 5);
        var sue = new Person("Sue", 3);
        var george = new Person("George", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, george, sue, tim, george, tim, george];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        int i = 0;
        for (; i < 5; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        players.AddPerson("George", 3);

        while (players.Length > 0)
        {
            if (i >= expectedResult.Length)
            {
                Assert.Fail("Queue should have ran out of items by now.");
            }

            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);

            i++;
        }
    }

    // TEST CASE:
    // Create a queue with Bob (2), Tim (0, infinite), Sue (3), run 10 times.
    // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    //
    // TEST RESULT:
    // ❌ Failed before fix
    // Expected: Bob, Tim, Sue, Bob, Tim, Sue, Tim, Sue, Tim, Tim
    // Actual: Tim removed after first turn instead of staying forever.
    // ERROR FOUND:
    // Infinite turns (0) not re-enqueued; wrong logic for turns <=0.
    //
    // RESULT AFTER FIX:
    // ✅ Passed
    [TestMethod]
    public void TestTakingTurnsQueue_ForeverZero()
    {
        var timTurns = 0;

        var bob = new Person("Bob", 2);
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [bob, tim, sue, bob, tim, sue, tim, sue, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(bob.Name, bob.Turns);
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        // Verify that the people with infinite turns really do have infinite turns.
        var infinitePerson = players.GetNextPerson();
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite.");
    }

    // TEST CASE:
    // Create a queue with Tim (-3, infinite), Sue (3), run 10 times.
    // Expected: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    //
    // TEST RESULT:
    // ❌ Failed before fix
    // Expected: Tim, Sue, Tim, Sue, Tim, Sue, Tim, Tim, Tim, Tim
    // Actual: Tim removed after first turn.
    // ERROR FOUND:
    // Negative turns not treated as infinite; not re-enqueued.
    //
    // RESULT AFTER FIX:
    // ✅ Passed
    [TestMethod]
    public void TestTakingTurnsQueue_ForeverNegative()
    {
        var timTurns = -3;
        var tim = new Person("Tim", timTurns);
        var sue = new Person("Sue", 3);

        Person[] expectedResult = [tim, sue, tim, sue, tim, sue, tim, tim, tim, tim];

        var players = new TakingTurnsQueue();
        players.AddPerson(tim.Name, tim.Turns);
        players.AddPerson(sue.Name, sue.Turns);

        for (int i = 0; i < 10; i++)
        {
            var person = players.GetNextPerson();
            Assert.AreEqual(expectedResult[i].Name, person.Name);
        }

        // Verify that the people with infinite turns really do have infinite turns.
        var infinitePerson = players.GetNextPerson();
        Assert.AreEqual(timTurns, infinitePerson.Turns, "People with infinite turns should not have their turns parameter modified to a very big number. A very big number is not infinite.");
    }

    // TEST CASE:
    // Try to get next person from empty queue.
    // Expected: InvalidOperationException with "No one in the queue."
    //
    // TEST RESULT:
    // ✅ Passed
    [TestMethod]
    public void TestTakingTurnsQueue_Empty()
    {
        var players = new TakingTurnsQueue();

        try
        {
            players.GetNextPerson();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("No one in the queue.", e.Message);
        }
        catch (AssertFailedException)
        {
            throw;
        }
        catch (Exception e)
        {
            Assert.Fail(
                 string.Format("Unexpected exception of type {0} caught: {1}",
                                e.GetType(), e.Message)
            );
        }
    }
}