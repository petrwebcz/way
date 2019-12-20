Write-Output "Publishing WAY.PETRWEB";
$source = "C:\Users\petr\Documents\way\WhereAreYou.Web\way-client-app\";
$destination = "C:\inetpub\wwwroot\way\way.petrweb.local\"

cd  $source;
ng build;
Copy-Item ./dist/way-client-app/* -Destination $destination 

