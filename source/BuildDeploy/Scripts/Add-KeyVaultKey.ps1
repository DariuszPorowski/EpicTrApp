#
# Add key with secret to KeyVault
#

Param(
    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-zA-Z0-9-_]*$")]
    [String]$VaultName,

    [Parameter(Mandatory = $true)]
    [ValidatePattern("^[a-zA-Z0-9-_]*$")]
    [String]$Name,

    [Parameter(Mandatory = $true)]
    [String]$Secret,
	
    [Parameter(Mandatory = $false)]
	[ValidateSet("Software","HSM")] 
    [String]$Destination = 'Software'
)

Add-AzureKeyVaultKey -Destination $Destination -Name $Name -VaultName $VaultName
#$SecretSecureString = ConvertTo-SecureString $Secret -AsPlainText -Force
#Set-AzureKeyVaultSecret -VaultName $VaultName -Name $Name -SecretValue $SecretSecureString
