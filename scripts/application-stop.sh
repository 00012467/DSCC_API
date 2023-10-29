#!/bin/bash
# This script runs before the old version of your application is stopped.
pkill -f "dotnet DSCC_API.dll"