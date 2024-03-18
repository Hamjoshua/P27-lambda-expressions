using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace app
{
    public class LambdaExpressions
    {

        public class BinaryTree<Type>
        {
            public BinaryTreeNode<Type> Root = null;

            public void Add(Type value)
            {

            }
            public void Add(Type value)
            {

            }
        }
        public class BinaryTreeNode<Type>
        {
            public Type Key;
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
        }

        static void Main(string[] args)
        {
            var root = new BinaryTreeNode<int>(1);
            var left = new BinaryTreeNode<int>(2);
            var right = new BinaryTreeNode<int>(2);
            root.Right = right;
            root.Left = left;
        }
    }
}
