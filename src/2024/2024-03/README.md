# Quest 1: Mining Maestro

## Part I

The top knights of the Golden Duck Order are famous not just for their skills in battle, but also for their talent in building. They lead all royal building projects, making sure their designs are both impressive and eco-friendly. Their buildings are praised for blending in with nature, and they are especially valued for construction methods that protect the environment during the building process.

In the Kingdom of Algorithmia, mining for gold, silver, and other resources is done in a special way. Alchemists inspect the land and mark promising areas on a grid map (*your notes*) with a `#` symbol. Once marked, mining begins, but it must be done carefully: **the height difference between adjacent areas - both side to side and top to bottom - must never be more than one unit**. Of course, mining is only allowed in the areas marked by the Alchemists with the symbol `#`.

After digging, water mages fill the holes with water, turning them into peaceful ponds that soon become lively habitats. The survival of these ponds depends on keeping the slope at the correct angle during digging. A wrong step, with a slope greater than allowed, could not only disrupt mining, but create dangerous drops in the pond, risking the safety of both people and wildlife.

For this task, think of the area as a flat landscape covered by a grid, where each square is a 1 by 1 unit of earth. The digging machine can take out entire blocks of earth, one cubic unit at a time. Your goal is to find the maximum number of earth blocks that can be safely removed from the marked area while keeping the slope at a safe angle.

### Example based on the following notes:

```
..........
..###.##..
...####...
..######..
..######..
...####...
..........
```

In the first layer, the entire marked area can be safely dug out. This allows for the removal of *25* blocks of earth.

```
..........
..111.11..
...1111...
..111111..
..111111..
...1111...
..........
```

In the second layer we must be careful. Only **9** blocks can be taken out to keep the slope smooth and avoid steep drops.

```
..........
..111.11..
...1211...
..122221..
..122221..
...1111...
..........
```

In the third layer, only **one** block of earth can be safely removed.

```
..........
..111.11..
...1211...
..123221..
..122221..
...1111...
..........
```

In total, the maximum number of earth blocks that can be removed, while keeping the slope at a safe degree, is **35**.

*How many earth blocks can be safely removed at most from your map while maintaining the proper slope?*

## Part II

Finishing the first task quickly allows you to move to the next part of this challenge. This time, **the map is much bigger and more complex**. The task remains the same, but the larger map might present some new cases to consider. Will your intelligent thinking and developed instincts be enough again?

*How many earth blocks can be safely removed at most from your new map while maintaining the proper slope?*

## Part III

### Example based on the following notes:
