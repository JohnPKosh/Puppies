# Repository Structure

## Directory Structure
---

### Directory Setup

The root path of `%GIT%` referenced below should be set as a **System Environmental Variable**

### Contents

Root Directory "`%GIT%\Puppies\`" - The root folder structure contains the following basic structure:

1. a `doc` directory containing repository documentation
1. a `elm` directory containing loose file assets not included in the code directly
1. a `src` directory containing all repository source code
1. a `.gitignore` file for entire repository
1. a `LICENSE` file for the software
1. a `README` file describing the encompassing project

```shell
<DIR> doc
<DIR> elm
<DIR> src
.gitignore
LICENSE
README.md
```

Source Directory "`%GIT%\Puppies\src\`" - The src directory will contain one subfolder for each "__*.sln__" file as well as sub directories for projects or nested sub directories for common related project groupings if applicable.

## Solution Setup
---

### Create Solution

**Step 1.** - Navigate to src directory
```shell
cd %GIT%\Puppies\src\
```

**Step 2.** - Make the MvcPuppies solution directory
```shell
mkdir MvcPuppies
```

**Step 3.** - Create the solution

```shell
dotnet new sln -o .\MvcPuppies -n MvcPuppies
```

-- or --

```shell
dotnet new sln -o %GIT%\Puppies\src\MvcPuppies -n MvcPuppies
```

**Step 4.** - Create the ASP.Net MVC App

```shell
dotnet new mvc -o %GIT%\Puppies\src\MvcPuppies\Puppies.Web -n Puppies.Web
```

**Step 5.** - Add the ASP.Net MVC App to the solution

```shell
dotnet sln %GIT%\Puppies\src\MvcPuppies\MvcPuppies.sln add  %GIT%\Puppies\src\MvcPuppies\Puppies.Web\Puppies.Web.csproj
```

**Step 6.** - Verify project exists in the solution

```shell
dotnet sln %GIT%\Puppies\src\MvcPuppies\MvcPuppies.sln list
```

**Step 7.** - Build the .sln

```shell
dotnet build %GIT%\Puppies\src\MvcPuppies\MvcPuppies.sln
```


**Step 8.** - Run the ASP.Net MVC App 

```shell
dotnet run --project %GIT%\Puppies\src\MvcPuppies\Puppies.Web\Puppies.Web.csproj

chrome.exe https://localhost:5001
```

_*Note - if chrome does not launch from command line above you will need to add the chrome.exe directory to your PATH environment variables_

> Proceed to commit and Launch Solution in VS Code or Visual Studio

---

## Additional Changes

The original solution projects above were created using dotnet 5 SDK default templates. All of the `dotnet new` scaffolded code was then back-ported to .NET core 2.1. In order to target a specific .Net version add the `-f | --framework <FRAMEWORK>` options above.

e.g.

```shell
dotnet new mvc -o %GIT%\Puppies\src\MvcPuppies\Puppies.Web -n Puppies.Web -f net5.0
```

```shell
dotnet new mvc -o %GIT%\Puppies\src\MvcPuppies\Puppies.Web -n Puppies.Web -f netcoreapp3.1
```

```shell
dotnet new mvc -o %GIT%\Puppies\src\MvcPuppies\Puppies.Web -n Puppies.Web -f netcoreapp3.1
```
