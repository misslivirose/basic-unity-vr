<!-- TODO: fix all references to correct capitalization of asset store -->

# Introduction to the Unity Asset store
Right now, we have the bare basics of our maze and a general first person controller, so it's time to make our environment feel a little more welcoming. Unless you already have a passion for graphic design, 3D modeling, or photography, it's pretty likely you'll need to use the **Unity Asset Store** to get textures and models for your game objects.

{x: visit store}
[Explore the Unity Asset Store](https://www.assetstore.unity3d.com/en/)

You can access the Unity Asset store online and through the app itself with the shortcut CMD/CTRL + 9. The Asset store requires Unity 3.3 or later, so if you're using an older version or running Unity in Wine on Linux, you won't be able to access the store directly.

[Workaround for accessing the Asset Store on Linux](http://wiki.unity3d.com/index.php/Running_Unity_on_Linux_through_Wine#Unity_Asset_store_does_not_work_.28Has_a_workaround.29)

The Unity Asset store is a centralized location to find resources for building games and environments, and allows content creators to purchase assets, ranging from full scenes to character sprites and ground textures, so that you don't have to make everything yourself.

![unityassetstore](/img/10_assetstore.PNG)

Want to skip the asset store for textures? Unity has a few built-in textures in the Terrain Asset package that can be included in your project by going to Assets -> Import Package -> Environment.

# Finding and applying textures
Right now, we have a completed maze that is just about impossible to navigate due to all of the monotone colors, so we're going to make the environment more welcoming with textures. This will also add an element of realism based on the textures you choose.s

Launch the Unity Asset store. If this is your first time using the store, you'll need to create an account.

{x:create_account}
Create an account on the Unity Asset store

We're going to be downloading a texture pack from the Unity Asset store and importing it into our project. You can pick any texture you'd like - for this tutorial, we'll be using a couple of free store downloads, but you can also use the built-ins.

# Modifying the floor texture

{x: choose_floor_texture}
Download and import a texture package from the Unity Asset store to apply to the ground of the maze.  

1. From the asset store home page, select "Textures & Materials".

2. Under the list of available categories, select the type of ground you want to use.

  <i> Note: The "Ground", "Nature", and "Organic" categories contain natural textures, such as grass, rock, or dirt. Man-made material textures can be found under "Bricks", "Concrete", "Metal", "Pavement", "Roads", "Tiles", and "Wood". </i>

3. Select the asset package to download for your maze floor. This tutorial uses the [Ground Textures Pack](http://u3d.as/5Tu)'Ground Textures Pack', which is currently available for free from Nobiax/Yughues.

4. Import the desired textures into your application when prompted after the download completes. If there is a specific texture you want, you can select just that, but for now, you can just import them all to try out the different textures in your maze.

Once the import completes, you should see a new folder in the Asset window in Unity for the new texture pack. If you used the Ground Textures Pack, the folder name will just be the name of the imported package. Expand the folder to show the different textures.

![groundtexture](/img/11_groundtexture.PNG)

There are a few different ways that you can add textures to the various flooring components, depending on your personal preference, but the easiest way is to just grab the material (sphere) from the asset folder and drag it onto the map where you want to set the texture. In this case, we're using the 'Dry Ground' texture.

1. Expand the asset folder that you want to use and find the folder for your chosen texture.

2. Expand the texture folder for your chosen texture.

3. Drag the material - in this case, the file named 'Dry ground' - onto your map where you want to change the ground visuals. A green circle with a plus sign will appear when you can drop the texture on your GameObjects.

4. Repeat this for any components you want to give textures to.

Once you've added your desired textures to the ground of your maze, try running the game again - you'll notice that it's much easier to distinguish the pathways from the sky with the contrast from the new textured ground. We want to do the same thing with our walls to polish off the maze foundation.

![groundimg](/img/12_ground.PNG)

# Modifying the wall texture

{x: wall_texture}
Download, import, and apply a texture package from the Unity Asset store to apply to the walls of the maze.

1. From the asset store home page, we'll be going to "Textures & Materials" again.

2. Under the list of available categories, select the type of wall you want to use.

3. Select the asset package to download for your maze walls. This tutorial uses the [Nature Textures Pack](http://u3d.as/5Yy), also from Nobiax/Yughues.

4. Import your desired textures into your application the same way you did with the floor textures.

When you run your game now, you'll see that the walls and ground now have the new look applied to them. Depending on the scale of your maze, you may need to adjust the tiling of the texture.

![wallimg](/img/13_wall.PNG)

For more information about textures in Unity, we recommend checking out the following resources:

<!-- TODO: lots of links about background information on textures and other ways to assign textures to components. -->

[How do I add Textures?](http://answers.unity3d.com/questions/467051/how-to-apply-a-texture-to-an-object-in-unity-4-2.html)

[Textures - Official Unity Tutorials](https://www.youtube.com/watch?v=-6iquaC0Hf4)

[Normal Maps](http://docs.unity3d.com/Manual/HOWTO-bumpmap.html)

[Beginner Texture Tutorial](http://unity3d.com/learn/tutorials/modules/beginner/graphics/textures)

# Normal Maps and Tiling

You may need to manually add in normal maps to your textures in order for them to get the 3D feel to them in your environment. Normal maps are specific to materials and serve as a layer that specifies how lighting renders on your object to give the appearance of shadows and depth. To specify normal maps, you will need to change the type of your texture from "Diffuse" to one that supports an additional normal map. Then, follow the steps above for adding textures to include a normal mapping image to your material.

Additionally, depending on how much you scaled the walls and floor in your maze earlier, you may notice distortion in your materials. You can edit a texture by double clicking on the material and changing the tiling, but be aware that any changes you make to a material will apply to all of the GameObjects that use the material. To work around this, copy and paste the material with a different name (as an example, Ground5x5 and Ground5x10) and use the different sizes to match with the size of the walls.

# (Optional) Lighting and shadows

Unity 5 includes a directional light when you create a new scene, but you can modify the lighting style if you'd like to try something different. The types of lighting that Unity supports are:

* Directional Light
* Point Light
* Spotlight
* Area Light
* Reflection Probe
* Light Probe Group

You can play around with creating lighting effects the same way you'd create other GameObjects:

1. Right click in the hierarchy, select "Create" to open the drop down menu, or go to GameObject -> Light to choose a lighting type.

3. Position your light to your liking to cast shadows in your maze

You can change the various properties of your light(s) in the inspector. Adjusting the color & intensity will change the way the light appears on your maze and increase the contrast between light and shadows. There are several options for additional lighting effects that you can add to your lights for different appearances.

[Full list of properties for lights and descriptions](http://docs.unity3d.com/Manual/class-Light.html).


# (Optional) Adding a custom Skybox

With Unity 5, the scene comes with a skybox by default, but you can change this depending on how you want your environment to feel. To change the skybox:

1. Import your desired skybox from the Asset Stores

2. Select your FirstPersonCharacter controller and click "Add Component"

3. Under "Rendering" choose "Skybox"

4. Drag your new skybox into the Custom Skybox field

Run your maze - you can now run through it and you should see the sky surrounding the entire environment. You can download and try out additional skyboxes from the Unity Asset store.
