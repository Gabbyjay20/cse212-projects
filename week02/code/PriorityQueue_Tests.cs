using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    // TEST CASE:
    // Ensures highest priority item is dequeued first.
    //
    // TEST RESULT:
    // ❌ Failed before fix
    // Expected: "B"
    // Actual: "A"
    // ERROR FOUND:
    // Priority was ignored.
    //
    // RESULT AFTER FIX:
    // ✅ Passed
    [TestMethod]
    public void HighestPriorityDequeuedFirst()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);

        Assert.AreEqual("B", pq.Dequeue());
    }

    // TEST CASE:
    // Ensures FIFO order for same priority values.
    //
    // TEST RESULT:
    // ❌ Failed before fix
    // Expected: "A"
    // Actual: "B"
    // ERROR FOUND:
    // FIFO order not preserved.
    //
    // RESULT AFTER FIX:
    // ✅ Passed
    [TestMethod]
    public void SamePriorityFollowsFIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 3);
        pq.Enqueue("B", 3);

        Assert.AreEqual("A", pq.Dequeue());
    }

    // TEST CASE:
    // Ensures exception is thrown when queue is empty.
    //
    // TEST RESULT:
    // ✅ Passed
    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void EmptyQueueThrowsException()
    {
        var pq = new PriorityQueue();
        pq.Dequeue();
    }
}