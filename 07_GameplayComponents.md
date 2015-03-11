Now that we've got a nice environment set up, it's time to add a few components that make our game more enjoyable. We're going to include a basic GUI control so that you can see your time throughout the maze, a gameplay mechanism for winning, and a few other components to make the experience more challenging.

# Adding a GUI
The first thing that we're going to do is include a basic user interface that displays on our screen. Once you start adding in UI elements, it's often easier to switch over to a 2D view of the screen, which you can do by clicking the "2D" above the scene window.

{x: create_gui}
Create the container for a timer

1. In your project hierarchy, click Create -> UI -> Canvas

2. Under your Canvas, right-click and add a UI -> Panel item under the Canvas item

3. In the Inspector for your Panel, change the scale to x:.25, y:.25, z:.25 - we don't want this to cover the entire screen.

4. Change the color of the panel to be more visible, also in the Inspector tab

5. If needed, zoom out to see the full UI display. Adjust the positioning of your Panel to your desired location - in our example, we're putting this in the top right corner.

6. Making sure that the Panel is selected in the scene Hierarchy, right click one more time and create a UI -> Text item in the Panel

![UIpicture](/img/14_uipanelview.PNG)

If you run your game now, you should see your panel floating in your camera view screen. We'll create a script to show and hide this later, but for now, let's finish up with the timer. We'll want to adjust our text block first so it's visible when we add in the timing component.

{x: create_text}
Add placeholder string for a timer

1. Select your text item and find the properties for the text block. For now, we can put a placeholder text in, so under the Text (Script) box, type in a temporary string.

2. Under the 'Paragraph' header, check the 'Best Fit' box and set the max size to your desired size - we chose 60. You might need to play around here to get the look you want.

3. Change the color of your text to contrast with your panel.

4. Set the Vertical and Horizontal Overflow to "Overflow".

5. Change the Alignment to center horizontally and vertically.

Now, when you run the game, you should see your static panel in your view and the text in front of you.

# Getting Started with Scripting
In Unity, all of the game play is done through scripting. You have three choices for scripting, JavaScript, Boo, and C# - we'll be doing this tutorial in C#. By default, scripting is done in MonoDevelop, a tool included with Unity, but you may have changed this going through earlier parts of the tutorial -  you can use any editor you'd like to edit scripts, but MonoDevelop is pretty good for the small ones we'll be writing in this game.

Many of the preconfigured assets that are available through Unity come with their own scripts, such as the character controller we added. For some good scripting resources and a primer, check out the following links.

