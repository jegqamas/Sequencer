# SEQUENCER
A program that allows to create your own numbers sequence. 
Please note that this is the official repository of the program, that means official updates on source and releases will be commited/published here.

## Introduction:
Sequencer is a program that allows you to create your own sequence of numbers by adjusting properties for an element.
### The idea is simple:
- Imagine that you have an element: a cell, a living being ...etc then you put that element in an environment that good enough for that element for living, surviving and producing.
- That element can produce at least one element once during it's live time. The produced element is an exact copy of the parent element (same properties)
- The properties above are basics. The other properties can be adjusted as you like. 
For example, we make an element that live for 7 generations (or stages of live), it can give birth twice during it's live time, it can produce one element in a production stage and it can start producing at age of 2nd stage.
- After that, we start monitoring the environment and trace the element count we have in each stage. The elements count in stages will make up a sequence !!

This will give us more understanding for how sequences work, also can help studying some activities in live.
For example, to make up Fibonacci Number (see <https://en.wikipedia.org/wiki/Fibonacci_number>), we should set these properties:
1. The element does not have a limit for it's live (it can live forever).
2. The element must start producing (giving a birth, engender ...etc) at the 3rd stage of it's live time.
3. The element should be able to produce (giving a birth, engender ...etc) as long as it is alive (it has no limit to produce).
4. When that element reaches a stage of production, it will add 1 element(s) in that stage (the stage when that element is alive and can produce).

So, using Sequencer, we have at least a small idea how's Fibonacci Numbers can work on an element for example, that can live forever and produce as long as it is alive.

There are some sequences templates in the program, also the program allows you to create your own properties and save them into files !!

For the "Y: Summing digits of powers of 2" section, read "Power of number 9 !!.txt" file. 
Also see <https://math.stackexchange.com/questions/184823/summing-digits-of-powers-of-2-to-get-1-2-4-8-7-5-pattern>

Note: all sequences will be created by simulating the live of the element, no cheating and no math involved in the program except for the 
"Y: Summing digits of powers of 2" part (it use the formula to generate Y from X). 

## How to use

1. Adjust the element properties from the Properties section. (Also, you can use the properties templates section buttons for default saved sequences properties)
2. Click "Start the show" button in the controls section for one time.
3. Click "Next stage" button from the controls section to advance one stage.
4. Keep using the "Next stage" button from the controls section to create the sequence.

- All events will be listed in the Events section.
- You can start new any time by clicking "Start the show" button in the controls section. You can clear all the elements by clicking "Clear all" button in the controls section.
