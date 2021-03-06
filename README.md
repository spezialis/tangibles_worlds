# Tangibles Worlds
Virtual reality allows us to disconnect from reality to immerse ourselves in the unreal. But what happens when this virtual reality is also tangible?

This project offers an experience of sensory immersion, the tangibility of which leads us beyond a simple visual observation. We intervene in the world by touching it. The tactile experience is fundamental because becomes a catalyst, who tries to change, all the facets of the virtual reality in which we are placed. What we perceive from the outside, does not represent what we live inside the virtual world.

![Alt text](Readme_data/Photos/diplomesMID.01_LQ.jpg)
![Alt text](Readme_data/Photos/diplomesMID.02_LQ.jpg)

This project is an attempt to create and establish a strong link between reality and Virtual Reality. In a way the project reflect how to manipulate the reality and influence the virtual world and vice versa. I'm trying to explore what it means to touch some strange materials without seeing our hands and see something happening in a virtual world.

## Moodboard
![Alt text](Readme_data/Moodboard/Moodboard_Page_07.png)
![Alt text](Readme_data/Moodboard/Moodboard_Page_05.png)
![Alt text](Readme_data/Moodboard/Moodboard_Page_03.png)

## TODO | DONE
### Unity
- [x] Create 3 difference environment for each box.
	- [x] Bake textures
	- [x] Bake animations from Cinema 4D to Unity
- [x] When the user put his hand inside a cube the world is revealed
- [x] Improve the scripts for the serial communication between Unity and Arduino.
- [x] Animate each world.
- [x] Lights.
- [ ] End of the experience:
	- [ ] Check when all the worlds are completely explored.
	- [x] Show credits.
	- [ ] Restart the experience each time some one remove the VR headset.
- [x] Bunch of others things on the scripts:
	- [x] Animate lights.
	- [x] Move them around.
	- [x] Animate light intensity and range and color.
	- ~~[ ] Maybe add some shadows.~~

#### Some visuals
![Alt text](Readme_data/Images/Test_scene.png)

### Arduino sensors
- [x] Arduino mega.
- [x] 4 Capacitive wire + 4 10kΩ resistors + 4 270kΩ resistors.
- [x] 4 Photocells and optic fibre + 4 10kΩ resistors.
- [x] 1 LED stripe.
- [x] 4 Flex sensors + 4 47kΩ resistors.
- [x] 3 Distance sensors Sharp GP2Y0A21YK0F 5 V/DC (10-80cm).
- [x] Put everything together.
![Alt text](Readme_data/Images/Arduino_sensors_connections.png)
![Alt text](Readme_data/Images/Arduino_sensors_connections_scheme.png)

