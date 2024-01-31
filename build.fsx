#r "nuget:Fun.Build"

open Fun.Build
open Fun.Build.Github

pipeline "benchmark" {
    stage "run" {
        workingDir "Benchmark"
        run "dotnet run -c Release"
    }
    runIfOnlySpecified
}

pipeline "test" {
    collapseGithubActionLogs
    stage "run" { run "dotnet test -c Release" }
    runIfOnlySpecified
}

tryPrintPipelineCommandHelp ()
