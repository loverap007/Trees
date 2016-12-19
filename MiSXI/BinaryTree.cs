using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiSXI
{
    public class BinaryTree : ITree
    {
        protected BinaryTreeNode root;
        protected int Count { get; set; }

        public BinaryTree()
        {
            root = null;
            Count = 0;
        }

        public void Add(string s) {
            var new_node = new BinaryTreeNode(s);
            if (root == null)
            {
                root = new_node;
                root.Parent = null;
            }
            else AddHelper(ref root, ref new_node);
            Count++;
        }

        protected void AddHelper(ref BinaryTreeNode cur_node, ref BinaryTreeNode new_node)
        {
            if (new_node.Phone_number < cur_node.Phone_number)
                if (cur_node.Left == null)
                {
                    new_node.Parent = cur_node;
                    cur_node.Left = new_node;
                }
                else AddHelper(ref cur_node.Left, ref new_node);
            if (new_node.Phone_number > cur_node.Phone_number)
                if (cur_node.Right == null)
                {
                    new_node.Parent = cur_node;
                    cur_node.Right = new_node;
                }
                else AddHelper(ref cur_node.Right, ref new_node);
        }

        public string Find(object obj)
        {
            return FindHelper(root, (int)obj).ToString();
        }

        protected BinaryTreeNode FindHelper(BinaryTreeNode cur_node, int key)
        {
            if (cur_node.Phone_number == key) return cur_node;
            else if (cur_node.Phone_number > key & cur_node.Left != null) return FindHelper(cur_node.Left, key);
            else if (cur_node.Right != null) return FindHelper(cur_node.Right, key);
            else return null;
        }

        public void Delete(object obj)
        {
            DeleteHelper(FindHelper(root, (int)obj));
        }

        protected void DeleteHelper(BinaryTreeNode for_del)
        {
            Count--;
            if (for_del == null | root == null) return;
            if (for_del.Left == null & for_del.Right == null)
            {
                if (for_del.Equals(root)) root = null;
                else if (for_del.Equals(for_del.Parent.Left)) for_del.Parent.Left = null;
                else for_del.Right = null;
                return;
            }
            if (for_del.Left == null)
            {
                if (for_del.Equals(root))
                {
                    root = for_del.Right;
                    return;
                }
                if (for_del.Equals(for_del.Parent.Left)) for_del.Parent.Left = for_del.Right;
                else for_del.Parent.Right = for_del.Right;
                return;
            }
            if (for_del.Right == null)
            {
                if (for_del.Equals(root))
                {
                    root = for_del.Left;
                    return;
                }
                if (for_del.Equals(for_del.Parent.Left)) for_del.Parent.Left = for_del.Left;
                else for_del.Parent.Right = for_del.Left;
                return;
            }
            if (for_del.Equals(root))
            {
                root = MostLeft(root.Right);
                root.Left = for_del.Left;
                root.Right = for_del.Right;
                root.Parent.Left = null;
                root.Parent = null;
            }
            else
            {
                if (for_del.Equals(for_del.Parent.Left))
                {
                    for_del.Parent.Left = MostLeft(for_del.Right);
                    for_del.Parent.Left.Parent.Left = for_del.Parent.Left.Right;
                    for_del.Parent.Left.Left = for_del.Left;
                    for_del.Parent.Left.Right = for_del.Right;
                    for_del.Parent.Left.Right = for_del.Parent;
                }
                else
                {
                    for_del.Parent.Right = MostRight(for_del.Left);
                    for_del.Parent.Right.Parent.Right = for_del.Parent.Right.Left;
                    for_del.Parent.Right.Left = for_del.Left;
                    for_del.Parent.Right.Right = for_del.Right;
                    for_del.Parent.Right.Parent = for_del.Parent;
                }
            }
        }

        protected BinaryTreeNode MostLeft(BinaryTreeNode node)
        {
            if (node.Left != null) return MostLeft(node.Left);
            else return node;
        }

        protected BinaryTreeNode MostRight(BinaryTreeNode node)
        {
            if (node.Right != null) return MostRight(node.Right);
            else return node;
        }
    }
}
