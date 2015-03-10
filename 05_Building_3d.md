# Building a 3D Environment

Okay, so now we've installed Unity and gotten our empty project made. By now, you should know a little about the editor, and we're ready to start building our maze.

First things first: when building 3D games (or any other type of interactive experience) in Unity, you need to know the fundamentals about the GameObject. Just about every aspect of your game, from the interface to the characters, player, environment, and affects, will be composed of various GameObjects with different sets of components. For the first part of the environment we're making, we'll be using a built-in Unity UI GameObject element called the Plane GameObject.

[Positioning GameObjects in Unity](http://docs.unity3d.com/Manual/PositioningGameObjects.html)

# Using a plane to create a foundation
The first step in making an environment feel realistic to a player is to give it a foundation. If you try running your empty scene right now, all you'll see is a blank grey environment and a blue sky, which is to be expected - we haven't added any character controller or any objects to see. Later on, though, when we add a controller for the player, you'll notice that any time you step off of a plane, your character will fall until you kill the process and restart the level. By default, Unity 5 includes a Skybox enabled and has a directional light for your scene, so you won't have to worry about those off the bat - but we'll go into how to customize those later on.

So, let's get started!

The first thing we're going to do is create a GameObject using one of the prefabricated models (prefabs) that Unity has built in. As you build your game out with Unity, you'll become very familiar with the GameObject menu and the various components that make up objects in your environment.

{x: make floor}
Create the foundation for your maze by creating a series of plane objects


We'll start by going to GameObject -> 3D Object -> Plane
<!-- TODO: Image showing File menu for Plane object -->


When you generate a plane GameObject, you should see a shape appear in the center of your view field. This will be the starting point for our maze, but right now, it's just a square.

The first hurdle with developing in 3D is getting used to specifying object sizes and locations relative to their parent container. In this case, the parent for the plane we've just created is our (theoretically) infinite grid, so the plane size will serve as our relative point of reference for sizing the rest of our maze elements.

Running the game now results in a static image where we can see the plane we've just created at the bottom of the field of vision. As we build out our maze, we'll want to change our view to place our new GameObjects, so let's cover a few basics with views:

* The fastest way to get precise camera control for the perspective you want is by holding down the alt/option key while you grab the view field and rotate (Mac). This switches the control mode to pan, but allows you to manipulate the view over all three axes - helpful when checking collision points.

* Dragging and dropping with the view mode set to 'Pan' allows you to view different areas of your map without changing the view angle. Pressing & holding the Control key will let you zoom in and out from a static point.

* To manually drag objects around on the grid, change the view mode to (!!arrow) keys. This can be helpful when placing objects in the general area you want them before using the coordinate system to polish up their exact location. You can specify which axis to move the object on by clicking the object and dragging along the arrow on the axis you want to change.


{x: gameobject-component relationship}
[Understand the relationship between GameObjects and Components](http://docs.unity3d.com/Manual/TheGameObject-ComponentRelationship.html)

Generally speaking, the relationship between a GameObject and a Component is fairly straightforward: a **GameObject** is the object's representation in the world and it's "physical" aspects, such as location and size, and it contains a set of **components** that define its characteristics and behaviors, such as it's motion controls or how it lights the area around it.


#x Creating a first person control

<!-- TODO: Add image here -->

{x: create character}
Create your first character controller using the built-in Unity FPS character component

We won't get very far with playing our game without a controller, so let's pause now to make a controller so that we can manipulate the camera and move around the board.

<!--Since we're developing an experience for the Oculus Rift, we'll be using the default first person controller rather than a third person character control at first - we'll update this with an Oculus character control object later on in the tutorial.-->

Because we created our project without any assets, the first thing that we'll want to do is import the standard Character Controller asset package.

1. Go to Assets -> Import Package -> Characters to import the character package into your project. You can uncheck the Third Person Prefab to save space, but it's not strictly necessary, especially if you feel like playing around with the various character controllers.

2. In the Asset directory at the bottom of the screen, expand the Standard Assets folder, choose the Characters folder, open the First Person Character directory, and double-click 'Prefabs'. You should see two prefabricated controllers, an FPSController and a RigidBodyFPSController

3. Grab the FPSController and drag it into your scene over your plane. Make sure that the character is fully above the plane, or the collider won't take and the character will fall through the floor.

4. Delete the Main Camera. The FPSController comes with a camera component, so we no longer need the one that Unity created by default.

When you run the game now, you will have a first person view of the plane we've created. Notice that many of the typical controls for a first-person controller have been added for us automatically. You can move with the arrow or WASD keys, jump with the space bar, and the view adjusts automatically for us when we move around the plane.

If you jump off the plane at this point, gravity kicks in and you'll fall through space until you restart the scene.

<!-- TODO: Add a falling script to reset the position -->

## Building out the maze floor
This next part of the tutorial allows you to get creative. There are different ways that you can choose to build a maze in Unity, but we'll be going through one that lets you add on to the maze easily by having the floor follow our maze pattern rather than relying on the walls alone for the plan. Whether you choose to use one large base or break it out into the sections as shown is up to you, but there are several benefits to creating the floor layout in pieces rather than using one large foundation:

* Placing walls is easier since you have the coordinates of the floor already
* You can view the entire maze from any angle while you're building
* Allows for a better holistic view of the layout than you can with a single base
* Gameplay is more controlled since the user will not be able to run around the maze outside of the paths you've created

{x: build hallway}
Build a single pathway for the maze

1. Select the plane that we've created and modify the size to scale for your maze. Notice the perspective tool at the top right of our viewer, which shows which direction each of the axes will change. In our example, we'll be changing our plane to have an X scaling factor of 5 and a Z scaling factor of .5

2. Create a second plane to make a crossroad. You can do this by creating another plane from the GameObject menu, but I prefer to just copy and paste the existing one since it keeps the Y and Z sizing consistent across the pathways.

3. Rotate the second plane by selecting it and changing the Y rotation to 90. This will make a path that is perpendicular to the original one. Move the new plane where you want it on the environment. For the example, we'll be changing the X location from 0 to 25.

<i> **How do we figure out the location?** The location is determined by figuring out the size of the original plane and multiplying that by the desired location. Our X scaling factor for the first plane was 5, with an original size of 10 units, which means that the length of the entire pathway is 50 units, centered on the X axis at the origin. So we need to put the new pathway at the end by setting X to +/- (5 x Scaling Factor). </i>

We'll pause here to introduce a new GameObject to the maze we're building by adding in walls. You can layout the entire maze floor first if you'd like, but we recommend building the floor and walls in sections to make it easier to layout the objects as you go.


<!-- TODO: Include screen capture for scaling / pictures -->

{x: build walls}
Build walls around your existing paths

A maze is no fun when you can see to the exit, so our next step is to add walls. Do do this, we'll need to add a new type of object. Unity provides a **cube** GameObject, which we'll be using to make our walls.

Create a cube using the following properties (if you're following the same pattern we used above) by going to GameObject -> 3D Object -> Cube:

* Position (x:0, y = 2, z = 2.75)
* Rotation: (x: 0, y:0, z:0 )
* Scale: (x: 50, y: 4, z = 0.5)

This will give you one wall that runs alongside the original floor we laid out, stopping a little short of the crossing path at the end. If you've built your own design and used different sizes, you'll need to modify the position and scale for the walls.

<i>**How do we figure out wall placement?** There are a few things to consider when placing your walls in a 3D environment. You want your wall to be consistently placed - in this example, we are placing all of our walls entirely outside of the floor, right at the edge, but you could also do your wall placed just inside of the floor or splitting the middle - it's up to you and it makes the most sense to decide this based on the scaling you're using so you don't end up with awkward decimals. </i>

#### Positioning
* x: this number will determine the location along the X axis. This should be the center of where your floor plane is.

* y: this number should be the positive value of 1/2 the height of your wall - the positioning is from the origin, in our case, 0, and this will prevent our walls from sticking through the bottom of the maze.

* z: this number should be 1/2 of the width of your floor plane + 1/2 of the width of the wall. In our case, the width of the plane is 1 (5 units) and the wall is half a unit (note that this is relative to the parent, so in our case, this is 0.5 units when compared to the plane) for a z position of 2.5 + .25 = 2.75.

#### Rotation
For this tutorial, you will only need to rotate along the Y axis to create different angles for your walls and planes.

#### Scale
Scaling with Unity can be tricky before you're used to it - scaling is done relevant to the parent of an object, which can vary for different objects. In this example, the cube has a different scaling than the plane, specifically that the cube is 1/10 the scale of the plane by default. The best example of this is the comparison of the wall to the ground:

Let's say we are measuring in meters. We specified a scaling factor on the Z axis (width) of the plane at .5. Here, one "unit" for the plane is actually 10 "meters", so the floor is 5m across.

We made a cube with a default of 1 unit<sup>3</sup> - the scaling here is 1:1 with "meters", so the cube is 1m<sup>3</sup>. When we change the z-axis scaling to .5, our cube shrinks to .5m instead. You can see how this gets confusing with relating differently scaled objects, but thinking about it in terms of absolute measurements can help if you get tripped up.

For our wall, we have a scale of x:50 (since the base is 5*10 units), y:4 (you can choose the height here of your walls to vary the effect) and z:0.5 since there isn't a need for wall thickness to increase and keeping it small allows more flexibility with building paths.  

<!-- TODO: screencast where we show copying and pasting the walls for the basis of the maze -->

Now that you know the basics about building the skeleton for your maze, you can finish building your own maze design or copy the one that we've provided in the source code.

{x: Build out your maze layout with floors and walls}
Finish the general maze layout using the steps above to create your maze

<!-- TODO: Include diagram renderings as part of the paid tutorial content-->

## Additional Resources for Environment Building:
Generally speaking, if you are planning on building a more complex environment and game experience, you'll need to incorporate a more advanced element into your scene - the Terrain GameObject. We won't go into too much detail here, but you can find additional resources on building complex environments with the Terrain Editor in Unity below.

[Building a more complex environment with the Terrain Editor](http://docs.unity3d.com/Manual/script-Terrain.html)

Next up, we'll explore the Asset Store and apply textures to our maze.
