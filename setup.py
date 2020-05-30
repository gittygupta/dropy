
from distutils.core import setup
setup(
  name = 'dropy',
  packages = ['dropy'],
  version = '0.0.2',
  license='MIT',
  description = 'A simple package for a simple drone simulator created in unity',
  author = 'Aousnik Gupta',
  author_email = 'guptaaousnik@gmail.com',
  url = 'https://github.com/gittygupta/dropy',
  download_url = 'https://github.com/gittygupta/dropy/archive/v0.0.2.tar.gz',
  keywords = ['simulator', 'python', 'unity', 'flight', 'control', 'NN', 'training', 'utility'],
  install_requires=[
          'validators',
          'pywinauto',
          'ctypes',
          'PIL',
          'pyautogui'
      ],
  classifiers=[
    'Development Status :: 3 - Alpha',
    'Intended Audience :: Developers',
    'Topic :: Software Development :: Build Tools',
    'License :: OSI Approved :: MIT License',
    'Programming Language :: Python :: 3',
    'Programming Language :: Python :: 3.6',
    'Programming Language :: Python :: 3.7',
    'Programming Language :: Python :: 3.8',
  ],
)