using System.Collections;
using System.Reflection;
using System.Runtime.InteropServices;

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
        Root = Delete(Root!, DeleteNode);
    }

    public InventoryNode Delete(InventoryNode Current, Item DeleteNode) {
        InventoryNode ReplacementNode = Root;

        
    }

    public bool IsBalanced() => GetHeight(Root!.left!) == GetHeight(Root.Right!);

    public int GetHeight(InventoryNode Current) => Current == null ? -1 : Math.Max( GetHeight(Current.left!), GetHeight(Current.Right!) + 1 );
}