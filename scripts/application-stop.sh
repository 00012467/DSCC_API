#!/bin/bash
# This script runs before the old version of your application is stopped.
cd /var/www/games-api/DSCC_API
pkill -f "dotnet DSCC_API.dll"