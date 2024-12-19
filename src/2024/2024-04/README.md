# Quest 4: Royal Smith's Puzzle

## Part I

One of the grand tournament's most time-honoured traditions is the Master of the Royal Forge challenge. Knights proceed to the colossal forge, where the song of steel echoes from afar. The King's Smith awaits, silently gesturing towards a section of the courtyard where wooden logs have been meticulously arranged. **Massive nails**, with heads the size of a human hand, are embedded in the logs. Next to each log lies a hammer. Each contender stands by one.

The blacksmith explains the rules of the first round. Several nails have been driven into the top of the log, each protruding at a **different height**. You must drive the nails into the logs so that their heads **form a perfectly straight line**.

You begin hammering, but it's hard to tell if the nail has moved even a fraction. It seems this will be a test of endurance... To pass the time, you note the **length each nail** protrudes. It turns out that they are precisely measured, each expressed in whole units. Additionally, you notice that each nail head has a small black dot in the center. Examining your hammer closely, you find a similar dot on its head. You take a swing, aiming to align the dots upon impact. The nail drives into the log **exactly one unit deeper with each strike**! It's not about endurance, but precision and accuracy! The blacksmith glances your way and smiles knowingly. You know the length of all the nails (`your notes`), so you can calculate **how many strikes at minimum** it will take to align them all perfectly.

### Example based on the following notes:

```
3
4
7
8
```

The lengths of the nails are 3, 4, 7, and 8 units. The shortest nail is 3 units, and the rest must be levelled to this height.
It takes **1 strike** to drive the 4-unit nail to 3 units; **4 strikes** to bring the 7-unit nail down to 3 units; and **5 strikes** to do the same for the 8-unit nail.

In total, you need **10 strikes** of the hammer.

*What is the minimum number of hammer strikes needed to level all the nails?*

## Part II

As soon as the last nail is perfectly aligned with the others, the log begins to rotate with a soft creak, revealing another side **bristling with many more nails**, each awaiting its turn to be levelled. Despite the seemingly endless challenge, the rules remain unchanged: your task is to hammer each nail into the log until their heads are perfectly level, forming a straight, unbroken line across the surface of the log. You take a deep breath, knowing that precision and patience will once again be your greatest allies in this test of skill.

What is the minimum number of hammer strikes needed to level all the nails?

## Part III

You're getting the hang of it and swiftly complete the task. The log rotates again, revealing another section filled with nails. This time, however, the nails have additional **white dots**. Inspecting your hammer once more, you notice that the other side of the head has a corresponding white dot. Curious, you align the dots and strike. To your surprise, the **nail moves up exactly one unit**!

The nails are much longer than before, so it would be wise to level them in the most efficient manner possible. To achieve this, you must first determine the optimal height to which the nails should be driven or pulled so that the **total number of hammer strikes is minimized**.

### Example based on the following notes:

```
2
4
5
6
8
```

The lengths of the nails are 2, 4, 5, 6, and 8 units. Assuming you want to level them all to 5 units, you need to hit the 2-unit nail **3 times** and the 4-unit nail **once** on their white dots, and strike the 6-unit nail **once** and the 8-unit nail **3 times** on their black dots.

In total, this requires **8 hammer strikes**, which is the **minimal number** for this nail set.

*What is the minimum number of hammer strikes needed to level all the nails?*
