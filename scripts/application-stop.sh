#!/bin/bash
# This script runs before the old version of your application is stopped.
cd /home/ec2-user/games-api
pkill -f "dotnet DSCC_API.dll"