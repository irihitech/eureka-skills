using SemiSync;

// Syncs the Semi.Avalonia generator's output into this repository's semi-avalonia plugin:
//
//   dotnet run --project tools/semi-sync -- <semi-generator-output-dir> [--repo <eureka-skills-root>]

return SyncRunner.Run(args);
