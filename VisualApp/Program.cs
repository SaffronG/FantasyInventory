using System.IO.Pipes;
using System.Reflection.Metadata;
using Inventory;

FantasyInventory pack = new();

// TOP
pack.Insert(new Item(50, "Sword of Truth", Inventory.Type.Weapon, Rarity.Legendary, 100));
//LEFT
pack.Insert(new Item(25, "Potion of Healing", Inventory.Type.Potion, Rarity.Common, 10));
//RIGHT
pack.Insert(new Item(75, "Shield of Valor", Inventory.Type.Shield, Rarity.Rare, 50));
//LEFT, LEFT
pack.Insert(new Item(10, "Ring of Power", Inventory.Type.Accessory, Rarity.Legendary, 200));
// LEFT, RIGHT
pack.Insert(new Item(30, "Dagger of Shadows", Inventory.Type.Weapon, Rarity.Rare, 80));
// RIGHT, LEFT
pack.Insert(new Item(60, "Cloak of Invisibility", Inventory.Type.Armor, Rarity.Legendary, 120));
// RIGHT, RIGHT
pack.Insert(new Item(80, "Staff of Wisdom", Inventory.Type.Weapon, Rarity.Common, 30));
// LEFT, LEFT, LEFT
pack.Insert(new Item(5, "Boots of Swiftness", Inventory.Type.Accessory, Rarity.Rare, 40));

pack.IOTraversal();