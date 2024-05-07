# started manually. stdin and stdout are connected to the runtime open pipe.
#  cd "C:\Users\Siemens\Desktop\WinCC Unified\Demos\OpenPipe"
#  
# .\openpipe_piechart.ps1
# Set-ExecutionPolicy Unrestricted

$Excel = New-Object -ComObject Excel.Application


$scriptDir = Split-Path -Path $MyInvocation.MyCommand.Definition -Parent

#$Workbook = $Excel.Workbooks.Open("C:\Users\Siemens\Desktop\TIA_UnifiedDemo_V18_V19\UserFiles\07.OpenPipe\QualityAnalysis.xlsx") # (Get-Item -Path ".\" -Verbose).FullName + "\..\..\..\PowerShell\QualityAnalysis.xlsx")
$Workbook = $Excel.Workbooks.Open("$scriptDir\QualityAnalysis.xlsx") # (Get-Item -Path ".\" -Verbose).FullName + "\..\..\..\PowerShell\QualityAnalysis.xlsx")

$Worksheet = $Workbook.ActiveSheet

# change diagram type here (if you like)
# $chart = $worksheet.ChartObjects(1).Chart.ChartType = [Microsoft.Office.Interop.Excel.XlChartType]::xlDoughnutExploded

Start-Sleep -m 1000
$Excel.Visible = $True
Write-Host "Excel started"

function HandleUpdate($tags)
{
	For ($i=0; $i -lt $tags.Length; $i++) {
		$excelCell = "B1"
		switch($tags[$i].Name)
		{
			"10_OpenRT_Tag_1" {$excelCell = "B2"}
			"10_OpenRT_Tag_2" {$excelCell = "B3"}
			"10_OpenRT_Tag_3" {$excelCell = "B4"}
		}
		$script:Worksheet.Range($excelCell).Value = $tags[$i].Value
	}
}

# Open named pipe 
$npipeClient = new-object System.IO.Pipes.NamedPipeClientStream('.', 'HmiRuntime', [System.IO.Pipes.PipeDirection]::InOut,
                                                                [System.IO.Pipes.PipeOptions]::None, 
                                                                [System.Security.Principal.TokenImpersonationLevel]::Impersonation)


$pipeReader = $pipeWriter = $null
try {
	$npipeClient.Connect(1000) # 1s timeout
	$pipeReader = new-object System.IO.StreamReader($npipeClient)
	$pipeWriter = new-object System.IO.StreamWriter($npipeClient)
	$pipeWriter.AutoFlush = $true

	#Request the needed tags from the runtime
	$pipeWriter.WriteLine('{"Message":"SubscribeTag","Params":{"Tags":["10_OpenRT_Tag_1","10_OpenRT_Tag_2","10_OpenRT_Tag_3"]},"ClientCookie":"excelSubscription"}\n')
	Write-Host "Connected to open pipe and subsribed to tags"

	$continue = $true
	while($continue)
	{
		$command = $pipeReader.ReadLine()
		if($command -ne $null -and $command -ne '')
		{
			$jsonMessage = ConvertFrom-Json $command
			if($jsonMessage.ClientCookie -eq 'excelSubscription')
			{
				HandleUpdate $jsonMessage.Params.Tags
			}
		}
		else
		{
			$continue = $false
		}
	}
}
finally {
    'Exiting'
    $npipeClient.Dispose()
	$Workbook.Saved = $True
	$Excel.DisplayAlerts = $False
	$Excel.Quit()
}
