# Racing Simulator

CIS 350 Semester Project

## Tech Stack

| Tool | Used for |
| --- | --- |
| Unity + C# | Game engine and gameplay logic |
| Blender | 3D models (cars, track, environment) |
| GitHub Projects | Task tracking and project management |

## Repository Layout

| Path | Contents |
| --- | --- |
| `unity_project/` | The Unity project — open this folder in Unity (currently a scratch/demo project) |
| `docs/` | Design and reference documentation |

## Documentation

| Document | What's in it |
| --- | --- |
| [docs/design.md](docs/design.md) | Project scope — features, assets, and settings, with core vs. stretch goals |
| [docs/controls.md](docs/controls.md) | Keyboard and controller input mappings |
| [docs/learning-material.md](docs/learning-material.md) | Unity and Blender tutorials |

## Getting Started

1. Install [Unity Hub](https://unity.com/download) and **Unity 6.6**. Everyone must use the same editor version to avoid project conflicts.
2. Clone the repo:
   ```
   git clone https://github.com/vazqurog/racing-sim.git
   ```
3. In Unity Hub, click **Add** and select the `unity_project/` folder.
4. Open the project.

> Blender is only needed if you're working on 3D assets.

## Build & Run

<!-- TODO: Fill in once the project is set up. -->

**Run in the editor**

<!-- TODO: which scene to open, then press Play. -->

**Create a build**

<!-- TODO: build target(s), File > Build Settings steps, output location. -->

**Controls**

See [docs/controls.md](docs/controls.md).

## Workflow

- Track all tasks in **GitHub Projects**.
- Create a branch for your work, then open a pull request into `master`.
- Keep `docs/` up to date as the design evolves.

## Naming Conventions

Keep names consistent so the project stays easy to navigate.

### Branches

Format: `name/type/short-description`

| Type | For |
| --- | --- |
| `feature/` | New functionality |
| `fix/` | Bug fixes |
| `docs/` | Documentation changes |
| `asset/` | 3D models, textures, audio |

Examples: `rogelio/feature/time-attack-mode`, `amin/fix/handbrake-input`, `ryan/asset/sports-car-model`

### Commits

Format: `type: short summary` 

Use the same types as branches (`feat`, `fix`, `docs`, `asset`, `refactor`).

Examples:
- `feat: add lap timer`
- `fix: correct gear-up input mapping`
- `docs: update control scheme`

### C# Scripts

Two rules cover almost everything:

- **PascalCase** for classes, methods, and anything public.
- **camelCase** for private fields and local variables.

One class per file, named after the class (`CarController.cs`).

```csharp
public class CarController
{
    public float MaxSpeed;      // public  -> PascalCase
    private int currentGear;    // private -> camelCase

    public void ApplyBrake()    // method  -> PascalCase
    {
        float targetSpeed = 0;  // local   -> camelCase
    }
}
```

### 3D Objects (Blender / Unity)

Format: `category_name` in lowercase with underscores.

| Category | Prefix | Example |
| --- | --- | --- |
| Cars | `car_` | `car_coupe_red` |
| Track pieces | `track_` | `track_turn_hairpin` |
| Environment | `env_` | `env_tree_pine` |
| Props | `prop_` | `prop_cone` |

Keep model, material, and texture names matching (e.g. `car_coupe` mesh → `car_coupe_mat`).

## Team

<!-- Add team member names here -->
