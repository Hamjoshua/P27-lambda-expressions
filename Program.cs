using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace app
{
    public class LambdaExpressions
    {
        public class BinaryTree<Type> : IEnumerable<Type> where Type : IComparable<Type>
        {
            public class BinaryTreeNode<Type> where Type : IComparable<Type>
            {
                public Type Key;
                public int Level;
                private BinaryTreeNode<Type> _right = null;
                private BinaryTreeNode<Type> _left = null;
                public BinaryTreeNode<Type> Right
                {
                    get
                    {
                        return _right;
                    }
                    set
                    {
                        _right = value;
                        if (value != null)
                        {
                            value.Parent = this;
                            value.Level = this.Level + 1;
                        }
                    }
                }
                public BinaryTreeNode<Type> Left
                {
                    get
                    {
                        return _left;
                    }
                    set
                    {
                        _left = value;
                        if (value != null)
                        {
                            value.Parent = this;
                            value.Level = this.Level + 1;
                        }
                    }
                }

                public BinaryTreeNode<Type> Parent;

                public BinaryTreeNode(Type key)
                {
                    Key = key;
                }

                public BinaryTreeNode(Type key, BinaryTreeNode<Type> parentNode)
                {
                    Key = key;
                    Parent = parentNode;
                }
                public override string ToString()
                {
                    string margin = new string(' ', Level * 2);

                    string left = Left == null ? $"{margin}  null" : Left.ToString();
                    string right = Right == null ? $"{margin}  null" : Right.ToString();
                    return $"{margin}({Key}" +
                        $"\n{left}" +
                        $"\n{right}" +
                        $"\n{margin})";
                }
            }

            public BinaryTreeNode<Type> Root;
            private List<BinaryTreeNode<Type>> _leaves;

            public BinaryTree(Type value)
            {
                Root = new BinaryTreeNode<Type>(value);
                Root.Level = 0;
                _leaves = new List<BinaryTreeNode<Type>>();
                _leaves.Add(Root);
            }

            public BinaryTreeNode<Type> Current;

            private bool Move(bool nextDirection)
            {
                if (Current == null)
                {
                    Current = _leaves[0];
                    return nextDirection; // при вызове Previous поле Current будет уже на 0 индексе, а назад нельзя
                }

                int indexOfCurrent = _leaves.IndexOf(Current);
                int newIndex = 0;

                if (nextDirection)
                {
                    if (indexOfCurrent == _leaves.Count() - 1)
                    {
                        return false;
                    }
                    newIndex = indexOfCurrent + 1;
                }
                else
                {
                    if (indexOfCurrent == 0)
                    {
                        return false;
                    }
                    newIndex = indexOfCurrent - 1;
                }

                Current = _leaves[newIndex];
                return true;
            }

            public bool Next()
            {
                return Move(true);
            }

            public bool Previous()
            {
                return Move(false);
            }

            public void Reset()
            {
                Current = null;
            }

            public void Add(Type value)
            {
                Add(value, Root);
            }

            private void Add(Type value, BinaryTreeNode<Type> currentNode)
            {
                int comparsionResult = value.CompareTo(currentNode.Key);
                if (comparsionResult > 0)
                {
                    if (currentNode.Right == null)
                    {
                        currentNode.Right = new BinaryTreeNode<Type>(value);
                        _leaves.Add(currentNode.Right);
                        return;
                    }
                    Add(value, currentNode.Right);
                }
                else if (comparsionResult < 0)
                {
                    if (currentNode.Left == null)
                    {
                        currentNode.Left = new BinaryTreeNode<Type>(value);
                        int indexOfCurrentNode = _leaves.IndexOf(currentNode);
                        if (Current != null)
                        {
                            int indexOfCurrent = _leaves.IndexOf(Current);
                            if (indexOfCurrent == indexOfCurrentNode)
                            {
                                Current = currentNode.Left;
                            }
                        }

                        _leaves[indexOfCurrentNode] = currentNode.Left;
                        return;
                    }
                    Add(value, currentNode.Left);
                }
            }

            public override string ToString()
            {
                return Root.ToString();
            }

            public IEnumerator<Type> GetEnumerator()
            {
                for (int leaveIndex = 0; leaveIndex < _leaves.Count; ++leaveIndex)
                {
                    yield return _leaves[leaveIndex].Key;
                }
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                throw new NotImplementedException();
            }
        }

        public static Func<BinaryTree<int>, int> SumOf = null;

        static void Main(string[] args)
        {
            Random random = new Random();
            BinaryTree<int> binaryTree = new BinaryTree<int>(10);

            SumOf = (x) => x.Next() != false ? x.Current.Key + SumOf(x) : 0;

            for (int counter = 0; counter < 5; ++counter)
            {
                int number = random.Next(5, 15);
                binaryTree.Add(number);
            }
            Console.WriteLine($"Заполненное бинарное дерево:\n{binaryTree}");

            Console.WriteLine("\nЛистья дерева без левого элемента:");
            foreach (int key in binaryTree)
            {
                Console.WriteLine(key);
            }

            Console.WriteLine($"\nСумма всех листьев дерева, у которых нет левого элемента: {SumOf(binaryTree)}");

            Console.ReadLine();
        }
    }
}
