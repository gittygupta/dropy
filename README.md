# dropy

Scaled down version of Microsoft's AirSim (drone only). Ideal for developers looking to control the drone via keyboard. 'dropy' is a utility package to control the simulator by writing minimal code, essentially useful for training of NNs and ideally suited for RL. agents.

[![Simulator](https://img.shields.io/badge/Simulator-drive-red.svg)](https://drive.google.com)
[![PyPI](https://img.shields.io/badge/PyPI-v0.0.5-blue.svg)](https://pypi.org/project/dropy/)
[![python](https://img.shields.io/badge/python-3.6+-blue.svg)](https://www.python.org)
[![Maintained?](https://img.shields.io/badge/Maintained%3F-YES-green.svg)](https://github.com/gittygupta/dropy)

# Installation

```
pip install dropy
```

Requires Python 3.6+
Currently supported only on Win32 (MS Windows) environment

# Usage

```python
from dropy import Flight

flight = Flight(location='simulator')

for _ in range(10):
    flight.turn_left()

for _ in range(10):
    flight.forward()

print('Current Global Coordinates : ', flight.coords_xyz())
print('Current Global Angles : ', flight.angles_xyz())
```

The 'location' parameter specifies the directory of the simulator. In the above, it's in the folder 'simulator' under the same working directory.

# Examples

Examples of certain functions will be uploaded along with the package, in future releases.
