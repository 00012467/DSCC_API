#!/bin/bash
# This script runs after the new version of your application is successfully installed and started.
cd /var/www/games-api/publish
dotnet DSCC_API.dll
