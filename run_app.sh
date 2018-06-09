#!/bin/bash
# Run python
pushd Assets
python cv.py
popd

# Run app
./aMAZEing.app/Contents/MacOS/aMAZEing
