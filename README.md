# CarsAndCubes

UNFINISHED

Martin Ohlsson
Small car game prototype with inventory and items.

Patterns:
- Singleton in `class Singleton` (Singleton<T>)
  InputManager, in `class PlayerController` as `InputManager.Instance`
  Inventory, in `class Item` and `class InventoryUI` as `Inventory.Instance`
  
  Singletons used to make single instance of the class that could be accessed from anywhere.
    
- Observer pattern, 
  In `class Inventory` as `OnItemChanged`, in `Add();`
  Callback gets invoked when a new item is added to the inventory, `class InventoryUI` listens and calls `UpdateInventoryUi`
  
  (also tried creating `class IObserver` and `class IObservable` but had a hard time figuring out how to really use them.
  
  
- Object Pool
  As `class ObjectPool` - planned to be used while spawning new cubes but not implemented. Planned to be used with spawning items instead.
