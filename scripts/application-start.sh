#!/bin/bash
# This script runs after the new version of your application is successfully installed and started.
cd /home/ec2-user/games-api
dotnet DSCC_API.dll
