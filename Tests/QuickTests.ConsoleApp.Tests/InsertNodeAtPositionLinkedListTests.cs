using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickTests.ConsoleApp.Tests
{
    public class InsertNodeAtPositionLinkedListTests
    {
        [TestCaseSource(nameof(TestData))]
        public void ShouldReturnExpectedResult(SinglyLinkedListNode head, int data, int position, SinglyLinkedListNode expectedResult)
        {
            SinglyLinkedListNode result = null;

            var current = head;
            for (var i = 0; i < position; i++)
            {
                if (i == position - 1)
                {
                    var newNode = new SinglyLinkedListNode
                    {
                        data = data,
                        next = current.next
                    };
                    current.next = newNode;
                    break;
                }

                current = current.next;
            }

            result = head;

            result.Should().BeEquivalentTo(expectedResult);
        }

        public class SinglyLinkedListNode
        {
            public int data;
            public SinglyLinkedListNode next;
        }

        private static SinglyLinkedListNode GetSinglyLinkedListNodes(int[] arr)
        {
            var node = new SinglyLinkedListNode();
            var currentNode = node;
            for (int i = 0; i < arr.Length; i++)
            {
                currentNode.data = arr[i];
                SinglyLinkedListNode nextNode = null;
                if (i + 1 < arr.Length)
                {
                    nextNode = new SinglyLinkedListNode();
                    currentNode.next = nextNode;
                    currentNode = nextNode;
                }
            }

            return node;
        }

        private static IEnumerable<object[]> TestData()
        {
            yield return new object[] {
                GetSinglyLinkedListNodes(new [] { 1, 2, 3 }),
                4,
                2,
                GetSinglyLinkedListNodes(new [] { 1, 2, 4, 3 }),
            };
            yield return new object[] {
                GetSinglyLinkedListNodes(new [] { 16, 13, 7 }),
                1,
                2,
                GetSinglyLinkedListNodes(new [] { 16, 13, 1, 7 }),
            };
        }
    }
}
