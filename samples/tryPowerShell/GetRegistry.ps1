param(
    $path = "HKLM:\SOFTWARE\Microsoft\MSBuild",
    $property = "MSBuildOverrideTasksPath"
)

(Get-ChildItem $path | Get-ItemProperty).$property