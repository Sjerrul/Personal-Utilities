using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sjerrul.Utilities.Collections
{
    public class Staque
    {
        private const int _maxSize = 50;

        private Node _top;

        private int _count = 0;
        public int Count
        {
            get
            {
                return _count;
            }
        }

        public Staque()
        {
            
        }
        

        public void Push(object data)
        {
            Node node = new Node(data, _top);
            _top = node;

            _count++;
        }

        public object Pop()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }

            Node nodeToreturn = _top;
            _top = _top.GetPrevious();

            _count--;

            return nodeToreturn.GetData();
        }

        public object Peek()
        {
            if (_count == 0)
            {
                throw new InvalidOperationException();
            }

            Node node = _top;

            return node.GetData();
        }



        private class Node
        {
            private object _data;
            private Node _previous;

            public Node(object data, Node previous)
            {
                _data = data;
                _previous = previous;
            }

            public object GetData()
            {
                return _data;
            }

            public Node GetPrevious()
            {
                return _previous;
            }
        }
    }
}
