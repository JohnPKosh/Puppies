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

**Step 4.** - Create the MVC ASP.Net App

```shell
dotnet new mvc -o %GIT%\Puppies\src\MvcPuppies\Puppies.Web -n Puppies.Web
```

**Step 5.** - Add the MVC ASP.Net App to the solution

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

> Proceed to commit and Launch Solution in VS Code or Visual Studio