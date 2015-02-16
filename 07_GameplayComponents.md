Now that we've got a nice environment set up, it's time to add a few components that make our game more enjoyable. We're going to include a basic GUI control so that you can see your time throughout the maze, a gameplay mechanism for winning, and a few other components to make the experience more challenging.

## Adding a GUI
The first thing that we're going to do is include a basic user interface that displays on our screen.

{x: create_gui} Create the container for a timer

1. In your project hierarchy, click Create -> UI -> Canvas

2. Under your Canvas, right-click and add a UI -> Panel item under the Canvas item

3. In the Inspector for your Panel, change the scale to {x:.25, y:.25, z:.25} - we don't want this to cover the entire screen.

4. Change the color of the panel to be more visible, also in the Inspector tab

5. If needed, zoom out to see the full UI display. Adjust the positioning of your Panel to your desired location - in our example, we're putting this in the top right corner.

6. Making sure that the Panel is selected in the scene Hierarchy, right click one more time and create a UI -> Text item in the Panel

If you run your game now, you should see your panel floating in your camera view screen. We'll create a script to show and hide this later, but for now, let's finish up with the timer. We'll want to adjust our text block first so it's visible when we add in the timing component.

{x: create_text} Add placeholder string for a timer

1. Select your text item and find the properties for the text block. For now, we can put a placeholder text in, so under the Text (Script) box, type in a temporary string.

2. Under the 'Paragraph' header, check the 'Best Fit' box and set the max size to your desired size - we chose 60. You might need to play around here to get the look you want.

3. Change the color of your text to contrast with your panel.

4. Set the Vertical and Horizontal Overflow to "Overflow".

5. Change the Alignment to center horizontally and vertically.

Now, when you run the game, you should see your static panel in your view and the text in front of you.

#Getting Started with Scripting
In Unity, all of the game play is done through scripting. You have three choices for scripting, JavaScript, Boo, and C# - we'll be doing this tutorial in C#. By default, scripting is done in MonoDevelop, a tool included with Unity, but you may have changed this going through earlier parts of the tutorial -  you can use any editor you'd like to edit scripts, but MonoDevelop is pretty good for the small ones we'll be writing in this game.

Many of the preconfigured assets that are available through Unity come with their own scripts, such as the character controller we added. For some good scripting resources and a primer, check out the following links.

[Unity3D Wiki - Scripting](http://wiki.unity3d.com/index.php/Scripts)

[Official Unity Scripting Reference](http://docs.unity3d.com/ScriptReference/)

[Unity Scripting Lessons](http://unity3d.com/learn/tutorials/modules/beginner/scripting)

## Implementing the Timer

Since we've got the placeholder text in order, it's time to actually give it some functionality. Since we're writing our first custom script for the timer, we'll launch MonoDevelop (or your IDE of choice) when we create the new file.

{x:make_timer} Create a timer script to time your maze

1. Under your Assets folder in the Project hierarchy, right-click and select Create -> C# Script. Name the new script 'TimerController'

2. Drag your TimerController file onto your Text GameObject and double-click the script to open it in your editor.

By default, Unity will generate a code template when you create new scripts from within the editor. The boilerplate code gives you everything you need for the basic functionality of your script, including two methods that will manage the initialization of the script and update it on each tick of the gameplay.

````
using UnityEngine;
using System.Collections;

public class TimerController : MonoBehaviour {

  // Use this for initialization
  void Start () {


  }

  // Update is called once per frame
  void Update () {

  }
}

````
The two methods are pretty straightforward: `Start()` is called when the scene is first rendered, and `Update()` is called on subsequent frames of the gameplay. To create the timer text, the first thing we'll want to do is add the following directive:

````
using UnityEngine.UI;
````

This will allow us to interact with our GUI objects on the screen so that we can update our text box text. Next, we'll declare our variables for two objects - the text box we're editing, and a float to store the timer. Above the `Start()` function, add the following lines:

````
static float timer = 0.0f;
public Text text_box;
````
Unity uses their editor to interact with the scripts we write, so we'll actually be assigning the `text_box` item back in Unity, rather than in code, so it's important to make sure that the `Text` item is actually visible outside of the script file.

Once we have those lines set, the next thing we'll do is include an incremental addition to the `Update()` method and update our UI to show the running time:

````
// Update is called once per frame
   void Update () {
    timer += Time.deltaTime;
    text_box.text = timer.ToString("0.00");}
````

With that, we're almost done with our first script - all that's left is assigning our UI Text box to be the one we update with the timer. Save your script and return back to Unity.

To set the target for our `text_box`:
1. Select the Text box in the Hierarchy and scroll down to the bottom of the Inspector.

2. Under the TimerController (Script) header, select the dot on the far right of the box next to 'Text_box'

3. Choose the Text object in the window that pops up by double-clicking

When you run your game now, your GUI should display a running timer in your text box, trimmed to two decimals.

## Winning the Game

Now that we have the timer to track our pace, it's time to add a "finish line" of sorts - you can extend the gameplay in a variety of ways, but for simplicity we'll just be adding a hidden goal that the player needs to find. To do this, we'll need to do a couple of things:

* Create a GameObject where we want the end of our maze to be
* Add a 'Game Over' UI element
* Write a script to handle finding the ending trigger, displaying the Game Over UI, and resetting the character position & timer

{x: game_object_final} Creating the final GameObject

{x: gameover_gui} Make the Game Over GUI

{x: game_controller_script} Write the GamePlay Controller
