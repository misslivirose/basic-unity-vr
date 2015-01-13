<!-- TODO: fix all references to correct capitalization of asset store -->

# Introduction to the Unity Asset store
Right now, we have the bare basics of our maze and a general first person controller, so it's time to make our environment feel a little more welcoming. Unless you already have a passion for graphic design, 3D modeling, or photography, it's pretty likely you'll need to use the **Unity Asset Store** to get textures and models for your game objects.

{x: visit store}
<a href="https://www.assetstore.unity3d.com/en/">Explore the Unity Asset Store </a>

You can access the Unity Asset store online and through the program with the shortcut CMD + 9. The Asset store requires Unity 3.3 or later, so if you're using an older version or running Unity in Wine on Linux, you won't be able to access the store directly.

<a href="http://wiki.unity3d.com/index.php/Running_Unity_on_Linux_through_Wine#Unity_Asset_store_does_not_work_.28Has_a_workaround.29"> Workaround for accessing the Asset Store on Linux </a>

The Unity Asset store is a centralized location to find resources for building games and environments, and allows content creators to purchase assets, ranging from full scenes to character sprites and ground textures, so that you don't have to make everything yourself.

<!-- TODO: detail the asset store -->

Want to skip the asset store for the terrain? Unity has a few built-in textures in the Terrain Asset package that can be included in your project by going to Assets -> Import Package -> Terrain Assets.

## Finding and applying textures
Right now, we have a completed maze that is just about impossible to navigate, so we're going to make the environment more welcoming with textures. This will also add an element of realism based on the textures you choose.

<!-- TODO: Add interesting links for creating texture packages -->

Launch the Unity Asset store. If this is your first time using the store, you'll need to create an account.

{x:create_account}
Create an account on the Unity Asset store

We're going to be downloading a texture pack from the Unity Asset store and importing it into our project. You can pick any texture you'd like - for this tutorial, we'll be using a couple of free store downloads.

{x: choose_floor_texture}
Download and import a texture package from the Unity Asset store to apply to the ground of the maze.

<!-- TODO: Include screencast video / screenshots -->


1. From the asset store home page, select "Textures & Materials".
2. Under the list of available categories, select the type of ground you want to use.

  <i> Note: The "Ground", "Nature", and "Organic" categories contain natural textures, such as grass, rock, or dirt. Man-made material textures can be found under "Bricks", "Concrete", "Metal", "Pavement", "Roads", "Tiles", and "Wood". </i>

3. Select the asset package to download for your maze floor. This tutorial uses the <a href="http://u3d.as/5Tu">'Ground Textures Pack'</a>, which is currently available for free from Nobiax/Yughues.

4. Import the desired textures into your application when prompted after the download completes. If there is a specific texture you want, you can select just that, but for now, you can just import them all to try out the different textures in your maze.

Once the import completes, you should see a new folder in the Asset window in Unity for the new texture pack. If you used the Ground Textures Pack, the folder name will just be the name of the imported package. Expand the folder to show the different textures.

<!-- TODO: Screencast / image -->

There are a few different ways that you can add textures to the various flooring components, depending on your personal preference, but the easiest way is to just grab the texture from the asset folder and drag it onto the map where you want to set the texture. In this case, we're using the 'Grass & Moss' texture.

1. Expand the asset folder that you want to use and find the folder for your chosen texture.

2. Expand the texture folder for your chosen texture.

3. Drag the texture - in this case, the file named 'diffuse' - onto your map where you want to change the ground visuals. A green circle with a plus sign will appear when you can drop the texture on your GameObjects.

4. Repeat this for any components you want to give textures to.


<!-- TODO: lots of links about background information on textures and other ways to assign textures to components. -->

Try running the game again - you'll notice that it's much easier to distinguish the pathways from the sky with the contrast from the new textured ground. We want to do the same thing with our walls to polish off the maze foundation.

{x: wall_texture}
Download, import, and apply a texture package from the Unity Asset store to apply to the walls of the maze.

1. From the asset store home page, we'll be going to "Textures & Materials" again.

2. Under the list of available categories, select the type of wall you want to use.

3. Select the asset package to download for your maze walls. This tutorial uses the <a href="http://u3d.as/5Yy"> 'Nature Textures Pack'</a>, also currently available from Nobiax/Yughues.

4. Import your desired textures into your application the same way you did with the floor textures.

When you run your game now, you'll see that the walls and ground now have the new look applied to them. Depending on the scale of your maze, you may need to adjust the tiling of the texture.

<!-- TODO: explain tiling -->

<!-- TODO: add resources for different texture models -->

# Lighting and shadows

# Adding a sky
