War Thunder crew administration
================

You can use it to keep track of your crews (up to 9 per nation) in War Thunder.
The code is totally open and free, so change anything and everything. Let me know if you like it!

(I'm not saying it's perfect, but I think it will serve as a nice starting point!)

----------------

Features:

- Keep track of 5 nations with 9 crews each.
Everything you enter into the application is persistent, so it stays with the application after you shut it down.
- Crews each have a level, an amount of experienced gunners, an experience level and an empty text field, so you can keep track of whatever you'd like.


Programming:

- Data is saved in Json and then in a text file, this makes it really easy to edit (since it is human readable).
- Written in C# with (hopefully) clear variable names, might make for a nice project to practice programming on.


Possible additions:

- Variable amount of crews per nation, so that when you have 6 crews in the game, you won't see crews 7, 8 and 9.
- Ditching the slow collection of TextBoxes, ComboBoxes and NumericUpDown thingies and replacing it all with a nice (Object)ListView or something.
