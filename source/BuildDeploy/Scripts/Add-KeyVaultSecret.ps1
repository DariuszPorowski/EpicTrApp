#
# Add_KeyVaultSecret.ps1
#

Param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-zA-Z0-9-_]*$")]
    [String]$VaultName,

    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-zA-Z0-9-_]*$")]
    [String]$Name,

    [Parameter(Mandatory = $true)]
    [String]$Secret
)

Add-AzureKeyVaultKey -Destination Software -Name $Name -VaultName $VaultName
$SecretValue = ConvertTo-SecureString $Secret -AsPlainText -Force
Set-AzureKeyVaultSecret -VaultName $VaultName -Name $Name -SecretValue $Secret