## 1. Bubble
**Materials:**
- [x] Mold
![Alt text](Readme_data/Photos/IMG_20170511_193611.jpg)
- [x] 4 Silicone mold with 4 flex sensors.
- [x] Fill the mold with:
	- [ ] [Pearl clay](https://s-media-cache-ak0.pinimg.com/originals/c7/f3/d3/c7f3d376586a34ae77c89879f5f09bfa.jpg) or
	- [x] Sagex pearls.
- [x] Mold support MDF
![Alt text](Readme_data/Images/Bubble_mold_support.png)
- [x] Base MDF
	- [x] Make a hole for the cables
	- [x] 4 MDF pieces to connect the mold support and the base
![Alt text](Readme_data/Images/Bubble_base.png)
- [x] Buy somo Rhodorsil Additif 11013 from [Silitech](http://www.silitech.ch/f/index.asp)

**World palette color**<br>
![Alt text](Readme_data/Images/Bubble_palette_color.png)

**Virtual Universe:**
![Alt text](Readme_data/Images/Bubble_world.png)

**Sensors:**
- [x] 1 Arduino mega
- [x] 4 Flex
- [x] 4 47kΩ resistors
- [x] Wires from the other boxes

## 2. Pics
**Materials:**
- [x] Brush hairs
- [x] Brush hairs support MDF
![Alt text](Readme_data/Images/Pics_support.png)
- [x] 4 MDF pieces to connect the support and the base
- [x] Fiber hairs
- [x] Base MDF
	- [x] Make a hole for the cables
![Alt text](Readme_data/Images/Pics_base.png)
- [x] Wires from the arduino

**World palette color**<br>
![Alt text](Readme_data/Images/Pics_palette_color.png)

**Virtual Universe:**
![Alt text](Readme_data/Images/Pics_world.png)

**Sensors:**
- [x] 4 Photocells
- [x] 4 10kΩ resistors
- [x] [LED](https://www.google.ch/search?q=st%C3%B6tta+ikea&tbm=isch&imgil=hdbnV116b7ZRTM%253A%253BKCulAlFXAJDd7M%253Bhttp%25253A%25252F%25252Fwww.ikea.com%25252Fch%25252Ffr%25252Fcatalog%25252Fproducts%25252F50277133%25252F&source=iu&pf=m&fir=hdbnV116b7ZRTM%253A%252CKCulAlFXAJDd7M%252C_&usg=__WQGrO_8pHb7VvvWq1aFQA2HoJL4%3D&biw=1106&bih=663&ved=0ahUKEwiC-ZL7kbvUAhWBNBQKHdM3CZUQyjcITw&ei=NAVAWYIPgelQ0--kqAk#imgrc=hdbnV116b7ZRTM:)

## 3. Wires
**Materials:**
- [x] Wire support Steel
![Alt text](Readme_data/Images/Wire_support.png)
- [x] Put some elastic wire
- [x] Put some conductive wire
- [x] Base MDF
	- [x] Make a hole for the cables
![Alt text](Readme_data/Images/Wire_base.png)
- [ ] Wires from the arduino

**World palette color**<br>
![Alt text](Readme_data/Images/Wire_palette_color.png)

**Virtual Universe:**
![Alt text](Readme_data/Images/Wire_world.png)

**Sensors:**
- [x] 4 Capacitive wire
- [x] 4 10kΩ resistors
- [x] 4 270kΩ resistors

## Manufacturing planning
- [x] 3 plexiglass boxes.
![Alt text](Readme_data/Images/Plexi_box_2D.png)
- [x] Make a hole on the wall to support the oculus sensor
- [x] 3 [table legs](http://www.ikea.com/ch/it/catalog/products/70217973/)
	- [x] holes for the cables.
	- [x] base
- [x] Build a box to hide the pc
- [x] Cut 3 pads for the plexiglass holes on the digital cutter
![Alt text](Readme_data/Images/Digital_cutter_pads.png)

## Setup
The 3 boxes will be over a special support.
![Alt text](Readme_data/Images/Setup_pieces_2D-01.jpg)

### Setup spot propositions
On the CV openspace.

## Useful links:
**Baking Animations in Cinema4D:**<br>
- [Bake Nurbs into PLA Cinema 4D Tutorial](https://vimeo.com/88822458)
- [Baking Animated Deformers or Effectors with Point Cache Tag](https://www.thepixellab.net/c4d-tutorial-baking-animated-deformers-or-effectors-with-point-cache-tag)
- [Shaders](http://www.shaderslab.com)
- [Cubemap](http://www.andrewnoske.com/wiki/Cinema_4D_-_Generating_a_Skybox)
- [Unity Skyboxes](http://www.andrewnoske.com/wiki/Unity_-_Skyboxes)<br>

**Serial communication for integrating Arduino and Unity:**<br>
[SerialCommUnity](https://github.com/dwilches/SerialCommUnity)

## Git from Terminal
- Status
```
git status
```

- add all the files
```
git add .
```

- Commit
```
git commit -m "message string"
```

- Push uploader
```
git push
```

- Clone locally
```
git clone git@github.com:spezialis/DiplomaProject.git
```

- Recuperer ficher
```
git pull
```

- Following steps:
pull -> add -> commit -> push

## Credits
By [Stella Speziali](https://stellaspeziali.myportfolio.com/)<br>
Tangibles Worlds<br>
Lead by Alain Bellet, Gaël Hugo, Cyril Diagne, Christophe Guignard<br>
Assisted by Tibor Udvari, David Roulin<br>
ECAL/Bachelor Media & Interaction Design<br>
University of Art & Design, Lausanne 2017<br>
[www.ecal.ch](www.ecal.ch)
