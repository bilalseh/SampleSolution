cd ..
cd Project1/
start "Project1TempInstance" dotnet run
cd ..
cd IntegrationTest
dotnet test
taskkill /F /FI "WINDOWTITLE eq Project1TempInstance" /T
set /p DUMMY=Hit ENTER to continue...