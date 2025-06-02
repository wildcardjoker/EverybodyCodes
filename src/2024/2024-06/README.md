# Quest 6: 

## Part I
On this beautiful taksunny day, the tournament participants are directed to the royal gardens, specifically to the orchards where the trees cultivated for magical potions are meticulously tended to.

Among these trees are the **apples of superhuman strength**, which transform anyone who consumes them into a titan of power. The cultivation of these remarkable fruits requires a specific approach, as the potency of each apple depends on whether it shares resources with other apples.

**Fruits with paths of the same length to the root share resources**. If all branches were cut to ensure that the final paths have unique lengths, the harvest would be drastically reduced. Therefore, it was decided that each tree would maintain **exactly one path to a fruit with a unique length**.

Each knight approaches a tree and takes a moment to observe its branches (*your notes*). The root is marked with `RR` and the fruits are represented by `@`. The remaining letters denote the branches. The notes are organised as a list of lines, each beginning with a branch name followed by a colon as a separator. After that, there is a list of branches or fruits they connect to, separated by commas.

The challenge for each knight is to identify the path from the root that leads to the most powerful fruit on that tree.

### Example based on the following notes:

```
RR:A,B,C
A:D,E
B:F,@
C:G,H
D:@
E:@
F:@
G:@
H:@
```

Based on the connections from the notes, the following tree can be reconstructed:

```
@ @ @   @  @
| | | @ |  |
D E F | G  H
\ | \ /  \ /
  \  |   /
   A B  C
    |
    RR
```

All the fruits, except for one, are located on branches with the same path length relative to the root. The path to this singular, most powerful fruit is: `RRB@`.

*What is the path to the most powerful fruit on your tree?*

## Part II

Each participant quickly locates the finest fruit on their tree and then ventures deeper into the garden where the trees stand much taller and more majestic. Once again, everyone finds themselves in front of a tree adorned with fruits that provide superhuman strength, with each participant diligently attempting to uncover the path to the most potent fruit among the tree’s vibrant branches.

Confident in your understanding of the rules, you carefully jot down the intricate connections of your tree and set to work. The root is still marked with `RR`; however, there are many more branches to analyse.

Given the tree's impressive size, **describe the final path using only the first letters of each branch**. For example a path with branches: `RR,ABAB,CDCD,EFEF,ROLO,@` becomes a `RACER@`.

*What is the path to the most powerful fruit on your tree?*

## Part III

### Example based on the following notes:
