# Project
*Gameplay Ability System (Unity)*

## Description
*Technical gameplay system prototype. Not a full game, not a vertical slice, not a content demo.*

## Primary goal
Demonstrate the design and implementation of a modular data-driven gameplay ability system with designer-friendly tools and clear separation of responsibilities.

## Secondary goals
* Clean C# architecture
* Unity Editor tooling
* Gameplay–Design bridge
* Clear presentation (video + documentation)

---

## Project contains:

### 1. Ability System

#### Ability

* Represented as **ScriptableObject**
* Contains:
  * name
  * icon
  * cooldown data
  * cost data
  * list of effects

#### Activation

* Manual activation by player input
* Validation before activation:
  * cooldown ready
  * enough resource
* Emits events

### 2. Cooldown System

* Per-ability cooldown
* Timer-based
* Independent from ability logic
* UI-readable

### 3. Cost System

* Single resource type
* Ability checks cost before activation
* Resource regeneration over time
* Event on insufficient resource

### 4. Effect System

#### Effect Interface

* Effects executed on activation
* Multiple effects per ability

#### Set of effects:

* Damage (instant)
* Damage Over Time
* Heal / Regeneration
* Temporary Stat Modifier

### 5. Simple AI

* Stationary or simple movement
* Can receive effects
* Displays feedback (damage numbers / state)

No behavior trees, no combat logic.

### 6. Basic Player Locomotion
* 2D movement
* Simple control via WASD and arrows
* Constant speed when pressed
* No collisions at all

### 7. UI Feedback

* Ability icons / buttons
* Cooldown visualization
* Resource bar
* Basic feedback on activation

No animations, no sound polish.

### 8. Custom Inspector

* Custom inspector for Ability ScriptableObject
* Clear visualization of:
  * cooldown
  * cost
  * effect list
* Designer-friendly editing

### 9. Debug Tools

* Debug overlay or panel
* Ability state display
* Resource values
* Cooldown timers

### 10. Documentation and version control

* Clean folder structure
* Meaningful commit history
* README with:
  * Project overview
  * Architecture description
  * Design decisions
  * How to extend system

### 11. Presentation

* Video 1–2 minutes length shows:
  * abilities in action
  * UI feedback
  * custom inspector
  * debug tools

---

## Out of scope

These features are explicitly excluded:

* Progression systems
* Ability upgrades
* Multiple characters
* Inventory
* Saving / loading
* Advanced AI
* Animations / VFX polish
* Multiplayer
* Audio polish

## Non-goals

* Visual quality
* Game balance
* Content amount
* Narrative / lore

## Success criteria

* A new ability can be created without code changes
* Effects are reusable and composable
* Ability logic is not hardcoded
* System is understandable from README alone
* Video clearly communicates functionality

## Time

* Target duration: 4 weeks
* Development time: ~80 hours

## If it’s not in this document — it does not exist.

