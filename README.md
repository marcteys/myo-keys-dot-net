Myo Keys
=====================

Myo keys allows you to simulate keys press.

This program is super easy to use (user firendly!) and is usefull to remotly control the applications on **Windows**.

## How it works

1. Select the gesture(s) you want to use.
2. Type the key you want to assign on the right-side area.
3. Select the vibration type if you want an haptic feedback.
4. Press Start to start sending keys!

You can now let the app running on the background. Myo-Keys will work on the current active window. 

### Feature : Validation gesture

You can also use a "Validation gesture" to prevent interfering movements. If you select one, you will have first to do this gesture and then do the gesture you want to do.


## Dev stuff

###SDK Modifications 
For this project I had to add a new VibrationType (None) to the *enum* of the myo-dotnet SDK. There are probably other ways to do that, but it was the easiest. 

###Know issues
* Some keys may not work (I didn't manually add them)
* Bug ? The validation gesture cannot be set back to None

###To do
* Find a new method to deteck multiple keys shortcuts, case, etc...
* Complete the readme
* Best practices / functions to optimize the come
* Disable the vibration field at the begenning and enable it later. (or set default to none)
* Disconnect the Myo on application quit

### Updates
* Added haptic feedback for the validation gesture