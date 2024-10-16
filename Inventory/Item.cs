namespace Inventory;

public class Item {
    public int ID { get; private set; }
    public string Name { get; private set; }
    public Type ItemType { get; private set; }
    public Rarity ItemRarity { get; private set; }
    public int Strength { get; private set; }

    public Item(int ID, string Name, Type ItemType, Rarity ItemRarity, int Strength) {
        this.ID = ID;
        this.Name = Name;
        this.ItemType = ItemType;
        this.ItemRarity = ItemRarity;
        this.Strength = Strength;
    }

    public string Display() => $"{ID}, {Name}, {ItemType}, {ItemRarity}, {Strength}";
}