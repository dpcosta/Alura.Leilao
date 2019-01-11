#tool "nuget:?package=coveralls.io&version=1.4.2"
#addin Cake.Git
#addin nuget:?package=Nuget.Core
#addin "nuget:?package=Cake.Coveralls&version=0.9.0"

using System.IO;

var target = Argument("target", "Default");
var solutionPath = "./Alura.Leilao.sln";
var configuration = "Release";
var artifactsDir = "./artifacts/";
var project = "./Alura.Leilao.Core/Alura.Leilao.Core.csproj";
var testFolder = "./Alura.Leilao.Tests/";
var testProject = testFolder + "Alura.Leilao.Tests.csproj";
var coverageResultsFileName = "coverage.xml";
var coverallsToken = Argument<string>("coverallsToken", null);

//////////////////////////////////////////////////////
//                     TASKS                        //
//////////////////////////////////////////////////////
Task("Clean")
	.Does(() => 
	{
		if (DirectoryExists(artifactsDir))
		{
			DeleteDirectory(
				artifactsDir, 
				new DeleteDirectorySettings {
					Recursive = true,
					Force = true
				}
			);
		}
		CreateDirectory(artifactsDir);
		DotNetCoreClean(solutionPath);
	});

Task("Restore")
	.Does(() => 
	{
		DotNetCoreRestore(solutionPath);
	});

Task("Build")
	.IsDependentOn("Clean")
	.IsDependentOn("Restore")
	.Does(() => 
	{
		DotNetCoreBuild(
			solutionPath,
			new DotNetCoreBuildSettings 
			{
				Configuration = configuration
			}
		);
	});

Task("Test")
	.Does(() => 
	{
		var settings = new DotNetCoreTestSettings
		{
			ArgumentCustomization = args => args.Append("/p:CollectCoverage=true")
												.Append("/p:CoverletOutputFormat=opencover")
												.Append("/p:CoverletOutput=./" + coverageResultsFileName)
												.Append("/p:Exclude=[xunit*]*")
		};
		DotNetCoreTest(testProject, settings);
		MoveFile(testFolder + coverageResultsFileName, artifactsDir + coverageResultsFileName);
	});

Task("UploadCoverage")
	.IsDependentOn("Test")
	.Does(() =>
	{
		var coverageResultsFullFileName = artifactsDir + coverageResultsFileName;
		Information($"Token: {coverallsToken}");
		if(!System.IO.File.Exists(coverageResultsFullFileName))
		{
			Information("Arquivo com os resultados da cobertura não existe!");
		}
		CoverallsIo(
			coverageResultsFullFileName, 
			new CoverallsNetSettings()
			{
				RepoToken = coverallsToken
			}
		);
	});

Task("Complete")
	.IsDependentOn("Build")
	.IsDependentOn("Test")
	.IsDependentOn("UploadCoverage");

Task("Default")
	.IsDependentOn("Complete");

RunTarget(target);