[Unity3D Wiki - Scripting](http://wiki.unity3d.com/index.php/Scripts)

[Official Unity Scripting Reference](http://docs.unity3d.com/ScriptReference/)

[Unity Scripting Lessons](http://unity3d.com/learn/tutorials/modules/beginner/scripting)

# Implementing the Timer

Since we've got the placeholder text in order, it's time to actually give it some functionality. Since we're writing our first custom script for the timer, we'll launch MonoDevelop (or your IDE of choice) when we create the new file.

{x:make_timer}
Create a timer script to time your maze

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

With that, we're almost done with our first script - all that's left is assigning our UI Text box to be the one we update with the timer.The final code should look like this:

````
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

static float timer = 0.0f;
public Text text_box;

public class TimerController : MonoBehaviour {

  // Use this for initialization
  void Start () {


  }

  // Update is called once per frame
  void Update () {
    timer += Time.deltaTime;
    text_box.text = timer.ToString("0.00");
  }
}

````


Save your script and return back to Unity.

To set the target for our `text_box`:
1. Select the Text box in the Hierarchy and scroll down to the bottom of the Inspector.

2. Under the TimerController (Script) header, select the dot on the far right of the box next to 'Text_box'

3. Choose the Text object in the window that pops up by double-clicking

When you run your game now, your GUI should display a running timer in your text box, trimmed to two decimals.

# Winning the Game

Now that we have the timer to track our pace, it's time to add a "finish line" of sorts - you can extend the gameplay in a variety of ways that we won't necessarily cover here, but for simplicity we'll just be adding a hidden goal that the player needs to find. To do this, we'll need to do a couple of things:

* Create a GameObject where we want the end of our maze to be
* Add a 'Game Over' UI element
* Write a script to handle finding the ending trigger, displaying the Game Over UI, and resetting the character position & timer

# Creating a final GameObject

{x: game_object_final}
Add a capsule 3D object to represent the end point of the maze

The first thing we want to do is create an element in our maze that looks different enough for the player to recognize that they've gotten to the finishing point. You should add this far enough away from your spawning point (the initial position of your character controller) that the maze doesn't immediately give away the final element - in this case, we are going to place our "game over" object in the far corner from the starting point.

To create our ending point:

1. In the hierarchy, click Create -> 3D Object -> Capsule
2. Drag the capsule to your desired location

# Particle Systems

Right now, we have a capsule, but it looks pretty boring so we're going to add a [particle system](http://docs.unity3d.com/Manual/ParticleSystems.html) to make it more interesting.

{x: particle_system}
Create a particle system effect for our end point

Particle systems are effects that you can use in Unity to give game objects their magic. You can use them during animations, to create interesting lighting effects, give your environment wow factor, represent in-game interactions - the opportunities are pretty much endless. In this section, we're going to be giving our capsule a particle system using the built-in Unity particle asset package so it gives the user the memo that it's not a default component of the maze.

* [The Particle System](http://unity3d.com/learn/tutorials/modules/beginner/live-training-archive/particle-systems) - a beginner overview tutorial from Unity3D on what particle systems do and how to implement them

* [Particle system documentation](http://docs.unity3d.com/ScriptReference/ParticleSystem.html)

The first thing we'll need to do to create our particle system is import the Unity asset package, as this comes with a variety of effects that we can use in our maze. You can find a lot of additional particle effects on the asset store, but for now, we'll just be using the default since Unity gives a lot of flexibility with how you can manipulate particles in different ways.

1. Go to Assets -> Import Package -> Particles
2. Import the asset package into your project
3. Select your capsule and click "Add Component"
4. Choose Effects -> Particle System

What you should be seeing now is a series of glowing objects flying out of your capsule. We want to make the effect a little less intrusive so it's not too obvious from the rest of our maze, so we're going to go ahead and change some of the characteristics of our particle system and change how it renders. You can be creative, or copy what we ended up with by changing the follow particle system attributes in the Inspector on your capsule by ticking the header for particular characteristics and making the following changes:

1. Start Speed: 1
2. Start Lifetime: 4
3. Inherit Velocity: 4
4. Start Size: .4
5. Shape -> Angle: 0
6. Color Over Lifetime -> Gradient (we made ours gold)

After changing the particle effect, we want to hide the mesh for the capsule by unchecking "Mesh Renderer" on the capsule object in the Inspector.

Lastly, we'll rotate our capsule -90 degree on the X axis so it appears our particles are floating up into the sky and gives the player a sense of stepping into the ring they form.

# Putting it all together
<!-- TODO: Re-write this section to put it in a better order -->

{x: game_controller_script}
Write the GamePlay Controller

Now that we have all the pieces together, there are just a few more steps to finishing up our game play. We're going to implement a timer feature that does the following:

* Captures how long it takes to go through the maze
* Recognizes when we collide with our particle system (the game ending trigger)
* Displays our "Game Over" UI
* Resets the timer and the character position for another chance to go through the maze

We're going to do this by improving our earlier timer script. To do this, we'll have to make a few changes to where we have the script in the game and add a few new lines of code to our current script.

{x: update_timer_script}
Update Timer Script

The first thing that we'll need to do is add a few more variables to our timer script to track 1) our character's starting position 2) whether or not the timer is running and 3) which character controller in the scene is being used. Since we only have one, this is straightforward, but we'll still need to reference it in our script, so in the variable goes.

{x: update_vars}
Add in global variables

To implement these, add the following lines of code to your TimerController script under the timer and text_box objects:

```
public bool isRunning = true;
Vector3 startPosition;
public CharacterController characterController;
```

{x: save_start}
Store the starting position

In order to reset the position of our camera once the player has finished navigating through the maze, we need to store our initial coordinates for the character controller in the `startPosition` object. The 'Vector3' object [stores these coordinates](http://docs.unity3d.com/ScriptReference/Vector3.html) when the game is launched, so we'll be including this in our `Start()` method.

```
// Use this for initialization
void Start () {
  startPosition = characterController.gameObject.transform.position;
}
```

Now that we have the player's initial starting point, we'll need to create a new function that triggers the behavior of our end game. We've already initialized the boolean that tells us whether or not the timer is running, so we can move right into our `OnTriggerEnter` function. This will be called when our player controller collides with our particle system.

*Note: If you were creating a more complex gameplay system, you would need to check which object was colliding with our capsule in the `OnTriggerEnter` event, but since we only have one character and our particle system capsule, we'll skip this part now for simplicity.*

{x: onTriggerEnter}
Create the `OnTriggerEnter()` and `Reset()` functions

The `OnTriggerEnter()` function is what Unity will call when your object recognizes that there is an overlap between it and another GameObject - in this case, we are writing the function for our capsule, and whatever object collides with it (in this case, our character) will be passed in as an argument.

```
void OnTriggerEnter(Collider other)
	{
		isRunning = false;
		Reset ();
	}
```

At this point, we should get an error if we switch back into Unity since we haven't added our reset function. In this case, we've pulled it out as a separate function so we can modify the reset behavior without getting strange behaviors in `OnTriggerEnter()` but for the basic behavior, you could add in the `Reset()` code to the collision trigger if you so chose.

Add in the `Reset()` function by copy and pasting the following function. `Reset()` will move our character controller back to the start of the maze, begin the timer at zero again, and restart the timer.

```
void Reset()
	{
		characterController.gameObject.transform.position = startPosition;
		timer = 0.0f;
		isRunning = true;
	}
```

{x: updatetimer}
Change the `Update()` function to check if the timer should be running

With those two functions in place, we need to make one minor change to our `Update()` call so that the timer checks to make sure it's running before incrementing the number of seconds on the clock. This is an important step because we will later want to implement a keypress to start the timer, and we need it to stay paused until it's reset when the maze is completed. To do this, we'll just be putting an if-statement around the current `Update()` code to check the boolean we declared above:

```
// Update is called once per frame
	void Update () {

		if (isRunning) {
						timer += Time.deltaTime;
						text_box.text = timer.ToString ("0.00");
				}
	}
```
After that change, we're just about ready to go - but we've got a few more tweaks to do in Unity itself so that the script runs. The full code should look like this:

```
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

	static float timer = 0.0f;
	public Text text_box;
	public bool isRunning = true;
	Vector3 startPosition;
	public CharacterController characterController;

	// Use this for initialization
	void Start () {

		startPosition = characterController.gameObject.transform.position;
	}

	// Update is called once per frame
	void Update () {

		if (isRunning) {
						timer += Time.deltaTime;
						text_box.text = timer.ToString ("0.00");
				}
	}

	void OnTriggerEnter(Collider other)
	{
		isRunning = false;
		Reset ();
	}

	void Reset()
	{
		characterController.gameObject.transform.position = startPosition;
		timer = 0.0f;
		isRunning = true;
	}
}
```

{x: attach_script}
Update the script references in Unity

When we were first testing out our script, we had originally attached it to our GUI, but we're going to change this since we now have a collider to work with. Back in Unity, select the text GUI and delete the script out of the Inspector by clicking the drop down Settings menu on the script and selecting 'Remove Component'.

Attach the script to the Capsule by dragging and dropping the script from the Project directory onto the Capsule GameObject.

Try running your game. When you run into the capsule effects now, your character will automatically begin back at the start and the timer will reset.

{x: key_trigger}
Wait on a key press to start the game

The last thing that we're going to do is add a function in our TimerController that allows us to trigger when we'd like to start our game. This will allow us to be in control of when the game play actually starts, whereas the current behavior simply starts the gameplay over immediately. We will need to:

1. Prevent the timer from running automatically
2. Display an instructional text in the UI while our timer isn't running
3. Modify our `OnTriggerEnter` function to reset and wait for the player input

First, we want to change our timer declaration. Over in our `TimerController.cs` script, change

```
public bool isRunning = true;
```

to

```
public bool isRunning = false;
```

This will prevent our game from starting automatically, but that's okay - we'll take care of that in a bit. For now, switch back over to Unity and locate your GUI Text object. Change the default text (ours is 'Hi!') to "Press F to begin." Then, switch back over to the capsule, and under the Inspector for the script, uncheck the 'isRunning' box.

Finally, we want to make a few changes to our `OnTriggerEnter()`, `Reset()`, and `Update()` methods that will allow us to control when we want the game play to begin.

{x: finalize_script}
Finalize script functions

In the `Reset()` function, we want to change the behavior from immediately resetting the game and starting the timer to having the timer reset and allowing for another player to try. We're also going to remove the `isRunning = false` line from our `OnTriggerEnter()` function and move that into `Reset()` after we put the player back into the original position. Now, `OnTriggerEnter` will just call `Reset()`, and the two functions should look like:

```
  void OnTriggerEnter(Collider other)
	{
		Reset ();
	}

	/* Call Reset once we start the game over. */
	void Reset()
	{
		characterController.gameObject.transform.position = startPosition;
		isRunning = false;
		timer = 0.0f;
		text_box.text = "Press 'F' to begin";
	}

```

With these two functions in place, all that's left is to add in a check to see if the player has pressed the 'F' key to start the timer. We will add the following block of code under the existing lines in the `Update()` method. This will check first that the timer isn't running (we don't want to reset if the game is in progress) and if there was a registered key down input on the 'F' keyboard key. If these are both true, then we will begin the timer to start the game.

```
if (!isRunning & Input.GetKeyDown (KeyCode.F)) {
          isRunning = true;
      }
```

The final script we have will look like this:

```
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TimerController : MonoBehaviour {

	static float timer = 0.0f;
	public Text text_box;
	public bool isRunning = false;
	Vector3 startPosition;
	public CharacterController characterController;

	// Use this for initialization
	void Start () {

		startPosition = characterController.gameObject.transform.position;
	}

	// Update is called once per frame
	void Update () {

				if (isRunning) {
						timer += Time.deltaTime;
						text_box.text = timer.ToString ("0.00");
				}

				if (!isRunning & Input.GetKeyDown (KeyCode.F)) {
						isRunning = true;
				}

	}
	/* We want to check when the character collides with a trigger object,
	   in this case, the particle system cylinder that ends the run. */
	void OnTriggerEnter(Collider other)
	{
		Reset ();
	}

	/* Call Reset once we start the game over. */
	void Reset()
	{
		characterController.gameObject.transform.position = startPosition;
		isRunning = false;
		timer = 0.0f;
		text_box.text = "Press 'F' to begin";
	}
}

```
