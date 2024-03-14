using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace app
{
    public class LambdaExpressions
    {
        public class BinaryTreeNode<Type>
        {
            public Type Key;
            public BinaryTreeNode<Type> Right;
            public BinaryTreeNode<Type> Left;
            private Type key;

            public BinaryTreeNode(Type key)
            {
                Key = key;
            }
        }
        class BinaryTree<Type> : IEnumerable<Type>
        {
            public BinaryTreeNode<Type> Root;

            // todo
            public BinaryTree(Type key)
            {
                Root = new BinaryTreeNode<Type>(key);
            }

            public Type Current
            {
                get
                {
                    return _currentTree.Key;
                }
            }

            public bool Next()
            {
                if (SubTree.Item2 == null)
                {
                    if ()
                }
                return true;
            }

            public bool Previous()
            {
                if (_keySet.Count == 0)
                {
                    return false;
                }
                _keySet.RemoveAt(_keySet.Count);
                return true;
            }

            public IEnumerator GetEnumerator()
            {
                return SubTree;
            }


            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        static void Main(string[] args)
        {

        }
    }
}
