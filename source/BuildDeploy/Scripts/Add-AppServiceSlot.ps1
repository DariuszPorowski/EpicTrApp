#
# Add slot to AppService Web Site
#

Param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-zA-Z0-9-_]*$")]
    [String]$ResourceGroupName,

    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-zA-Z0-9-_]*$")]
    [String]$WebAppName,

    [Parameter(Mandatory = $true)]
    [String]$Slot
)

New-AzureRmWebAppSlot -Name $WebAppName -ResourceGroupName $ResourceGroupName -Slot $Slot