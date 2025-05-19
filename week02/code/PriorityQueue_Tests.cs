using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue three items with different priorities and dequeue all.
    // Expected Result: Items are dequeued in order of highest to lowest priority.
    // Defect(s) Found: Dequeue does not remove the item from the queue, so repeated calls return the same item.
    public void TestPriorityQueue_DifferentPriorities()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with the same priority and dequeue all.
    // Expected Result: Items are dequeued in FIFO order.
    // Defect(s) Found: If >= is used in Dequeue, the last inserted item is dequeued first (LIFO), not FIFO.
    public void TestPriorityQueue_SamePriority_FIFO()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 2);
        pq.Enqueue("B", 2);
        pq.Enqueue("C", 2);

        Assert.AreEqual("A", pq.Dequeue());
        Assert.AreEqual("B", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities and dequeue some, then enqueue more and dequeue all.
    // Expected Result: Always removes the highest priority, FIFO for ties, and works after more enqueues.
    // Defect(s) Found: See above.
    public void TestPriorityQueue_MixedOperations()
    {
        var pq = new PriorityQueue();
        pq.Enqueue("A", 1);
        pq.Enqueue("B", 3);
        pq.Enqueue("C", 2);

        Assert.AreEqual("B", pq.Dequeue());
        pq.Enqueue("D", 3);
        Assert.AreEqual("D", pq.Dequeue());
        Assert.AreEqual("C", pq.Dequeue());
        Assert.AreEqual("A", pq.Dequeue());
    }

    [TestMethod]
    // Scenario: Dequeue from empty queue.
    // Expected Result: Throws InvalidOperationException.
    // Defect(s) Found: None.
    public void TestPriorityQueue_Empty()
    {
        var pq = new PriorityQueue();
        Assert.ThrowsException<InvalidOperationException>(() => pq.Dequeue());
    }

    // Add more test cases as needed below.
}