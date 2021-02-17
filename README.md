# Puppies

**Instructor Interview Assessment Project** (Tech Elevator)

## Purpose

>_provide a solution that you feel would be suitable to teach junior developers while demonstrating what you consider to be the best practice._

Throughout the project additional attention has been payed to apply appropriate commenting, minimal logging, basic error handling, TODOs and other general practices surrounding modern application development. The ASP.Net MVC project encapsulates the minimum viable product with a few callout comments meant for talking points and discussion. 

The entire project was built by hand (initially using the `dotnet` command line tool) based on the bitbucket repository. Not all standard industy patterns and practices have been applied however there is a fair amount of quality code delivered in the project that could be beneficial as instructional material. All SCM local repository management was also conducted with the **`git`** command line tool.

---

_Demonstration project requirements and direction were taken from the original [bitbucket repository](https://bitbucket.org/te-curriculum/instructor-candidate-assessment/src/master/)._

The repository structure has been modified to accomodate a more general larger project structure capable of working with multiple demonstration solutions as well as additional support materials.

To understand the repository structure or to learn how to build the project using **`dotnet new`** see the [layout documentation](doc/layout.md).

---

# Module 3 Assessment Exercise

This assessment will help you validate your understanding of the module objectives using ASP.NET MVC. The following learning objectives are covered:

- Controllers
- Views & View logic using Razor
- Passing data from controllers to views
- Handling request data
- Dynamic-link creation
- Query parameter access
- Dependency Injection

You also receive practice with coding assessments that you may encounter during the job interview process.

## Overview

The assessment uses a standard ASP.NET Core MVC Web Application template. You will have one hour to complete as much of your assigned problem as you can.

Whatever you complete and submit should not have any compile or run-time errors. Any features you can complete should run successfully to receive credit.

If you are nearing the end of the hour and you have compile/run-time errors, consider commenting out or removing the code causing the errors before pushing your final effort.

In the end, you should push your final effort to your repository.

You are expected to remain in the classroom until you have completed the coding assessment.

If you finish before the end of the time-box, please be respectful of those still working. Please leave the classroom if you would like to talk with others that have completed the coding assignment.

## Required Tools

The following tools/software are used by students to complete the assessment:

- Visual Studio 2017/2019 (support for .NET Core 2.1)
- SQL Server Express 201x

The script to set up the database is located under `scripts/setup.sql`.

## Instructions

1. Create a controller action in `PuppiesController` that maps to `/Puppies`. It will call `GetPuppies()` in the DAL. The information that is returned should be returned to the `Index` view.
2. Change the `Index` view to show all the entries from the controller in the provided table. Weights should have `lbs` after it. The `PaperTrained` value should show as 'Yes' when true and 'No' when false.
3. Create a controller action in `PuppiesController` that receives request data generated from the form on `Index` and saves that information as a new entry in the database by passing it to the `SavePuppy(Puppy)` method in the DAL. Redirect the user back to the controller action defined from step 1.
4. Create a controller action in `PuppiesController` that maps to `/Puppies/Detail/{id}`. It will call `GetPuppy(int)` in the DAL. The information that is returned will be passed to the `Detail` view.
5. Change the `Index` view to make the name of the puppy a link to the controller action created in step 4.