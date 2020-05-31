# dropy

Scaled down version of Microsoft's AirSim (drone only). Ideal for developers looking to control the drone via keyboard. 'dropy' is a utility package to control the simulator (developed in Unity) by writing minimal code, essentially useful for training of NNs and ideally suited for RL agents.

[![Simulator](https://img.shields.io/badge/Simulator-drive-yellow.svg)](https://drive.google.com/drive/folders/1rJ4Kyzz2G8YoW9sLQ4O9FGsdoRb4Epek?usp=sharing)
[![PyPI](https://img.shields.io/badge/PyPI-v0.0.5-blue.svg)](https://pypi.org/project/dropy/)
[![python](https://img.shields.io/badge/python-3.6+-blue.svg)](https://www.python.org)
[![Maintained?](https://img.shields.io/badge/Maintained%3F-YES-green.svg)](https://github.com/gittygupta/dropy)

## Installation

#### For the package to work, please download the simulator from the the drive link provided in the badge above. 

```
pip install dropy
```

Requires Python 3.6+
Currently supported only on Win32 (MS Windows) environment


## Usage

#### Before using any functionalities of the package, make sure that the simulator is running and also that it is TPP mode. Key bindings for the simulator is provided in the link itself.

```python
from dropy import Flight

flight = Flight(location='simulator')

flight.turn_left(180)

print('Current Global Coordinates : ', flight.coords_xyz())
print('Current Global Angles : ', flight.angles_xyz())
```

The 'location' parameter specifies the directory of the simulator. In the above, it's in the folder 'simulator' under the same working directory.

turn_left(n) -> 'n' specifies the number of degrees to turn

## Examples

Examples of certain functions will be uploaded along with the package, in future releases.
