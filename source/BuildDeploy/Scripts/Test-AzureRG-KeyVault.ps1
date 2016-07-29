#
# Azure RG with KeyVault Unit Test
#
Param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-z0-9]*$")]
    [String]$ResourceGroup  
)

Write-Output $ResourceGroup
Write-Output --------
Find-AzureRmResource -ResourceGroupNameContains $ResourceGroup | Measure-Object

#Testing number of Resources
$NumberOfResources = Find-AzureRmResource -ResourceGroupNameContains $ResourceGroup | Measure-Object
Write-Output "Number Of Resources:" $NumberOfResources.Count
$NumberOfResourcesCount = $NumberOfResources.Count -eq 1
Write-Output "Test pass:" $NumberOfResourcesCount
if ($NumberOfResourcesCount -like "false") {
    Throw "Ooops!!! Something is wrong with the number of Resources in the Resource Group"
}