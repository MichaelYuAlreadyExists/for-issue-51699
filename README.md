# This solution is used to reproduce the issue #51699
https://github.com/dotnet/aspnetcore/issues/51699

# How ?
- Obtain this source code and open it in vs. Ensure that VS contains functions related to blazer.
- Set BlazorApp1 as the startup project. Run it, it will work.
- You can find my code in the file BlazorApp1\Pages\Index. The rest is actually the default project template.
- Now, set the ServerBlazorHosts project as the startup project. Run it. You will see an error message on the homepage.
