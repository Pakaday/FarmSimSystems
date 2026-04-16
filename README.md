# FarmSimSystems

A C# system design project laying the groundwork for a Unity farm simulation game. Rather than jumping straight into Unity scenes, this project focuses on designing and validating the core game logic in isolation — modeling items, crop growth, and inventory management as plain C# classes before wiring them to a game engine.

## What This Is

The goal is to think through the data model and behavior of a farm sim's core systems before the complexity of Unity's component model gets involved. Each class is independently testable in a console environment, which makes it easier to reason about edge cases in growth logic and inventory stacking before they become visual bugs in a game.

## Systems

### Item

Represents any collectible or usable object in the game world. Items have an `Id`, `Name`, `Quantity`, and a `Rarity` tier.

```
Rarity: Bronze | Silver | Gold
```

### Crop

Models a plant's growth lifecycle from planting through harvest. Each crop progresses through four stages based on a configurable number of days per stage.

```
CropStage: Seed → Sprout → Mature → Harvest
```

`AdvanceDay()` increments the day counter and automatically promotes the crop to the next stage when the threshold is met. The crop holds a reference to the `Item` it yields at harvest, keeping the harvest outcome part of the crop's definition.

### Inventory

A dictionary-backed item store keyed by item ID. Handles two cases cleanly:
- **Existing item:** adds to quantity (stacking)
- **New item:** inserts a new entry

Removing an item reduces quantity and automatically cleans up the entry when it reaches zero.

## Example Output

```
Day 1: Wheat is at stage Sprout.
Day 2: Wheat is at stage Sprout.
Day 3: Wheat is at stage Mature.
Day 4: Wheat is at stage Mature.
Day 5: Wheat is at stage Harvest.
Day 6: Wheat is ready to harvest! You get 1 Wheat(s).
```

## Running

```bash
cd FarmSimSystems
dotnet run
```

## Design Intent

This is an early-stage systems design project. The intent is to build out a complete set of validated game mechanics in plain C# first, then bring them into Unity. Separating the logic from the engine makes each system easier to reason about, refactor, and eventually test.

## What's Next

- **Farmplot** — a tile that holds a crop and tracks watering state
- **Player** — holds an inventory, can plant and harvest crops
- **Time system** — advances all active crops each in-game day
- **Save/load** — serialize game state to JSON
- **Unity integration** — attach these systems to MonoBehaviours once the logic is stable
