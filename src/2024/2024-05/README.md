# Quest 5: Pseudo-Random Clap Dance

## Part I

No grand tournament is complete without lively music and spirited dancing! As evening falls, crowds gather in the main square to partake in the whimsical **Pseudo-Random Clap Dance**. Each participant receives a number from the Master of Ceremonies which is then prominently displayed on their chest. Then, they choose their places in one of **four columns**, standing one behind the other, forming long lines.

With everyone in position, the dance begins. It unfolds in **rounds**, with each round featuring one person designated as the **Clapper**. In the first round, the Clapper is the first person in the first column. In the second round, it's the first person in the second column, followed by the first person in the third column in the third round, and finally, the first person in the fourth column in the fourth round.

The Clapper **moves** to the beginning of the column to their right, facing its members. If the Clapper is from the fourth column, they move to the start of the first column. All members of that column **extend their arms to the sides**. The Clapper then **dances around the column** from the left, high-fiving each extended hand. Upon reaching the end of the column, they switch to the right side and continue in the opposite direction. The crowd **counts each clap out loud**, starting from one. **When the shouted number matches the Clapper's chest number, an absorption occurs**.

A Clapper can be **absorbed into the column** in two ways. If they are circling from the left side, they are absorbed **in front of** the person they are high-fiving. If on the right side, they are absorbed **behind** that person.

After absorption, the first person from each column combines their numbers into a **single large number**, shouting it out loud before the next round begins.

Just before the start, the king delivers a brief speech, concluding with a caution to the knights participating in the tournament to remain vigilant! You decide to **practice predicting the flow of the dance**, so you note down all columns (*your notes*) as seen from above.

### Example based on the following notes:

1|2|3|4
-|-|-|-
-|-|-|-
2|3|4|5
3|4|5|2
4|5|2|3
5|2|3|4

The first Clapper is the person marked with 2 on the top left side. After the initial move to the next column, it looks like this:

1|2|3|4
-|-|-|-
-|-|-|-
 ||2| | 
3|3|4|5
4|4|5|2
5|5|2|3
 |2|3|4

Clapping time! The Clapper's number is 2, so there will be only 2 claps.


"ONE!"|||||"TWO!"
-------|---------
3|`2`3|4|5| |3|3|4|5
4|4|5|2| |4|`2`4|5|2
5|5|2|3| |5|5|2|3
||2|3|4| ||2|3|4

The Clapper is on the left side of the target column, so absorption results in them taking the place in front of the last high-fived dancer.

-|-|-|-
-|-|-|-
3|3|4|5
4|`2`|5|2|
5|4|2|3|
 ||5|3|4
 ||2||


The people in the front combine their numbers and shout:

