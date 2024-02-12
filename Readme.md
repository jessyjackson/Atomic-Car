# Atomic Car
This is a simple AI that use Reinforcment Learning and Q-learning with Bellman formula to create a small car able to complete race tracks. \
Implemented in a windows software this programm allow the user to experiment with the the different training methods, and see the result memory. 
## The problem
This was a school project to understanding the base of Machine Learning and Reinforcment Learning. \
Creating a c# software all from scratch without any Machine Learning Library.
# Description
The track is matrix with (0,1,2) in order (track,borders,finish line). \
The car use a camera to see the frontal wiew of the car and select the best action for the wiew.

The mechanism implemented by Reinforcement Learning involves the observation of the external environment from which state information is obtained (the image seen by the driver, the speed of the car) and on the basis of this information identify the most appropriate driving action, in order to maximize the total "rewards" received.

The car use the HOG (Histogram of Oriented Gradient) to reduce the wiew size and improve the performances 

## Installation

Use the git command to clone the repository [git](https://git-scm.com/).

```bash
git clone https://github.com/jessyjackson/Atomic-Car
```
Extract the build in
```bash
"AtomicDrive\Bin\Debug\net6.0-windows"  
```
Execute the .exe

### OR

Use the release version on this repository

# Docs

Full documentation of the project (in Italian) -> [HERE](https://github.com/jessyjackson/Atomic-Car/blob/main/docs/docs.pdf).




