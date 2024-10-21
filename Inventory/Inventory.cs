using System.Diagnostics.Contracts;

namespace Inventory;

public class InventoryNode {
    public InventoryNode? left = null;
    public Item? value;
    public InventoryNode? Right = null;
    public InventoryNode(Item value) {
        this.value = value;
    }
}
public class FantasyInventory
{
    public InventoryNode? Root = null;

    public FantasyInventory() {}
    
    public void Insert(Item insertItem) {
        Root = Insert(Root!, insertItem);
    }

    public InventoryNode Insert(InventoryNode Current, Item insertItem) {
        if (Current == null)
            Current = new InventoryNode(insertItem);
        if (insertItem.ID > Current.value!.ID)
            Current.Right = Insert(Current.Right!, insertItem);
        else if (insertItem.ID < Current.value.ID)
            Current.left = Insert(Current.left!, insertItem);
        return Current;
    }

    public void IOTraversal() {
        IOTraversal(Root!);
    }
    public void IOTraversal(InventoryNode Root) {
        if (Root != null) {
            IOTraversal(Root.left!);
            Console.WriteLine($"[ {Root.value!.Display()} ]");
            IOTraversal(Root.Right!);
        }
    }

    public InventoryNode Find(Item Target) {
        return Find(Target);
    }

    public InventoryNode Find(InventoryNode Current, Item Target) {
        if (Current.value!.ID > Target.ID)
            return Find(Current.Right!, Target);
        else if (Current.value.ID < Target.ID)
            return Find(Current.left!, Target);
        return Current;
    }

    public void Delete(Item DeleteNode) {
        Delete(Root!, DeleteNode);
    }

    public void Delete(InventoryNode Current, Item DeleteNode) {
        if (Current == null)
            return;

        if (Current.left == null && Current.Right == null) {
            if (Current.value!.ID == DeleteNode.ID) {
                Current = null;
                return;
            }
            else
                return;
        }

    static void deleteDeepest(InventoryNode root, Item DeleteNode)
    {
        Queue<InventoryNode> q = new();
        q.Enqueue(root);

        InventoryNode temp = null;

        // Do level order traversal until last node
        while (q.Count != 0) {
            temp = q.Peek();
            q.Dequeue();

            if (temp.value.ID == DeleteNode.ID) {
                temp = null;
                return;
            }
            if (temp.Right != null) {
                if (temp.Right.value.ID == DeleteNode.ID) {
                    temp.Right = null;
                    return;
                }

                else
                    q.Enqueue(temp.Right);
            }

            if (temp.left != null) {
                if (temp.left.value.ID == DeleteNode.ID) {
                    temp.left = null;
                    return;
                }
                else
                    q.Enqueue(temp.left);
            }
        }
    }

        Queue<InventoryNode> q = new Queue<InventoryNode>();
        q.Enqueue(Current);
        InventoryNode temp = null, keyNode = null;

        // Do level order traversal until
        // we find key and last node.
        while (q.Count != 0) {
            temp = q.Peek();
            q.Dequeue();

            if (temp.value.ID == DeleteNode.ID)
                keyNode = temp;

            if (temp.left != null)
                q.Enqueue(temp.left);

            if (temp.Right != null)
                q.Enqueue(temp.Right);
        }

        if (keyNode != null) {
            int x = temp.value.ID;
            keyNode.value = x;
            deleteDeepest(Current, DeleteNode);
        }
    }

    public void OptimizeTree() {
        if (GetHeight(Root.left) < GetHeight(Root.Right)) {
            //rotate left
        }
        else if (GetHeight(Root.left) > GetHeight(Root.Right)) {
            //rotate right
        }
        //do nothing
    }

    public bool IsBalanced() => GetHeight(Root!.left!) == GetHeight(Root.Right!);

    public int GetHeight(InventoryNode Current) => Current == null ? -1 : Math.Max( GetHeight(Current.left!), GetHeight(Current.Right!) + 1 );
}