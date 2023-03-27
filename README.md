# Assignment3-VR
## Implemented Features
(All requirements + Optional)
- You can look around using gaze tracking.
- You can engange with objects using the touchscreen through the laser cut hole 
  - grab with tap 
  - drop with tap
  - tap and hold for grabbing and changing the depth of an object
- Enable physics on **blocks** and the **environment** so they behave naturally (drop and collide)
- Make sure all interactions work in both the Unity emulator (mouse first person camera) and your Android phone
  - grab with left-click
  - drop with left-click
  - hold **right-click**/**mousewheel** for changing the depth of an object

## Additional Features added
- Object texture changes on when hovering the object with your gaze
- Object physics enhanced -> Ability to throw items (They keep momentum)
- Gaze Dot with 3D location shows where a grabbed object will move towards
- Objects floats with **Ease Out** animation towards Gaze Dot when grabbed
- Objects are bouncy
- Text that explains controls for both PC and Android VR
- Added RigidBody to camera to make objects not clip through your head (They bounce off instead)

## Known Bugs
- Occasional ground clipping could happen if the user forces this by looking at the floor
- The rightmost block seems to have undefined behaviour despite using the exact same code 
