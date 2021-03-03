cd ../SearchEngine.API
osascript -e 'tell application "System Events" to tell process "Terminal" to keystroke "t" using command down'
osascript -e 'tell app "Terminal" to do script "cd ../SearchEngine.API && dotnet watch run --urls=http://localhost:5002/" in window 1'
dotnet watch run --urls=http://localhost:5000/
