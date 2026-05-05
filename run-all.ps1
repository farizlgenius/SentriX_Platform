Write-Host "Starting all SentriX microservices (HTTPS)..." -ForegroundColor Green

$services = @(
    @{ path="./SentriX_AeroAdapter/AeroAdapter.Api"; urls="https://localhost:5004;http://localhost:5009" },
    @{ path="./SentriX_Core/Core.Api";           urls="https://localhost:5003;http://localhost:5008" },
    @{ path="./SentriX_Gateway/Gateway.Api";     urls="https://localhost:5000;http://localhost:5005" },
    @{ path="./SentriX_Identity/Identity.Api";   urls="https://localhost:5001;http://localhost:5006" },
    @{ path="./SentriX_Realtime/Realtime.Api";   urls="https://localhost:5002;http://localhost:5007" }
    # @{ path="./SentriX_AmicoAdapter/AmicoAdapter.Api"; urls="https://localhost:5010;http://localhost:5011" }
)

foreach ($service in $services) {
    Write-Host "Starting $($service.path)" -ForegroundColor Yellow
    Start-Process powershell -ArgumentList "-NoExit -Command `"cd $($service.path); `$env:ASPNETCORE_URLS='$($service.urls)'; dotnet watch`" 
}

Write-Host "All services running with HTTPS 🚀"