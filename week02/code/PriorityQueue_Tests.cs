using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    // TEST CASE:
    // Ensures highest priority item is dequeued first.

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

    // TEST CASE:
    // If multiple items share the highest priority, the item closest to the front
    // of the queue (FIFO) should be removed first.
    //
    // Arrange: A(2), B(5), C(5), D(1)
    // Expected: B is dequeued first (B and C tie for highest priority, B is earlier)
    // Arrange: A(2), B(5), C(5), D(1)
    // Expected: B is dequeued first (B and C tie for highest priority, B is earlier)
    [TestMethod]
    public void HighestPriorityTie_FollowsFIFOAmongHighest()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 5);
        pq.Enqueue("C", 5);
        pq.Enqueue("D", 1);

        Assert.AreEqual("B", pq.Dequeue());
    }



    [TestMethod]
    public void Dequeue_RemovesItemFromQueue()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 5);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    // TEST CASE:
    // When empty, Dequeue must throw InvalidOperationException with the message
    // "The queue is empty." (exact message requirement).


    [TestMethod]
    public void EmptyQueueThrowsException_WithExpectedMessage()
    {
        var pq = new PriorityQueue();

        var ex = Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
        Assert.AreEqual("The queue is empty.", ex.Message);
    }
}
