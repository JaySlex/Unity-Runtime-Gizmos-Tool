# Unity-Runtime-Gizmos-Tool
This tool allows you to create runtime gizmos in unity that also get shown in playmode/build.
It can be very usefull in builds to show **Trigger** or **Colliders**.

![Capture](https://github.com/JaySlex/Unity-Runtime-Gizmo-Tool/assets/50266396/2bcae1bd-af5e-4bfe-ab80-3985bbaa3fa9)


## Features
- Works in **editor/playmode/builds**
- Draw wire cube
- Draw wire box (custom x y z size)
- Draw Box collider (Allows to draw a box collider automatically)
- Works with rotation *(unity default gizmos doesnt have rotation)*

## Example Code
RuntimeGizmosDrawer.cs should be placed on the scene camera in orde to work.
RuntimeGizmosDrawer's functions should be called in Update in order to work correctly.
```c#
RuntimeGizmosDrawer.DrawWireCube(transform.position, transform.rotation, 1, Color.green);
RuntimeGizmosDrawer.DrawWireBox(transform.position, transform.rotation, new Vector3(1, 2, 3), Color.blue);
RuntimeGizmosDrawer.DrawWireBox(boxCollider, Color.black);
```
## Futur feature
I am currently trying to figure out how to make wire mesh, circle, capsule and cylinder.

Tested on Unity 2022.3.17f1