|`"3`|`3`|`4`|`5!"`|
-|-|-|-
`3`|`3`|`4`|`5``
4| 2| 5| 2
5| 4| 2| 3
  |5| 3| 4
  ||2|

The result of the first round is **3345**.

The second round goes like this:

| | | | | | | |`3`| | |"ONE!"| | | | |"TWO!"| | | | |"THREE!"| | | | | | | | | |"3245!"| | | |
-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|
3|`3`|4|5| |3|2|4|5| |3|2|`3`4|5| |3|2|4|5| |3|2|4|5| |3|2|4|5| |3|2|4|5
4|2|5|2| |4|4|5|2| |4|4|5|2| |4|4|`3`5|2| |4|4|5|2| |4|4|5|2| |4|4|5|2
5|4|2|3| |5|5|2|3| |5|5|2|3| |5|5|2|3| |5|5|`3`2|3| |5|5|`3`|3| |5|5|3|3
| |5|3|4| | |2|3|4| | |2|3|4| | |2|3|4| | |2|3|4| | |2|2|4| | |2|2|4
| |2| | | | | | | | | | | | | | | | | | | | | | | | | |3| | | | |3||

The third round:

|||||||||`4`||"ONE!"|||||"TWO!"|||||"THREE!"|||||"FOUR!"||||||||||"3255!"||||
-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|
3|2|`4`|5| |3|2|5|5| |3|2|5|`4`5| |3|2|5|5|    |3|2|5|5|    |3|2|5|5|    |3|2|5|5|   |3|2|5|5
4|4|5|2|   |4|4|3|2| |4|4|3|2|    |4|4|3|`4`2| |4|4|3|2|    |4|4|3|2|    |4|4|3|2|   |4|4|3|2
5|5|3|3|   |5|5|2|3| |5|5|2|3|    |5|5|2|3|    |5|5|2|`4`3| |5|5|2|3|    |5|5|2|3|   |5|5|2|3
||2|2|4|   | |2|3|4| | |2|3|4|    | |2|3|4|    | |2|3|4|    | |2|3|`4`4| | |2|3|`4`| | |2|3|4
|| |3| |   | | | | | | | | | |    | | | | |    | | | | |    | | | |    | | | | |4|   | | | |4

The following round:

||||||`5`|||||"ONE!"|||||"TWO!"|||||"THREE!"|||||"FOUR!"|||||"FIVE!"||||||||||"3252!"||||
-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|-|
3|2|5|`5`| |3|2|5|2| |`5`3|2|5|2| |3|2|5|2|    |3|2|5|2|    |3|2|5|2|    |3|2|5|2|    |3|2|5|2|     |3|2|5|2
4|4|3|2  | |4|4|3|3| | 4  |4|3|3| |`5`4|4|3|3| |4|4|3|3|    |4|4|3|3|    |4|`5`4|3|3| |4|4|3|3| |4|4|3|3
5|5|2|3  | |5|5|2|4| | 5  |5|2|4| | 5 |5|2|4|  |`5`5|5|2|4| |5`5`|5|2|4| |5|5|2|4|    |5|5|2|4| |5|5|2|4
| |2|3|4 | | |2|3|4| |    |2|3|4| |   |2|3|4|  | |2|3|4|    | |2|3|4|    | |2|3|4|    |5|2|3|4| |5|2|3|4
| | | |4 |

Note that the Clapper ends on the right side of the column, so the target place in this case is **behind** the last high-fived person.

For this example, the numbers shouted at the end of each round are as follows:

|Round | Number|
|--------------|
|1     | 3345  |
|2     | 3245  |
|3     | 3255  |
|4     | 3252  |
|5     | 4252  |
|6     | 4452  |
|7     | 4422  |
|8     | 4423  |
|9     | 2423  |
|10    | 2323  |

*What is the number shouted at the end of the 10th round?*

## Part II

The first dance went exactly as you predicted, so you feel ready for the real challenge.

For the upcoming dance, the master of ceremonies meticulously assigns numbers and personally positions the participants in columns. The king takes the stage once more:
 
> As you know, in our traditional dance some of the numbers shouted at the end of each round 
 can eventually repeat. The next dance will conclude in the round where one of the numbers 
 at the end of the round is shouted for the 2024th time! Your task, my dear knights,
 is to **predict this number and the duration of the dance**. Multiply the final number
 by the round in which it was shouted for the 2024th time to get your final answer.
>
> Good luck!

### Example based on the following notes:

```
2 3 4 5
6 7 8 9
```

In this example, the dance unfolds as follows:

Round | Number | Shouts
------|--------|-------
1:    | 6345   | 1	    
2:    | 6245   | 1	    
3:    | 6285   | 1	    
4:    | 5284   | 1	    
5:    | 6584   | 1	    
6:    | 6254   | 1	    
7:    | 6285   | 2	    
8:    | 5284   | 2	    
9:    | 6584   | 2	    
10:   | 6254   | 2	    
...   |        |	    
8095: | 6285   | 2024  

After 10 rounds, some numbers were shouted twice already: 6285, 5284, 6584, and 6254. By continuing further, the first number shouted for the 2024th time is **6285**, and this happens at the end of round **8095**.

Multiplying 6285 by 8095 gives the final answer: **50877075**.

*What do you get if you multiply the first number shouted for the 2024th time by the total number of dance rounds?*

## Part III

Time for the final dance! The Master of Ceremonies once again arranges everyone with the utmost care.
The king presents another riddle:
 
> Sadly, every good time must come to an end eventually,
> but what if our next dance were to go on forever? 
> Can you predict what would be the highest number that could be shouted? 
    
### Example based on the following notes:

```
2 3 4 5
6 7 8 9
```

Assuming this dance would never end, the highest number shouted would be: `6584`.

*What is the highest possible number that can appear at the end of a round in the final dance?*
