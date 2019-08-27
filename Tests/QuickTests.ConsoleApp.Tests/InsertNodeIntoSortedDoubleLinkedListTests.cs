using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class InsertNodeIntoSortedDoubleLinkedListTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(DoublyLinkedListNode head, int data, DoublyLinkedListNode expectedResult)
        {
            DoublyLinkedListNode result = null;

            var current = head;
            var prev = head.prev;

            do
            {
                if (current == null)
                {
                    var newNode = new DoublyLinkedListNode(data);
                    newNode.prev = prev;
                    prev.next = newNode;
                    break;
                }

                if (current.data > data)
                {
                    var newNode = new DoublyLinkedListNode(data);
                    newNode.prev = current.prev;
                    newNode.next = current;
                    if (current.prev != null)
                    {
                        current.prev.next = newNode;
                    }

                    current.prev = newNode;

                    if (newNode.prev == null)
                    {
                        head = newNode;
                    }

                    break;
                }

                prev = current;
                current = current.next;
            }
            while (true);

            result = head;

            result.Should().BeEquivalentTo(expectedResult, option => option.IgnoringCyclicReferences());
        }

        public class DoublyLinkedListNode
        {
            public int data;
            public DoublyLinkedListNode prev;
            public DoublyLinkedListNode next;

            public DoublyLinkedListNode()
            {
            }

            public DoublyLinkedListNode(int data)
            {
                this.data = data;
            }
        }

        private static DoublyLinkedListNode GetNodes(int[] arr)
        {
            var node = new DoublyLinkedListNode();
            var currentNode = node;
            for (int i = 0; i < arr.Length; i++)
            {
                currentNode.data = arr[i];
                DoublyLinkedListNode nextNode = null;
                if (i + 1 < arr.Length)
                {
                    nextNode = new DoublyLinkedListNode();
                    nextNode.prev = currentNode;
                    currentNode.next = nextNode;

                    currentNode = nextNode;
                }
            }

            return node;
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                GetNodes(new [] { 1, 3, 4, 10 }),
                5,
                GetNodes(new [] { 1, 3, 4, 5, 10 }),
            };
            yield return new object[] {
                GetNodes(new [] { 1, 2, 3 }),
                4,
                GetNodes(new [] { 1, 2, 3, 4 }),
            };
            yield return new object[] {
                GetNodes(new [] { 2, 3, 4 }),
                1,
                GetNodes(new [] { 1, 2, 3, 4 }),
            };
        }
    }
}
